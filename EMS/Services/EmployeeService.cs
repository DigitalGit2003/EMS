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
        public string addEmployee(Employee e, string deptName)
        { 
            using (var context = new EMSDbContext())
            {
                Department dept = context.Departments.FirstOrDefault(d => d.Name == deptName);
                e.Department = dept;
                context.Employees.Add(e);
                context.SaveChanges();
            }
            return "Employee added.";
        }

        // ----------------------------------------------------------------------

        //public Employee getEmployee(int emp_id)
        //{
        //    using (var context = new EMSDbContext())
        //    {
        //        Employee emp = context.Employees.Find(emp_id);
        //        return emp;
        //    }
        //}

        // ----------------------------------------------------------------------
        public string updateEmployee(int emp_id, Employee e)
        {
            using (var context = new EMSDbContext())
            {
                Employee emp = context.Employees.Find(emp_id);
                emp.Name = e.Name;
                emp.Salary = e.Salary;
                emp.Department = e.Department;
                context.SaveChanges();
            }   

            return "Employee updated.";
        }

        // ----------------------------------------------------------------------
        public string deleteEmployee(int emp_id)
        {
            using (var context = new EMSDbContext())
            {
                var employeeToDelete = context.Employees.FirstOrDefault(e => e.EmployeeId == emp_id);

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

        // ----------------------------------------------------------------------

        //public ICollection<Employee> getEmployees()
        //{
        //    using (var context = new EMSDbContext())
        //    {
        //        return context.Employees.ToList();
        //    }
        //}

        // ----------------------------------------------------------------------
    }
}
