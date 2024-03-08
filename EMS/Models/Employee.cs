﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.ServiceModel;
using System.Runtime.Serialization;
using System.ComponentModel.DataAnnotations.Schema;

namespace EMS
{
    [DataContract]
    public class Employee
    {
        [DataMember]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int EmployeeId { get; set; }

        [DataMember]
        public string Name { get; set; }

        [DataMember]
        public int Salary { get; set; }

        public virtual Department Department { get; set; }

        public virtual ICollection<Project> projects{ get; set; }

        public Employee() { }

    }
}
