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
    public interface IEmployeeService
    {
        [OperationContract]
        EmployeeDTO getEmployee(int emp_id);

        [OperationContract]
        List<EmployeeDTO> getEmployees();

        [OperationContract]
        string addEmployee(EmployeeDTO dto, string deptName);

        [OperationContract]
        string updateEmployee(int emp_id, Employee e);

        [OperationContract]
        string deleteEmployee(int emp_id);

    }
}
