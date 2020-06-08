using FakeProjectG.Tools;
using System.Net;
namespace FakeProjectG.Config
{
    public class MessengerSettings
    {
        public IPAddress IP { get; set; }

        public int Port { get; set; }
        public string Name { get; set; }
        public int ID { get; set; }
        /// <summary>
        /// Is Read Data
        /// </summary>
        /// <param name="ip"></param>
        /// <param name="port"></param>
        /// <param name="name"></param>
        /// <param name="id"></param>
        public MessengerSettings(IPAddress ip, int port, string name, int id)
        {
            IP = ip;
            Port = port;
            Name = name;
            ID = id;
        }
        public MessengerSettings()
        {
        }
    }
}
