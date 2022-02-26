using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Net;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Subnetting
{
    public partial class Form1 : Form
    {
        int[] ottetto;
        int netmask;
        int numhost;
        List<Sottorete> listSottorete;

        public Form1()
        {
            InitializeComponent();
            listSottorete = new List<Sottorete>();
            ottetto = new int[3];
            netmask = 0;
            numhost = 0;
        }

        private void btnCalcola_Click(object sender, EventArgs e)
        {
            ottetto = txtIP.Text.Split('.').Select(int.Parse).ToArray();
            netmask = Int32.Parse(txtMask.Text);
            numhost = Int32.Parse(txtHost.Text);
            Ip ip = new Ip(ottetto, netmask);
            Sottorete sottorete = new Sottorete(ip,numhost);

            if (sottorete.isValido())
            {
                listSottorete.Add(sottorete);

                Console.WriteLine("IP: " + ip.getIndirizzo() + "/" + ip.getMask());

                //TODO: AGGIUNGERE LA RIGA ALLA TABELLA SOLO QUANDO LA SOTTORETE E' GIA' STATA CALCOLATA
                dataGridView1.Rows.Add(ip.getIndirizzo(), ip.getMask(), "", "", numhost);     
            }else
            {
                MessageBox.Show("Inserire un indirizzo IP valido");
                txtIP.Clear();
                txtMask.Clear();
                txtHost.Clear();
            }

        }
    }
}
