using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Net.Sockets;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace SocketClient
{
    public partial class SocketClientForm : Form
    {
        private TcpListener TcpServer { get; set; }
        private TcpClient TcpClient { get; set; }
        private StreamReader StreamReader { get; set; }
        private StreamWriter StreamWriter { get; set; }
        private NetworkStream NetworkStream { get; set; }
        private Thread ReceiveThread { get; set; }
        private bool IsConnected { get; set; }

        private delegate void AddTextDelegate(string strText);

        public SocketClientForm()
        {
            InitializeComponent();
        }

        private void SocketClientForm_Load(object sender, EventArgs e)
        {
            string IP = "127.0.0.1";
            int port = 8081;
            TcpClient = new TcpClient();
            TcpClient.Connect(IP, port);

            IsConnected = true;
            textBox1.AppendText("Connected Server!! \r\n");

            NetworkStream = TcpClient.GetStream();
            StreamReader = new StreamReader(NetworkStream);
            StreamWriter = new StreamWriter(NetworkStream);

            ReceiveThread = new Thread(() => Receive());
            ReceiveThread.Start();
        }

        private void SocketClientForm_FormClosing(object sender, FormClosingEventArgs e)
        {
            IsConnected = false;
            StreamReader?.Dispose();
            StreamWriter?.Dispose();
            NetworkStream?.Dispose();
            TcpServer?.Stop();
            TcpClient?.Close();
            ReceiveThread?.Abort();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            if (!IsConnected)
                return;

            textBox1.AppendText($"Me : {textBox2.Text} \r\n");

            StreamWriter.WriteLine(textBox2.Text); // 보내버리기
            StreamWriter.Flush();

            textBox2.Clear();
        }

        private void Receive()
        {
            AddTextDelegate addText = new AddTextDelegate(textBox1.AppendText);

            while (IsConnected)
            {
                Thread.Sleep(10);
                if (NetworkStream.CanRead)
                {
                    string tempStr = StreamReader.ReadLine();
                    if (!string.IsNullOrEmpty(tempStr))
                        Invoke(addText, $"You : {tempStr} \r\n");
                }
            }
        }
    }
}
