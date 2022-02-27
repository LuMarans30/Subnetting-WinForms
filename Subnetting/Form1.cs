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
        private int[] ottetto;
        private int netmask;
        private int numhost;
        private List<Sottorete> listSottorete;

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
            dataGridView1.Rows.Clear();
            listSottorete.Sort();

            //TODO: calcolare sottoreti

            Sottorete s = null;

            for (int i = 0; i < listSottorete.Count; i++)
            {
                s = listSottorete[i];
                dataGridView1.Rows.Add(s.ip.classe, s.ip, s.ip.netmask, "", "", s.numhost);
                //dataGridView1.Rows.Add(s.ip.classe, s.ip, s.ip.netmask, s.broadcast, s.range[0] + " - " + s.range[1], s.numhost);
            }
        }

        private void pulisci()
        {
            txtIP.Clear();
            txtMask.Clear();
            txtHost.Clear();
        }

        private void btnInserisci_Click(object sender, EventArgs e)
        {
            ottetto = txtIP.Text.Split('.').Select(int.Parse).ToArray();
            netmask = Int32.Parse(txtMask.Text);
            numhost = Int32.Parse(txtHost.Text);
            Ip ip = null;
            Sottorete sottorete = null;

            try
            {
                ip = new Ip(ottetto, netmask);
                sottorete = new Sottorete(ip, numhost);
                sottorete.checkValido();
                listSottorete.Add(sottorete);
                dataGridView1.Rows.Add(ip.classe, ip, ip.netmask, "", "", numhost);
            }
            catch(EccezioneClasseNonValida ex)
            { 
                MessageBox.Show(ex.Message);
                pulisci();
            }

            this.txtIP.Enabled = false;
            this.txtMask.Enabled = false;

        }
    }
}
