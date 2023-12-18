using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Net;
using System.Net.Sockets;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace TCP1Protocol
{
    public partial class Form1 : Form
    {
        TcpListener server;
        TcpClient client;
        NetworkStream stream;
        public Form1()
        {
            InitializeComponent();
        }

        private void Start_Click(object sender, EventArgs e)
        {
            int port = Int32.Parse(textBox2.Text);
            server = new TcpListener(IPAddress.Any, port);
            server.Start();
            client = server.AcceptTcpClient();
            stream = client.GetStream();
            Thread listenThread = new Thread(ListenForData);
            listenThread.Start();
        }
        private void ListenForData()
        {
            while (true)
            {
                byte[] data = new byte[1024];
                int bytesRead = stream.Read(data, 0, data.Length);
                string message = Encoding.UTF8.GetString(data, 0, bytesRead);
                if (message == "EXIT")
                {
                    Close();
                    break;
                }
                dataGridView1.Invoke((MethodInvoker)delegate {
                    dataGridView1.Rows.Add(message);
                });
            }
        }
        private void Close()
        {
            stream.Close();
            client.Close();
            server.Stop();
            this.Close();
        }

        private void textBox1_TextChanged(object sender, EventArgs e)
        {

        }

        private void textBox2_TextChanged(object sender, EventArgs e)
        {

        }

        private void dataGridView1_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }
    }
}
