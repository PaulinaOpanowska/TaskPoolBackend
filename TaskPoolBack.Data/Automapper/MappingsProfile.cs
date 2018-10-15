using AutoMapper;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using TaskPoolBack.Model.Models.DB;
using TaskPoolBack.Model.ViewModels;

namespace TaskPoolBack.Data.Automapper
{
    public class MappingsProfile : Profile
    {
        public MappingsProfile()
        {
            CreateMap<Task, TaskViewModel>()
            .ForMember(dest => dest.Id, opt => opt.MapFrom(src => src.Id))
            .ForMember(dest => dest.Name, opt => opt.MapFrom(src => src.Name))
            .ReverseMap();

            CreateMap<User, UserViewModel>()
            .ForMember(dest => dest.Id, opt => opt.MapFrom(src => src.Id))
            .ForMember(dest => dest.FullName, opt => opt.MapFrom(src => src.Name + " " + src.Surname))
            .ForMember(dest => dest.Tasks, opt => opt.MapFrom(src => src.Tasks.Select(x => new TaskViewModel
                {
                    Id = x.Id,
                    Name = x.Name
                }).ToArray()))
            .ReverseMap();
        }
    }
}
