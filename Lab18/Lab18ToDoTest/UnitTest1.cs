using System;
using Xunit;
using Lab18.Controllers;
using Lab18.Models;
using Lab18.Data;
using Microsoft.EntityFrameworkCore;

namespace Lab18ToDoTest
{
    public class UnitTest1
    {
        [Fact]
        public void CanGetAll()
        {
            //Arrange
            var options = new DbContextOptionsBuilder<ToDoAppDbContext>()
                .UseInMemoryDatabase(databaseName: "testDb")
                .Options;
            using (var context = new ToDoAppDbContext(options))
            {
                var controller = new ToDoItemController(context);

                //Add toDoLists
                ToDoList listOne = new ToDoList() { Name = "List One" };
                context.ToDoListsItems.Add(listOne);
                ToDoList listTwo = new ToDoList() { Name = "List Two" };
                context.ToDoListsItems.Add(listTwo);
                ToDoList listThree = new ToDoList() { Name = "List Three" };
                context.ToDoListsItems.Add(listThree);

                context.SaveChanges(); //Save database

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

                //Act
                var results = controller.GetAll();

                //Assert
                Assert.Equal(results, controller.GetAll());
            }
        }
    }
}
