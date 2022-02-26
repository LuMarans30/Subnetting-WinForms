using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Subnetting
{
    class Ip
    {
        public int[] indirizzo;
        public int netmask;

        public Ip(int[] ottetto, int netmask)
        {
            this.indirizzo = ottetto;
            this.netmask = netmask;
        }

        public int getMask()
        {
            return netmask;
        }

        public string getIndirizzo()
        {
            return string.Join(".", indirizzo);
        }

    }
}
