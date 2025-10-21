using Microsoft.AspNetCore.Http;
using System.ComponentModel.DataAnnotations;

namespace CodeYad_Blog.Web.Areas.Admin.Models.Posts
{
    public class CreatePostViewModel
    {
        public int? SubCategoryId { get; set; }
        public int CategoryId { get; set; }
        public string Title { get; set; }
        public string Slug { get; set; }
        [UIHint("CkEditor4")]
        public string Description { get; set; }
        public IFormFile ImageFile { get; set; }
    }
}
