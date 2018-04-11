using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Lab18.Models;

namespace Lab18.Data
{
    public class ToDoAppDbContext : DbContext
    {
        public ToDoAppDbContext(DbContextOptions<ToDoAppDbContext> options) : base(options){}

        public DbSet<ToDo> ToDoItems { get; set; }
        public DbSet<ToDoList> ToDoListsItems { get; set; }
    }
}
