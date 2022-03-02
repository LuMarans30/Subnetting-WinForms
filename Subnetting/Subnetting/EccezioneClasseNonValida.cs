using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Subnetting
{
    public class EccezioneClasseNonValida : Exception
    {

        public EccezioneClasseNonValida(string message):base(message)
        {

        }
    }
}
