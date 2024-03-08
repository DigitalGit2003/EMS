using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.ServiceModel;


namespace EMS.Services
{
    [ServiceContract]
    public interface IEmployeeService
    {
        [OperationContract]
        string addEmployee(Employee e, string deptName);

        //[OperationContract]
        //Employee getEmployee(int emp_id);

        [OperationContract]
        string updateEmployee(int emp_id, Employee e);

        [OperationContract]
        string deleteEmployee(int emp_id);

        //[OperationContract]
        //ICollection<Employee> getEmployees();
    }
}
