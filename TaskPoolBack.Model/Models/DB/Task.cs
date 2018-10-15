using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace TaskPoolBack.Model.Models.DB
{
    public class Task
    {
        public int Id { get; set; }
        [Required]
        [StringLength(256)]
        public string Name { get; set; }
        public int? UserId { get; set; }
        public User User { get; set; }
    }
}
