using Practical_17.Models.Entity;
using Practical_17.Models.Repository;

namespace Practical_17.Models.Service
{
    public class StudentService : IStudentService
    {
        private readonly IGenericRepository<Student> _repo;
        public StudentService(IGenericRepository<Student> repo)
        {
            _repo = repo;
        }
        public IEnumerable<Student> GetAll()
        {
            return _repo.GetAll();
        }
        public Student GetById(int id)
        {
            return _repo.GetById(id);
        }
        public void Add(Student student)
        {
            _repo.Insert(student);
            _repo.Save();
        }
        public void Update(Student student)
        {
            _repo.Update(student);
            _repo.Save();
        }
        public void Delete(int id)
        {
            _repo.Delete(id);
            _repo.Save();
        }
    }
}
