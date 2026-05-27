using Practical_17.Application.DTOs.Student;
using Practical_17.Application.Interfaces.Services;
using Practical_17.Application.Interfaces.UnitOfWork;
using Practical_17.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Practical_17.Application.Services
{
    public class StudentService : IStudentService
    {
        private readonly IUnitOfWork _unitOfWork;
        public StudentService(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }

        public async Task<IEnumerable<StudentDto>> GetAllAsync()
        {
            var students = await _unitOfWork.Students.GetAllAsync();
            return students.Select(x => new StudentDto
            {
                Id = x.Id,
                FirstName = x.FirstName,
                LastName = x.LastName,
                Email = x.Email,
                Age = x.Age,
                Course = x.Course
            });
        }

        public async Task<StudentDto?> GetByIdAsync(int id)
        {
            var student = await _unitOfWork.Students.GetById(id);
            if(student == null)
            {
                return null;
            }
            return new StudentDto
            {
                Id = student.Id,
                FirstName = student.FirstName,
                LastName = student.LastName,
                Email = student.Email,
                Age = student.Age,
                Course = student.Course
            };
        }
        public async Task CreateAsync(CreateStudentDto dto)
        {
            var student = new Student
            {
                FirstName = dto.FirstName,
                LastName = dto.LastName,
                Email = dto.Email,
                Age = dto.Age,
                Course = dto.Course
            };
            await _unitOfWork.Students.AddAsync(student);
            await _unitOfWork.SaveChangesAsync();
        }

        public async Task DeleteAsync(int id)
        {
            var student = await _unitOfWork.Students.GetById(id);
            if (student == null)
            {
                throw new Exception("Student not found");
            }

            _unitOfWork.Students.Delete(student);
            await _unitOfWork.SaveChangesAsync();
        }


        public async Task UpdateAsync(int id, UpdateStudentDto dto)
        {
            var student = await _unitOfWork.Students.GetById(id);
            if (student == null)
            {
                throw new Exception("Student not found");
            }

            student.FirstName = dto.FirstName;
            student.LastName = dto.LastName;
            student.Email = dto.Email;
            student.Age = dto.Age;
            student.Course = dto.Course;

            _unitOfWork.Students.Update(student);
            await _unitOfWork.SaveChangesAsync();
        }
    }
}
