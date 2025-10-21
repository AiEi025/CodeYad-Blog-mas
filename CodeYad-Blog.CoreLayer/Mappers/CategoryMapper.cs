using CodeYad_Blog.CoreLayer.DTOs.Categories;
using CodeYad_Blog.DataLayer.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CodeYad_Blog.CoreLayer.Mappers
{
    public class CategoryMapper
    {
        public static CategoryDto Map(Category p)
        { 
        return new CategoryDto()
        {
            MetaDescription = p.MetaDescription,
            Title = p.Title,
            MetaTag = p.MetaTag,
            Slug = p.Slug,
            ParentId = p.ParentId,
            Id = p.Id
        };
        }
    }
}
