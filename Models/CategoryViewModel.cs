﻿using RedForums.Data.Mapping;
using RedForums.Data.Models;

namespace RedForums.Models
{
    public class CategoryViewModel : IMapFrom<Category>
    {
        public string Name { get; set; }

        public string? Description { get; set; }

        public int PostsCount { get; set; } 
    }
}
