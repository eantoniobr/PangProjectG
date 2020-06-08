using FakeProjectG.ClientProjectG;
using FakeProjectG.Config;
using FakeProjectG.Packet;
using System;
using System.Net;
using System.Net.Sockets;
using System.Threading;
using FakeProjectG.Defines;
using System.Collections.Generic;

namespace FakeProjectG.ServerClient
{
    public abstract partial class TCPClient
    {
        #region Delegates
        public delegate void ConnectedEvent(PClient player);
        public delegate void PacketReceivedEvent(PClient player, ClientPacket packet);
        #endregion


        #region Events
        /// <summary>
        /// Este evento ocorre quando o ProjectG se conecta ao Servidor
        /// </summary>
        public event ConnectedEvent OnClientConnected;

        /// <summary>
        /// Este evento ocorre quando o Servidor Recebe um Packet do ProjectG
        /// </summary>
        public event PacketReceivedEvent OnPacketReceived;

        #endregion
        public TcpClient OnClient { get; set; }
        public TcpClient TcpLogin { get; set; }
        public TcpClient TcpGame { get; set; }
        public TcpClient TcpMessenge { get; set; }
        IPAddress LoginServerIP { get; set; }
        int LoginServerPort { get; set; }

        private bool running;
        public ServerTypeEnum ServerType { get; set; } = ServerTypeEnum.Login;
        public GameSettings SelectGame { get; set; }
        public abstract PClient OnConnectBot(TcpClient tcp);
        public abstract void OnDisconnectBot(PClient player);

        public abstract void OnException(PClient player, Exception ex);
        public List<PClient> Clients { get; set; }
        public TCPClient(string IP, int Port)
        {
            try
            {
                this.LoginServerIP = IPAddress.Parse(IP);
                this.LoginServerPort = Port;
                OnClient = new TcpClient();
                Clients = new List<PClient>();
                TcpLogin = new TcpClient();
                TcpGame = new TcpClient();
                TcpMessenge = new TcpClient();
            }
            catch (Exception e)
            {
                Console.WriteLine(e.ToString());
                Console.ReadKey();
                Environment.Exit(0);
            }
        }

        public void Start()
        {
            try
            {

                TcpLogin.Connect(this.LoginServerIP, LoginServerPort);
                OnClient = TcpLogin;
                running = true;
                //Inicia Thread para escuta de OnClientes
                var WaitConnectionsThread = new Thread(new ThreadStart(HandleClient));
                WaitConnectionsThread.Start();
            }
            catch
            {
                WriteConsole.WriteLine("[BOT_EXCEPTION]: SERVER OFFLINE", ConsoleColor.Red);
                Console.ReadKey();
                Environment.Exit(0);
            }
        }

        public void Start(IPAddress IP, int Port)
        {
            try
            {
                if (ServerType == ServerTypeEnum.Login)
                {
                    TcpLogin.Connect(IP, Port);
                    OnClient = TcpLogin;
                }
                else if (ServerType == ServerTypeEnum.Game)
                {
                    TcpGame.Connect(IP, Port);
                    OnClient = TcpGame;
                }
                else if (ServerType == ServerTypeEnum.Message)
                {
                    TcpMessenge.Connect(IP, Port);
                    OnClient = TcpMessenge;
                }
                running = true;
                //Inicia Thread para escuta de OnClientes
                var WaitConnectionsThread = new Thread(new ThreadStart(HandleClient));
                WaitConnectionsThread.Start();
            }
            catch
            {
                WriteConsole.WriteLine("[BOT_EXCEPTION]: SERVER OFFLINE", ConsoleColor.Red);
                Console.ReadKey();
                Environment.Exit(0);
            }
        }

        void HandleClient()
        {
            while (running)
            {
                // Cliente conectado
                Thread t = new Thread(new ParameterizedThreadStart(HandlePacket));
                t.Start(OnClient);
                break;
            }
        }

        private void HandlePacket(object obj)
        {
            //Recebe OnCliente a partir do parâmetro
            TcpClient tcpClient = (TcpClient)obj;

            var Player = OnConnectBot(tcpClient);

            //Chama evento OnClientConnected
            this.OnClientConnected?.Invoke(Player);

            while (Player.Tcp.Connected)
            {
                try
                {
                    var messageBufferRead = new byte[500000]; //Tamanho do BUFFER á ler

                    //Lê mensagem do OnCliente
                    //size =500000;
                    int bytesRead = Player.Tcp.GetStream().Read(messageBufferRead, 0, 500000);

                    //variável para armazenar a mensagem recebida
                    byte[] message = new byte[bytesRead];

                    //Copia mensagem recebida
                    Buffer.BlockCopy(messageBufferRead, 0, message, 0, bytesRead);

                    if (message.Length >= 5)
                    {
                        var packet = new ClientPacket(message);

                        OnPacketReceived?.Invoke(Player, packet);
                    }
                }
                catch (Exception ex)
                {
                    OnException(Player, ex);
                }
            }
        }
    }
}
