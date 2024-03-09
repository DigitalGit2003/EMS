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
    public class ProjectDTO
    {
        [DataMember]
        public int ProjectId { get; set; }

        [DataMember]
        public string Title { get; set; }

        [DataMember]
        public string Status { get; set; }
    }
}
