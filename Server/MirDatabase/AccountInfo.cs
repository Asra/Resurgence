using Microsoft.EntityFrameworkCore;
using Server.MirNetwork;
using Server.MirEnvir;
using Server.Utils;
using C = ClientPackets;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Server.Services;

namespace Server.MirDatabase
{
    [Table("AccountInfo")]
    public class AccountInfo : DatabaseEntity
    {       
        [NotMapped]
        protected static Envir Envir => Envir.Main;
        [NotMapped]
        protected static MessageQueue MessageQueue => MessageQueue.Instance;

        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int Id { get; set; }
        
        public int Index { get; set; }

        [Required]
        [StringLength(50)]
        public string AccountID { get; set; } = string.Empty;
        
        public string PasswordHash { get; set; }
        public byte[] Salt { get; set; } = new byte[24];

        public string UserName { get; set; } = string.Empty;
        public DateTime BirthDate { get; set; }
        public string SecretQuestion { get; set; } = string.Empty;
        public string SecretAnswer { get; set; } = string.Empty;
        public string EMailAddress { get; set; } = string.Empty;
        public string CreationIP { get; set; } = string.Empty;
        public DateTime CreationDate { get; set; }
        public bool Banned { get; set; }
        public bool RequirePasswordChange { get; set; }
        public string BanReason { get; set; } = string.Empty;
        public DateTime ExpiryDate { get; set; }
        public int WrongPasswordCount { get; set; }
        public string LastIP { get; set; } = string.Empty;
        public DateTime LastDate { get; set; }
        public bool HasExpandedStorage { get; set; }
        public DateTime ExpandedStorageExpiryDate { get; set; }
        public uint Gold { get; set; }
        public uint Credit { get; set; }
        public bool AdminAccount { get; set; }

        public virtual List<CharacterInfo> Characters { get; set; } = new List<CharacterInfo>();

        private string _storageJson { get; set; }
        [NotMapped]
        private UserItem[] _storage = new UserItem[80];
        [NotMapped]
        public UserItem[] Storage 
        { 
            get
            {
                if (_storage == null || _storage.Length == 0)
                {
                    _storage = string.IsNullOrEmpty(_storageJson) 
                        ? new UserItem[80] 
                        : System.Text.Json.JsonSerializer.Deserialize<UserItem[]>(_storageJson);
                }
                return _storage;
            }
            set
            {
                _storage = value;
                _storageJson = System.Text.Json.JsonSerializer.Serialize(value);
            }
        }
        public virtual LinkedList<AuctionInfo> Auctions { get; set; } = new LinkedList<AuctionInfo>();

        [NotMapped]
        public MirConnection Connection;
        
        public AccountInfo() { }

        public AccountInfo(C.NewAccount p)
        {
            AccountID = p.AccountID;

            Salt = Crypto.GenerateSalt();
            PasswordHash = CreatePassword(p.Password, Salt);
            UserName = p.UserName;
            SecretQuestion = p.SecretQuestion;
            SecretAnswer = p.SecretAnswer;
            EMailAddress = p.EMailAddress;

            BirthDate = p.BirthDate;
            CreationDate = Envir.Now;
        }

        private String CreatePassword(String password, byte[] salt){
            return Crypto.HashPassword(PasswordHash, Salt);
        }

        //Used for the interface setting password
        public void CreatePassword(String password){
            Salt = Crypto.GenerateSalt();
            PasswordHash = CreatePassword(password, Salt);
        }

        public List<SelectInfo> GetSelectInfo()
        {
            List<SelectInfo> list = new List<SelectInfo>();

            for (int i = 0; i < Characters.Count; i++)
            {
                if (Characters[i].Deleted) continue;
                list.Add(Characters[i].ToSelectInfo());
                if (list.Count >= Globals.MaxCharacterCount) break;
            }

            return list;
        }

        public int ExpandStorage()
        {
            if (!HasExpandedStorage)
            {
                if (Storage.Length == Globals.StorageGridSize)
                    Array.Resize(ref _storage, _storage.Length + Globals.StorageGridSize);
            }

            return Storage.Length;
        }

        public bool IsValidStorageIndex(int index)
        {
            if (index >= Globals.StorageGridSize)
            {
                var level = index / Globals.StorageGridSize;
                if (level > (HasExpandedStorage ? 1 : 0))
                    return false;
            }
            return true;
        }
    }

    // Specific service for accounts.
    /*public class AccountService : CacheService<AccountInfo>
    {
        // Return the correct DbSet from your GameDbContext.
        protected override DbSet<AccountInfo> GetDbSet(GameDbContext context)
        {
            return context.AccountInfos;
        }

        // Override the Load method to include characters
        public override void Load()
        {
            using (var context = new GameDbContext())
            {
                _cache = context.AccountInfos
                    .Include(a => a.Characters)
                    .ToList();
                
            }
        }
    }*/
}
