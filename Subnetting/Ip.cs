using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Subnetting
{
    class Ip
    {
        public int[] indirizzo {  get; private set; }
        public char classe {  get; private set; }

        public Ip(int[] ottetto)
        {
            this.indirizzo = ottetto;
            int tmpClasse = ottetto[0] >> 5;
            switch(tmpClasse)
            {
                case int n when n < 4:
                    this.classe = 'A';
                    break;
                case int n when n < 6:
                    this.classe = 'B';
                    break;
                case 6:
                    this.classe = 'C';
                    break;
                default:
                    throw new EccezioneClasseNonValida("La classe dell'indirizzo IP non è valida");
            }
        }

        public Ip (Ip ip)
        {
            this.classe = ip.classe;
            this.indirizzo = ip.indirizzo;
        }

        public override string ToString()
        {
            return string.Join(".", indirizzo);
        }
    }
}
