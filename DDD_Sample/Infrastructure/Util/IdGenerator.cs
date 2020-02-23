using System;
using System.Collections.Generic;
using System.Text;

namespace Infrastructure.Util
{
    public class IdGenerator
    {
        public static string NextId()
        {
            return Guid.NewGuid().ToString();
        }
    }
}
