using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Runtime.Serialization;
using System.Text;
using System.Threading.Tasks;

namespace EMS.Models
{
    [DataContract]
    public class EmployeeDTO
    {
        [DataMember]
        public int EmployeeId { get; set; }

        [DataMember]
        public string Name { get; set; }

        [DataMember]
        public int Salary { get; set; }
    }
}
