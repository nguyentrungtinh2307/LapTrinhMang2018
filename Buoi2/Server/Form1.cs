using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Net;
using System.Net.Sockets;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Server
{
    public partial class Form1 : Form
    {
        Socket server;
        Socket client;
        IPEndPoint ipServer;
        public Form1()
        {
            InitializeComponent();
        }
        private void Form1_Load(object sender, EventArgs e)
        {
            server = new Socket(AddressFamily.InterNetwork, SocketType.Stream, ProtocolType.Tcp);
            ipServer = new IPEndPoint(IPAddress.Any, 1234);
            server.Bind(ipServer);
            server.Listen(5);
            client = server.Accept();
            textBox1.Text = (client.RemoteEndPoint).ToString();
            byte[] data = new byte[1024];
            client.Receive(data);
            listBox1.Items.Add("Client: " + Encoding.ASCII.GetString(data));
        }

        private void button1_Click(object sender, EventArgs e)
        {
            string text = textBox2.Text;
            listBox1.Items.Add("Server: " + text);
            textBox2.Text = "";
            byte[] data = new byte[1024];
            data = Encoding.ASCII.GetBytes(text);
            client.Send(data);
            data = new byte[1024];
            client.Receive(data);
            listBox1.Items.Add("Client: " + Encoding.ASCII.GetString(data));

        }
    }
}
