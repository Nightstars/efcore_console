using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace efcore_console.Entity
{
    [Keyless]
    public class TestCus
    {
        public int PID { get; set; }
        public string name { get; set; }
    }
}
