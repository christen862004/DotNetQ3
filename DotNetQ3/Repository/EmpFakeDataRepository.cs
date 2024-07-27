using DotNetQ3.Models;

namespace DotNetQ3.Repository
{
    public class EmpFakeDataRepository : IEmployeeRepository
    {
        List<Employee> employees;
        public EmpFakeDataRepository()
        {
            employees=new List<Employee>();
            employees.Add(new Employee() { Id=1,Name="Ahmed",Salary=10000});
            employees.Add(new Employee() { Id = 2, Name = "Alaa", Salary = 10000 });

            employees.Add(new Employee() { Id = 3, Name = "Mohamed", Salary = 10000 });

        }
        public void Delete(int id)
        {
            throw new NotImplementedException();
        }

        public List<Employee> GetAll()
        {
            return employees;   
        }

        public List<Employee> GetByDeptID(int deptID)
        {
            throw new NotImplementedException();
        }

        public Employee GetById(int id)
        {
            throw new NotImplementedException();
        }

        public void Insert(Employee obj)
        {
            throw new NotImplementedException();
        }

        public void Save()
        {
            throw new NotImplementedException();
        }

        public void Update(Employee obj)
        {
            throw new NotImplementedException();
        }
    }
}
