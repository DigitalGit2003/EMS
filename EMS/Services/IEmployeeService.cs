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
        EmployeeDTO getEmployee(string emp_name);

        [OperationContract]
        List<EmployeeDTO> getEmployees();

        [OperationContract]
        List<EmployeeDTO> getEmployeesByDepartmentName(string dept_name);

        [OperationContract]
        string addEmployee(EmployeeDTO dto, string deptName);

        [OperationContract]
        string updateEmployee(string emp_name, EmployeeDTO e);

        [OperationContract]
        string deleteEmployee(string emp_name);

    }
}
