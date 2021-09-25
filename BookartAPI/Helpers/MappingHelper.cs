using AutoMapper;
using BookartAPI.DTO;
using Core.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace BookartAPI.Helpers
{
    public class MappingHelper : Profile
    {
        public MappingHelper()
        {
            CreateMap<Book, BookReturnToDto>()
                .ForMember(d => d.CategoryName, o => o.MapFrom(s => s.CategoryName.CategoryName))
                .ForMember(d => d.BookAuthor, o => o.MapFrom(s => s.BookAuthor.AuthorName))
                .ForMember(d=>d.PictureUrl, o=>o.MapFrom<ProductImageUrlResolver>());
        }
    }
}
