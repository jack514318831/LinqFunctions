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
    public partial class ClientForm : Form
    {
        public ClientForm()
        {
            InitializeComponent();
        }

        public Socket ClientSocket;
        private void btnConnet_Click(object sender, EventArgs e)
        {
            //Create Socket
            ClientSocket = new Socket(AddressFamily.InterNetwork, SocketType.Stream, ProtocolType.Tcp);

            //Connect
            ClientSocket.Connect(new IPEndPoint(IPAddress.Parse(tbIPAdrress.Text), int.Parse(tbPort.Text)));

        }

        byte[] data = new byte[1024];
        byte[] result = new byte[1025];
        private void btnSendMessage_Click(object sender, EventArgs e)
        {
            result[0] = 1;
            Array.Clear(data, 0, data.Length);
            data = Encoding.Default.GetBytes(tbMessage.Text);
            Buffer.BlockCopy(data, 0, result, 1, data.Length);
            ClientSocket.Send(result);
        }

        private void btnSendFile_Click(object sender, EventArgs e)
        {
           
        }

        private void ClientForm_FormClosing(object sender, FormClosingEventArgs e)
        {

        }
    }
}
