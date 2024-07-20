using Microsoft.EntityFrameworkCore;

namespace DotNetQ3.Models
{
    public class ITIContext:DbContext
    {
        public DbSet<Employee> Employee { get; set; }
        public DbSet<Department> Department { get; set; }
        //Server name | server type | Login | Database "Connection string"

        public ITIContext() : base()
        { }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseSqlServer("Data Source=.;Initial Catalog=DotNet_Q3;Integrated Security=True;Encrypt=False;Trust Server Certificate=False");
            base.OnConfiguring(optionsBuilder);
        }
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Department>().HasData(new Department() { Id = 1, Name = "SD", ManagerName = "Ahemd" });
            modelBuilder.Entity<Department>().HasData(new Department() { Id = 2, Name = "Open Sourse", ManagerName = "Moohamed" });
            modelBuilder.Entity<Department>().HasData(new Department() { Id = 3, Name = "AI", ManagerName = "Marwa" });

            
            modelBuilder.Entity<Employee>().HasData(new Employee() { Id = 1, Name = "Yossef", ImageUrl = "1.png", Salary = 2000, Address = "alex", JobTitle = "BackEnd Developer", DeptartmentId = 1 });
            modelBuilder.Entity<Employee>().HasData(new Employee() { Id = 2, Name = "Ahmed Kamel", ImageUrl = "1.png", Salary = 2000, Address = "alex", JobTitle = "BackEnd Developer", DeptartmentId = 2 });
            modelBuilder.Entity<Employee>().HasData(new Employee() { Id = 3, Name = "Mohamed younes", ImageUrl = "1.png", Salary = 2000, Address = "alex", JobTitle = "BackEnd Developer", DeptartmentId = 3 });

            base.OnModelCreating(modelBuilder);
        }
    }
}
