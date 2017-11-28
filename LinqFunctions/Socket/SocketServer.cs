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


namespace LinqFunctions
{
    public partial class SocketServer : Form
    {
        public SocketServer()
        {
            InitializeComponent();
        }

        public ManualResetEvent AcceptDone = new ManualResetEvent(false);
        List<Socket> ProxySocketList = new List<Socket>();
        private void btnServerStart_Click(object sender, EventArgs e)
        {
            //Create Socket
            Socket serverSocket = new Socket(AddressFamily.InterNetwork, SocketType.Stream, ProtocolType.Tcp);

            //Port Bind
            serverSocket.Bind(new IPEndPoint(IPAddress.Parse(tbIPAdrress.Text), int.Parse(tbPort.Text)));

            //Listen
            serverSocket.Listen(10);

            //Accept
            Thread AcceptThread = new Thread((obj) =>
            {
                AcceptClient(obj);
            });
            AcceptThread.IsBackground = true;
            AcceptThread.Start(serverSocket);
          
        }

        private void AcceptClient(object obj)
        {
            Socket serverSocket = (Socket)obj;
            while (true)
            {
                AcceptDone.Reset();
                serverSocket.BeginAccept(Accept, serverSocket);
                AcceptDone.WaitOne();
            }
        }

        private void Accept(IAsyncResult asy)
        {
            AcceptDone.Set();
            Socket ServerSocket = asy.AsyncState as Socket;
            Socket ProxySocket = ServerSocket.EndAccept(asy);
            ProxySocketList.Add(ProxySocket);
            SetInfoText(ProxySocket.RemoteEndPoint.ToString());

            byte[] data = new byte[1024];
            byte[] result = new byte[1025];
            while(true)
            {
                Array.Clear(result, 0, result.Length);
                Array.Clear(data, 0, data.Length);
                ProxySocket.Receive(result);
                if (result[0] != 1) return;
                Buffer.BlockCopy(result, 1, data, 0, data.Length);
                SetInfoText(Encoding.Default.GetString(data));
            }
        }

        private void SetInfoText(string info)
        {
            StringBuilder sb = new StringBuilder();
            if (tbInfo.InvokeRequired)
            {
                tbInfo.Invoke(new Action(() =>
                {
                   tbInfo.Text= sb.Append(tbInfo.Text).AppendLine(info).ToString();
                }));
            }
        }

        private void btnSendMessage_Click(object sender, EventArgs e)
        {
            
        }

        private void btnCreateClient_Click(object sender, EventArgs e)
        {
            ClientForm cf = new ClientForm();
            cf.Show();
        }

    }
}
