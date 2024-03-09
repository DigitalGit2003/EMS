using EMS.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EMS.Services
{
    public class ProjectService : IProjectService
    {
        private static ProjectDTO convertToDTO(Project p)
        {
            return new ProjectDTO
            {
                ProjectId = p.ProjectId,
                Title = p.Title,
                Status = p.Status
            };
        }

        private static Project convertFromDTO(ProjectDTO dto)
        {
            return new Project
            {
                ProjectId = dto.ProjectId,
                Title = dto.Title,
                Status = dto.Status
            };
        }
        // ----------------------------------------------------------------------

        public ProjectDTO getProject(int p_id)
        {
            using (var context = new EMSDbContext())
            {
                Project proj = context.Projects.Find(p_id);
                ProjectDTO result = convertToDTO(proj);
                return result;
            }
        }

        public List<ProjectDTO> getProjects()
        {
            using (var context = new EMSDbContext())
            {
                List<Project> projs = context.Projects.ToList();
                List<ProjectDTO> projDTOs = new List<ProjectDTO>();
                foreach (var proj in projs)
                {
                    ProjectDTO projDTO = convertToDTO(proj);
                    projDTOs.Add(projDTO);
                }

                return projDTOs;
            }
        }

        // ----------------------------------------------------------------------

        public string addProject(ProjectDTO dto, string deptName)
        {
            using (var context = new EMSDbContext())
            {
                Project p = convertFromDTO(dto);
                Department dept = context.Departments.FirstOrDefault(d => d.Name == deptName);
                p.Department = dept;
                context.Projects.Add(p);
                context.SaveChanges();
            }
            return "Project added.";
        }

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

        
    }
}
