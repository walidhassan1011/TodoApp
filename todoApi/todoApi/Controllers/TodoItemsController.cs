

using Microsoft.AspNetCore.Mvc;
using todoApi.Model;
using todoApi.Models;

namespace todoApi.Controllers
{

    [Route("api/[controller]")]
    [ApiController]
    [ApiConventionType(typeof(DefaultApiConventions))]
    public class TodoItemsController : ControllerBase
    {

        private readonly DbHelper _dbHelper;

        public TodoItemsController(DataContext dataContext)
        {
            _dbHelper = new DbHelper(dataContext);
        }

        

        
        // GET: api/TodoItems
        [HttpGet]
        [Produces("application/json")]
        public ActionResult< List<TodoItem>> Get()
        {
            IEnumerable<TodoItem> todoList = _dbHelper.GetTodos();
            return Ok(todoList);
        }

        // GET: api/TodoItems/1
        [HttpGet("{id}", Name = "Get")]
        [Produces("application/json")]
        public ActionResult <TodoItemModel> GetById(long id)
        {
            TodoItem? todoItem = _dbHelper.GetTodoById(id);
            if (todoItem == null)
            {
                return NotFound();
            }
            return Ok(todoItem);
        }
        

        // POST: api/TodoItems
        [HttpPost]
        [Consumes("application/json")]
        public ActionResult Post( TodoItem todoItem)
        {
            if (todoItem == null)
            {
                return BadRequest();
            }
            _dbHelper.AddTodoItem(todoItem);
            return Ok();
        }

        // PUT: api/TodoItems/5
        [HttpPut("{id}")]
        [Consumes("application/json")]
        public ActionResult Put(long id, TodoItem todoItem)
            
        {
           TodoItem? todo= _dbHelper.UpdateTodoItem(id, todoItem);
            if (todo == null)
            {
                return NotFound();
            }
            return Ok(todoItem);

        }

        // DELETE: api/ApiWithActions/5
        [HttpDelete("{id}")]
        public ActionResult Delete(int id)
        {
            string Mess=_dbHelper.DeleteTodoItem(id);
            if (Mess == "Not Found")
            {
                
                    return NotFound();
                
            }
            return Ok();

        }
      
    }
}
