using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;
using Lab18.Data;
using Lab18.Models;

namespace Lab18.Models
{
    public class SeedData
    {
        public static void Initialize(IServiceProvider serviceProvider)
        {
            using (var context = new ToDoAppDbContext(serviceProvider
                .GetRequiredService<DbContextOptions<ToDoAppDbContext>>()))
            {
                //Check ToDoLists
                if (context.ToDoListsItems.Any()) return; //No need to seed

                //Add toDoLists
                ToDoList listOne = new ToDoList() { Name = "List One" };
                context.ToDoListsItems.Add(listOne);
                ToDoList listTwo = new ToDoList() { Name = "List Two" };
                context.ToDoListsItems.Add(listTwo);
                ToDoList listThree = new ToDoList() { Name = "List Three" };
                context.ToDoListsItems.Add(listThree);

                context.SaveChanges(); //Save database

                //Check ToDo items
                if (context.ToDoItems.Any()) return; //No need to seed

                //Add ToDoItems
                context.ToDoItems.AddRange(
                    new ToDo() { Name = "Item One", List = listOne },
                    new ToDo() { Name = "Item One", List = listTwo },
                    new ToDo() { Name = "Item One", List = listThree },
                    new ToDo() { Name = "Item One", List = listOne },
                    new ToDo() { Name = "Item One", List = listTwo },
                    new ToDo() { Name = "Item One", List = listThree }
                    );

                context.SaveChanges(); //Save database
            }
        }
    }
}
