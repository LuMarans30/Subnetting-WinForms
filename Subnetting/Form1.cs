using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Collections;

namespace Subnetting
{
    public partial class Form1 : Form
    {
        private Int32[] indirizzo =new Int32[4];
        private int netmask;
        private int numhost;
        private List<Sottorete> listSottorete = new List<Sottorete>();

        public Form1()
        {
            InitializeComponent();
            netmask = 0;
            numhost = 0;
        }

        private void btnCalcola_Click(object sender, EventArgs e)
        {
            dataGridView1.Rows.Clear();
            listSottorete.Sort();

            for (int i = 0; i < listSottorete.Count; i++)
            {
                Sottorete s = listSottorete[i];
                int num = s.ToPotenzaDi2();
                s.broadcast = new Ip(s.ip.indirizzo);

                switch(num)
                {
                    case int n when n < 8:
                        s.broadcast.indirizzo[3] |= (Int32)Math.Pow(2,num)-1;
                        break;
                    case int n when n >= 8 && n<16:
                        s.broadcast.indirizzo[3] |= 255;
                        num -= 8;
                        s.broadcast.indirizzo[2] |= (Int32)Math.Pow(2,num)-1;
                        break;
                    case int n when n >= 16 && n < 24:
                        s.broadcast.indirizzo[3] |= 255;
                        s.broadcast.indirizzo[2] |= 255;
                        num -= 16;
                        s.broadcast.indirizzo[1] |= (Int32)Math.Pow(2, num)-1;
                        break;
                }

                s.range[0] = new Ip(s.ip.indirizzo);
                s.range[0].indirizzo[3] += 1;
                s.range[1] = new Ip(s.broadcast.indirizzo);
                s.range[1].indirizzo[3] -= 1;
                dataGridView1.Rows.Add(s.ip.classe, s.ip, s.netmask, s.broadcast, s.range[0] + " - " + s.range[1], s.numhost);
            }

        }

    

        private void pulisci()
        {
            if (txtIP.Enabled == true)
            {
                txtIP.Clear();
                txtMask.Clear();
            }

            txtHost.Clear();
        }

        private void btnInserisci_Click(object sender, EventArgs e)
        {
            try
            {
                if (String.IsNullOrEmpty(txtIP.Text) || String.IsNullOrEmpty(txtMask.Text) || String.IsNullOrEmpty(txtHost.Text))
                {
                    throw new EccezioneClasseNonValida("Tutti i campi sono obbligatori");
                }

                indirizzo = txtIP.Text.Split('.').Select(Int32.Parse).ToArray();
                netmask = Int32.Parse(txtMask.Text);
                numhost = Int32.Parse(txtHost.Text);

                Ip ip = new Ip(indirizzo);
                Sottorete sottorete = new Sottorete(ip, netmask, numhost);
                sottorete.checkValido();
                listSottorete.Add(sottorete);
                dataGridView1.Rows.Add(ip.classe, ip, netmask, "", "", numhost);

                this.txtIP.Enabled = false;
                this.txtMask.Enabled = false;
            }
            catch(EccezioneClasseNonValida ex)
            {
                MessageBox.Show(ex.Message);
                pulisci();
            }

        }
    }
}

