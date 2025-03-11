using Server.MirNetwork;
using Server.MirEnvir;
using Server.Utils;
using C = ClientPackets;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Server.MirDatabase
{
    public class AccountInfo
    {       
        protected static Envir Envir => Envir.Main;
        protected static MessageQueue MessageQueue => MessageQueue.Instance;

        public int Index { get; set; }

        [Required]
        [StringLength(50)]
        public string AccountID { get; set; } = string.Empty;
        
        private string password { get; set; } = string.Empty;
        public string Password 
        {
            get { return password; }
            set
            {                
                Salt = Crypto.GenerateSalt();
                password = Crypto.HashPassword(value, Salt);
            }
        }

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

        // Navigation properties
        public virtual List<CharacterInfo> Characters { get; set; } = new List<CharacterInfo>();
        [NotMapped]
        private UserItem[] _storage = new UserItem[80];
        [NotMapped]
        public UserItem[] Storage 
        { 
            get => _storage;
            set => _storage = value;
        }
        public virtual LinkedList<AuctionInfo> Auctions { get; set; } = new LinkedList<AuctionInfo>();

        // Non-persistent properties
        [NotMapped]
        public MirConnection Connection { get; set; }
        
        public AccountInfo()
        {

        }

        public AccountInfo(C.NewAccount p)
        {
            AccountID = p.AccountID;

            Password = p.Password;
            UserName = p.UserName;
            SecretQuestion = p.SecretQuestion;
            SecretAnswer = p.SecretAnswer;
            EMailAddress = p.EMailAddress;

            BirthDate = p.BirthDate;
            CreationDate = Envir.Now;
        }
        public AccountInfo(BinaryReader reader)
        {
            Index = reader.ReadInt32();

            AccountID = reader.ReadString();
            if (Envir.LoadVersion < 94)
                Password = reader.ReadString();
            else
                password = reader.ReadString();

            if (Envir.LoadVersion > 93)
                Salt = reader.ReadBytes(reader.ReadInt32());

            if (Envir.LoadVersion > 97)
                RequirePasswordChange = reader.ReadBoolean();

            UserName = reader.ReadString();
            BirthDate = DateTime.FromBinary(reader.ReadInt64());
            SecretQuestion = reader.ReadString();
            SecretAnswer = reader.ReadString();
            EMailAddress = reader.ReadString();

            CreationIP = reader.ReadString();
            CreationDate = DateTime.FromBinary(reader.ReadInt64());

            Banned = reader.ReadBoolean();
            BanReason = reader.ReadString();
            ExpiryDate = DateTime.FromBinary(reader.ReadInt64());

            LastIP = reader.ReadString();
            LastDate = DateTime.FromBinary(reader.ReadInt64());

            int count = reader.ReadInt32();

            for (int i = 0; i < count; i++)
            {
                var info = new CharacterInfo(reader, Envir.LoadVersion, Envir.LoadCustomVersion) { AccountInfo = this };

                if (info.Deleted && info.DeleteDate.AddMonths(Settings.ArchiveDeletedCharacterAfterMonths) <= Envir.Now)
                {
                    MessageQueue.Enqueue($"Player {info.Name} has been archived due to {Settings.ArchiveDeletedCharacterAfterMonths} month deletion.");
                    Envir.SaveArchivedCharacter(info);
                    continue;
                }

                if (info.LastLoginDate == DateTime.MinValue && info.CreationDate.AddMonths(Settings.ArchiveInactiveCharacterAfterMonths) <= Envir.Now)
                {
                    MessageQueue.Enqueue($"Player {info.Name} has been archived due to no login after {Settings.ArchiveInactiveCharacterAfterMonths} months.");
                    Envir.SaveArchivedCharacter(info);
                    continue;
                }
                
                if (info.LastLoginDate > DateTime.MinValue && info.LastLoginDate.AddMonths(Settings.ArchiveInactiveCharacterAfterMonths) <= Envir.Now)
                {
                    MessageQueue.Enqueue($"Player {info.Name} has been archived due to {Settings.ArchiveInactiveCharacterAfterMonths} months inactivity.");
                    Envir.SaveArchivedCharacter(info);
                    continue;
                }

                Characters.Add(info);
            }

            if (Envir.LoadVersion > 75)
            {
                HasExpandedStorage = reader.ReadBoolean();
                ExpandedStorageExpiryDate = DateTime.FromBinary(reader.ReadInt64());
            }
            
            Gold = reader.ReadUInt32();
            if (Envir.LoadVersion >= 63) Credit = reader.ReadUInt32();

            count = reader.ReadInt32();

            Array.Resize(ref _storage, count);

            for (int i = 0; i < count; i++)
            {
                if (!reader.ReadBoolean()) continue;
                UserItem item = new UserItem(reader, Envir.LoadVersion, Envir.LoadCustomVersion);
                if (Envir.BindItem(item) && i < Storage.Length)
                    Storage[i] = item;
            }

            if (Envir.LoadVersion >= 10) AdminAccount = reader.ReadBoolean();
            if (!AdminAccount)
            {
                for (int i = 0; i < Characters.Count; i++)
                {
                    if (Characters[i] == null) continue;
                    if (Characters[i].Deleted) continue;
                    if ((Envir.Now - Characters[i].LastLogoutDate).TotalDays > 13) continue;
                    Envir.CheckRankUpdate(Characters[i]);
                }
            }
        }

        public void Save(BinaryWriter writer)
        {
            writer.Write(Index);
            writer.Write(AccountID);
            writer.Write(Password);
            writer.Write(Salt.Length);
            writer.Write(Salt);
            writer.Write(RequirePasswordChange);

            writer.Write(UserName);
            writer.Write(BirthDate.ToBinary());
            writer.Write(SecretQuestion);
            writer.Write(SecretAnswer);
            writer.Write(EMailAddress);

            writer.Write(CreationIP);
            writer.Write(CreationDate.ToBinary());

            writer.Write(Banned);
            writer.Write(BanReason);
            writer.Write(ExpiryDate.ToBinary());

            writer.Write(LastIP);
            writer.Write(LastDate.ToBinary());

            writer.Write(Characters.Count);
            for (int i = 0; i < Characters.Count; i++)
            {
                Characters[i].Save(writer);
            }

            writer.Write(HasExpandedStorage);
            writer.Write(ExpandedStorageExpiryDate.ToBinary());
            writer.Write(Gold);
            writer.Write(Credit);
            writer.Write(Storage.Length);
            for (int i = 0; i < Storage.Length; i++)
            {
                writer.Write(Storage[i] != null);
                if (Storage[i] == null) continue;

                Storage[i].Save(writer);
            }
            writer.Write(AdminAccount);
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
}
