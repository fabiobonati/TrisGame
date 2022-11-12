using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using System.Net.Sockets;
using System.Net;

namespace Bonati_Cividini_Tris
{
    public partial class Gioco : Form
    {
        IPAddress ip;
        int porta;
        private UdpClient client;
        private UdpClient server = null;
        public Gioco(bool isHost, IPAddress ip = null)
        {
            this.ip = ip; 
            InitializeComponent();
            MessageReceiver.DoWork += MessageReceiver_DoWork;
            CheckForIllegalCrossThreadCalls = false;

            if (isHost)
            {
                Giocatore = 'X';
                Avversario = 'O';
                server = new UdpClient(10000);
                porta = 11000;
            }
            else
            {
                Giocatore = 'O';
                Avversario = 'X';
                porta = 10000;
                try
                {
                    client = new UdpClient(11000);
                    MessageReceiver.RunWorkerAsync();
                }
                catch (Exception ex)
                {
                    MessageBox.Show(ex.Message);
                    Close();
                }
            }
        }

        private void MessageReceiver_DoWork(object sender, DoWorkEventArgs e)
        {
            if (CheckState())
                return;
            FreezeBoard();
            label1.Text = "Opponent's Turn!";
            ReceiveMove();
            label1.Text = "Your Trun!";
            if (!CheckState())
                UnfreezeBoard();
            this.Refresh();
        }

        private char Giocatore;
        private char Avversario;
        private BackgroundWorker MessageReceiver = new BackgroundWorker();

        private bool CheckState()
        {
            //Horizontals
            if (button1.Text == button2.Text && button2.Text == button3.Text && button3.Text != "")
            {
                if (button1.Text[0] == Giocatore)
                {
                    label1.Text = "You Won!";
                    if (Giocatore == 'X')
                        server.Close();
                    if (Giocatore == 'O')
                        client.Close();
                    MessageBox.Show("You Won!");
                }
                else
                {
                    label1.Text = "You Lost!";
                    if (Giocatore == 'X')
                        server.Close();
                    if (Giocatore == 'O')
                        client.Close();
                    MessageBox.Show("You Lost!");
                }
                return true;
            }

            else if (button4.Text == button5.Text && button5.Text == button6.Text && button6.Text != "")
            {
                if (button4.Text[0] == Giocatore)
                {
                    label1.Text = "You Won!";
                    if (Giocatore == 'X')
                        server.Close();
                    if (Giocatore == 'O')
                        client.Close();
                    MessageBox.Show("You Won!");
                }
                else
                {
                    label1.Text = "You Lost!";
                    if (Giocatore == 'X')
                        server.Close();
                    if (Giocatore == 'O')
                        client.Close();
                    MessageBox.Show("You Lost!");
                }
                return true;
            }

            else if (button7.Text == button8.Text && button8.Text == button9.Text && button9.Text != "")
            {
                if (button7.Text[0] == Giocatore)
                {
                    label1.Text = "You Won!";
                    if (Giocatore == 'X')
                        server.Close();
                    if (Giocatore == 'O')
                        client.Close();
                    MessageBox.Show("You Won!");
                }
                else
                {
                    label1.Text = "You Lost!";
                    if (Giocatore == 'X')
                        server.Close();
                    if (Giocatore == 'O')
                        client.Close();
                    MessageBox.Show("You Lost!");
                }
                return true;
            }

            //Verticals
            else if (button1.Text == button4.Text && button4.Text == button7.Text && button7.Text != "")
            {
                if (button1.Text[0] == Giocatore)
                {
                    label1.Text = "You Won!";
                    if (Giocatore == 'X')
                        server.Close();
                    if (Giocatore == 'O')
                        client.Close();
                    MessageBox.Show("You Won!");
                }
                else
                {
                    label1.Text = "You Lost!";
                    if (Giocatore == 'X')
                        server.Close();
                    if (Giocatore == 'O')
                        client.Close();
                    MessageBox.Show("You Lost!");
                }
                return true;
            }

            else if (button2.Text == button5.Text && button5.Text == button8.Text && button8.Text != "")
            {
                if (button2.Text[0] == Giocatore)
                {
                    label1.Text = "You Won!";
                    if (Giocatore == 'X')
                        server.Close();
                    if (Giocatore == 'O')
                        client.Close();
                    MessageBox.Show("You Won!");
                }
                else
                {
                    label1.Text = "You Lost!";
                    if (Giocatore == 'X')
                        server.Close();
                    if (Giocatore == 'O')
                        client.Close();
                    MessageBox.Show("You Lost!");
                }
                return true;
            }

            else if (button3.Text == button6.Text && button6.Text == button9.Text && button9.Text != "")
            {
                if (button3.Text[0] == Giocatore)
                {
                    label1.Text = "You Won!";
                    if (Giocatore == 'X')
                        server.Close();
                    if (Giocatore == 'O')
                        client.Close();
                    MessageBox.Show("You Won!");
                }
                else
                {
                    label1.Text = "You Lost!";
                    if (Giocatore == 'X')
                        server.Close();
                    if (Giocatore == 'O')
                        client.Close();
                    MessageBox.Show("You Lost!");
                }
                return true;
            }

            else if (button1.Text == button5.Text && button5.Text == button9.Text && button9.Text != "")
            {
                if (button1.Text[0] == Giocatore)
                {
                    label1.Text = "You Won!";
                    if (Giocatore == 'X')
                        server.Close();
                    if (Giocatore == 'O')
                        client.Close();
                    MessageBox.Show("You Won!");
                }
                else
                {
                    label1.Text = "You Lost!";
                    if (Giocatore == 'X')
                        server.Close();
                    if (Giocatore == 'O')
                        client.Close();
                    MessageBox.Show("You Lost!");
                }
                return true;
            }

            else if (button3.Text == button5.Text && button5.Text == button7.Text && button7.Text != "")
            {
                if (button3.Text[0] == Giocatore)
                {
                    label1.Text = "You Won!";
                    if (Giocatore == 'X')
                        server.Close();
                    if (Giocatore == 'O')
                        client.Close();
                    MessageBox.Show("You Won!");
                }
                else
                {
                    label1.Text = "You Lost!";
                    if (Giocatore == 'X')
                        server.Close();
                    if (Giocatore == 'O')
                        client.Close();
                    MessageBox.Show("You Lost!");
                }
                return true;
            }

            //Draw
            else if (button1.Text != "" && button2.Text != "" && button3.Text != "" && button4.Text != "" && button5.Text != "" && button6.Text != "" && button7.Text != "" && button8.Text != "" && button9.Text != "")
            {
                label1.Text = "It's a draw!";
                if (Giocatore == 'X')
                    server.Close();
                if (Giocatore == 'O')
                    client.Close();
                MessageBox.Show("It's a draw!");
                return true;
            }
            return false;
        }
        private void FreezeBoard()
        {
            button1.Enabled = false;
            button2.Enabled = false;
            button3.Enabled = false;
            button4.Enabled = false;
            button5.Enabled = false;
            button6.Enabled = false;
            button7.Enabled = false;
            button8.Enabled = false;
            button9.Enabled = false;
        }

        private void UnfreezeBoard()
        {
            if (button1.Text == "")
                button1.Enabled = true;
            if (button2.Text == "")
                button2.Enabled = true;
            if (button3.Text == "")
                button3.Enabled = true;
            if (button4.Text == "")
                button4.Enabled = true;
            if (button5.Text == "")
                button5.Enabled = true;
            if (button6.Text == "")
                button6.Enabled = true;
            if (button7.Text == "")
                button7.Enabled = true;
            if (button8.Text == "")
                button8.Enabled = true;
            if (button9.Text == "")
                button9.Enabled = true;
        }

        private void ReceiveMove()
        {
            IPEndPoint ep = new IPEndPoint(IPAddress.Any, Giocatore == 'X' ? 10000 : 11000);
            byte[] buffer = new byte[1];
            buffer = Giocatore == 'X' ? server.Receive(ref ep) : client.Receive(ref ep);
            if (buffer[0] == 1)
                button1.Text = Avversario.ToString();
            if (buffer[0] == 2)
                button2.Text = Avversario.ToString();
            if (buffer[0] == 3)
                button3.Text = Avversario.ToString();
            if (buffer[0] == 4)
                button4.Text = Avversario.ToString();
            if (buffer[0] == 5)
                button5.Text = Avversario.ToString();
            if (buffer[0] == 6)
                button6.Text = Avversario.ToString();
            if (buffer[0] == 7)
                button7.Text = Avversario.ToString();
            if (buffer[0] == 8)
                button8.Text = Avversario.ToString();
            if (buffer[0] == 9)
                button9.Text = Avversario.ToString();

        }

        private void button1_Click(object sender, EventArgs e)
        {
            IPEndPoint ep = new IPEndPoint(ip, porta);
            byte[] num = { 1 };
            if(Giocatore == 'X')
            {
                server.Send(num, num.Length, ep);
            }
            else if(Giocatore == 'O')
            {
                client.Send(num, num.Length, ep);
            }
            button1.Text = Giocatore.ToString();
            MessageReceiver.RunWorkerAsync();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            IPEndPoint ep = new IPEndPoint(ip, porta);
            byte[] num = { 2 };
            if (Giocatore == 'X')
            {
                server.Send(num, num.Length, ep);
            }
            else if (Giocatore == 'O')
            {
                client.Send(num, num.Length, ep);
            }
            button2.Text = Giocatore.ToString();
            MessageReceiver.RunWorkerAsync();
        }

        private void button3_Click(object sender, EventArgs e)
        {
            IPEndPoint ep = new IPEndPoint(ip, porta);
            byte[] num = { 3 };
            if (Giocatore == 'X')
            {
                server.Send(num, num.Length, ep);
            }
            else if (Giocatore == 'O')
            {
                client.Send(num, num.Length, ep);
            }
            button3.Text = Giocatore.ToString();
            MessageReceiver.RunWorkerAsync();
        }

        private void button4_Click(object sender, EventArgs e)
        {
            IPEndPoint ep = new IPEndPoint(ip, porta);
            byte[] num = { 4 };
            if (Giocatore == 'X')
            {
                server.Send(num, num.Length, ep);
            }
            else if (Giocatore == 'O')
            {
                client.Send(num, num.Length, ep);
            }
            button4.Text = Giocatore.ToString();
            MessageReceiver.RunWorkerAsync();
        }

        private void button5_Click(object sender, EventArgs e)
        {
            IPEndPoint ep = new IPEndPoint(ip, porta);
            byte[] num = { 5 };
            if (Giocatore == 'X')
            {
                server.Send(num, num.Length, ep);
            }
            else if (Giocatore == 'O')
            {
                client.Send(num, num.Length, ep);
            }
            button5.Text = Giocatore.ToString();
            MessageReceiver.RunWorkerAsync();
        }

        private void button6_Click(object sender, EventArgs e)
        {
            IPEndPoint ep = new IPEndPoint(ip, porta);
            byte[] num = { 6 };
            if (Giocatore == 'X')
            {
                server.Send(num, num.Length, ep);
            }
            else if (Giocatore == 'O')
            {
                client.Send(num, num.Length, ep);
            }
            button6.Text = Giocatore.ToString();
            MessageReceiver.RunWorkerAsync();
        }

        private void button7_Click(object sender, EventArgs e)
        {
            IPEndPoint ep = new IPEndPoint(ip, porta);
            byte[] num = { 7 };
            if (Giocatore == 'X')
            {
                server.Send(num, num.Length, ep);
            }
            else if (Giocatore == 'O')
            {
                client.Send(num, num.Length, ep);
            }
            button7.Text = Giocatore.ToString();
            MessageReceiver.RunWorkerAsync();
        }

        private void button8_Click(object sender, EventArgs e)
        {
            IPEndPoint ep = new IPEndPoint(ip, porta);
            byte[] num = { 8 };
            if (Giocatore == 'X')
            {
                server.Send(num, num.Length, ep);
            }
            else if (Giocatore == 'O')
            {
                client.Send(num, num.Length, ep);
            }
            button8.Text = Giocatore.ToString();
            MessageReceiver.RunWorkerAsync();
        }

        private void button9_Click(object sender, EventArgs e)
        {
            IPEndPoint ep = new IPEndPoint(ip, porta);
            byte[] num = { 9 };
            if (Giocatore == 'X')
            {
                server.Send(num, num.Length, ep);
            }
            else if (Giocatore == 'O')
            {
                client.Send(num, num.Length, ep);
            }
            button9.Text = Giocatore.ToString();
            MessageReceiver.RunWorkerAsync();
        }
    }
}
