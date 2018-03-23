using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Net;
using System.Net.Sockets;

namespace Client
{
    public partial class Form1 : Form
    {
        Socket client;
        EndPoint remote;
        public Form1()
        {
            InitializeComponent();
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            client = new Socket(AddressFamily.InterNetwork, SocketType.Dgram, ProtocolType.Udp);
            IPEndPoint ipe = new IPEndPoint(IPAddress.Parse("192.168.1.28"), 995);
            remote = (EndPoint)ipe;
        }

        private void button1_Click(object sender, EventArgs e)
        {
            textBox1.Text = "Kéo";
            byte[] sendData = Encoding.ASCII.GetBytes("0");

            client.SendTo(sendData, remote);
            byte[] receiveData = new byte[20];
            client.ReceiveFrom(receiveData, ref remote);
            int recv = Convert.ToInt32(Encoding.ASCII.GetString(receiveData));

            if (recv == 0)
                textBox2.Text = "Hòa";
            else if (recv == 1)
                textBox2.Text = "Thắng";
            else
                textBox2.Text = "Thua";
        }

        private void button2_Click(object sender, EventArgs e)
        {
            textBox1.Text = "Búa";
            byte[] sendData = Encoding.ASCII.GetBytes("2");

            client.SendTo(sendData, remote);
            byte[] receiveData = new byte[20];
            client.ReceiveFrom(receiveData, ref remote);
            int recv = Convert.ToInt32(Encoding.ASCII.GetString(receiveData));
 
            if (recv == 0)
                textBox2.Text = "Thắng";
            else if (recv == 1)
                textBox2.Text = "Thua";
            else
                textBox2.Text = "Hòa";
        }

        private void button3_Click(object sender, EventArgs e)
        {
            textBox1.Text = "Bao";
            byte[] sendData = Encoding.ASCII.GetBytes("1");

            client.SendTo(sendData, remote);
            byte[] receiveData = new byte[20];
            client.ReceiveFrom(receiveData, ref remote);
            int recv = Convert.ToInt32(Encoding.ASCII.GetString(receiveData));

            if (recv == 0)
                textBox2.Text = "Thua";
            else if (recv == 1)
                textBox2.Text = "Hòa";
            else
                textBox2.Text = "Thắng";
        }
    }
}
