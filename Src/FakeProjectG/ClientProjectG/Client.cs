using FakeProjectG.Config;
using FakeProjectG.Defines;
using FakeProjectG.BinaryModels;
using System;
using System.Configuration;
using System.IO;
using System.Net.Sockets;
using FakeProjectG.Tools;
using FakeProjectG.ClientProjectG.Data;
using FakeProjectG.Packet;
using FakeProjectG.ServerClient;

namespace FakeProjectG.ClientProjectG
{
    public abstract partial class PClient
    {
        #region Public Fields

        /// <summary>
        /// Cliente está conectado
        /// </summary>
        public bool Connected { get; set; }

        /// <summary>
        /// Conexão do cliente
        /// </summary>
        public TcpClient Tcp { get; set; }

        public PangyaBinaryWriter Response { get; set; }
        /// <summary>
        /// Identificador da conexão
        /// </summary>
        public uint ConnectionID { get; set; }
        public UInt32 GetUID { get; set; }

        public byte KeyLogin { get; set; }
        public byte KeyGame { get; set; }
        public byte GetKey { get; set; }
        public byte GetFirstLogin { get; set; }
        public string GetLogin { get; set; } = string.Empty;
        public string GetPass { get; }
        public string GetNickname { get; set; } = string.Empty;
        public byte GetSex { get; set; }
        public byte GetCapability { get; set; } = 0;
        public byte GetLevel { get; set; } = 0;
        public string GetAuth1 { get; set; } = String.Empty;
        public string GetAuth2 { get; set; } = String.Empty;

        public LoginSettings Login { get; set; }
        public GameSettings Game { get; set; }

        public ServerTypeEnum ServerType { get; set; }
        public PlayerInfo Info { get; set; }
        public abstract void HandleTypeClient(ClientPacket packet);

        public TCPClient Conn { get; set; }
        #endregion
        public PClient(TcpClient tcp)
        {
            KeyGame = 255;
            KeyLogin = 255;
            Tcp = tcp;
            Response = new PangyaBinaryWriter(new MemoryStream());
            Info = new PlayerInfo();
            try
            {
                var Ini = new IniFile(ConfigurationManager.AppSettings["Config"]);
                Login = new LoginSettings(Ini);
                Game = new GameSettings(Ini);

                GetLogin = Login.User;
                GetPass = Login.PassWord;

            }
            catch
            {
            }
            Connected = true;
        }

        public void Disconnect()
        {
            Conn.OnDisconnectBot(this);
        }
    }
}
