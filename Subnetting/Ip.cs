using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Subnetting
{
    public class Ip
    {
        public Int32[] indirizzo { get; set; }
        public char classe {  get; set; }

        public Ip(Int32[] indirizzo)
        {
            this.indirizzo = new Int32[4];
            this.indirizzo=indirizzo;
            classe = ' ';

            int tmpClasse = indirizzo[0] >> 5;
            switch(tmpClasse)
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

        public override string ToString()
        {
            return string.Join(".", indirizzo);
        }
    }
}
