using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Subnetting
{
    internal class Sottorete
    {
        private Ip ip;
        private int numhost;
        private Ip broadcast;
        private Ip[] range;

        public Sottorete(Ip ip, int numhost)
        {
            this.ip = ip;
            this.numhost = numhost;
            this.range = new Ip[1];
        }

        public bool isValido()
        {
            if (ip.indirizzo.Count() == 4 && ip.netmask <= 30 && !ip.indirizzo.Any(item => item > 255) && numhost > 0)
                return true;
            else
                return false;

        }
    }
}
