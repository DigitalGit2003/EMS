using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


namespace EMS
{
    public class EMSDbContext : DbContext
    {
        public DbSet<Employee> Employees { get; set; }
        public DbSet<Department> Departments { get; set; }
        public DbSet<Project> Projects { get; set; }
        public EMSDbContext() : base("EMSConnection")
        {

        }

        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {

            // Configure cascading delete for Department-Employee relationship
            modelBuilder.Entity<Department>()
                .HasMany(d => d.Employees)
                .WithRequired(e => e.Department)
                .HasForeignKey(e => e.DepartmentId)
                .WillCascadeOnDelete(true);

            // Configure cascading delete for Department-Project relationship
            modelBuilder.Entity<Department>()
                .HasMany(d => d.Projects)
                .WithRequired(p => p.Department)
                .HasForeignKey(p => p.DepartmentId)
                .WillCascadeOnDelete(false) ;
        }
    }
}
