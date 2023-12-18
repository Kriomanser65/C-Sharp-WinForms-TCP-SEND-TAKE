using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Net.Sockets;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace TCP1Protocol
{
    public partial class Form2 : Form
    {
        TcpClient client;
        NetworkStream stream;
        public Form2()
        {
            InitializeComponent();
        }

        private void Send_Click(object sender, EventArgs e)
        {
            client = new TcpClient(textBox1.Text, Int32.Parse(textBox2.Text));
            stream = client.GetStream();
            byte[] data = Encoding.UTF8.GetBytes(textBox3.Text);
            stream.Write(data, 0, data.Length);
            stream.Close();
            client.Close();
        }

        private void textBox1_TextChanged(object sender, EventArgs e)
        {

        }

        private void textBox2_TextChanged(object sender, EventArgs e)
        {

        }

        private void textBox3_TextChanged(object sender, EventArgs e)
        {

        }
    }
}
