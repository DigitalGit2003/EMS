using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EMS.Services
{
    public class DepartmentService : IDepartmentService
    {

        // ----------------------------------------------------------------------

        //public Department getDepartment(int dept_id)
        //{
        //    using (var context = new EMSDbContext())
        //    {
        //        Department dept = context.Departments.Find(dept_id);
        //        return dept;
        //    }
        //}

        //public ICollection<Department> getDepartments()
        //{
        //    using (var context = new EMSDbContext())
        //    {
        //        return context.Departments.ToList();
        //    }
        //}

        // ----------------------------------------------------------------------
        public string addDepartment(Department d)
        {
            using (var context = new EMSDbContext())
            {
                context.Departments.Add(d);
                context.SaveChanges();
            }
            return $"Department {d.Name} is added.";
        }

        public string updateDepartment(int dept_id, Department d)
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

        public string deleteDepartment(string dept_name)
        {
            using (var context = new EMSDbContext())
            {
                var departmentToDelete = context.Departments.FirstOrDefault(d => d.Name == dept_name);

                if (departmentToDelete != null)
                {
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


        public List<string> getDepartmentNames()
        {
            using (var context = new EMSDbContext())
            {
                return context.Departments.Select(d => d.Name).ToList();
            }
        }

        public List<string> getDepartmentLocations()
        {
            using(var context = new EMSDbContext())
            {
                return context.Departments.Select(d => d.Location).ToList();
            }
        }


    }
}
