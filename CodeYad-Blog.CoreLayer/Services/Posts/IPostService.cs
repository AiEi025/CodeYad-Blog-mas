using CodeYad_Blog.CoreLayer.DTOs.Posts;
using CodeYad_Blog.CoreLayer.Utilities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CodeYad_Blog.CoreLayer.Services.Posts
{
    public interface IPostService
    {
        OperationResult Createpost(CreatePostDTO command);
        OperationResult EditPost(EditPostDTO command);
        PostDTO GetPostById(int postid);
        bool IsSlugExist(string slug);
        PostFilterDTO GetPostsByFilter(PostFilterParams postFilterParams);
    }
}
