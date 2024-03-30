using EMS.Models;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Linq;

namespace EMS.Services
{
    public class EmployeeService : IEmployeeService
    {
        private static EmployeeDTO convertToDTO(Employee e)
        {
            return new EmployeeDTO
            {
                EmployeeId = e.EmployeeId,
                Name = e.Name,
                Salary = e.Salary
            };
        }

        private static Employee convertFromDTO(EmployeeDTO dto)
        {
            return new Employee
            {
                EmployeeId = dto.EmployeeId,
                Name = dto.Name,
                Salary = dto.Salary
            };
        }
        // ----------------------------------------------------------------------

        public EmployeeDTO getEmployee(int emp_id)
        {
            using (var context = new EMSDbContext())
            {
                Employee emp = context.Employees.Find(emp_id);
                EmployeeDTO result = convertToDTO(emp);
                return result;
            }
        }

        public List<EmployeeDTO> getEmployees()
        {
            using (var context = new EMSDbContext())
            {
                List<Employee> emps = context.Employees.ToList();
                List<EmployeeDTO> empDTOs = new List<EmployeeDTO>();
                foreach (var emp in emps)
                {
                    EmployeeDTO empDTO = convertToDTO(emp);
                    empDTOs.Add(empDTO);
                }

                return empDTOs;
            }
        }

        public List<EmployeeDTO> getEmployeesByDepartmentId(int dept_id)
        {
            using (var context = new EMSDbContext())
            {
                List<Employee> emps = context.Employees.Where(e => e.DepartmentId == dept_id).ToList();
                List<EmployeeDTO> empDTOs = new List<EmployeeDTO>();
                foreach (var emp in emps)
                {
                    EmployeeDTO empDTO = convertToDTO(emp);
                    empDTOs.Add(empDTO);
                }

                return empDTOs;
            }
        }
        
        // ----------------------------------------------------------------------
        public string addEmployee(EmployeeDTO dto, int dept_id)
        { 
            using (var context = new EMSDbContext())
            {
                Employee e = convertFromDTO(dto);
                Department dept = context.Departments.Find(dept_id);
                e.Department = dept;
                context.Employees.Add(e);
                context.SaveChanges();
            }
            return "Employee added.";
        }

        public string updateEmployee(int emp_id, EmployeeDTO e)
        {
            using (var context = new EMSDbContext())
            {
                Employee emp = context.Employees.Find(emp_id);
                emp.Name = e.Name;
                emp.Salary = e.Salary;
                context.SaveChanges();
            }   

            return "Employee updated.";
        }

        public string deleteEmployee(int emp_id)
        {
            using (var context = new EMSDbContext())
            {
                var employeeToDelete = context.Employees.Find(emp_id);

                if (employeeToDelete != null)
                {
                    context.Employees.Remove(employeeToDelete);
                    context.SaveChanges();
                }
                else
                {
                    return "Employee not found.";
                }
            }
            return "Employee deleted.";
        }

    }
}
