using Microsoft.AspNetCore.Mvc;
using todoApi.Models;
using todoApi.Model;

namespace todoApi.Model
{
    public class DbHelper
    {
        private DataContext _context;
        public DbHelper(DataContext context)
        {
            _context = context;
        }
        public List<TodoItem> GetTodos()
        {
            List<TodoItem> todoList = new List<TodoItem>();
            var dataList = _context.Todos.ToList();
            if (dataList.Count <= 0)
            {
                return todoList;
            }
            dataList.ForEach(x =>
            {
                todoList.Add(new TodoItem()
                {
                    Id = x.Id,
                    Title = x.Title,
                    Description = x.Description,
                    Status = x.Status
                });
            });
            return todoList;
        }
        public TodoItem? GetTodoById(long id)
        {
            var data = _context.Todos.Find(id);
            if (data == null)
            {
                return null;
            }
            return new TodoItem()
            {
                Id = data.Id,
                Title = data.Title,
                Description = data.Description,
                Status = data.Status
            };
        }
        public void AddTodoItem(TodoItem todoItem)
        {
            
            var data = new TodoItemModel()
            {
                Id = todoItem.Id,
                Title = todoItem.Title,
                Description = todoItem.Description,
                Status = todoItem.Status
            };
            _context.Todos.Add(data);
            _context.SaveChanges();
           
        }
        public TodoItem? UpdateTodoItem(long id,TodoItem todoItem)
        {
            var data = _context.Todos.Find(id);
            if (data == null)
            {
                return null;
            }
        
            data.Title = todoItem.Title;
            data.Description = todoItem.Description;
            data.Status = todoItem.Status;
            _context.Todos.Update(data);
            _context.SaveChanges();
            return todoItem;
        }

        public string DeleteTodoItem(long id)
        {
            var data = _context.Todos.Find(id);
            if (data == null)
            {
                return "Not Found";

            }
            _context.Todos.Remove(data);
            _context.SaveChanges();
            return "deleted success";
        }
        
        
    }
}
