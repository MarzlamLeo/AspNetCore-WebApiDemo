using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Marzlam1
{
    public class configclass
    {
        public string SecurityKey { get; set; }
        public string Issuer { get; set; }
        public string Audience { get; set; }
        public int ExpireSeconds { get; set; }
    }
}
