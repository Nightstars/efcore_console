using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace efcore_console.Entity
{
    [Table("TestTableDetail")]
    public class TestTableDetail
    {
        [Key]
        public int Id { get; set; }
        public int PID { get; set; }
        public string Name { get; set; }

        [ForeignKey("PID")]
        public virtual TestTable testTable { get; set; }
    }
}
