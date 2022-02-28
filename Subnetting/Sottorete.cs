using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Subnetting
{
    internal class Sottorete: IComparable<Sottorete>
    {

        public Ip broadcast { private set; get; }
        public Ip[] range { private set; get; }
        public int numhost { private set; get; }
        public Ip ip { private set; get; }

        public Sottorete(Ip ip, int numhost)
        {
            this.ip = ip;
            this.numhost = numhost;
            range = new Ip[2];
        }

        public void checkValido()
        {
            if (ip.indirizzo.Count() != 4 || ip.netmask > 30 || ip.indirizzo.Any(item => item > 255) || numhost <= 0)
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

            return (int)Math.Log(numhost - 1, 2) + 1;
        }

    }
}
