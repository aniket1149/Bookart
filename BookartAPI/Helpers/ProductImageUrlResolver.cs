using AutoMapper;
using BookartAPI.DTO;
using Core.Entities;
using Microsoft.Extensions.Configuration;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace BookartAPI.Helpers
{
    public class ProductImageUrlResolver : IValueResolver<Book, BookReturnToDto, string>
    {
        private readonly IConfiguration _config;

        public ProductImageUrlResolver(IConfiguration config)
        {
            _config = config;
        }

        public string Resolve(Book source, BookReturnToDto destination, string destMember, ResolutionContext context)
        {
            if (!string.IsNullOrEmpty(source.PictureUrl)) {
                return _config["ApiUrl"] + source.PictureUrl;
            }

            return null;
        }
    }
}
