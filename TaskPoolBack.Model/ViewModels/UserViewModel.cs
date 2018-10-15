using System;
using System.Collections.Generic;
using System.Text;

namespace TaskPoolBack.Model.ViewModels
{
    public class UserViewModel
    {
        public int Id { get; set; }
        public string FullName { get; set; }

        public ICollection<TaskViewModel> Tasks { get; set; }
    }
}
