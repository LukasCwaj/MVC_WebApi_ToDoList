using Microsoft.EntityFrameworkCore;
using MVC_WebApi_ToDoList.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MVC_WebApi_ToDoList.DAL
{
    public class ToDoListContext : DbContext
    {
        /*public ToDoListContext (DbContextOptions<ToDoListContext> options): base(options)
        {

        }*/

        public ToDoListContext()
        {
            this.Database.EnsureCreated();
        }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseSqlite(connectionString: "Filename=./sqlite");
        }

        public DbSet<ToDoList> ToDoList { get; set; }
    }
}
