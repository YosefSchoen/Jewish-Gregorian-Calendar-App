using System;
using System.Collections.Generic;
using System.Text;
using BELayer;

namespace BLLayer
{
    internal class MyBL : IBL
    {
        
        DALayer.IDAL DAL = DALayer.FactoryDAL.getInstance();

        bool IBL.createCalendar(int lastYear)
        {
            if(lastYear < 1 || lastYear > 6000) { return false; }
            return DAL.createCalendar(lastYear);
        }

        Calendar IBL.GetCalendar() { return DAL.GetCalendar(); }
    }
}
