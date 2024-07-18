namespace DotNetQ3.Models
{
    public class StudentBL
    {
        List<Student> students;
        public StudentBL()
        {
            students = new List<Student>();
            students.Add(new Student() { Id=1,Name="Ahmed",Address="Alex",ImageUrl="1.png"});
            students.Add(new Student() { Id = 2, Name = "Ali", Address = "Alex", ImageUrl = "1.png" });
            students.Add(new Student() { Id = 3, Name = "Mary", Address = "Alex", ImageUrl = "2.jpg" });
            students.Add(new Student() { Id = 4, Name = "Abdo", Address = "Alex", ImageUrl = "1.png" });

        }
        public List<Student> getAll() {
            return students;
        }
        public Student  GetByID(int id)
        {
            return students.FirstOrDefault(s => s.Id == id);
        }
    }
}
