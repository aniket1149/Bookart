using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Core.Entities
{
    public class Book :BaseEntity
    {
        [Required]
        [MaxLength(100)]
        public string BookName { get; set; } 
        [Required]
        [MaxLength(180)]
        public string Description { get; set; }
        [Required]
        public decimal Price { get; set; }
        public string PictureUrl { get; set; }
        [Required]
        public Category CategoryName { get; set; }
        public int CategoryId { get; set; }
        [Required]
        public Author BookAuthor { get; set; }
        public int BookAuthorId { get; set; }

        public DateTime? GetDateTime { get; set; }
    } 
}
