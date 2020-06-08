using FakeProjectG;
using FakeProjectG.Packet;
using PangProjectG.Defines;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PangProjectG.Client.Messanger
{
    public class ClientMessanger
    {
        public void Handle(ProjectG client, MessengerResponseEnum packetID, ClientPacket packet)
        {
            WriteConsole.WriteLine($"[BOT_LOGIN_PACKET]: {packetID}", ConsoleColor.Cyan);
            switch (packetID)
            {
                case MessengerResponseEnum.PLAYER_CONNECTION:
                    {
                        var key = packet.Message[8];

                        Console.WriteLine("Key =>" + key);

                        client.GetKey = key;

                        client.Response.Write(new byte[] { 0x12, 0x00 });
                        client.Response.Write(client.GetUID);
                        client.Response.Write(client.GetLogin);
                    }
                    break;
                default:
                    {
                        WriteConsole.WriteLine($"[BOT_MESSENGER_PACKETLOG]: {packet.GetLog()}", ConsoleColor.Cyan);
                        packet.Save();
                    }
                    break;
            }
        }
    }
}
