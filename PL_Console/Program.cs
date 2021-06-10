using System;
using System.Linq;

namespace PL_Console
{
    class Program
    {
        private static BLLayer.IBL BL = BLLayer.FactoryBL.getInstance();
        
        
        static void Main(string[] args)
        {
            BL.createCalendar(6000);
            BELayer.Calendar calendar = BL.GetCalendar();
            Console.WriteLine("end test");
            Console.ReadLine();
        }
    }
}
