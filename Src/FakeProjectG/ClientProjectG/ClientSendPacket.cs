using FakeProjectG.BinaryModels;
using FakeProjectG.Crypts;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FakeProjectG.ClientProjectG
{
    public partial class PClient
    {
        public void Send(PangyaBinaryWriter packet)
        {
            var buffer = packet.GetBytes().ClientEncrypt(GetKey);

            SendBytes(buffer);
        }

        public void Write(PangyaBinaryWriter Data)
        {
            Send(Data);
        }

        public void Write(byte[] Data)
        {
            Send(Data);
        }
        public void SendResponse(List<byte[]> Data)
        {
            Response = new PangyaBinaryWriter();
            Data.ForEach(item => Response.Write(item));
            SendResponse();
        }
        public void SendResponse(byte[] Data)
        {
            Send(Data);
        }
       
        public void SendResponse(byte[] Header, byte[] Data)
        {
            Response.Write(Header);
            Response.Write(Data);
            Send(Response.GetBytes());
            Response.Clear();
        }
        public void SendResponse()
        {
            var buffer = Response.GetBytes().ClientEncrypt(GetKey);

            SendBytes(buffer);
            if (Response.GetSize > 0)
            {
                Response.Clear();
            }
        }
        public void SendResponse(PangyaBinaryWriter packet)
        {
            Send(packet);
            if (packet.GetSize > 0)
            {
                Response.Clear();
            }
        }
        public void Send(byte[] Data)
        {
            var buffer = Data.ClientEncrypt(GetKey);

            SendBytes(buffer);
        }

        public void SendBytes(byte[] buffer)
        {
            if (Tcp.Connected && Connected)
            {
                Tcp.GetStream().Write(buffer, 0, buffer.Length);
            }
        }
        
    }
}
