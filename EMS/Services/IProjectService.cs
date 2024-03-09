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
        ProjectDTO getProject(int p_id);

        [OperationContract]
        List<ProjectDTO> getProjects();

        [OperationContract]
        List<ProjectDTO> getProjectsByDepartmentName(string dept_name);

        [OperationContract]
        string addProject(ProjectDTO dto, string deptName);

        [OperationContract]
        string updateProject(int p_id, Project p);

        [OperationContract]
        string deleteProject(int p_id);

    }
}
