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
    public interface IProjectService
    {
        [OperationContract]
        ProjectDTO getProject(int proj_id);

        [OperationContract]
        List<ProjectDTO> getProjects();

        [OperationContract]
        List<ProjectDTO> getProjectsByDepartmentId(int dept_id);

        [OperationContract]
        string addProject(ProjectDTO dto, int dept_id);

        [OperationContract]
        string updateProject(int proj_id, ProjectDTO p);

        [OperationContract]
        string deleteProject(int proj_id);

        [OperationContract]
        string addEmployees(int proj_id, List<string> Emps);

        [OperationContract]
        List<EmployeeDTO> viewEmployees(int proj_id);

        [OperationContract]
        string removeEmployeeFromProject(int proj_id, int emp_id);
    }
}
