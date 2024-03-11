using EMS.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.Entity;

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

        public ProjectDTO getProject(string proj_title)
        {
            using (var context = new EMSDbContext())
            {
                Project proj = context.Projects.FirstOrDefault(pp => pp.Title == proj_title);
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

        public List<ProjectDTO> getProjectsByDepartmentName(string dept_name)
        {
            using (var context = new EMSDbContext())
            {
                Department dept = context.Departments.FirstOrDefault(d => d.Name == dept_name);

                List<Project> projs = context.Projects.Where(p => p.DepartmentId == dept.DepartmentId).ToList();
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

        public string updateProject(string proj_title, ProjectDTO p)
        {
            using (var context = new EMSDbContext())
            {
                Project proj = context.Projects.FirstOrDefault(pp => pp.Title == proj_title);
                proj.Title = p.Title;
                proj.Status = p.Status;
                context.SaveChanges();
            }

            return "Project updated.";
        }

        public string deleteProject(string proj_title)
        {
            using (var context = new EMSDbContext())
            {
                var projectToDelete = context.Projects.FirstOrDefault(p => p.Title == proj_title);

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

        public string addEmployees(string proj_title, List<string> emps)
        {
            using (var context = new EMSDbContext())
            {
                var project = context.Projects.FirstOrDefault(p => p.Title == proj_title);

                if (project == null)
                {
                    return "Project not found";
                }

                // Find the employees by name and add them to the project
                foreach (var empName in emps)
                {
                    var employee = context.Employees.FirstOrDefault(e => e.Name == empName);

                    if (employee == null)
                    {
                        continue;
                    }

                    // Check if the employee is already associated with the project
                    if (!project.Employees.Any(e => e.EmployeeId == employee.EmployeeId))
                    {
                        project.Employees.Add(employee);
                    }
                }

                context.SaveChanges();
            }

            return "Employees added to project successfully";
        }

        public List<string> viewEmployees(string proj_title)
        {
            List<string> employeeNames = new List<string>();

            using (var context = new EMSDbContext())
            {
                // Find the project by title including its associated employees
                var project = context.Projects
                                    .Include(p => p.Employees)
                                    .FirstOrDefault(p => p.Title == proj_title);

                if (project != null)
                {
                    // Extract employee names
                    foreach (var employee in project.Employees)
                    {
                        employeeNames.Add(employee.Name);
                    }
                }
            }

            return employeeNames;
        }

        public string removeEmployeeFromProject(string proj_title, string emp_name)
        {
            using (var context = new EMSDbContext())
            {
                // Find the project by title including its associated employees
                var project = context.Projects
                                    .Include(p => p.Employees)
                                    .FirstOrDefault(p => p.Title == proj_title);

                if (project == null)
                {
                    return "Project not found";
                }

                // Find the employee by name
                var employee = context.Employees.FirstOrDefault(e => e.Name == emp_name);

                if (employee == null)
                {
                    return "Employee not found";
                }

                // Remove the employee from the project
                project.Employees.Remove(employee);

                context.SaveChanges();
            }

            return "Employee removed from project successfully";

        }
    }
}
