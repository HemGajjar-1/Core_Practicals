using AutoMapper;
using Practical_18.Application.Interfaces;
using Practical_18.Application.ViewModels;
using Practical_18.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Practical_18.Application.Services
{
    public class StudentService : IStudentService
    {
        private readonly IUnitOfWork _unitOfWork;
        private readonly IMapper _mapper;

        public StudentService(IUnitOfWork unitOfWork,IMapper mapper)
        {
            _unitOfWork = unitOfWork;
            _mapper = mapper;
        }

        public async Task<IEnumerable<StudentViewModel>> GetAllAsync()
        {
            var students = await _unitOfWork.Students.GetAllAsync();
            return _mapper.Map<List<StudentViewModel>>(students);
        }

        public async Task<StudentViewModel?> GetByIdAsync(int id)
        {
            var student = await _unitOfWork.Students.GetByIdAsync(id);
            if(student == null)
            {
                return null;
            }
            return _mapper.Map<StudentViewModel>(student);
        }
        public async Task CreateAsync(StudentViewModel studentmodel)
        {
            var student = _mapper.Map<Student>(studentmodel);
            await _unitOfWork.Students.AddAsync(student);
            await _unitOfWork.CompleteAsync();
        }
        public async Task<bool> UpdateAsync(StudentViewModel studentmodel)
        {
            var student = await _unitOfWork.Students.GetByIdAsync(studentmodel.Id);
            if(student == null)
            {
                return false;
            }
            _mapper.Map(studentmodel,student);
            _unitOfWork.Students.Update(student);
            await _unitOfWork.CompleteAsync();
            return true;
        }

        public async Task<bool> DeleteAsync(int id)
        {
            var student = await _unitOfWork.Students.GetByIdAsync(id);
            if(student == null)
            {
                return false;
            }
            _unitOfWork.Students.Delete(student);
            await _unitOfWork.CompleteAsync();
            return true;
        }


    }
}
