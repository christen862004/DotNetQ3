using DotNetQ3.Models;

namespace DotNetQ3.Repository
{
    public class DepartmentRepository:IDepartmentRepository
    {
        //CRUD
        ITIContext context;

        public string Id { get ; set; }

        public DepartmentRepository(ITIContext _Context)
        {
            context = _Context;// new ITIContext();
            Id = Guid.NewGuid().ToString();//object unique id
        }

        public List<Department> GetAll()
        {
            return context.Department.ToList();
        }

        public Department GetById(int id)
        {
            return context.Department.FirstOrDefault(d => d.Id == id);
        }
        public void Insert(Department obj)
        {
            context.Add(obj);
        }
        public void Update(Department obj)
        {
            context.Update(obj);
        }
        public void Delete(int id)
        {
            Department obj=GetById(id);
            context.Remove(obj);
        }
        public void Save()
        {
            context.SaveChanges();
        }
    }
}
