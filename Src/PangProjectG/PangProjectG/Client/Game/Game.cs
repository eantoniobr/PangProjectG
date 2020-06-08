using FakeProjectG;
using FakeProjectG.ClientProjectG.Data;
using FakeProjectG.Defines;
using FakeProjectG.Packet;
using PangProjectG.CommandForm;
using PangProjectG.Defines;
using System;
using System.Linq;
using System.Windows.Forms;

namespace PangProjectG.Client.Game
{
    public class ClientGame
    {
        public int CountPacket { get; set; }

        public void Handle(ProjectG client, GamePacketEnumResponse packetID, ClientPacket packet)
        {
            WriteConsole.WriteLine($"[BOT_GAME_PACKET]: {packetID}", ConsoleColor.Cyan);
            switch (packetID)
            {
                case GamePacketEnumResponse.PLAYER_CONNECTION:
                    {
                        CountPacket++;
                        HandleSendGameLogin(client, packet.Message[8]);
                    }
                    break;
                case GamePacketEnumResponse.PLAYER_GAME_RESUME:
                    break;
                case GamePacketEnumResponse.PLAYER_GAME_SUCESS:
                    break;
                case GamePacketEnumResponse.PLAYER_TRANSTION_ITEMS:
                    break;
                case GamePacketEnumResponse.GAME_CHANNEL_DATA:
                    {
                        CountPacket++;
                        HadleReadGameChannelData(client, packet);
                    }
                    break;
                case GamePacketEnumResponse.GAME_CHANNEL_INVALID:
                    break;
                case GamePacketEnumResponse.PLAYER_ENTER_CHANNEL_RESULT:
                    {
                        CountPacket++;
                        HandleReadResultEnterLobby(client, packet.ReadByte());
                    }
                    break;
                case GamePacketEnumResponse.PACKET_UNK_F6:
                    break;
                case GamePacketEnumResponse.PACKET_UNK_F1:
                    break;
                case GamePacketEnumResponse.PACKET_UNK_F5:
                    break;
                case GamePacketEnumResponse.PACKET_UNK_131:
                    break;
                case GamePacketEnumResponse.PACKET_UNK_136:
                    break;
                case GamePacketEnumResponse.PACKET_UNK_181:
                    break;
                case GamePacketEnumResponse.PACKET_UNK_B4:
                    break;
                case GamePacketEnumResponse.PLAYER_ACHIEVEMENT_COUNTER:
                    break;
                case GamePacketEnumResponse.PLAYER_ACHIEVEMENT:
                    break;
                case GamePacketEnumResponse.PLAYER_CARD_DATA:
                    break;
                case GamePacketEnumResponse.PLAYER_CARD_EQUIPED:
                    break;
                case GamePacketEnumResponse.PLAYER_MAIN_DATA:
                    {
                        CountPacket++;
                        HandleReadGameLogin(client, packet, (PLAYER_GAME_LOGIN_RESULT)packet.Message[2]);
                    }
                    break;
                case GamePacketEnumResponse.GAME_PLAY_INFO:
                    break;
                case GamePacketEnumResponse.PLAYER_FURNITURE_DATA:
                    break;
                case GamePacketEnumResponse.PLAYER_ACTION_GAME:
                    break;
                case GamePacketEnumResponse.PLAYER_ACTION_SHOT:
                    break;
                case GamePacketEnumResponse.PLAYER_ACTION_ROTATE:
                    break;
                case GamePacketEnumResponse.PLAYER_ACTION_CHANGE_CLUB:
                    break;
                case GamePacketEnumResponse.PLAYER_TROPHIES_DATA:
                    break;
                case GamePacketEnumResponse.PLAYER_TROPHIES_DATA_GP:
                    break;
                case GamePacketEnumResponse.PLAYER_NEXT:
                    break;
                case GamePacketEnumResponse.PLAYER_CHARACTERS_DATA:
                    break;
                case GamePacketEnumResponse.PLAYER_CADDIES_DATA:
                    break;
                case GamePacketEnumResponse.PLAYER_CADDIES_EXPIRATION_DATA:
                    break;
                case GamePacketEnumResponse.PLAYER_EQUIP_DATA:
                    break;
                case GamePacketEnumResponse.PLAYER_ITEMS_DATA:
                    break;
                case GamePacketEnumResponse.PLAYER_1ST_SHOT_READY:
                    break;
                case GamePacketEnumResponse.PLAYER_COOKIES:
                    {
                        HandleReadPlayerCookies(client, packet);
                    }
                    break;
                case GamePacketEnumResponse.PLAYER_LOADING_INFO:
                    break;
                case GamePacketEnumResponse.PLAYER_MASCOTS_DATA:
                    break;
                case GamePacketEnumResponse.PLAYER_CALL_MESSAGESERVER_DATA:
                    {
                        HandleSendClientSelectChannelID(client);
                    }
                    break;
                case GamePacketEnumResponse.PLAYER_TUTORIAL_DATA:
                    break;
                case GamePacketEnumResponse.PLAYER_DAILYLOGIN_CHECK_DATA:
                    {
                        if (client.InLobby == false)
                        {
                            Console.WriteLine("Do you want to enter the Games list: YES or NOT ");
                            var result = Console.ReadLine();
                            Console.WriteLine();
                            if (result == "yes" && result == "YES")
                            {
                                client.InLobby = true;
                                HandleSendEnterLobbyList(client);
                            }
                        }
                    }
                    break;
                case GamePacketEnumResponse.PLAYER_DAILYLOGIN_ITEM_DATA:
                    break;
                case GamePacketEnumResponse.PLAYER_STATISTIC_DATA:
                    {
                        CountPacket++;
                        HandleReadStatisticData(client, packet);
                    }
                    break;
                case GamePacketEnumResponse.PLAYER_REQUEST_INFO:
                    break;
                case GamePacketEnumResponse.PLAYER_CHARACTER_INFO:
                    break;
                case GamePacketEnumResponse.PLAYER_TOOLBAR_INFO:
                    break;
                case GamePacketEnumResponse.PLAYER_GUILD_INFO:
                    break;
                case GamePacketEnumResponse.PLAYER_RECORD_INFO:
                    break;
                case GamePacketEnumResponse.PLAYER_TROPHY_INFO_NORMAL:
                    break;
                case GamePacketEnumResponse.PLAYER_TROPHY_INFO_SPECIAL:
                    break;
                case GamePacketEnumResponse.PLAYER_MAILBOX_POPUP_DATA:
                    break;
                case GamePacketEnumResponse.PLAYER_OPEN_MAILBOX_DATA:
                    break;
                case GamePacketEnumResponse.PLAYER_CHAT_RECV_DATA:
                    break;
                case GamePacketEnumResponse.PLAYER_KEEPLIVE:
                    break;
                case GamePacketEnumResponse.PLAYER_LOBBY_DATA:
                    break;
                case GamePacketEnumResponse.PLAYER_GAME_HEADERDATA:
                    break;
                case GamePacketEnumResponse.CREATE_PLAYER_IN_GAME:
                    break;
                case GamePacketEnumResponse.PLAYER_ACQUIRE_DATA:
                    break;
                case GamePacketEnumResponse.NOTICE_GAME:
                    break;
                case GamePacketEnumResponse.PLAYER_START_GAME:
                    break;
                case GamePacketEnumResponse.GAME_ACTION:
                    break;
                case GamePacketEnumResponse.PLAYER_BUY_ITEM_SHOP:
                    break;
                case GamePacketEnumResponse.PLAYER_REQUEST_INFO_RESULT_TYPE:
                    break;
                case GamePacketEnumResponse.NOTHING:
                    break;
                default:
                    break;
            }

            client.ServerType = ServerTypeEnum.Game;
        }

        private void HandleReadGameLogin(ProjectG client, ClientPacket packet, PLAYER_GAME_LOGIN_RESULT Type)
        {
            WriteConsole.WriteLine($"[BOOT_LOGIN_PROCESS]: {Type}");
            if (Type == PLAYER_GAME_LOGIN_RESULT.UNKNOW)
            {
                Console.WriteLine("PLAYER_MAIN_DATA_UN");
            }

            if (Type == PLAYER_GAME_LOGIN_RESULT.LOAD_SERVER_TIME)
            {
                var time = packet.ReadByte();
                Console.WriteLine($"PACKET_TIME: {time}");
            }

            if (Type == PLAYER_GAME_LOGIN_RESULT.SUCESS && packet.Message[3] == 0x06)
            {
                packet.Skip(110);
                client.ConnectionID = packet.ReadUInt32();

                Console.WriteLine($"PLAYER_LOGIN_COMPLETE !");
            }
        }


        public void HadleReadGameChannelData(ProjectG player, ClientPacket packet)
        {
            var total = packet.ReadByte();
            for (int i = 0; i < total; i++)
            {
                var channel = new PlayerLobby();

                channel = (PlayerLobby)packet.Read(channel);
                Program.Channels.Add(channel);
            }

            if (Program.Channels.Count > 0)
            {
                foreach (var data in Program.Channels.Where(c => c.MaxPlayer > c.CurrUser))
                {
                    player.Info.Lobby.ID = data.ID;
                }
            }
            else
            {
            }
        }


        private void HandleSendGameLogin(ProjectG client, byte Key)
        {
            client.GetKey = Key;
            client.KeyLogin = client.GetKey;


            client.Response.Write(new byte[] { 0x02, 0x00 });
            client.Response.WritePStr(client.GetLogin);
            client.Response.Write(client.GetUID);
            client.Response.Write(0);
            client.Response.Write(new byte[] { 0x96, 0x66, });
            client.Response.WritePStr(client.GetAuth1);
            if (client.Login.PangyaVersion == EnumPangyaVersion.US)
            {
                client.Response.WritePStr("824.00");// is server version US
                client.Response.Write(new byte[] { 0xD2, 0xC9, 0x4A, 0x25, 0x00, 0x00, 0x00, 0x00, });
                client.Response.WritePStr(client.GetAuth2);
            }
            if (client.Login.PangyaVersion == EnumPangyaVersion.TH)
            {
                client.Response.WritePStr("829.01");// is server version TH
                client.Response.Write(new byte[] { 0xC7, 0xD2, 0x4A, 0x25, 0x00, 0x00, 0x00, 0x00, });
                client.Response.WritePStr(client.GetAuth2);
                client.Response.Write(new byte[] { 0x32, 0x33, 0x5D, 0x0D, 0x05, });
            }
            client.SendResponse();
        }

        public void HandleSendClientSelectChannelID(ProjectG player)
        {
            var rnd = new Random();
            player.Response.Write(new byte[] { 0x04, 0x00 });
            player.Response.Write(player.Info.Lobby.ID);
            player.Response.Write((byte)rnd.Next(1, 255));
            player.Response.Write((ushort)0x0700);
            player.Response.Write((byte)rnd.Next(1, 255));
            player.Response.Write(new byte[] { 0x69, 0x69, 0x01 });
            player.SendResponse();
        }

        public void HandleSendEnterLobbyList(ProjectG player)
        {
            player.SendBytes(new byte[] { 0x81, 0x00 });
        }

        public void HandleSendLeaveLobbyList(ProjectG player)
        {
            player.Response.Write(new byte[] { 0x82, 0x00 });
            player.SendResponse();
        }

        public void HandleSendClientDisconnect(ProjectG player)
        {
            player.Response.Write(new byte[] { 0x6E, 0x01 });
            player.SendResponse();
        }

        public void HandleSendClientLobbyInfo(ProjectG player)
        {
            player.Send(new byte[] { 0x43, 0x00 });
        }

        public void HandleSendClientEnterPapelShop(ProjectG player)
        {
            if (player.Pangs > 0)
                player.Response.Write(new byte[] { 0x98, 0x00 });
            player.SendResponse();
        }

        public void HandleSendClientCreateRoom(ProjectG player, int VersusTime = 0, int TorneyTime = 0, byte MaxProjectG = 0, byte GameType = 0, byte TotalHoles = 0, byte Map = 0, byte Mode = 0, int natural = 0, string RomName = "Test", string RomPass = "")
        {
            player.Response.Write(new byte[] { 0x08, 0x00 });
            player.Response.Write((byte)0);//unk
            player.Response.Write(VersusTime);
            player.Response.Write(TorneyTime);
            player.Response.Write(MaxProjectG);
            player.Response.Write(GameType);
            player.Response.Write(TotalHoles);
            player.Response.Write(Map);
            player.Response.Write(Mode);
            player.Response.Write(natural);
            player.Response.WritePStr(RomName);
            player.Response.WritePStr(RomPass);
            player.Response.Write(0);//artefato
            player.SendResponse();
        }

        public void HandleReadStatisticData(ProjectG player, ClientPacket packet)
        {
            packet.Skip(164);
            player.Pangs = packet.ReadUInt64();
        }

       
        public void HandleReadResultEnterLobby(ProjectG player, byte Code)
        {
            if (Code == 1)
            {
                Console.WriteLine("Sucess Enter In Lobby !");
            }
            if (Code == 2)
            {
                Console.WriteLine("Await New LobbyID !");
                if (Program.Channels.Count > 0)
                {
                    foreach (var data in Program.Channels.Where(c => c.ID != player.Info.Lobby.ID && c.MaxPlayer > c.CurrUser))
                    {
                        player.Info.Lobby.ID = data.ID;
                    }
                }
                HandleSendClientSelectChannelID(player);
            }
        }

        //public void HandleReadChatData(ProjectG player, ClientPacket packet)
        //{
        //    var type = packet.ReadByte();
        //    var NickName = packet.ReadPStr();
        //    var MessageReceived = packet.ReadPStr();
        //    //ChatCommand.ChatData(NickName, MessageReceived);
        //}

        public void HandleReadPlayerCookies(ProjectG player, ClientPacket packet)
        {
            player.Cookies = packet.ReadInt64();
        }
    }
}
