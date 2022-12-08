using Microsoft.EntityFrameworkCore;
using todoApi.Model;

namespace todoApi.Models
{
    public class DataContext:DbContext
    {
        public DataContext(DbContextOptions<DataContext> options) : base(options)
        {
        }
       
        
        public DbSet<TodoItemModel>Todos { get; set; }
    }
}
