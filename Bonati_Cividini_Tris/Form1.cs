using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Text.RegularExpressions;
using System.Net;
using System.Net.Sockets;

namespace Bonati_Cividini_Tris
{
    public partial class Form1 : Form
    {
        private UdpClient client2;
        IPAddress ipsender;
        public Form1()
        {
            InitializeComponent();
        }

        private void btn_start_Click(object sender, EventArgs e)
        {
            try
            {
                ipsender = IPAddress.Parse(tb_IP_ospite.Text);
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
                return;
            }
            client2 = new UdpClient();
            IPEndPoint ep = new IPEndPoint(ipsender, 12000);
            var hostname = Dns.GetHostName();
            string myIP = Dns.GetHostByName(hostname).AddressList[0].ToString();
            byte[] buf = Encoding.ASCII.GetBytes(myIP.ToString());
            client2.Send(buf, buf.Length, ep);
            Gioco nuovaPartita = new Gioco(false, ipsender);
            Visible = false;
            if (!nuovaPartita.IsDisposed)
                nuovaPartita.ShowDialog();
            Visible = true;
            client2.Close();
        }

        private void btn_host_Click(object sender, EventArgs e)
        {
            byte[] buffer;
            client2 = new UdpClient(12000);
            IPEndPoint ep = new IPEndPoint(IPAddress.Any, 0);
            do
            {
                buffer = client2.Receive(ref ep);
            } while (client2.Available < 0);
            var ipGiocatore2 = IPAddress.Parse(Encoding.ASCII.GetString(buffer));
            if (ipGiocatore2 != null)
            {
                Gioco nuovaPartita = new Gioco(true, ipGiocatore2);
                Visible = false;
                if (!nuovaPartita.IsDisposed)
                    nuovaPartita.ShowDialog();
                Visible = true;
            }
            client2.Close();
        }

    }
}
