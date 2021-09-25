﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Core.Specification
{
    public class BookSpecParams
    {
        private const int MaxPageSize = 50;
        public int PageIndex { get; set; } = 1;
        private int _pageSize = 16;
        public int PageSize
        {
            get => _pageSize;
            set => _pageSize = (value > MaxPageSize) ? MaxPageSize : value;
        }
         public int? categoryId { get; set; }
        public int? authorId { get; set; }

        public string sort { get; set; }

        private string _search;

        public string search
        {
            get => _search;
            set => _search = value.ToLower();
        }
    }
}
