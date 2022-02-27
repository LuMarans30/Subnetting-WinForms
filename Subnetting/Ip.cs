using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Subnetting
{
    class Ip
    {
        public int[] indirizzo { private set; get; }
        public int netmask { private set; get; }
        public char classe { private set; get; }

        public Ip(int[] ottetto, int netmask)
        {
            this.indirizzo = ottetto;
            this.netmask = netmask;
            int tmpClasse = ottetto[0] >> 5;
            switch(tmpClasse)
            {
                case 0:
                case 1:
                case 2:
                case 3:
                    this.classe = 'A';
                    break;
                case 4:
                case 5:
                    this.classe = 'B';
                    break;
                case 6:
                    this.classe = 'C';
                    break;
                default:
                    throw new EccezioneClasseNonValida("La classe dell'indirizzo IP non è valida");
            }
        }

        public override string ToString()
        {
            return string.Join(".", indirizzo);
        }

    }
}
