using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Assign1.Models
{
    public class DataProvider
    {
        private static DataProvider _ins;
        public static DataProvider ins { get { if (_ins == null) _ins = new DataProvider(); return _ins; } set { _ins = value; } }

        public Assign1Prn221Context context { get; set; }

        private DataProvider() { 
            context = new Assign1Prn221Context();
        }
    }
}
