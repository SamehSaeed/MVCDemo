using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BL
{
    [Table("tblDepartment")]
    public class Department
    {
        public int ID { get; set; }

        [Required]
        public string Name { get; set; }


        public virtual ICollection<Employee> Employees { get; set; }
    }
}
