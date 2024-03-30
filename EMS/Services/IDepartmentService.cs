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
        DepartmentDTO getDepartment(int dept_id);

        [OperationContract]
        List<DepartmentDTO> getDepartments();

        [OperationContract]
        string addDepartment(DepartmentDTO d);

        [OperationContract]
        string updateDepartment(int dept_id, DepartmentDTO d);

        [OperationContract]
        string deleteDepartment(int dept_id);

    }
}
