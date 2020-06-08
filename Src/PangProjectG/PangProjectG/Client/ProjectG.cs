using FakeProjectG.BinaryModels;
using FakeProjectG.ClientProjectG;
using FakeProjectG.Defines;
using FakeProjectG.Packet;
using PangProjectG.Client.Game;
using PangProjectG.Client.Login;
using PangProjectG.Client.Messanger;
using PangProjectG.CommandForm;
using PangProjectG.Defines;
using System.Linq;
using System.Net;
using System.Net.Sockets;
namespace PangProjectG.Client
{
    public partial class ProjectG : PClient
    {
        ClientLogin PacketLogin { get; set; }
        public ClientGame PacketGame { get; set; }
        public ClientMessanger PacketMessenger { get; set; }
        public long Cookies { get; set; }
        public ulong Pangs { get { return Info.Statistic.Pang; } set { Info.Statistic.Pang = value; } }

        public bool InLobby { get; set; }
        public bool InGame { get; set; }
        public ChatCommands Commands { get; set; }

        public ProjectG(TcpClient tcp) : base(tcp)
        {
            ServerType = ServerTypeEnum.Login;
            PacketLogin = new ClientLogin();
            PacketGame = new ClientGame();
            PacketMessenger = new ClientMessanger();
            Commands = new ChatCommands();
        }

        public override void HandleTypeClient(ClientPacket packet)
        {
            Response = new PangyaBinaryWriter();

            switch (ServerType)
            {
                case ServerTypeEnum.Unknown:
                    break;
                case ServerTypeEnum.Login:
                    {
                        var packetID = (LoginPacketEnumResponse)packet.Id;

                        if (packetID == LoginPacketEnumResponse.PLAYER_CONNECTION)
                        {
                            PacketLogin.Handle(this, packetID, packet);
                        }
                        else if (packetID != LoginPacketEnumResponse.PLAYER_CONNECTION && Login.PangyaVersion == EnumPangyaVersion.US)
                        {
                            var packetold = packet;
                            packet = new ClientPacket(packetold.Message, GetKey);
                            packetID = (LoginPacketEnumResponse)packet.Id;

                            PacketLogin.Handle(this, packetID, packet);
                        }
                        else if (packetID != LoginPacketEnumResponse.PLAYER_CONNECTION && Login.PangyaVersion == EnumPangyaVersion.TH)
                        {
                            var packetold = packet;

                            var packets = packetold.GetSubPackets(packetold.Message, GetKey);
                            if (packets.Count > 1)
                            {
                                for (int i = 0; i < packets.Count; i++)
                                {
                                    packet = packets[i];

                                    packetID = (LoginPacketEnumResponse)packet.Id;

                                    PacketLogin.Handle(this, packetID, packet);
                                }
                            }
                            else if (packets.Count == 1)
                            {
                                packet = packets.First();

                                packetID = (LoginPacketEnumResponse)packet.Id;

                                PacketLogin.Handle(this, packetID, packet);
                            }
                        }
                    }
                    break;
                case ServerTypeEnum.Game:
                    {
                        var packetID = (GamePacketEnumResponse)packet.Id;

                        if (packetID == GamePacketEnumResponse.PLAYER_CONNECTION)
                        {
                            PacketGame.Handle(this, packetID, packet);
                        }
                        else if (packetID != GamePacketEnumResponse.PLAYER_CONNECTION)
                        {
                            var packetold = packet;
                            packet = new ClientPacket(packetold.Message, GetKey);
                            packetID = (GamePacketEnumResponse)packet.Id;

                            PacketGame.Handle(this, packetID, packet);
                        }
                        Commands.SetPlayer(this);
                    }
                    break;
                case ServerTypeEnum.Message:
                    {
                        var packetID = (MessengerResponseEnum)packet.Id;


                        PacketMessenger.Handle(this, packetID, packet);
                    }
                    break;
                default:
                    break;
            }
        }

        public void HandleSendClientChat(string comando)
        {
            Response.Write(new byte[] { 0x03, 0x00 });
            Response.Write(GetNickname);
            Response.Write(comando);
            SendResponse();
        }

        public string GetIpAdress
        {
            get {return ((IPEndPoint)Tcp.Client.RemoteEndPoint).Address.ToString(); }
        }

        public byte[] GetIpAdressBytes
        {
            get {return new byte[GetIpAdress.Length]; }
        }
    }
}
