using System;
using System.Collections.Generic;
using System.Text;

namespace BLLayer
{
    public class FactoryBL
    {
        public static IBL getInstance() { return new MyBL(); }
    }
}
