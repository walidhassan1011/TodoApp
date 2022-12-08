using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
namespace todoApi.Models
{
    [Table("todos")]
    public class TodoItemModel
    {
        
        [Key ]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public long Id { get; set; }
        [Required]
        public string? Title { get; set; }

       
        public string? Description { get; set; } = "";
        [Required]

        public string? Status { get; set; } // done, InProgress, todo
    }
}
