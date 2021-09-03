using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Net;
using System.Net.Sockets;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace SocketServer
{
    // 참고 : https://yeolco.tistory.com/31?category=757612
    public partial class SocketServerForm : Form
    {
        private TcpListener TcpServer { get; set; }
        private TcpClient TcpClient { get; set; }
        private StreamReader StreamReader { get; set; }
        private StreamWriter StreamWriter { get; set; }
        private NetworkStream NetworkStream { get; set; }
        private Thread ReceiveThread { get; set; }
        private bool IsConnected { get; set; }

        private delegate void AddTextDelegate(string strText);

        public SocketServerForm()
        {
            InitializeComponent();
        }

        private void SocketServerForm_Load(object sender, EventArgs e)
        {
            Thread listenThread = new Thread(() => Listen());
            listenThread.Start();
        }

        private void Listen()
        {
            AddTextDelegate addText = new AddTextDelegate(textBox1.AppendText);

            IPAddress addr = IPAddress.Loopback; // new IPAddress(0);
            // IPAddress.Loopback
            int port = 8081;

            TcpServer = new TcpListener(addr, port);
            TcpServer.Start();
            Invoke(addText, "Server Start!!\r\n");

            TcpClient = TcpServer.AcceptTcpClient();            

            IsConnected = true;
            Invoke(addText, "Connected Client!!\r\n");

            NetworkStream = TcpClient.GetStream();
            StreamReader = new StreamReader(NetworkStream);
            StreamWriter = new StreamWriter(NetworkStream);

            ReceiveThread = new Thread(() => Receive());
            ReceiveThread.Start();
        }

        private void Receive()
        {
            AddTextDelegate addText = new AddTextDelegate(textBox1.AppendText);

            while(IsConnected)
            {
                Thread.Sleep(10);
                if (NetworkStream.CanRead)
                {
                    string tempStr = StreamReader.ReadLine();

                    if (tempStr is null)
                    {
                        Invoke(addText, $"DisConneted Client!! \r\n");
                        IsConnected = false; 
                        break;
                    }

                    if (!string.IsNullOrEmpty(tempStr))
                        Invoke(addText, $"You : {tempStr} \r\n");
                }
            }
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

        private void SocketServerForm_FormClosing(object sender, FormClosingEventArgs e)
        {
            IsConnected = false;
            StreamReader?.Dispose();
            StreamWriter?.Dispose();
            NetworkStream?.Dispose();
            TcpServer?.Stop();
            TcpClient?.Close();
            ReceiveThread?.Abort();
        }
    }
}
