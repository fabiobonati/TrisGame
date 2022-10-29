using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Net;
using System.Net.Sockets;

namespace Bonati_Cividini_Tris
{
    public partial class Gioco : Form
    {
        private BackgroundWorker MessageReceiver = new BackgroundWorker();
        private char Giocatore;
        private char Avversario;
        IPEndPoint epHost = new IPEndPoint(IPAddress.Parse(Form1.ipOspite), 0);//il server accetta dall'ip dell'ospite e da qualsiasi porta
        private UdpClient client;
        private UdpClient server = null;
        public Gioco(bool isHost, string ip = null)
        {
            InitializeComponent();
            CheckForIllegalCrossThreadCalls = false;
            MessageReceiver.DoWork += MessageReceiver_DoWork;
            if (isHost)
            {
                Giocatore = 'X';
                Avversario = 'O';
                var udpServer = new UdpClient(10400);
            }
            else
            {
                Giocatore = 'O';
                Avversario = 'X';
                try
                {
                    var udpClient = new UdpClient();
                    udpClient.Connect(epHost);
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
            if (CheckVittoria())
                return;
            DisabilitaTris();
            label1.Text = "Turno avversario!";
            RiceviMossa();
            label1.Text = "E' il tuo turno!";
            if (!CheckVittoria())
                AbilitaTris();
        }
        private void DisabilitaTris()
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
        private void AbilitaTris()
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
        private void RiceviMossa()
        {
            byte buffer = 0;
            if (buffer == 1)
                button1.Text = Avversario.ToString();
            if (buffer == 2)
                button2.Text = Avversario.ToString();
            if (buffer == 3)
                button3.Text = Avversario.ToString();
            if (buffer == 4)
                button4.Text = Avversario.ToString();
            if (buffer == 5)
                button5.Text = Avversario.ToString();
            if (buffer == 6)
                button6.Text = Avversario.ToString();
            if (buffer == 7)
                button7.Text = Avversario.ToString();
            if (buffer == 8)
                button8.Text = Avversario.ToString();
            if (buffer == 9)
                button9.Text = Avversario.ToString();

        }
        private bool CheckVittoria()
        {
            //Check sulle orizzontali
            //La logica del controllo e' molto semplice: se nella stessa riga orizzontale il testo dei button è uguale assegnamo la vittoria
            if (button1.Text == button2.Text && button2.Text == button3.Text && button3.Text != "")
            {
                if (button1.Text[0] == Giocatore)
                {
                    label1.Text = "Complimenti hai vinto!";
                    MessageBox.Show("Hai vinto!");
                }
                else
                {
                    label1.Text = "Peccato, hai perso!";
                    MessageBox.Show("Hai perso!");
                }
                return true;
            }

            else if (button4.Text == button5.Text && button5.Text == button6.Text && button6.Text != "")
            {
                if (button4.Text[0] == Giocatore)
                {
                    label1.Text = "Complimenti hai vinto!";
                    MessageBox.Show("Hai vinto!");
                }
                else
                {
                    label1.Text = "Peccato, hai perso!";
                    MessageBox.Show("Hai perso!");
                }
                return true;
            }

            else if (button7.Text == button8.Text && button8.Text == button9.Text && button9.Text != "")
            {
                if (button7.Text[0] == Giocatore)
                {
                    label1.Text = "Complimenti hai vinto!";
                    MessageBox.Show("Hai vinto!");
                }
                else
                {
                    label1.Text = "Peccato, hai perso!";
                    MessageBox.Show("Hai perso!");
                }
                return true;
            }

            //Check sulle verticali
            //La logica del controllo e' molto semplice: se nella stessa riga verticale il testo dei button è uguale assegnamo la vittoria
            //Nel caso delle oblique la logica e' la stessa (oblique: 1,5,9 e 3,5,7)
            else if (button1.Text == button4.Text && button4.Text == button7.Text && button7.Text != "")
            {
                if (button1.Text[0] == Giocatore)
                {
                    label1.Text = "Complimenti hai vinto!";
                    MessageBox.Show("Hai vinto!");
                }
                else
                {
                    label1.Text = "Peccato, hai perso!";
                    MessageBox.Show("Hai perso!");
                }
                return true;
            }

            else if (button2.Text == button5.Text && button5.Text == button8.Text && button8.Text != "")
            {
                if (button2.Text[0] == Giocatore)
                {
                    label1.Text = "Complimenti hai vinto!";
                    MessageBox.Show("Hai vinto!");
                }
                else
                {
                    label1.Text = "Peccato, hai perso!";
                    MessageBox.Show("Hai perso!");
                }
                return true;
            }

            else if (button3.Text == button6.Text && button6.Text == button9.Text && button9.Text != "")
            {
                if (button3.Text[0] == Giocatore)
                {
                    label1.Text = "Complimenti hai vinto!";
                    MessageBox.Show("Hai vinto!");
                }
                else
                {
                    label1.Text = "Peccato, hai perso!";
                    MessageBox.Show("Hai perso!");

                }
                return true;
            }
            //Check obliqui
            else if (button1.Text == button5.Text && button5.Text == button9.Text && button9.Text != "")
            {
                if (button1.Text[0] == Giocatore)
                {
                    label1.Text = "Complimenti hai vinto!";
                    MessageBox.Show("Hai vinto!");
                }
                else
                {
                    label1.Text = "Peccato, hai perso!";
                    MessageBox.Show("Hai perso!");
                }
                return true;
            }

            else if (button3.Text == button5.Text && button5.Text == button7.Text && button7.Text != "")
            {
                if (button3.Text[0] == Giocatore)
                {
                    label1.Text = "Complimenti hai vinto!";
                    MessageBox.Show("Hai vinto!");
                }
                else
                {
                    label1.Text = "Peccato, hai perso!";
                    MessageBox.Show("Hai perso!");
                }
                return true;
            }
            //Pareggio
            //La logica del controlllo e' molto semplice: se passati i check della vittoria sugli orizzontali,verticali e obliqui senza aver un vincitori e tutta la griglia di gioco e' piena allora si termina la partita in pareggio
            else if (button1.Text != "" && button2.Text != "" && button3.Text != "" && button4.Text != "" && button5.Text != "" && button6.Text != "" && button7.Text != "" && button8.Text != "" && button9.Text != "")
            {
                label1.Text = "Pareggio!";
                MessageBox.Show("Pareggio!");
                return true;
            }
            return false;
        }

        private void button1_Click(object sender, EventArgs e)
        {
            byte[] valoreGriglia = { 1 };
            //Invio messaggio via UDP
            button1.Text = Giocatore.ToString();
            MessageReceiver.RunWorkerAsync();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            byte[] valoreGriglia = { 2 };
            //Invio messaggio via UDP
            button1.Text = Giocatore.ToString();
            MessageReceiver.RunWorkerAsync();
        }

        private void button3_Click(object sender, EventArgs e)
        {
            byte[] valoreGriglia = { 3 };
            //Invio messaggio via UDP
            button1.Text = Giocatore.ToString();
            MessageReceiver.RunWorkerAsync();
        }

        private void button4_Click(object sender, EventArgs e)
        {
            byte[] valoreGriglia = { 4 };
            //Invio messaggio via UDP
            button1.Text = Giocatore.ToString();
            MessageReceiver.RunWorkerAsync();
        }

        private void button5_Click(object sender, EventArgs e)
        {
            byte[] valoreGriglia = { 5 };
            //Invio messaggio via UDP
            button1.Text = Giocatore.ToString();
            MessageReceiver.RunWorkerAsync();
        }

        private void button6_Click(object sender, EventArgs e)
        {
            byte[] valoreGriglia = { 6 };
            //Invio messaggio via UDP
            button1.Text = Giocatore.ToString();
            MessageReceiver.RunWorkerAsync();
        }

        private void button7_Click(object sender, EventArgs e)
        {
            byte[] valoreGriglia = { 7 };
            //Invio messaggio via UDP
            button1.Text = Giocatore.ToString();
            MessageReceiver.RunWorkerAsync();
        }

        private void button8_Click(object sender, EventArgs e)
        {
            byte[] valoreGriglia = { 8 };
            //Invio messaggio via UDP
            button1.Text = Giocatore.ToString();
            MessageReceiver.RunWorkerAsync();
        }

        private void button9_Click(object sender, EventArgs e)
        {
            byte[] valoreGriglia = { 9 };
            //Invio messaggio via UDP
            button1.Text = Giocatore.ToString();
            MessageReceiver.RunWorkerAsync();
        }
    }
}
