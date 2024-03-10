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

        public EmployeeDTO getEmployee(string emp_name)
        {
            using (var context = new EMSDbContext())
            {
                Employee emp = context.Employees.FirstOrDefault(ee => ee.Name == emp_name);
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

        public List<EmployeeDTO> getEmployeesByDepartmentName(string dept_name)
        {
            using (var context = new EMSDbContext())
            {
                Department dept = context.Departments.FirstOrDefault(d => d.Name == dept_name);

                List<Employee> emps = context.Employees.Where(e => e.DepartmentId == dept.DepartmentId).ToList();
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
        public string addEmployee(EmployeeDTO dto, string deptName)
        { 
            using (var context = new EMSDbContext())
            {
                Employee e = convertFromDTO(dto);
                Department dept = context.Departments.FirstOrDefault(d => d.Name == deptName);
                e.Department = dept;
                context.Employees.Add(e);
                context.SaveChanges();
            }
            return "Employee added.";
        }

        public string updateEmployee(string emp_name, EmployeeDTO e)
        {
            using (var context = new EMSDbContext())
            {
                Employee emp = context.Employees.FirstOrDefault(ee => ee.Name == emp_name);
                emp.Name = e.Name;
                emp.Salary = e.Salary;
                context.SaveChanges();
            }   

            return "Employee updated.";
        }

        public string deleteEmployee(string emp_name)
        {
            using (var context = new EMSDbContext())
            {
                var employeeToDelete = context.Employees.FirstOrDefault(e => e.Name == emp_name);

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
