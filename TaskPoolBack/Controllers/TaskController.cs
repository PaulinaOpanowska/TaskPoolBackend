using System;
using System.Collections.Generic;
using System.Linq;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using TaskPoolBack.Model.ViewModels;
using TaskPoolBack.Service.Services;

namespace TaskPoolBack.Controllers
{
    [Route("api/task")]
    [ApiController]
    public class TaskController : ControllerBase
    {
        private readonly ITaskService taskService;

        public TaskController(ITaskService taskService)
        {
            this.taskService = taskService;
        }

        /// <summary>
        /// get unasigned tasks
        /// </summary>
        /// <returns></returns>
        [ProducesResponseType(200, Type = typeof(IEnumerable<TaskViewModel>))]
        [ProducesResponseType(401)]
        [ProducesResponseType(403)]
        [HttpGet]
        public IActionResult UnasignedTasks()
        {
            return Ok(taskService.UnasignedTasks());
        }

        /// <summary>
        /// Edit user's tasks
        /// </summary>
        /// <param name="userId"></param>
        /// <param name="taskId"></param>
        /// <returns></returns>
        [ProducesResponseType(401)]
        [ProducesResponseType(403)]
        [ProducesResponseType(400)]
        [HttpPut]
        public IActionResult Put([FromQuery] int userId, [FromQuery] int taskId)
        {
            taskService.UpdateUserTasks(userId, taskId);
            return Ok();
        }
    }
}
