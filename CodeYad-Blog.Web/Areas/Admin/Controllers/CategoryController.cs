using CodeYad_Blog.CoreLayer.DTOs.Categories;
using CodeYad_Blog.CoreLayer.Services.Categories;
using CodeYad_Blog.Web.Areas.Admin.Models.Categories;
using Microsoft.AspNetCore.Mvc;
using System;

namespace CodeYad_Blog.Web.Areas.Admin.Controllers
{
    [Area("Admin")]
    public class CategoryController : Controller
    {
        private readonly ICategoryService _categoryService;
        public CategoryController(ICategoryService categoryService)
        {
            _categoryService = categoryService;
        }
        public IActionResult Index()
        {
            return View(_categoryService.GetAllCategory());
        }
       // [Route("Admin/category/add/{parentid?}")]
        public IActionResult Add(int? parentid)
        {
            var model = new CreateCategoryViewModel()
            { 
            ParentId = parentid
            };
            return View(model);
        }

        [HttpPost]
        public IActionResult Add(int? parentid,CreateCategoryViewModel viewModel)
        {
            viewModel.ParentId = parentid;
            var result = _categoryService.CreateCategory(viewModel.MapDto());
            if (result.Status == CoreLayer.Utilities.OperationResultStatus.Error)
            {
                ModelState.AddModelError("UserName",  " است این دسته از قبل  موجود ");
                return View();
            }
            if (result.Status != CoreLayer.Utilities.OperationResultStatus.Success)
            {
                ModelState.AddModelError(nameof(viewModel.Slug), result.Message);
                return View();
            }
            return RedirectToAction("Index");
        }
        public IActionResult Edit(int id)
        {
            var category = _categoryService.GetCategoryBy(id);
            if (category is null)
                return RedirectToAction("Index");
            var model = new EditCategoryViewModel()
            {
                Slug = category.Slug,
                MetaDescription = category.MetaDescription,
                MetaTag = category.MetaTag,
                Title = category.Title
            };
            return View(model);
        }
        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Edit(int id,EditCategoryViewModel viewModel)
        {
            var category = _categoryService.GetCategoryBy(id);
            if (category is null)
                return RedirectToAction("Index");

            var result = _categoryService.EditCategory(new EditCategoryDto()
            {
                Slug = viewModel.Slug,
                MetaDescription = viewModel.MetaDescription,
                MetaTag = viewModel.MetaTag,
                Title = viewModel.Title,
                Id =id
            });
            if (result.Status != CoreLayer.Utilities.OperationResultStatus.Success)
            {
                ModelState.AddModelError(nameof(viewModel.Slug), result.Message);
                return View();
            }
            return RedirectToAction("Index");
        }
    }
}
