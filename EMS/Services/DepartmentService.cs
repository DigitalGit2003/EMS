using EMS.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EMS.Services
{
    public class DepartmentService : IDepartmentService
    {
        private static DepartmentDTO convertToDTO(Department d)
        {
            return new DepartmentDTO
            {
                DepartmentId = d.DepartmentId,
                Name = d.Name,
                Location = d.Location
            };
        }

        private static Department convertFromDTO(DepartmentDTO dto)
        {
            return new Department
            {
                DepartmentId = dto.DepartmentId,
                Name = dto.Name,
                Location = dto.Location
            };
        }
        // ----------------------------------------------------------------------

        public DepartmentDTO getDepartment(int dept_id)
        {
            using (var context = new EMSDbContext())
            {
                Department dept = context.Departments.Find(dept_id);
                DepartmentDTO result = convertToDTO(dept);
                return result;
            }
        }

        public List<DepartmentDTO> getDepartments()
        {
            using (var context = new EMSDbContext())
            {
                List<Department> depts = context.Departments.ToList();
                List<DepartmentDTO> deptDTOs = new List<DepartmentDTO>();
                foreach (var dept in depts)
                {
                    DepartmentDTO deptDTO = convertToDTO(dept);
                    deptDTOs.Add(deptDTO);
                }

                return deptDTOs;
            }
        }

        // ----------------------------------------------------------------------
        public string addDepartment(DepartmentDTO dto)
        {
            using (var context = new EMSDbContext())
            {
                Department d = convertFromDTO(dto);
                context.Departments.Add(d);
                context.SaveChanges();
            }
            return $"Department {dto.Name} is added.";
        }

        public string updateDepartment(int dept_id, DepartmentDTO d)
        {
            using (var context = new EMSDbContext())
            {
                Department dept = context.Departments.Find(dept_id);
                dept.Name = d.Name;
                dept.Location = d.Location;
                context.SaveChanges();
            }

            return "Department updated.";
        }

        public string deleteDepartment(int dept_id)
        {
            using (var context = new EMSDbContext())
            {
                var departmentToDelete = context.Departments.Find(dept_id);

                if (departmentToDelete != null)
                {
                    List<Project> projectsToDelete = context.Projects.Where(p => p.DepartmentId == departmentToDelete.DepartmentId).ToList();
                    foreach (var project in projectsToDelete)
                    {
                        context.Projects.Remove(project);
                    }

                    context.Departments.Remove(departmentToDelete);
                    context.SaveChanges();
                }
                else
                {
                    return "Department not found.";
                }
            }
            return "Department deleted.";
        }

    }
}
