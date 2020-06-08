using FakeProjectG.Tools;
using System.Net;
namespace FakeProjectG.Config
{
    public class GameSettings
    {
        public IPAddress IP { get; set; }

        public int Port { get; set; }
        public string Name { get; set; }
        public int ID { get; set; }

        public byte Sub_ID { get; set; }

        public string Version_Client { get; set; }
        /// <summary>
        /// Is Config
        /// </summary>
        /// <param name="Ini"></param>
        public GameSettings(IniFile Ini)
        {
            ID = Ini.ReadInt32("GameServer", "SELECT_SERVER_ID", 20201);
            Sub_ID = Ini.ReadByte("GameServer", "SELECT_SUBSERVER", 1);
            Version_Client = Ini.ReadString("GameServer", "VERSION_CLIENT", "824.00");
            IP = IPAddress.Parse(Ini.ReadString("LoginServer", "IP", "127.0.0.1"));    //use ip for login
        }
        /// <summary>
        /// Is Read Data
        /// </summary>
        /// <param name="ip"></param>
        /// <param name="port"></param>
        /// <param name="name"></param>
        /// <param name="id"></param>
        public GameSettings(IPAddress ip, int port, string name, int id)
        {
            IP = ip;
            Port = port;
            Name = name;
            ID = id;
        }
    }
}
