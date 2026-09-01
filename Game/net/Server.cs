using System;
using System.IO;
using System.Net;
using System.Net.Sockets;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Game
{
    public partial class Server : Form
    {
        public Server()
        {
            InitializeComponent();
        }


        private TcpListener server;
        private TcpClient client;
        private NetworkStream stream;
        private CancellationTokenSource receiveCts;


        private async Task ReceiveMessagesAsync()
        {
            if (stream == null)
                return;

            byte[] buffer = new byte[1024];

            try
            {
                while (client != null && client.Connected)
                {
                    int bytes = await stream.ReadAsync(
                        buffer,
                        0,
                        buffer.Length,
                        receiveCts.Token
                    );

                    if (bytes == 0)
                    {
                        txtChat.AppendText("Клиент отключился.\r\n");
                        break;
                    }

                    string message = Encoding.UTF8.GetString(
                        buffer,
                        0,
                        bytes
                    );

                    txtChat.AppendText("Клиент: " + message + "\r\n");
                }
            }
            catch (OperationCanceledException)
            {
            }
            catch (ObjectDisposedException)
            {
            }
            catch (IOException)
            {
                txtChat.AppendText("Соединение с клиентом потеряно.\r\n");
            }
        }


        private async void startServer_Click(object sender, EventArgs e)
        {
            try
            {
                int port = Convert.ToInt32(txtPortCreate.Text);
                IPAddress localAddr = IPAddress.Parse(txtHostCreate.Text);

                server = new TcpListener(localAddr, port);
                server.Start();

                txtChat.AppendText("Сервер запущен.\r\n");

                while (server != null)
                {
                    txtChat.AppendText("Ожидание подключения...\r\n");
                    client = await server.AcceptTcpClientAsync();

                    txtChat.AppendText("Клиент подключился!\r\n");
                    stream = client.GetStream();

                    receiveCts = new CancellationTokenSource();
                    _ = ReceiveMessagesAsync();
                }
            }
            catch (ObjectDisposedException)
            {
                txtChat.AppendText("Сервер остановлен.\r\n");
            }
            catch (SocketException ex)
            {
                txtChat.AppendText("Ошибка: " + ex.Message + "\r\n");
            }
        }


        private void stopServer_Click(object sender, EventArgs e)
        {
            if (server == null)
            {
                txtChat.AppendText("Сервер не запущен.\r\n");
                return;
            }

            server.Stop();
            server = null;

            txtChat.AppendText("Сервер отключён.\r\n");
        }


        private async void sendMessage_Click(object sender, EventArgs e)
        {
            try
            {
                if (client == null || stream == null)
                {
                    txtChat.AppendText("Клиент не подключён.\r\n");
                    return;
                }

                string message = txtMessage.Text;
                if (string.IsNullOrWhiteSpace(message))
                {
                    return;
                }

                byte[] data = Encoding.UTF8.GetBytes(message);
                await stream.WriteAsync(data, 0, data.Length);
                txtChat.AppendText("Сервер: " + message + "\r\n");
                txtMessage.Clear();
            }
            catch (Exception ex)
            {
                txtChat.AppendText("Ошибка отправки: " + ex.Message + "\r\n");
            }
        }


        private void exit_Click(object sender, EventArgs e)
        {
            Hide();
        }

        private void txtPortCreate_TextChanged(object sender, EventArgs e)
        {

        }

        private void label1_Click(object sender, EventArgs e)
        {

        }

        private void txtMessage_TextChanged(object sender, EventArgs e)
        {

        }
    }
}
