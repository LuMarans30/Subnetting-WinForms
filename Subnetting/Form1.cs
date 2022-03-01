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
                if(i>0)
                {
                    for (int k = 0; k < 4; k++)
                        listSottorete[i].ipRete[k] = listSottorete[i - 1].broadcast[k];

                    if(listSottorete[i].ipRete[3] == 255)
                    {
                        listSottorete[i].ipRete[3] = 0;
                        listSottorete[i].ipRete[2] += 1;
                    }else
                        listSottorete[i].ipRete[3] += 1;
                }

                Sottorete s = listSottorete[i];
                int num = s.ToPotenzaDi2();
                for(int k=0; k<4; k++)
                    s.broadcast[k] = s.ipRete[k];

                switch(num)
                {
                    case int n when n < 8:
                        s.broadcast[3] |= (Int32)Math.Pow(2,num)-1;
                        break;
                    case int n when n >= 8 && n<16:
                        s.broadcast[3] |= 255;
                        num -= 8;
                        s.broadcast[2] |= (Int32)Math.Pow(2,num)-1;
                        break;
                    case int n when n >= 16 && n < 24:
                        s.broadcast[3] |= 255;
                        s.broadcast[2] |= 255;
                        num -= 16;
                        s.broadcast[1] |= (Int32)Math.Pow(2, num)-1;
                        break;
                }

                for (int k = 0; k < 4; k++)
                {
                    s.primoH[k] = s.ipRete[k];
                    s.ultimoH[k] = s.broadcast[k];
                }

                s.primoH[3] += 1;
                s.ultimoH[3] -= 1;
                dataGridView1.Rows.Add(s.classe, s, s.netmask, string.Join(".", s.broadcast), string.Join(".", s.primoH) + " - " + string.Join(".", s.ultimoH), s.numhost);
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

                Sottorete sottorete = new Sottorete(indirizzo, netmask, numhost);
                sottorete.checkValido();
                listSottorete.Add(sottorete);
                dataGridView1.Rows.Add(sottorete.classe, sottorete, netmask, "", "", numhost);

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

