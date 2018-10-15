using System;
using System.Collections.Generic;
using System.Linq;
using Microsoft.AspNetCore.Mvc;
using TaskPoolBack.Model.Models.DB;
using TaskPoolBack.Model.ViewModels;
using TaskPoolBack.Service.Services;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace TaskPoolBack.Controllers
{
    [Route("api/user")]
    public class UserController : Controller
    {
        private readonly IUserService userService;

        public UserController(IUserService userService)
        {
            this.userService = userService;
        }

        /// <summary>
        /// get users with taska
        /// </summary>
        /// <returns></returns>
        [ProducesResponseType(200, Type = typeof(IEnumerable<UserViewModel>))]
        [ProducesResponseType(401)]
        [ProducesResponseType(403)]
        [HttpGet]
        public IActionResult Get()
        {
            return Ok(userService.Get());
        }

        /// <summary>
        /// get user with taska by id
        /// </summary>
        /// <returns></returns>
        [ProducesResponseType(200, Type = typeof(UserViewModel))]
        [ProducesResponseType(401)]
        [ProducesResponseType(403)]
        [HttpGet("{id}")]
        public IActionResult Get(int id)
        {
            return Ok(userService.GetById(id));
        }
    }
}
