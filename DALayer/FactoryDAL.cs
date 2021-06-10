using System;
using System.Collections.Generic;
using System.Text;

namespace DALayer
{
    public class FactoryDAL
    {
        public static IDAL getInstance()
        {
            //no clue what this is for yet
            return new MyDAL();
        }
    }
}
