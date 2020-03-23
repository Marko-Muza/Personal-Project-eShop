using System;
using System.Collections.Generic;
using System.Text;

namespace BussinesLogicLayer
{
    public class CurrentDate:ICurrentDate
    {
        public DateTime GetCurrentDate()
        {
            return DateTime.Now;
        }
    }
}
