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

namespace Bonati_Cividini_Tris
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }
        public static string ipOspite;
        private bool MatchIP(string expression)
        {
            IPAddress ipOspite;
            return IPAddress.TryParse(expression, out ipOspite);
            
        }

        private void btn_start_Click(object sender, EventArgs e)
        {
            if (MatchIP(tb_IP_ospite.Text) == true)
            {
                ipOspite = tb_IP_ospite.Text;
            }
            else
            {
                MessageBox.Show("L'IP inserito non e' corretto!");
                tb_IP_ospite.Text = "";
                return;
            }
            Gioco nuovaPartita = new Gioco(false, ipOspite);
            Visible = false;
            if (!nuovaPartita.IsDisposed)
                nuovaPartita.ShowDialog();
            Visible = true;
        }

        private void btn_host_Click(object sender, EventArgs e)
        {
            Gioco nuovaPartita = new Gioco(true);
            Visible = false;
            if (!nuovaPartita.IsDisposed)
                nuovaPartita.ShowDialog();
            Visible = true;
        }

       
    }
}
