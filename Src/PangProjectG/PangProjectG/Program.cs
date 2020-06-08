using FakeProjectG.ClientProjectG;
using FakeProjectG.ClientProjectG.Data;
using FakeProjectG.Config;
using FakeProjectG.Packet;
using PangProjectG.Client;
using PangProjectG.ClientTCP;
using System;
using System.Collections.Generic;

namespace PangProjectG
{
    class Program
    {
        public static ProjectGClient ProjectGClient;

        public static List<GameSettings> ServersGame { get; set; } = new List<GameSettings>();
        public static List<MessengerSettings> ServersMessenger { get; set; } = new List<MessengerSettings>();

        public static string LoginServerIP { get; private set; }
        public static int LoginServerPort { get; private set; }
        public static List<PlayerLobby> Channels { get; set; } = new List<PlayerLobby>();

        static void Main()
        {
            Console.Title = "Bot Client Pangya";
            Console.WriteLine("                           ===============================================");
            Console.WriteLine("                           ||                                           ||");
            Console.WriteLine("                           ||   By LuisMK - Unogames ProjectG Fake      ||");
            Console.WriteLine("                           ||   Copyright <c> 2019 Unogames-Team        ||");
            Console.WriteLine("                           ||   ---------------------------------       ||");
            Console.WriteLine("                           ||             Bot Client                    ||");
            Console.WriteLine("                           ===============================================");
            Console.WriteLine("                          used to force information about an official server");
            Console.WriteLine();
            if (LoginServerIP == null)
            {
                Console.Write("-- Please input target LoginServer IP: ");
                LoginServerIP = Console.ReadLine();
                Console.WriteLine();
            }

            if (LoginServerPort == 0)
            {
                Console.Write("-- Please input target LoginServer Port: ");
                LoginServerPort = int.Parse(Console.ReadLine());
                Console.WriteLine();
            }
            ProjectGClient = new ProjectGClient(LoginServerIP, LoginServerPort);

            ProjectGClient.Start();

            ProjectGClient.OnPacketReceived += Server_OnPacketReceived;
        }

        public static void Server_OnPacketReceived(PClient player, ClientPacket packet)
        {
            var client = (ProjectG)player;

            client.HandleTypeClient(packet);
        }
    }
}
