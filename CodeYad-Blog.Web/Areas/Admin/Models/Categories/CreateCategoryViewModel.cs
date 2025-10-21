using CodeYad_Blog.CoreLayer.DTOs.Categories;
using System.ComponentModel.DataAnnotations;

namespace CodeYad_Blog.Web.Areas.Admin.Models.Categories
{
    public class CreateCategoryViewModel
    {                                      
        [Display(Name ="عنوان")]                                                
        [Required(ErrorMessage ="وارد کردن {0} اجباری است")]                                       
        public string Title { get; set; }
        [Display(Name = "Slug")]
        [Required(ErrorMessage = "وارد کردن {0} اجباری است")]
        public string Slug { get; set; }                                   
        public int? ParentId { get; set; }                                 
        public string MetaTag { get; set; }
        [DataType(DataType.MultilineText)]
        public string MetaDescription { get; set; }

        public CreateCategoryDto MapDto()
        {
            return new CreateCategoryDto
            {
                Title = Title,
                Slug = Slug,
                ParentId = ParentId,
                MetaDescription = MetaDescription,
                MetaTag = MetaTag
            };
        }
    }
}
