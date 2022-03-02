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
            this.Icon = Properties.Resources.icon;
            netmask = 0;
            numhost = 0;
        }

        private void btnCalcola_Click(object sender, EventArgs e)
        {
            dataGridView1.Rows.Clear();
            listSottorete.Sort();

            for (int i = 0; i < listSottorete.Count; i++)
            {
                try
                {
                    if (i > 0)
                    {
                        Int32[] sot = listSottorete[i].ipRete;

                        for (int k = 0; k < 4; k++)
                            sot[k] = listSottorete[i - 1].broadcast[k];

                        if ((listSottorete[i].classe == 'A' && sot[0] < 127) || (listSottorete[i].classe == 'B' && sot[0] < 191) || (listSottorete[i].classe == 'C' && sot[0] < 223))
                        {

                            if (sot[3] == 255 && sot[2] == 255 && sot[1] == 255)
                            {
                                sot[3] = 0;
                                sot[2] = 0;
                                sot[1] = 0;
                                sot[0]++;
                            }
                            else if (sot[3] == 255 && sot[2] == 255 && sot[1] != 255)
                            {
                                sot[3] = 0;
                                sot[2] = 0;
                                sot[1]++;
                            }
                            else if (sot[3] == 255 && sot[2] != 255)
                            {
                                sot[3] = 0;
                                sot[2]++;

                            }
                            else if (sot[3] != 255)
                            {
                                sot[3]++;

                            }
                            
                        }
                        else
                            throw new EccezioneClasseNonValida("Non è possibile aggiungere ulteriori sottoreti");

                        listSottorete[i].ipRete = sot;
                    }
                    
                }catch(EccezioneClasseNonValida ex)
                {
                    MessageBox.Show(ex.Message);
                    pulisci();
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
                int realh = s.ultimoH[3] - s.primoH[3] + s.ultimoH[2] * 255 - s.primoH[2] * 255 + s.ultimoH[1] * 255 * 255 - s.primoH[1] * 255 * 255;
                dataGridView1.Rows.Add(
                    s.classe,
                    s,
                    s.netmask,
                    string.Join(".", s.broadcast),
                    string.Join(".", s.primoH) + " - " + string.Join(".", s.ultimoH),
                    s.numhost,
                    realh,
                    realh - s.numhost);
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
                dataGridView1.Rows.Add(sottorete.classe, sottorete, netmask, "", "", numhost, "", "");

                txtIP.Enabled = false;
                txtMask.Enabled = false;
            }
            catch(EccezioneClasseNonValida ex)
            {
                MessageBox.Show(ex.Message);
                pulisci();
            }

        }

    }
}

