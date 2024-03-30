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
        private static EmployeeDTO convertEmployeeToDTO(Employee e)
        {
            return new EmployeeDTO
            {
                EmployeeId = e.EmployeeId,
                Name = e.Name,
                Salary = e.Salary
            };
        }

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

        public ProjectDTO getProject(int proj_id)
        {
            using (var context = new EMSDbContext())
            {
                Project proj = context.Projects.Find(proj_id);
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

        public List<ProjectDTO> getProjectsByDepartmentId(int dept_id)
        {
            using (var context = new EMSDbContext())
            {
                List<Project> projs = context.Projects.Where(p => p.DepartmentId == dept_id).ToList();
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

        public string addProject(ProjectDTO dto, int dept_id)
        {
            using (var context = new EMSDbContext())
            {
                Project p = convertFromDTO(dto);
                Department dept = context.Departments.Find(dept_id);
                p.Department = dept;
                context.Projects.Add(p);
                context.SaveChanges();
            }
            return "Project added.";
        }

        public string updateProject(int proj_id, ProjectDTO p)
        {
            using (var context = new EMSDbContext())
            {
                Project proj = context.Projects.Find(proj_id);
                proj.Title = p.Title;
                proj.Status = p.Status;
                context.SaveChanges();
            }

            return "Project updated.";
        }

        public string deleteProject(int proj_id)
        {
            using (var context = new EMSDbContext())
            {
                var projectToDelete = context.Projects.Find(proj_id);

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

        public string addEmployees(int proj_id, List<string> emps)
        {
            using (var context = new EMSDbContext())
            {
                var project = context.Projects.Find(proj_id);

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

        public List<EmployeeDTO> viewEmployees(int proj_id)
        {
            List<EmployeeDTO> employees = new List<EmployeeDTO>();

            using (var context = new EMSDbContext())
            {
                // Find the project by title including its associated employees
                var project = context.Projects
                                    .Include(p => p.Employees)
                                    .FirstOrDefault(p => p.ProjectId == proj_id);

                if (project != null)
                {
                    // Extract employee names
                    foreach (var employee in project.Employees)
                    {
                        employees.Add(convertEmployeeToDTO(employee));
                    }
                }
            }

            return employees;
        }

        public string removeEmployeeFromProject(int proj_id, int emp_id)
        {
            using (var context = new EMSDbContext())
            {
                // Find the project by id including its associated employees
                var project = context.Projects
                                    .Include(p => p.Employees)
                                    .FirstOrDefault(p => p.ProjectId == proj_id);

                if (project == null)
                {
                    return "Project not found";
                }

                // Find the employee by id
                var employee = context.Employees.Find(emp_id);

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
