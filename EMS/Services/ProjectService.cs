using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EMS.Services
{
    public class ProjectService : IProjectService
    {
        public string addProject(Project p, string deptName)
        {
            using (var context = new EMSDbContext())
            {
                Department dept = context.Departments.FirstOrDefault(d => d.Name == deptName);
                p.Department = dept;
                context.Projects.Add(p);
                context.SaveChanges();
            }
            return "Project added.";
        }

        // ----------------------------------------------------------------------

        //public Project getProject(int p_id)
        //{
        //    using (var context = new EMSDbContext())
        //    {
        //        Project proj = context.Projects.Find(p_id);
        //        return proj;
        //    }
        //}

        // ----------------------------------------------------------------------
        public string updateProject(int p_id, Project p)
        {
            using (var context = new EMSDbContext())
            {
                Project proj = context.Projects.Find(p_id);
                proj.Title = p.Title;
                proj.Status = p.Status;
                context.SaveChanges();
            }

            return "Project updated.";
        }

        // ----------------------------------------------------------------------
        public string deleteProject(int p_id)
        {
            using (var context = new EMSDbContext())
            {
                var projectToDelete = context.Projects.FirstOrDefault(p => p.ProjectId == p_id);

                if (projectToDelete != null)
                {
                    context.Projects.Remove(projectToDelete);
                    context.SaveChanges();
                }
                else
                {
                    return "Project not found.";
                }
            }
            return "Project deleted.";
        }

        // ----------------------------------------------------------------------

        //public ICollection<Project> getProjects()
        //{
        //    using (var context = new EMSDbContext())
        //    {
        //        return context.Projects.ToList();
        //    }
        //}

        // ----------------------------------------------------------------------
    }
}
