using FakeProjectG;
using FakeProjectG.ClientProjectG.Data;
using FakeProjectG.Config;
using FakeProjectG.Defines;
using FakeProjectG.Packet;
using PangProjectG.Defines;
using System;
using System.ComponentModel;
using System.Diagnostics;
using System.Linq;
using System.Net;

namespace PangProjectG.Client.Login
{
    public class ClientLogin
    {
        public int CountPacket { get; set; }
        public bool PacketGameRead { get; set; }
        public void Handle(ProjectG client, LoginPacketEnumResponse packetID, ClientPacket packet)
        {
            WriteConsole.WriteLine($"[BOT_LOGIN_PACKET]: {packetID}", ConsoleColor.Cyan);
            switch (packetID)
            {
                case LoginPacketEnumResponse.PLAYER_CONNECTION:
                    {
                        CountPacket++;
                        HandleSendLogin(client, packet.Message[6]);
                    }
                    break;
                case LoginPacketEnumResponse.PLAYER_LOGIN_DATA:
                    {
                        CountPacket++;
                        HandleLoginProcess(client, packet);
                    }
                    break;
                case LoginPacketEnumResponse.PLAYER_SELECT_SERVER_DATA:
                    {
                        CountPacket++;
                        HandleReadAuthKey(client, packet, 2);
                    }
                    break;
                case LoginPacketEnumResponse.PLAYER_GAME_MACRO_DATA:
                    {
                        CountPacket++;
                        HandleReadMacro(client, packet);
                    }
                    break;
                case LoginPacketEnumResponse.PLAYER_AUTH_LOGIN_KEY_DATA:
                    {
                        CountPacket++;
                        HandleReadAuthKey(client, packet,1);
                    }
                    break;
                case LoginPacketEnumResponse.MESSAGEBOX_NICKNAME:
                    break;
                case LoginPacketEnumResponse.GAME_SERVERS_LIST_DATA:
                    {
                        CountPacket++;
                        HandleReadDataServers(client, packet, 2);
                    }
                    break;
                case LoginPacketEnumResponse.MESSENGE_SERVER_LIST_DATA:
                    {
                        CountPacket++;
                        HandleReadDataServers(client, packet, 9);
                        //if (PacketGameRead)
                        //{
                        //}
                    }
                    break;
                default:
                    {
                        Console.WriteLine(packet.GetLog());
                        packet.Save();
                    }
                    break;
            }

            client.ServerType = ServerTypeEnum.Login;
            if (CountPacket >= 5 && PacketGameRead && client.Login.PangyaVersion == EnumPangyaVersion.US)
            {
                SelectServer(client);

                CountPacket = 0;
                PacketGameRead = false;
               // client.Disconnect();

                Program.ProjectGClient.ServerType = ServerTypeEnum.Game;
                Program.ProjectGClient.Start(client.Game.IP, client.Game.Port);
            } 
            else if (CountPacket >= 6 && PacketGameRead && client.Login.PangyaVersion == EnumPangyaVersion.TH)
            {
                SelectServer(client);

                CountPacket = 0;
                PacketGameRead = false;
            }
        }

        private void HandleReadDataServers(ProjectG client, ClientPacket packet, byte Type)
        {
            var ServerCount = packet.ReadByte();
            switch (Type)
            {
                case 2:
                    {
                        //try to improve ^^
                        packet.Save();
                        for (var i = 0; i < ServerCount; i++)
                        {
                            try
                            {
                                var game = (ServerInfo)packet.Read(new ServerInfo());
                                var name = game.Name;
                                var id = game.ID;
                                var ip = IPAddress.Parse(game.IP);
                                var port = game.Port;
                                var s = new GameSettings(ip, port, name, id);
                                Program.ServersGame.Add(s);
                                if (client.Game.Name == null || client.Game.Name == "")
                                {
                                    client.Game = s;
                                    PacketGameRead = true;
                                    break;
                                }
                                PacketGameRead = true;
                            }
                            catch
                            {
                            }
                        }
                    }
                    break;
                    //is messenger server 
                case 9:
                    {
                        for (var i = 0; i < ServerCount; i++)
                        {
                            try
                            {
                                var msg = (ServerInfo)packet.Read(new ServerInfo());
                                var name = msg.Name;
                                var id = msg.ID;
                                var ip = IPAddress.Parse(msg.IP);
                                var port = msg.Port;

                                var s = new MessengerSettings(ip, port, name, id);
                                Program.ServersMessenger.Add(s);

                                client.Messenger = s;
                            }
                            catch
                            {
                            }
                        }
                    }
                    break;
            }
        }

        private void HandleReadMacro(ProjectG client, ClientPacket packet)
        {
            var Macro = new string[8];
           
            for (int i = 0; i < 8; i++)
            {
                Macro[i] = packet.ReadPStr(64);
            }

            client.Info.SetMacro(Macro);
        }

        private void HandleSendLogin(ProjectG client, byte Key)
        {
            client.GetKey = Key;
            client.KeyLogin = client.GetKey;

            client.Response.Write(new byte[] { 0x01, 0x00 });
            client.Response.WritePStr(client.GetLogin);
            client.Response.WritePStr(client.GetPass);
            if (client.Login.PangyaVersion == EnumPangyaVersion.US)
            {
                client.Response.WriteZero(17);
            }
            else if (client.Login.PangyaVersion == EnumPangyaVersion.TH)
            {
                //facebook conection Login
                client.Response.Write(new byte[] { 0x02, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0xFF, 0xFF, 0xFF, 0xFF, 0xFF, 0xFF, 0xFF, 0x7F, 0x00, 0x00, 0x00, 0x00, 0x80, 0xFF });
            }
            client.Send(client.Response);
        }
        private void HandleLoginProcess(ProjectG client, ClientPacket packet)
        {
            if (client.Login.PangyaVersion == EnumPangyaVersion.US)
            {
                LoginPacketCodeEnum Code = (LoginPacketCodeEnum)packet.ReadByte();

                WriteConsole.WriteLine($"[BOOT_LOGIN_PROCESS]: {Code}");
                switch (Code)
                {
                    case LoginPacketCodeEnum.Sucess:
                        {
                            client.GetLogin = packet.ReadPStr();
                            client.GetUID = packet.ReadUInt32();
                            client.GetCapability = (byte)packet.ReadInt32();
                            client.GetLevel = (byte)packet.ReadUInt32();
                            packet.Skip(6);
                            client.GetNickname = packet.ReadPStr();
                            Console.WriteLine();
                            Console.WriteLine("**************************************************************************");
                            Console.WriteLine("                                   LOGIN:         " + client.GetLogin);
                            Console.WriteLine("                                   UID:             " + client.GetUID);
                            Console.WriteLine("                                   TYPE:      " + client.GetCapability);
                            Console.WriteLine("                                   LEVEL:         " + client.GetLevel);
                            Console.WriteLine("                                   NICK:       " + client.GetNickname);
                            Console.WriteLine("**************************************************************************");
                            Console.WriteLine();
                        }
                        break;
                    case LoginPacketCodeEnum.InvalidoIdPw:
                        {

                        }
                        break;
                    case LoginPacketCodeEnum.InvalidoId:
                        {

                        }
                        break;
                    case LoginPacketCodeEnum.UsuarioEmUso:
                        {
                            WriteConsole.WriteLine("[BOOT_LOGIN_PROCESS]: Await User");
                            client.SendResponse(new byte[] { 0x04, 0x00, 0x00, 0x00, 0x00, 0x00 });
                            WriteConsole.WriteLine("[BOOT_LOGIN_PROCESS]: Logging in do User");
                        }
                        break;
                    case LoginPacketCodeEnum.Banido:
                        break;
                    case LoginPacketCodeEnum.UsernameOuSenhaInvalido:
                        break;
                    case LoginPacketCodeEnum.ContaSuspensa:
                        break;
                    case LoginPacketCodeEnum.Player13AnosOuMenos:
                        break;
                    case LoginPacketCodeEnum.SSNIncorreto:
                        break;
                    case LoginPacketCodeEnum.UsuarioIncorreto:
                        break;
                    case LoginPacketCodeEnum.OnlyUserAllowed:
                        break;
                    case LoginPacketCodeEnum.ServerInMaintenance:
                        break;
                    case LoginPacketCodeEnum.NaoDisponivelNaSuaArea:
                        break;
                    case LoginPacketCodeEnum.CreateNickName_US:
                        break;
                    case LoginPacketCodeEnum.CreateNickName:
                        break;
                    default:
                        {
                        }
                        break;
                }
            }
            else if (client.Login.PangyaVersion == EnumPangyaVersion.TH)
            {
                THLoginPacketCodeEnum Code = THLoginPacketCodeEnum.LOGIN_SUCESS;
                if (packet.Message.Count() <= 7)
                {
                    Code = (THLoginPacketCodeEnum)packet.ReadUInt32();
                }
                else if (packet.Message.Count() > 7)
                {
                    Code = (THLoginPacketCodeEnum)packet.ReadByte();
                }
                WriteConsole.WriteLine($"[BOOT_LOGIN_PROCESS]: Type {Code}");
                switch (Code)
                {
                    case THLoginPacketCodeEnum.LOGIN_SUCESS:
                        {
                            client.GetLogin = packet.ReadPStr();
                            client.GetUID = packet.ReadUInt32();
                            client.GetCapability = (byte)packet.ReadInt32();
                            client.GetLevel = (byte)packet.ReadUInt32();
                            packet.Skip(6);
                            client.GetNickname = packet.ReadPStr();
                            Console.WriteLine();
                            Console.WriteLine("**************************************************************************");
                            Console.WriteLine("                                   LOGIN:         "+ client.GetLogin);
                            Console.WriteLine("                                   UID:             "+ client.GetUID);
                            Console.WriteLine("                                   TYPE:      "+client.GetCapability);
                            Console.WriteLine("                                   LEVEL:         "+ client.GetLevel);
                            Console.WriteLine("                                   NICK:       "+ client.GetNickname);
                            Console.WriteLine("**************************************************************************");
                            Console.WriteLine();
                        }
                        break;
                    case THLoginPacketCodeEnum.INVALID_USER:
                        {
                            //client.Disconnect();
                        }
                        break;
                    case THLoginPacketCodeEnum.INVALID_PASS:
                        {
                            throw new Exception("SORRY, USER PASS INVALID ");
                        }
                    case THLoginPacketCodeEnum.Banido:
                        {
                           // client.Disconnect();
                        }
                        break;
                    case THLoginPacketCodeEnum.USER_IN_USE:
                        {
                            client.Response.Write(new byte[] { 0x04, 0x00, 0x00, 0x00, 0x00, 0x00 });
                            client.SendResponse();
                        }
                        break;
                    case THLoginPacketCodeEnum.ServerInMaintenance:
                        break;
                    default:
                        {
                            //client.Disconnect();
                            WriteConsole.WriteLine($"[BOOT_LOGIN_PACKETLOG]: {packet.GetLog()}");

                            packet.Save();
                        }
                        break;
                }
            }
        }

        private void HandleReadAuthKey(ProjectG client, ClientPacket packet, byte Type)
        {
            if (Type == 1)
            {
                client.GetAuth1 = packet.ReadPStr();
            }
            else
            {
                packet.Skip(4);
                client.GetAuth2 = packet.ReadPStr();
               
                client.Conn.ServerType = ServerTypeEnum.Game;
                client.Conn.Start(client.Game.IP, client.Game.Port);

                if (client.Messenger.ID != 0)
                {
                    client.Conn.ServerType = ServerTypeEnum.Message;
                    client.Conn.Start(client.Messenger.IP, client.Messenger.Port);
                }
            }
        }

        void SelectServer(ProjectG player)
        {
            player.Response.Write(new byte[] { 0x03, 0x00 });
            player.Response.Write(player.Game.ID);
            player.SendResponse();
        }
    }
}
