using SimpleTCP;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Game
{
    public partial class Server : Form
    {
        SimpleTcpServer server;


        public Server()
        {
            InitializeComponent();
            //server = new SimpleTcpServer();
            //server.Delimiter = 0x13;
            //server.StringEncoder = Encoding.UTF8;
            //server.DataReceived += Server_DataReceived;

            //client = new SimpleTcpClient();
            //client.StringEncoder = Encoding.UTF8;
            //client.DataReceived += Client_DataReceived;
        }



        private void Server_DataReceived(object sender, SimpleTCP.Message e)
        {
            chat.Invoke((MethodInvoker)delegate ()
            {
                chat.Text += e.MessageString;
                e.ReplyLine(string.Format($"Server: {e.MessageString}"));
            });
        }


        private void startServer_Click(object sender, EventArgs e)
        {
            server = new SimpleTcpServer();
            server.Delimiter = 0x13;
            server.StringEncoder = Encoding.UTF8;
            server.DataReceived += Server_DataReceived;

            chat.Text += "Server starting...";
            System.Net.IPAddress ip = System.Net.IPAddress.Parse(txtHostCreate.Text);
            server.Start(ip, Convert.ToInt32(txtPortCreate.Text));
        }


        private void stopServer_Click(object sender, EventArgs e)
        {
            if(server.IsStarted)
            {
                server.Stop();
                chat.Text += "Server stoping...";
            }
        }

        //

        SimpleTcpClient client;


        private void connectServer_Click(object sender, EventArgs e)
        {
            client = new SimpleTcpClient();
            client.StringEncoder = Encoding.UTF8;
            client.DataReceived += Client_DataReceived;
            btnConnect.Enabled = false;
            //System.Net.IPAddress ip = System.Net.IPAddress.Parse(txtHostConnect.Text);
            client.Connect(txtHostConnect.Text, Convert.ToInt32(txtPortConnect.Text));
        }

        private void Client_DataReceived(object sender, SimpleTCP.Message e)
        {
            chat.Invoke((MethodInvoker)delegate ()
            {
                chat.Text += e.MessageString;
                e.ReplyLine(string.Format($"Client: {e.MessageString}"));
            });
        }

        private void sendMessage_Click(object sender, EventArgs e)
        {
            if (client != null)
            {
                chat.Text += txtMessage.Text;
                client.WriteLineAndGetReply(txtMessage.Text, TimeSpan.FromSeconds(3));
            }
            else
            {
                chat.Text += txtMessage.Text;
            }
        }




        private void exit_Click(object sender, EventArgs e)
        {
            Hide();
        }

        private void btnDisconnect_Click(object sender, EventArgs e)
        {
            btnConnect.Enabled = true;
            client.Disconnect();
        }
    }
}
