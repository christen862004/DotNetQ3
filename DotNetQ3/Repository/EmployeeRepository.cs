using DotNetQ3.Models;

namespace DotNetQ3.Repository
{
    public class EmployeeRepository:IEmployeeRepository
    {
        ITIContext context;
        public EmployeeRepository(ITIContext _context)//ask ==> register(IOC Cotnainer)
        {
            context =  _context;
        }

        public List<Employee> GetByDeptID(int deptID)
        {
            return context.Employee.Where(e=>e.DeptartmentId == deptID).ToList();
        }

        public List<Employee> GetAll()
        {
            return context.Employee.ToList();
        }

        public Employee GetById(int id)
        {
            return context.Employee.FirstOrDefault(e => e.Id == id);
        }
        public void Insert(Employee obj)
        {
            context.Add(obj);
        }
        public void Update(Employee obj)
        {
            context.Update(obj);
        }
        public void Delete(int id)
        {
            Employee obj = GetById(id);
            context.Remove(obj);
        }
        public void Save()
        {
            context.SaveChanges();
        }
    }
}
