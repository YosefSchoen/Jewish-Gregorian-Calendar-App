using System;
using System.Collections.Generic;
using System.Text;
using BELayer;

namespace DALayer
{
    class DataSource
    {    
        private static BELayer.Calendar calendar;
        public static BELayer.Calendar Calendar { get => calendar; set => calendar = value; }
    }
}
