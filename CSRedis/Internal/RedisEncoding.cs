using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace CSRedis.Internal
{
    class RedisEncoding
    {
        public Encoding Encoding { get; set; }

        public RedisEncoding()
        {
            Encoding = new UTF8Encoding(false);
        }
    }
}
