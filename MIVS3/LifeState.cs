using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MIVS3
{
    class LifeState
    {
        private char code;
        private string name;
        enum State { s, a ,b, c, f, e, d, k}
        State sta;

        public LifeState(Indicators ind)
        {
            sta = State.s;
            Random rand = new Random();

            

        }
    }
}
