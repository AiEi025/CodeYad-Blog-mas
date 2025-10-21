using CodeYad_Blog.CoreLayer.DTOs.Categories;
using CodeYad_Blog.CoreLayer.Mappers;
using CodeYad_Blog.CoreLayer.Utilities;
using CodeYad_Blog.DataLayer.Context;
using CodeYad_Blog.DataLayer.Entities;
using System;
using System.Collections.Generic;
using System.Linq;

namespace CodeYad_Blog.CoreLayer.Services.Categories
{
    public class CategoryService : ICategoryService
    {
        private readonly BlogContext _blogContext;
        public CategoryService(BlogContext blogContext)
        {
            _blogContext = blogContext;
        }
        public OperationResult CreateCategory(CreateCategoryDto createdto)
        {
            if (IsSlugExist(createdto.Slug))
                return OperationResult.Error("این اسلاگ از قبل موجود میباشد");
            var IsExists = _blogContext.Categories.Any(p => p.Title == createdto.Title && 
            p.ParentId == createdto.ParentId &&
            p.Slug == createdto.Slug.ToSlug() && p.MetaTag == createdto.MetaTag &&
            p.MetaDescription == createdto.MetaDescription);

            if (IsExists)
            {
                return OperationResult.Error("این مورد از قبل موجود بود");
            }
            else
            {
                var category = new Category()
                {
                    Title = createdto.Title,
                    IsDelete = false,
                    ParentId = createdto.ParentId,
                    Slug = createdto.Slug.ToSlug(),
                    MetaTag = createdto.MetaTag,
                    MetaDescription = createdto.MetaDescription,
                };
                _blogContext.Categories.Add(category);
                _blogContext.SaveChanges();
                return OperationResult.Success();
            }
                
        }

        public OperationResult EditCategory(EditCategoryDto editCategory)
        {
            
            var IsExists = _blogContext.Categories.FirstOrDefault(p => p.Id == editCategory.Id);
            if (IsExists == null)
                return OperationResult.NotFound("مورد یافت نشد");
            if (editCategory.Slug.ToSlug() != IsExists.Slug.ToSlug())
                if (IsSlugExist(editCategory.Slug))
                    return OperationResult.Error("ُمعل هس ثطهسف");

            IsExists.MetaDescription = editCategory.MetaDescription;
            IsExists.Slug = editCategory.Slug.ToSlug();
            IsExists.Title = editCategory.Title;
            IsExists.MetaTag = editCategory.MetaTag;
            _blogContext.SaveChanges();
            return OperationResult.Success();
        }

        public List<CategoryDto> GetAllCategory() 
        {
            return _blogContext.Categories.Where(p=>p.IsDelete ==false).Select(p=> 
            CategoryMapper.Map(p)).ToList();
        }

        public CategoryDto GetCategoryBy(int id)
        {
            var category = _blogContext.Categories.FirstOrDefault(p=>p.Id == id);
            if (category is null)
            return null;
            return CategoryMapper.Map(category);
        }

        public CategoryDto GetCategoryBy(string Slug)
        {
            var category = _blogContext.Categories.FirstOrDefault(p => p.Slug == Slug);
            if (category is null)
                return null;
            return CategoryMapper.Map(category);
        }

        public bool IsSlugExist(string slug)
        {
            return _blogContext.Categories.Any(p => p.Slug == slug.ToSlug());
        }
    }
}
