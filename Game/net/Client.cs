using System;
using System.IO;
using System.Net.Sockets;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Game
{
    public partial class Client : Form
    {
        public Client()
        {
            InitializeComponent();
        }


        TcpClient client;
        NetworkStream stream;
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
                        txtChat.AppendText("Сервер закрыл соединение.\r\n");
                        break;
                    }

                    string message = Encoding.UTF8.GetString(buffer, 0, bytes);

                    txtChat.AppendText($"Сервер: {message}\r\n");
                }
            }
            catch (OperationCanceledException)
            {
                // При Disconnect это нормальное поведение
            }
            catch (IOException)
            {
                if (client != null)
                {
                    txtChat.AppendText("Соединение с сервером потеряно.\r\n");
                }
            }
            catch (SocketException ex)
            {
                txtChat.AppendText($"Ошибка соединения: {ex.Message}\r\n");
            }
            catch (ObjectDisposedException)
            {
                // Stream был закрыт при Disconnect
            }
            finally
            {
                if (client != null && !client.Connected)
                {
                    stream = null;
                    client = null;
                }
            }
        }


        private async void connect_Click(object sender, EventArgs e)
        {
            try
            {
                int port = Convert.ToInt32(txtPortConnect.Text);
                string server = txtHostConnect.Text;

                client = new TcpClient();

                txtChat.AppendText("Подключение к серверу...\r\n");
                await client.ConnectAsync(server, port);

                stream = client.GetStream();
                receiveCts = new CancellationTokenSource();
                txtChat.AppendText("Подключено к серверу!\r\n");

                _ = ReceiveMessagesAsync();
            }
            catch (SocketException ex)
            {
                txtChat.AppendText($"Ошибка подключения: {ex.Message}\r\n");

                client?.Dispose();
                client = null;
                stream = null;
            }
            catch (Exception ex)
            {
                txtChat.AppendText($"Ошибка: {ex.Message}\r\n");

                client?.Dispose();
                client = null;
                stream = null;
            }

        }


        private void btnDisconnect_Click(object sender, EventArgs e)
        {
            try
            {
                if (client == null)
                {
                    txtChat.AppendText("Клиент не подключён.\r\n");
                    return;
                }

                stream?.Close();
                client.Close();

                stream = null;
                client = null;

                txtChat.AppendText("Соединение закрыто.\r\n");
            }
            catch (Exception ex)
            {
                txtChat.AppendText($"Ошибка при отключении: {ex.Message}\r\n");
            }
        }

        private async void btnSend_Click(object sender, EventArgs e)
        {
            try
            {
                if (client == null || stream == null)
                {
                    txtChat.AppendText("Вы не подключены к серверу.\r\n");
                    return;
                }

                string message = txtMessage.Text;

                if (string.IsNullOrWhiteSpace(message))
                {
                    return;
                }

                byte[] data = Encoding.UTF8.GetBytes(message);

                await stream.WriteAsync(data, 0, data.Length);

                txtChat.AppendText("Вы: " + message + "\r\n");

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
    }
}
