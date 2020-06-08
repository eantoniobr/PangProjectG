using PangProjectG.Client;
using System;
using System.Windows.Forms;

namespace PangProjectG.CommandForm
{
    public partial class ChatCommands : Form
    {
        public string OldChat { get; set; }
        public ProjectG player { get; set; }
        public ChatCommands()
        {
            this.InitializeComponent();
            textBox1.Text = "player Name";
            textBox2.Text = "player Nick Name";
            textBox3.Text = "player UID";
        }

        public void SetText()
        {
            textBox1.Text = player.GetLogin;
            textBox2.Text = player.GetNickname;
            textBox3.Text = player.GetUID.ToString();
        }

        public void SetPlayer(ProjectG projectG)
        {
            player = projectG;

            if (player != null)
            {
                SetText();
            }
        }
        private void Btn_SendCommands(object sender, EventArgs e)
        {
            CommandAcess(BoxChatCommand.Text);
            BoxChatCommand.Clear();
        }

        public void CommandAcess(string command)
        {
            this.Visible = true;

            if (StrCompare(command, "/visual_mode"))
            {
                this.Hide();
            }
            if (StrCompare(command, "/showcommands"))
            {
                ShowConsoleHelp();
            }
            if (StrCompare(command, "/chat"))
            {
                var chat = command.Replace("/chat ", "");


                var Chat = DateTime.Now.ToString() + $" : SEND: {player.GetNickname}  CHAT: {chat} ";

                var count = listView1.Items.Count;

                var item = new ListViewItem(Chat)
                {
                    Tag = +count
                };
                listView1.Items.Add(item);

               player.HandleSendClientChat(chat);
            }
            if (StrCompare(command, "/lobbyinfo"))
            {
              //  player.HandleSendClientLobbyInfo();
            }
            if (StrCompare(command, "/disconnect"))
            {
                Console.WriteLine("Boot Await Close !");
            }
            if (StrCompare(command, "/createrom"))
            {
                Console.WriteLine("Room Fix !");
               // player.HandleSendClientCreateRoom();
            }
            if (StrCompare(command, "/leavelobby"))
            {
                //player.HandleSendLeaveLobbyList();
            }
            if (StrCompare(command, "/enterlobby"))
            {
              ///  player.HandleSendEnterLobbyList();
            }
        }

        public static bool StrCompare(string a, string b)
        {
            var result = a.Contains(b);
            return result;
        }

        public void ChatData(string _RecvNick, string _RecvChat)
        {
            var Chat = DateTime.Now.ToString() + $" : RECV: {_RecvNick}  CHAT: {_RecvChat} ";

            var count = listView1.Items.Count;

            var item = new ListViewItem(Chat)
            {
                Tag = +count
            };
            listView1.Items.Add(item);
        }
        public void ShowConsoleHelp()
        {
            Console.WriteLine(Environment.NewLine);
            Console.WriteLine("Bem vindo(a) ao Boot-Server!" + Environment.NewLine);

            Console.WriteLine("Veja os comandos disponíveis do console:" + Environment.NewLine);

            Console.WriteLine("/command     | exibe os comandos do console");
            Console.WriteLine("/chat        | envia mensagem  no lobbyList-Game");
            Console.WriteLine("/disconnect  | Disconecta boot do servidor");

            Console.WriteLine("/leavelobby  | realiza um pedido para sair do lobbylist ");

            Console.WriteLine(Environment.NewLine);
        }
    }
}
