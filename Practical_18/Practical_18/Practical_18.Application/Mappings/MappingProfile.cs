using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime;
using System.Text;
using System.Threading.Tasks;
using AutoMapper;
using Practical_18.Application.ViewModels;
using Practical_18.Domain.Entities;
namespace Practical_18.Application.Mappings
{
    public class MappingProfile : Profile
    {
        public MappingProfile()
        {
            CreateMap<Student, StudentViewModel>();
            CreateMap<StudentViewModel, Student>();
        }
    }
}
