using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Lab18.Models
{
    public class ToDo
    {
        public int ID { get; set; }
        public string Name { get; set; }
        public DateTime DueDate { get; set; }
        public ToDoList List { get; set; }
        public bool IsDone { get; set; }
    }
}
