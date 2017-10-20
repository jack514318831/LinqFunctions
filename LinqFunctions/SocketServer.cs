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
        public List<Socket> ProxySocketList = new List<Socket>();
        private void btnServerStart_Click(object sender, EventArgs e)
        {
            //Create Socket
            Socket ServerSocket = new Socket(AddressFamily.InterNetwork, SocketType.Stream, ProtocolType.Tcp);

            //Bind Port
            ServerSocket.Bind(new IPEndPoint(IPAddress.Parse(tbIPAdrress.Text), int.Parse(tbPort.Text)));

            //Listen
            ServerSocket.Listen(10);

            // Accept Thread
            Thread AcceptThread = new Thread((obj) =>
            {
                AcceptClient(obj);
            });
            AcceptThread.IsBackground = true;
            AcceptThread.Start(ServerSocket);
        }

        private void AcceptClient(object obj)
        {
            Socket serverSocket = obj as Socket;
            while (true)
            {
                AcceptDone.Reset();
                serverSocket.BeginAccept(Accept, serverSocket);
                AcceptDone.WaitOne();
            }

        }

        private void Accept(IAsyncResult ar)
        {
            AcceptDone.Set();
            Socket server = ar.AsyncState as Socket;
            Socket ProxySocket = server.EndAccept(ar);
            ProxySocketList.Add(ProxySocket);
            SetInfoText(ProxySocket.RemoteEndPoint.ToString());

            byte[] data = new byte[1024];
            byte[] result = new byte[data.Length + 1];
            while (true)
            {
                Array.Clear(result, 0, result.Length);
                ProxySocket.Receive(result);
                if (result[0] == 1)
                {
                    Buffer.BlockCopy(result, 1, data, 0, data.Length);
                    SetInfoText(Encoding.Default.GetString(data));
                }
            }

        }

        private void SetInfoText(string info)
        {
            if (tbInfo.InvokeRequired)
            {
                tbInfo.Invoke(new Action<string>(s =>
                {
                    if (tbInfo.Text.Equals(string.Empty)) { tbInfo.Text = s; }
                    else {
                        StringBuilder sb = new StringBuilder();
                        sb.Append(tbInfo.Text);
                        sb.AppendLine().Append(s);
                        tbInfo.Text = sb.ToString();
                    }
                }), info);
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
