using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Crypto_Info
{
    public static class Mediator
    {
        private static string _name ;
        private static string _interval;
        public static decimal? Supply { get; set; }
        public static decimal? Price { get; set; }
        public static string _Name
        {
            get { return _name; }
            set { _name = value; }
        }

        public static string _Interval
        {
            get { return _interval; }
            set { _interval = value; }
        }
    }
}
