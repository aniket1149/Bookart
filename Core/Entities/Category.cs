using System.ComponentModel.DataAnnotations;

namespace Core.Entities
{
    public class Category: BaseEntity
    {
        [Required]
        public string CategoryName { get; set; }
    }
}