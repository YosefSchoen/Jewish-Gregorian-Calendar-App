using System;
using System.Collections.Generic;

namespace BLLayer
{
    public interface IBL
    {
        bool createCalendar(int lastYear);
        BELayer.Calendar GetCalendar();
    }
}
