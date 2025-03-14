using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Caching.Memory;
using Server.MirDatabase;

public class AccountCacheService
{
    private readonly GameDbContext _context;
    private readonly IMemoryCache _cache;
    private const string AccountsCacheKey = "AccountsCacheKey";
    private readonly MemoryCacheEntryOptions _cacheOptions = new MemoryCacheEntryOptions
    {
        SlidingExpiration = TimeSpan.FromMinutes(5)
    };

    public AccountCacheService(GameDbContext context, IMemoryCache cache)
    {
        _context = context;
        _cache = cache;
    }

    /// <summary>
    /// Retrieves the list of accounts (with their characters) from the cache,
    /// loading from the database if necessary.
    /// </summary>
    public List<AccountInfo> GetAccounts()
    {
        if (!_cache.TryGetValue(AccountsCacheKey, out List<AccountInfo> accounts))
        {
            accounts = _context.AccountInfos
                               .Include(a => a.Characters)
                               .AsNoTracking()
                               .ToList();
            _cache.Set(AccountsCacheKey, accounts, _cacheOptions);
        }
        return accounts;
    }

    /// <summary>
    /// Checks whether an account with the specified username exists in the cached accounts.
    /// The comparison is case-insensitive.
    /// </summary>
    /// <param name="username">The username of the account to search for.</param>
    /// <returns>True if an account with the given username exists; otherwise, false.</returns>
    public bool AccountExists(string username)
    {
        if (string.IsNullOrWhiteSpace(username))
            throw new ArgumentException("Account username cannot be null or whitespace.", nameof(username));

        return GetAccounts()
            .Any(a => string.Equals(a.UserName, username, StringComparison.OrdinalIgnoreCase));
    }

    /// <summary>
    /// Creates a new account and updates the cache by adding only the new account.
    /// </summary>
    public AccountInfo CreateAccount(AccountInfo newAccount)
    {
        _context.AccountInfos.Add(newAccount);
        _context.SaveChanges();

        // Update the cache if it exists.
        if (_cache.TryGetValue(AccountsCacheKey, out List<AccountInfo> accounts))
        {
            accounts.Add(newAccount);
            _cache.Set(AccountsCacheKey, accounts, _cacheOptions);
        }
        return newAccount;
    }

    /// <summary>
    /// Updates an existing account and updates its entry in the cache.
    /// </summary>
    public void UpdateAccount(AccountInfo account)
    {
        _context.AccountInfos.Update(account);
        _context.SaveChanges();

        if (_cache.TryGetValue(AccountsCacheKey, out List<AccountInfo> accounts))
        {
            var existing = accounts.FirstOrDefault(a => a.Id == account.Id);
            if (existing != null)
            {
                var index = accounts.IndexOf(existing);
                accounts[index] = account;
                _cache.Set(AccountsCacheKey, accounts, _cacheOptions);
            }
        }
    }

    /// <summary>
    /// Adds a new character to the specified account and updates only that account in the cache.
    /// </summary>
    public void AddCharacterToAccount(int accountId, CharacterInfo newCharacter)
    {
        // Load the account from the database (with its Characters collection).
        var account = _context.AccountInfos
                              .Include(a => a.Characters)
                              .SingleOrDefault(a => a.Id == accountId);
        if (account == null)
            throw new Exception("Account not found.");

        // Add the new character.
        account.Characters.Add(newCharacter);
        newCharacter.AccountInfo.Id = account.Id;
        newCharacter.AccountInfo = account;

        _context.SaveChanges();

        // If the cache exists, update only this account.
        if (_cache.TryGetValue(AccountsCacheKey, out List<AccountInfo> accounts))
        {
            var cachedAccount = accounts.FirstOrDefault(a => a.Id == accountId);
            if (cachedAccount != null)
            {
                // Replace the cached account with the newly loaded account.
                // Alternatively, you could update the Characters collection.
                var index = accounts.IndexOf(cachedAccount);
                accounts[index] = account;
                _cache.Set(AccountsCacheKey, accounts, _cacheOptions);
            }
        }
    }

    /// <summary>
    /// Saves all accounts from the in-memory cache to the database.
    /// New accounts (with Id == 0) are added; existing accounts are updated.
    /// After saving, the cache is refreshed.
    /// </summary>
    public void SaveAll()
    {
        // Retrieve the cached accounts.
        var accounts = GetAccounts();
        
        foreach (var account in accounts)
        {
            // Check if an account with the same ID is already being tracked.
            var trackedAccount = _context.AccountInfos.Local.FirstOrDefault(a => a.Id == account.Id);
            
            if (trackedAccount != null)
            {
                // If the account is already tracked, update its current values.
                _context.Entry(trackedAccount).CurrentValues.SetValues(account);
            }
            else
            {
                if (account.Id == 0)
                {
                    // New account: add to the context.
                    _context.AccountInfos.Add(account);
                }
                else
                {
                    // For an existing account, attach and mark as modified.
                    _context.AccountInfos.Update(account);
                }
            }
        }
        _context.SaveChanges();

        // Refresh the cache after saving changes.
        var refreshedAccounts = _context.AccountInfos
                                        .Include(a => a.Characters)
                                        .AsNoTracking()
                                        .ToList();
        _cache.Set(AccountsCacheKey, refreshedAccounts, _cacheOptions);
    }

    /// <summary>
    /// Retrieves a character from all cached accounts using a global index.
    /// This method flattens all characters from every account into a single list.
    /// </summary>
    /// <param name="index">The global index of the character across all accounts.</param>
    /// <returns>The CharacterInfo at the specified global index.</returns>
    /// <exception cref="IndexOutOfRangeException">Thrown if the index is out of range.</exception>
    public CharacterInfo GetCharacterByIndex(int index)
    {
        // Flatten the characters from all accounts.
        var allCharacters = GetAccounts().SelectMany(a => a.Characters).ToList();
        
        if (index < 0 || index >= allCharacters.Count)
            throw new IndexOutOfRangeException("Character index is out of range.");
        
        return allCharacters[index];
    }

    /// <summary>
    /// Retrieves a character from a specific account using the account ID and an index within that account's character list.
    /// </summary>
    /// <param name="accountId">The ID of the account.</param>
    /// <param name="charIndex">The index of the character within the account's character list.</param>
    /// <returns>The CharacterInfo at the specified index within the account.</returns>
    /// <exception cref="Exception">Thrown if the account is not found.</exception>
    /// <exception cref="IndexOutOfRangeException">Thrown if the character index is out of range.</exception>
    public CharacterInfo GetCharacterByAccountIndex(int accountId, int charIndex)
    {
        var account = GetAccounts().FirstOrDefault(a => a.Id == accountId);
        if (account == null)
            throw new Exception("Account not found.");

        if (charIndex < 0 || charIndex >= account.Characters.Count)
            throw new IndexOutOfRangeException("Character index is out of range.");

        return account.Characters[charIndex];
    }

    /// <summary>
    /// Retrieves a flattened list of all characters across all cached accounts.
    /// </summary>
    /// <returns>A list containing all CharacterInfo objects from every account.</returns>
    public List<CharacterInfo> GetAllCharacters()
    {
        return GetAccounts().SelectMany(a => a.Characters).ToList();
    }

    /// <summary>
    /// Checks whether a character with the specified name exists in the cached accounts.
    /// The comparison is case-insensitive.
    /// </summary>
    /// <param name="name">The name of the character to search for.</param>
    /// <returns>True if a character with the given name exists; otherwise, false.</returns>
    public bool CharacterExists(string name)
    {
        if (string.IsNullOrWhiteSpace(name))
            throw new ArgumentException("Character name cannot be null or whitespace.", nameof(name));

        // Flatten all characters and perform a case-insensitive check.
        return GetAccounts()
            .SelectMany(a => a.Characters)
            .Any(c => string.Equals(c.Name, name, StringComparison.OrdinalIgnoreCase));
    }

    /// <summary>
    /// Retrieves an account from the cached accounts using a string accountID.
    /// The accountID is expected to be parseable to an integer.
    /// </summary>
    /// <param name="accountID">A string representing the account's ID.</param>
    /// <returns>The AccountInfo corresponding to the account ID.</returns>
    /// <exception cref="FormatException">Thrown if the accountID cannot be parsed as an integer.</exception>
    /// <exception cref="Exception">Thrown if no account is found with the given ID.</exception>
    public AccountInfo GetAccount(int accountID)
    {
        var account = GetAccounts().FirstOrDefault(a => a.Id == accountID);
        if (account == null)
            throw new Exception("Account not found.");

        return account;
    }

    /// <summary>
    /// Retrieves an account using a string identifier. If the identifier can be parsed as an integer,
    /// the method returns the account with the matching ID. Otherwise, it searches for an account with a username
    /// that matches the identifier (case-insensitive).
    /// </summary>
    /// <param name="identifier">A string representing either the account's ID or its username.</param>
    /// <returns>
    /// The matching AccountInfo if found; otherwise, null.
    /// </returns>
    public AccountInfo GetAccountByName(string name)
    {
        if (string.IsNullOrWhiteSpace(name))
            throw new ArgumentException("Identifier cannot be null or whitespace.", nameof(name));

        // Try to parse the identifier as an integer.
        if (int.TryParse(name, out int id))
        {
            return GetAccounts().FirstOrDefault(a => a.Id == id);
        }
        else
        {
            // Otherwise, treat the identifier as a username.
            return GetAccounts().FirstOrDefault(a => 
                string.Equals(a.UserName, name, StringComparison.OrdinalIgnoreCase));
        }
    }

    /// <summary>
    /// Retrieves an account from the cached accounts that contains a character
    /// with a name matching the specified characterName (case-insensitive).
    /// </summary>
    /// <param name="characterName">The name of the character to search for.</param>
    /// <returns>
    /// The first AccountInfo containing a character with the specified name,
    /// or null if no such account exists.
    /// </returns>
    public AccountInfo GetAccountByCharacter(string characterName)
    {
        if (string.IsNullOrWhiteSpace(characterName))
            throw new ArgumentException("Character name cannot be null or whitespace.", nameof(characterName));

        return GetAccounts()
            .FirstOrDefault(a => a.Characters.Any(c => string.Equals(c.Name, characterName, StringComparison.OrdinalIgnoreCase)));
    }

    /// <summary>
    /// Retrieves a character from the cached accounts by name using a case-insensitive search.
    /// </summary>
    /// <param name="characterName">The name of the character to search for.</param>
    /// <returns>
    /// The first matching CharacterInfo if found; otherwise, null.
    /// </returns>
    public CharacterInfo GetCharacterByName(string characterName)
    {
        if (string.IsNullOrWhiteSpace(characterName))
            throw new ArgumentException("Character name cannot be null or whitespace.", nameof(characterName));

        return GetAccounts()
            .SelectMany(a => a.Characters)
            .FirstOrDefault(c => string.Equals(c.Name, characterName, StringComparison.OrdinalIgnoreCase));
    }
}