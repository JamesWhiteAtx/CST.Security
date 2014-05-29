using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data.Objects;

namespace CST.Security.Data
{
    public partial class SecurityEntities : ObjectContext
    {
        public string EncryptedStr(string plainText)
        {
            ObjectParameter outparm = new ObjectParameter("v_CRYPT_TEXT", typeof(string));
            GetEncryptText(plainText, outparm);
            return (string)outparm.Value;
        }

        public string DecryptedStr(string cryptText)
        {
            ObjectParameter outparm = new ObjectParameter("v_PLAIN_TEXT", typeof(string));
            GetDecryptText(cryptText, outparm);
            return (string)outparm.Value;
        }

        public string DBName()
        {
            return ExecuteStoreQuery<string>("SELECT NAME FROM V$DATABASE").FirstOrDefault();
        }

        public string DBNameObfuscate()
        {
            string dbName = DBName();
            if (dbName == null)
            {
                return "null";
            }
            else if (dbName.ToUpper() == "FSYS")
            {
                return "Production";
            }
            else if (dbName.ToUpper() == "TEST")
            {
                return "Testing";
            }
            else if (dbName.ToUpper() == "FTST")
            {
                return "Eff. Testing";
            }
            else if (dbName.ToUpper() == "FDEV")
            {
                return "Eff. Development";
            }
            else
            {
                char[] array = dbName.ToLower().ToCharArray();
                Array.Reverse(array);
                return "Unkn. " + new string(array);
            }
        }
    }

    public static class DataHelper
    {
        public const string BoolYNTue = "Y";
        public const string BoolYNFalse = "N";

        public static bool BoolYN(string flag)
        {
            return ((flag != null) && flag.Equals(BoolYNTue));
        }

        public static string BoolYNStr(bool active)
        {
            if (active)
            { return BoolYNTue; }
            else
            { return BoolYNFalse; }
        }

        public static void SetActive(this IActiveFlagYN obj, bool active)
        {
            obj.ActiveFlag = BoolYNStr(active);
            //if (active) { obj.ActiveFlag = BoolYNTue; } else { obj.ActiveFlag = BoolYNFalse; }
        }

        public static bool GetActive(this IActiveFlagYN obj)
        {
            return BoolYN(obj.ActiveFlag); // obj.ActiveFlag.Equals(BoolYNTue);
        }

        public const string StatusActive = "A";
        public const string StatusInactive = "I";

        public static bool BoolAI(string flag)
        {
            return ((flag != null) && flag.Equals(StatusActive));
        }
    }

    public interface IActiveFlagYN
    {
        String ActiveFlag { get; set; }
    }

    public interface ICodeName
    {
        Decimal ID { get; set; }
        String Code { get; set; }
        String Name { get; set; }
    }

    public interface ICodeNameAct : ICodeName, IActiveFlagYN
    { }

    public partial class User : IActiveFlagYN
    {
        public bool Active { get { return this.GetActive(); } set { this.SetActive(value); } }

        public bool AlterPassword
        {
            get { return DataHelper.BoolYN(AlterPasswordFlag); }
            set
            {
                AlterPasswordFlag = DataHelper.BoolYNStr(value);
            }
        }

        public string PlainPassword
        {
            get
            {
                using (SecurityEntities securityEntities = new SecurityEntities())
                {
                    string plainPassword = securityEntities.DecryptedStr(Password.Trim());
                    return plainPassword;
                }
            }
            set
            {
                using (SecurityEntities securityEntities = new SecurityEntities())
                {
                    Password = securityEntities.EncryptedStr(value);
                }
            }
        }

        public bool PlainPasswordMatch(string plaintext)
        {
            return (PlainPassword == plaintext);
        }

        public string GetLoginUpper()
        {
            if (Login != null)
            {
                return Login.ToUpper();
            }
            else
            {
                return null;
            }
        }

        public string FullName { get { return FirstName + " " + LastName; } }
    }

    public partial class App : ICodeNameAct
    {
        public bool Active { get { return this.GetActive(); } set { this.SetActive(value); } }

        public bool SysAdmin
        {
            get { return DataHelper.BoolYN(SysAdminFlag); }
            set { SysAdminFlag = DataHelper.BoolYNStr(value); }
        }

        public string CodeDashName { get { return Code + "-" + Name; } }
    }

    public partial class Group : ICodeNameAct
    {
        public bool Active { get { return this.GetActive(); } set { this.SetActive(value); } }

        public bool AppAdmin
        {
            get { return DataHelper.BoolYN(AppAdminFlag); }
            set { AppAdminFlag = DataHelper.BoolYNStr(value); }
        }

        public string CodeDashName { get { return Code + "-" + Name; } }

        public const char CodeSep = '/';

        public static string GetAppGroupCode(string appCode, string groupCode)
        {
            return appCode + CodeSep + groupCode;
        }

        public static bool SplitAppGroupCode(string appGroupCode, out string appCode, out string groupCode)
        {
            bool bothParts = false;
            appCode = null;
            groupCode = null;

            string[] parts = appGroupCode.Split(CodeSep);
            if (parts.Length > 0)
            {
                appCode = parts[0];

                if (parts.Length > 1)
                {
                    groupCode = parts[1];

                    bothParts = true;
                }
            }
            return bothParts;
        }

        public string AppGroupCode { get { return GetAppGroupCode(App.Code, Code); } }
    }
}
