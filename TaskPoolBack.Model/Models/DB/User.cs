using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace TaskPoolBack.Model.Models.DB
{
    public class User
    {
        public int Id { get; set; }
        [Required]
        [StringLength(32)]
        public string Name { get; set; }
        [Required]
        [StringLength(32)]
        public string Surname { get; set; }
        public ICollection<Task> Tasks { get; set; }

        public User()
        {
            Tasks = new HashSet<Task>();
        }
    }
}
