using FakeProjectG.BinaryModels;
using FakeProjectG.Crypts;
using FakeProjectG.Defines;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using static FakeProjectG.Crypts.Cryptor;
namespace FakeProjectG.Packet
{
    public class ClientPacket
    {
        #region Private Fields
        private readonly MemoryStream _stream;
        /// <summary>
        /// Leitor do packet
        /// </summary>
        private PangyaBinaryReader Reader;

        private PangyaBinaryWriter Reply = new PangyaBinaryWriter();
        private byte Key { get; set; }
        /// <summary>
        /// Mensagem do Packet
        /// </summary>
        public byte[] Message { get; set; }

        private byte[] MessageCrypted { get; set; }
        #endregion

        #region Public Fields
        /// <summary>
        /// Id do Packet
        /// </summary>
        public short Id { get; set; }


        #endregion

        #region Constructor

        public ClientPacket(byte[] message, byte key)
        {
            Key = key;
            MessageCrypted = new byte[message.Length];
            Buffer.BlockCopy(message, 0, MessageCrypted, 0, message.Length); //Copia mensagem recebida criptografada

            Message = message.ServerDecrypt(key);

            Id = BitConverter.ToInt16(new byte[] { Message[0], Message[1] }, 0);

            _stream = new MemoryStream(Message);

            _stream.Seek(2, SeekOrigin.Current); //Seek Inicial
            Reader = new PangyaBinaryReader(_stream);
        }

        public ClientPacket(byte[] message)
        {

            Message = message;

            MessageCrypted = new byte[message.Length];
            Buffer.BlockCopy(message, 0, MessageCrypted, 0, message.Length); //Copia mensagem recebida criptografada


            Id = BitConverter.ToInt16(new byte[] { message[0], message[1] }, 0);

            _stream = new MemoryStream(Message);

            _stream.Seek(2, SeekOrigin.Current); //Seek Inicial
            Reader = new PangyaBinaryReader(_stream);
        }

        public ClientPacket()
        { 
        
        }

        #region Methods Get
        public uint GetSize
        {
            get => Reader.GetSize();
        }
        public uint GetPos
        {
            get => Reader.GetPosition();
        }

        public double ReadDouble()
        {
            return Reader.ReadDouble();
        }

        public byte ReadByte()
        {
            return Reader.ReadByte();
        }
        public short ReadInt16()
        {
            return Reader.ReadInt16();
        }
        public ushort ReadUInt16()
        {
            return Reader.ReadUInt16();
        }



        public uint ReadUInt32()
        {
            return Reader.ReadUInt32();
        }
        public int ReadInt32()
        {
            return Reader.ReadInt32();
        }

        public ulong ReadUInt64()
        {
            return Reader.ReadUInt64();
        }

        public long ReadInt64()
        {
            return Reader.ReadInt64();
        }

        public float ReadSingle()
        {
            return Reader.ReadSingle();
        }

        public string ReadPStr()
        {
            return Reader.ReadPStr();
        }
        public void Skip(int count)
        {
            Reader.Skip(count);
        }


        public void Seek(int offset, int origin)
        {
            Reader.Seek(offset, origin);
        }

        public T Read<T>() where T : struct
        {
            return Reader.Read<T>();
        }
        public IEnumerable<uint> Read(uint count)
        {
            return Reader.Read(count);
        }
        public object Read(object value, int Count)
        {
            return Reader.Read(value, Count);
        }

        public object Read(object value)
        {
            return Reader.Read(value);
        }



        public string ReadPStr(uint Count)
        {
            var data = new byte[Count];
            //ler os dados
            Reader.BaseStream.Read(data, 0, (int)Count);
            var value = Encoding.ASCII.GetString(data).Replace("\0", "");
            return value;
        }

        public bool ReadPStr(out string value, uint Count)
        {
            return Reader.ReadPStr(out value, Count);
        }
        public bool ReadPStr(out string value)
        {
            return Reader.ReadPStr(out value);
        }
        public bool ReadDouble(out Double value)
        {
            return Reader.ReadDouble(out value);
        }
        public bool ReadBytes(out byte[] value)
        {
            return Reader.ReadBytes(out value);
        }
        public bool ReadByte(out byte value)
        {
            return Reader.ReadByte(out value);
        }
        public bool ReadInt16(out short value)
        {
            return Reader.ReadInt16(out value);
        }
        public bool ReadUInt16(out ushort value)
        {
            return Reader.ReadUInt16(out value);
        }

        public bool ReadUInt32(out uint value)
        {
            return Reader.ReadUInt32(out value);
        }

        public bool ReadInt32(out int value)
        {
            return Reader.ReadInt32(out value);
        }

        public bool ReadUInt64(out ulong value)
        {
            return Reader.ReadUInt64(out value);
        }

        public bool ReadInt64(out long value)
        {
            return Reader.ReadInt64(out value);
        }

        public bool ReadSingle(out float value)
        {
            return Reader.ReadSingle(out value);
        }


        public byte[] GetRemainingData
        {
            get => Reader.GetRemainingData();
        }
        public byte[] ReadBytes(int count)
        {
            return Reader.ReadBytes(count);
        }

        public string GetLog()
        {
            StringBuilder builder = new StringBuilder(Message.Length * 2);
            foreach (byte num2 in Message)
            {
                builder.AppendFormat("{0:X2} ", num2);
            }
            return $"[PACKET_LOG]: {builder}";
        }

      
        public void Save()
        {
            File.WriteAllBytes($"savepacket\\Packet{new Random().Next(9999)}.Hex", Message);
        }
        public void Save(string name)
        {
            File.WriteAllBytes($"savepacket\\{name}_{new Random().Next(9999)}.Hex", Message);
        }

        public void SetReader(PangyaBinaryReader read)
        {
            Reader = read;
        }

        #endregion

        #region Methods Writer

        public void Write(byte[] data)
        {
            try
            {
                Reply.Write(data);
            }
            catch
            {
            }
            return;
        }

        public void WriteStruct(object data)
        {
            try
            {
                Reply.WriteStruct(data);
            }
            catch
            {
            }
            return;
        }


        public void WriteStr(string message, int length)
        {

            try
            {
                if (message == null)
                {
                    message = string.Empty;
                }

                message = message.PadRight(length, (char)0x00);
                Reply.Write(message.Select(Convert.ToByte).ToArray());
            }
            catch
            {
            }
            return;
        }

        public bool WriteStr(string message)
        {
            try
            {
                WriteStr(message, message.Length);
            }
            catch
            {
                return false;
            }
            return true;

        }

        public void WritePStr(string value)
        {

            try
            {
                Reply.WritePStr(value);

            }
            catch
            {
                return;
            }
        }

        public void WriteZero(int count)
        {
            try
            {
                Reply.WriteZero(count);
            }
            catch
            {

            }

        }
        public void WriteUInt16(ushort value)
        {
            try
            {
                Reply.Write(value);
            }
            catch
            {

            }

        }

        public void WriteInt16(short value)
        {
            try
            {
                Reply.Write(value);
            }
            catch
            {

            }

        }
        public void WriteByte(byte value)
        {
            try
            {
                Reply.Write(value);
            }
            catch
            {

            }

        }

        public void WriteSingle(float value)
        {
            try
            {
                Reply.Write(value);
            }
            catch
            {

            }

        }

        public void WriteUInt32(uint value)
        {
            try
            {
                Reply.Write(value);
            }
            catch
            {

            }

        }

        public void WriteInt32(int value)
        {
            try
            {
                Reply.Write(value);
            }
            catch
            {

            }

        }

        public void WriteUInt64(ulong value)
        {
            try
            {
                Reply.Write(value);
            }
            catch
            {

            }

        }

        public void WriteInt64(long value)
        {
            try
            {
                Reply.Write(value);
            }
            catch
            {

            }

        }

        public void WriteDouble(double value)
        {
            try
            {
                Reply.Write(value);
            }
            catch
            {

            }

        }
        public byte[] GetBytes()
        {
            return Reply.GetBytes();
        }

        public void Clear()
        {
            Reply = new PangyaBinaryWriter();
        }
        #endregion

        public List<ClientPacket> GetSubPackets(byte[] Buffer, byte key)
        {
            var subpackets = new List<ClientPacket>();

            var buffer = new List<byte>(Buffer);

            try
            {
                while (true)
                {
                    var message = buffer.ToArray().UGServerDecrypt(key);

                    var packet = new ClientPacket(buffer.ToArray(), key);

                    var str = BitConverter.ToString(message).Replace("-", "").Replace("110000", "110000,");

                   
                    if (str.Contains("110000") == false)
                    {
                        subpackets.Add(packet);
                        return subpackets;
                    }

                    var strSplit = str.Replace("110000", "110000,").Split(',');

                    var packetHexDecrypted = Tools.Help.StringToByteArray(strSplit[0]);
                    var packetHexCrypted = buffer.Take(packetHexDecrypted.Length).ToArray();

                    subpackets.Add(packet);

                    buffer.RemoveRange(0, packetHexCrypted.Length);
                    if (buffer.Count == 0)
                        return subpackets;
                }
            }
            catch
            {
                return subpackets;
            }
        }
        #endregion
    }
}