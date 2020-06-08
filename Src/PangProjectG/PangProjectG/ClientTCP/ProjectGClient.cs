using FakeProjectG;
using FakeProjectG.ClientProjectG;
using FakeProjectG.ServerClient;
using PangProjectG.Client;
using System;
using System.Linq;
using System.Net.Sockets;

namespace PangProjectG.ClientTCP
{
    public class ProjectGClient : TCPClient
    {
        public ProjectGClient(string IP, int Port) : base(IP, Port)
        {
        }

        public override PClient OnConnectBot(TcpClient tcp)
        {
            ProjectG player = null;
            if (ServerType == FakeProjectG.Defines.ServerTypeEnum.Login)
            {
                player = new ProjectG(tcp)
                {
                    Conn = this
                };
                Clients.Add(player);
            }
            else if (ServerType == FakeProjectG.Defines.ServerTypeEnum.Game)
            {
                player = (ProjectG)Clients.First();

                Clients.RemoveAt(0);

                player.Tcp = tcp;
                player.Conn = this;
                player.ServerType = FakeProjectG.Defines.ServerTypeEnum.Game;
                Clients.Add(player);
            }
            WriteConsole.WriteLine($"[BOT_{player.ServerType}_CONNECTED]: Sucess", ConsoleColor.Red);
            return player;
        }

        public override void OnDisconnectBot(PClient player)
        {
            WriteConsole.WriteLine($"[BOT_{player.ServerType}_DISCONNECT]: {player.GetNickname}", ConsoleColor.Red);
            player.SendBytes(new byte[0]);
            player.Tcp.Close();
        }

        public override void OnException(PClient player, Exception ex)
        {
            Console.WriteLine("Unexpected exception : {0}", ex.ToString());
            Console.ReadKey();
            Environment.Exit(0);
        }
    }
}
