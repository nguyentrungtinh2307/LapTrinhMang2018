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

namespace Client
{
    public partial class Form1 : Form
    {
        Socket client;
        IPEndPoint ipServer;
        public Form1()
        {
            InitializeComponent();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            ipServer = new IPEndPoint(IPAddress.Parse("192.168.1.25"), 1234);
            client = new Socket(AddressFamily.InterNetwork, SocketType.Stream, ProtocolType.Tcp);
            client.Connect(ipServer);
            textBox1.Text = (client.RemoteEndPoint).ToString();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            byte[] data = new byte[1024];
            data = Encoding.ASCII.GetBytes(textBox2.Text);
            listBox1.Items.Add("Client: " + textBox2.Text);
            textBox2.Text = "";
            client.Send(data);
            data = new byte[1024];
            client.Receive(data);
            string text = Encoding.ASCII.GetString(data);
            listBox1.Items.Add("Server: " + text);
        }
    }
}
