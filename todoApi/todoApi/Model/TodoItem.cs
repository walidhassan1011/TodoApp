using System.ComponentModel.DataAnnotations;

namespace todoApi.Model
{
    public class TodoItem
    {
        [Key ]

        public long Id { get; set; }
        [Required]
        public string? Title { get; set; }


        public string? Description { get; set; } = "";
        [Required]

        public string? Status { get; set; }
    }
}
