using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Subnetting
{
    public class Sottorete: IComparable<Sottorete>
    {

        public Int32[] broadcast { get; set; }
        public Int32[] primoH { get; set; }
        public Int32[] ultimoH { get; set; }
        public int netmask { get; set; }
        public int numhost { get; set; }
        public Int32[] ipRete { get; set; }
        public char classe { get; set; }

        public Sottorete(Int32[] ipRete, int netmask, int numhost)
        {
            this.ipRete = new Int32[4];
            this.ipRete = ipRete;
            this.netmask = netmask;
            this.numhost = numhost;
            broadcast = new Int32[4];
            primoH = new Int32[4];
            ultimoH = new Int32[4];
            int tmpClasse = ipRete[0] >> 5;
            switch (tmpClasse)
            {
                case int n when n < 4:
                    classe = 'A';
                    break;
                case int n when n < 6:
                    classe = 'B';
                    break;
                case 6:
                    classe = 'C';
                    break;
                default:
                    throw new EccezioneClasseNonValida("La classe dell'indirizzo IP non è valida");
            }
        }

        public void checkValido()
        {
            if (ipRete.Count() != 4 || netmask > 30 || ipRete.Any(item => item > 255) || numhost <= 0)
                throw new EccezioneClasseNonValida("Ip non valido o parametri errati");
        }

        public int CompareTo(Sottorete s)
        {
            if (s.numhost == numhost)
                return 0;
            if (s.numhost < numhost)
                return -1;
            return 1;
        }

        public int ToPotenzaDi2()
        {
            if (numhost < 2)
            {
                return 0;
            }

            int exp = (int)Math.Log(numhost - 1, 2) + 1;
            if (Math.Pow(2,exp)-2>numhost)
            {
                return exp;
            }
            return exp + 1;
        }

        public override string ToString()
        {
            return string.Join(".", ipRete);
        }

    }
}
