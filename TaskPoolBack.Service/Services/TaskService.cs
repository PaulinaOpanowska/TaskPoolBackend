using AutoMapper;
using System;
using System.Collections.Generic;
using System.Text;
using TaskPoolBack.Data.Infrastructure;
using TaskPoolBack.Data.Repositories;
using TaskPoolBack.Model.ViewModels;

namespace TaskPoolBack.Service.Services
{
    public class TaskService : ITaskService
    {
        private readonly ITaskReporitory taskRepository;
        private readonly IUnitOfWork unitOfWork;
        private readonly IMapper mapper;

        public TaskService(ITaskReporitory taskRepository, IUnitOfWork unitOfWork,
            IMapper mapper)
        {
            this.taskRepository = taskRepository;
            this.unitOfWork = unitOfWork;
            this.mapper = mapper;
        }

        public IEnumerable<TaskViewModel> UnasignedTasks()
        {
            return mapper.Map<IEnumerable<TaskViewModel>>(taskRepository.GetMany(x => x.UserId == null));
        }

        public void UpdateUserTasks(int userId, int taskId)
        {
            var task = taskRepository.GetById(taskId);
            task.UserId = userId;

            taskRepository.Update(task);
            unitOfWork.Commit();
        }
    }

    public interface ITaskService
    {
        IEnumerable<TaskViewModel> UnasignedTasks();
        void UpdateUserTasks(int userId, int taskId);
    }
}
