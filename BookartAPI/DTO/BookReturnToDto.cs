using Core.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace BookartAPI.DTO
{
    public class BookReturnToDto
    {
        public int Id { get; set; }
       
        public string BookName { get; set; }
      
        public string Description { get; set; }
        
        public decimal Price { get; set; }
        public string PictureUrl { get; set; }
        
        public string CategoryName { get; set; }
       
        public string BookAuthor { get; set; }
        
    }
}
