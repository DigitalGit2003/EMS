using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.ServiceModel;

namespace EMS.Services
{
    [ServiceContract]
    public interface IDepartmentService
    {
        //[OperationContract]
        //Department getDepartment(int dept_id);

        //[OperationContract]
        //ICollection<Department> getDepartments();

        [OperationContract]
        string addDepartment(Department d);

        [OperationContract]
        string updateDepartment(int dept_id, Department d);

        [OperationContract]
        string deleteDepartment(string dept_name);


        [OperationContract]
        List<string> getDepartmentNames();

        [OperationContract]
        List<string> getDepartmentLocations();

    }
}
