using CodeYad_Blog.CoreLayer.DTOs.Posts;
using CodeYad_Blog.CoreLayer.Mappers;
using CodeYad_Blog.CoreLayer.Utilities;
using CodeYad_Blog.DataLayer.Context;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static Microsoft.EntityFrameworkCore.DbLoggerCategory.Database;

namespace CodeYad_Blog.CoreLayer.Services.Posts
{
    public class PostService : IPostService
    {
        private readonly BlogContext _blogContext;
        public PostService(BlogContext blogContext)
        {
            _blogContext = blogContext;
        }
        public OperationResult Createpost(CreatePostDTO command)
        {
           var post = PostMapper.Map(command);
            _blogContext.Posts.Add(post);
            _blogContext.SaveChanges();
            return OperationResult.Success();
            
        }

        public OperationResult EditPost(EditPostDTO command)
        {
            var post = _blogContext.Posts.FirstOrDefault(p=>p.Id == command.PostId);
            if(post is null)
                return OperationResult.Error("متن مورد نظر یافت نشد");
            PostMapper.mapperToPost(command, post);
            _blogContext.SaveChanges();
            return OperationResult.Success();
        }

        public PostDTO GetPostById(int postid)
        {
            var post = _blogContext.Posts.FirstOrDefault(p => p.Id == postid);

            return PostMapper.MaptoDTo(post);
        }

        public PostFilterDTO GetPostsByFilter(PostFilterParams postFilterParams)
        {
            var result = _blogContext.Posts.OrderByDescending(p=>p.CreationDate).AsQueryable();
            if (!String.IsNullOrWhiteSpace(postFilterParams.CategorySlug))
            {
                result = result.Where(r => r.Category.Slug == postFilterParams.CategorySlug);
            }
            if (!String.IsNullOrWhiteSpace(postFilterParams.Title))
            {
                result = result.Where(r => r.Title.Contains(postFilterParams.Title));
            }
            var skip = (postFilterParams.PageId - 1) * postFilterParams.Take;
            var pagecount = result.Count() / postFilterParams.Take;
            return new PostFilterDTO()
            {
                Posts = result.Skip(skip).Take(postFilterParams.Take).Select(Post => PostMapper.MaptoDTo(Post)).ToList(),
                PostParams = postFilterParams,
                PageCount = pagecount
            };
        }

        public bool IsSlugExist(string slug)
        {
            return _blogContext.Posts.Any(p => p.Slug == slug.ToSlug());
        }
    }
}
