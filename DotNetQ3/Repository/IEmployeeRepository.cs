using DotNetQ3.Models;

namespace DotNetQ3.Repository
{
    public interface IEmployeeRepository
    {
        List<Employee> GetByDeptID(int deptID);
        List<Employee> GetAll();
        Employee GetById(int id);
        void Insert(Employee obj);
        void Update(Employee obj);
        void Delete(int id);
        void Save();
    }
}