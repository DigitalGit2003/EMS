using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.ServiceModel;

namespace EMS.Services
{
    [ServiceContract]
    public interface IProjectService
    {
        [OperationContract]
        string addProject(Project p, string deptName);

        //[OperationContract]
        //Project getProject(int p_id);

        [OperationContract]
        string updateProject(int p_id, Project p);

        [OperationContract]
        string deleteProject(int p_id);

        //[OperationContract]
        //ICollection<Project> getProjects();
    }
}
