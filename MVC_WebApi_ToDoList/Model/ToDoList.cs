using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace MVC_WebApi_ToDoList.Model
{
    public class ToDoList
    {
        [Required, Key]
        public int Id { get; set; }

        [Required]
        [Column(TypeName = "varchar(50)")]
        public string Title { get; set; }

        [Required]
        [Column(TypeName = "varchar(1000)")]
        public string Description { get; set; }

        [Required]
        [Column(TypeName = "bit")]
        public bool IsCompleted { get; set; }
    }
}
