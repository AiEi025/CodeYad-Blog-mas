using System.ComponentModel.DataAnnotations;

namespace CodeYad_Blog.Web.Areas.Admin.Models.Categories
{
    public class EditCategoryViewModel 
    {
        [Display(Name = "عنوان")]
        [Required(ErrorMessage = "وارد کردن {0} اجباری است")]
        public string Title { get; set; }
        [Display(Name = "Slug")]
        [Required(ErrorMessage = "وارد کردن {0} اجباری است")]
        public string Slug { get; set; }
        public string MetaTag { get; set; }
        [DataType(DataType.MultilineText)]
        public string MetaDescription { get; set; }
    }
}
