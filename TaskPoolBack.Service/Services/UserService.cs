using AutoMapper;
using System;
using System.Collections.Generic;
using System.Text;
using TaskPoolBack.Data.Infrastructure;
using TaskPoolBack.Data.Repositories;
using TaskPoolBack.Model.Models.DB;
using TaskPoolBack.Model.ViewModels;

namespace TaskPoolBack.Service.Services
{
    public class UserService : IUserService
    {
        private readonly IUserRepository userRepository;
        private readonly IUnitOfWork unitOfWork;
        private readonly IMapper mapper;

        public UserService(IUserRepository userRepository, IUnitOfWork unitOfWork,
            IMapper mapper)
        {
            this.userRepository = userRepository;
            this.unitOfWork = unitOfWork;
            this.mapper = mapper;
        }

        public IEnumerable<UserViewModel> Get()
        {
            return mapper.Map<IEnumerable<UserViewModel>>(userRepository.GetAllUser());
        }

        public UserViewModel GetById(int id)
        {
            return mapper.Map<UserViewModel>(userRepository.GetUserById(id));
        }
    }

    public interface IUserService
    {
        IEnumerable<UserViewModel> Get();
        UserViewModel GetById(int id);
    }
}
