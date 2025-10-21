using CodeYad_Blog.CoreLayer.DTOs.Categories;
using CodeYad_Blog.CoreLayer.DTOs.Posts;
using CodeYad_Blog.CoreLayer.Utilities;
using CodeYad_Blog.DataLayer.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CodeYad_Blog.CoreLayer.Mappers
{
    public class PostMapper
    {
        public static Post Map(CreatePostDTO p)
        {
            return new Post()
            {
                CategoryId = p.CategoryId,
                UserId = p.UserId,
                Title = p.Title,
                Slug = p.Slug,
                Description = p.Description,
                IsDelete = false,
                Visit = 0
            };
        }
        public static PostDTO MaptoDTo(Post p)
        {
            return new PostDTO()
            {
                CategoryId = p.CategoryId,
                UserId = p.UserId,
                Title = p.Title,
                Slug = p.Slug,
                Description = p.Description,
                Visit = p.Visit,
                CreationDate = p.CreationDate,
                Category =CategoryMapper.Map(p.Category),
                ImageName = p.ImageName,
                PostId =p.Id
            };
        }
        public static Post mapperToPost(EditPostDTO edit, Post post)
        {
            post.Description = edit.Description;
            post.Title = edit.Title;
            post.Slug = edit.Slug.ToSlug();
            post.CategoryId = edit.CategoryId;
            return post;
        }
    }

}
