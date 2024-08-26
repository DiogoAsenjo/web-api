using AutoMapper;
using web_api.Data.DTOs;
using web_api.Models;

namespace web_api.Profiles
{
    public class StudentProfile : Profile
    {
        public StudentProfile()
        {
            CreateMap<CreateStudentDTO, Student>();
            CreateMap<UpdateStudentDTO, Student>();
            CreateMap<Student, UpdateStudentDTO>();
            CreateMap<Student, ReadStudentDTO>();
        }
    }
}
