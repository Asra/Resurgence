using Server.MirDatabase;


public class CharacterCacheService
{
    private List<CharacterInfo> _characters = new List<CharacterInfo>();
    private Dictionary<int, CharacterInfo> _characterById;

    public void RefreshCache(List<AccountInfo> accounts)
    {
        _characters = accounts.SelectMany(a => a.Characters).ToList();
        _characterById = _characters.ToDictionary(c => c.Id);
    }

    public CharacterInfo GetCharacterById(int id)
    {
        _characterById.TryGetValue(id, out var character);
        return character;
    }
}