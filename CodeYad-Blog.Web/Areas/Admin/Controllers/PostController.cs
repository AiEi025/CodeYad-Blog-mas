using CodeYad_Blog.CoreLayer.Services.Posts;
using Microsoft.AspNetCore.Mvc;

namespace CodeYad_Blog.Web.Areas.Admin.Controllers
{
    [Area("Admin")]
    public class PostController : Controller
    {
        private readonly IPostService _postService;
        public PostController(IPostService postService)
        {
            _postService = postService;
        }
        public IActionResult Index(int pageid=1 , string title =null , string categoryslug =null)
        {
            var model = _postService.GetPostsByFilter(new CoreLayer.DTOs.Posts.PostFilterParams()
            {
                CategorySlug = categoryslug,
                PageId = pageid,
                Title = title,
                Take =20
            });
            return View(model);
        }
        public IActionResult Add()
        { 
        return View();
        }
        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Add1()
        {
            return View();
        }
    }
}
