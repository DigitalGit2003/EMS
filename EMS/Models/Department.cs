using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.ServiceModel;
using System.Runtime.Serialization;
using System.ComponentModel.DataAnnotations.Schema;

namespace EMS
{
    public class Department
    {
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int DepartmentId { get; set; }

        public string Name { get; set; }

        public string Location { get; set; }

        public virtual ICollection<Employee> Employees { get; set; }

        public virtual ICollection<Project> Projects { get; set; }

        public Department() { }

    }
}
