using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ToDoListMVC.Models
{
    public class TodoViewModel
    {
        public TodoItem[] Items { get; set; }
        public TodoItem[] MarkedDoneItems { get; set; }
    }
}
