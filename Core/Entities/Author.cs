using System.ComponentModel.DataAnnotations;

namespace Core.Entities
{
    public class Author : BaseEntity
    {
        [Required]
        public string AuthorName { get; set; }
    }
}