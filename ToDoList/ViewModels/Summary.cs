using System;
using System.Collections.Generic;
using ToDoList.Models;

namespace ToDoList.ViewModels
{
    public class Summary
    {
        public List<ToDoItem> ActiveItems { get; set; }
        public ToDoItem NewItem { get; set; }
    }
}
