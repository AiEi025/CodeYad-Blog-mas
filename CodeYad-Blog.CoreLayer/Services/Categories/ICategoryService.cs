using CodeYad_Blog.CoreLayer.DTOs.Categories;
using CodeYad_Blog.CoreLayer.Utilities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CodeYad_Blog.CoreLayer.Services.Categories
{
    public interface ICategoryService
    {
        OperationResult CreateCategory(CreateCategoryDto createdto);
        OperationResult EditCategory(EditCategoryDto editCategory);
        List<CategoryDto> GetAllCategory();
        CategoryDto GetCategoryBy(int id);
        CategoryDto GetCategoryBy(string Slug);
        bool IsSlugExist(string slug);
    }
}
