using FakeProjectG.Defines;
using FakeProjectG.Tools;
using System.Net;
using System.Security.Cryptography;
using System.Text;

namespace FakeProjectG.Config
{
    public class LoginSettings
    {
        public string User { get; set; } = "luismk";

        public string PassWord { get; set; } = "teste";

        public byte AutoLogin { get; set; } = 0;

        public IPAddress IP { get; set; }

        public int Port { get; set; }
        public EnumPangyaVersion PangyaVersion { get; set; }
        /// <summary>
        /// Is Config
        /// </summary>
        /// <param name="Ini"></param>
        public LoginSettings(IniFile Ini)
        {
            User = Ini.ReadString("LoginServer", "Login", "luismk");
            PangyaVersion = (EnumPangyaVersion)Ini.ReadByte("LoginServer", "Type", 0);
            if (PangyaVersion == EnumPangyaVersion.US)
            {
                PassWord = StringToMd5(Ini.ReadString("LoginServer", "Password", "teste"));
                Port = Ini.ReadInt32("LoginServer", "Port", 10103);
            }
            else
            {
                PassWord = Ini.ReadString("LoginServer", "Password", "teste");
                Port = Ini.ReadInt32("LoginServer", "Port", 10201);
            }
            IP = IPAddress.Parse(Ini.ReadString("LoginServer", "IP", "127.0.0.1"));           
        }

        string StringToMd5(string input)
        {
            StringBuilder hash = new StringBuilder();
            MD5CryptoServiceProvider md5provider = new MD5CryptoServiceProvider();
            byte[] bytes = md5provider.ComputeHash(new UTF8Encoding().GetBytes(input));

            for (int i = 0; i < bytes.Length; i++)
            {
                hash.Append(bytes[i].ToString("x2"));
            }
            return hash.ToString().ToUpper();
        }
    }
}
