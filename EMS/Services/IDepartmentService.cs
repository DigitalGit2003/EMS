using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.ServiceModel;
using EMS.Models;

namespace EMS.Services
{
    [ServiceContract]
    public interface IDepartmentService
    {
        [OperationContract]
        DepartmentDTO getDepartment(string dept_name);

        [OperationContract]
        List<DepartmentDTO> getDepartments();

        [OperationContract]
        string addDepartment(DepartmentDTO d);

        [OperationContract]
        string updateDepartment(string dept_name, Department d);

        [OperationContract]
        string deleteDepartment(string dept_name);

    }
}
