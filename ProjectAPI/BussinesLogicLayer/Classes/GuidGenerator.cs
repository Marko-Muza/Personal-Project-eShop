using System;
using System.Collections.Generic;
using System.Text;

namespace BussinesLogicLayer
{
    public class GuidGenerator: IGuidGenerator
    {
        public string GetGuid()
        {
            return Guid.NewGuid().ToString();
        }
    }
}
