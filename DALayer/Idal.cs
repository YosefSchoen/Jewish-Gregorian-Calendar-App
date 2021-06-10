using System;
using System.Collections.Generic;

namespace DALayer
{
    public interface IDAL
    {
        bool createCalendar(int lastYear);
        BELayer.Calendar GetCalendar();
    }
}
