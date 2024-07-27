using DotNetQ3.Models;

namespace DotNetQ3.Repository
{
    public interface IDepartmentRepository
    {
        string Id { get; set; }

        List<Department> GetAll();
        Department  GetById(int id);
        void Insert(Department obj);
        void Update(Department obj);
        void Delete(int id);
        void Save();
    }
}