using CodeYad_Blog.CoreLayer.DTOs.Categories;
using System;

namespace CodeYad_Blog.CoreLayer.DTOs.Posts
{
    public class PostDTO
    {
        public int UserId { get; set; }
        public int CategoryId { get; set; }
        public string Title { get; set; }
        public string Slug { get; set; }
        public string Description { get; set; }
        public int PostId { get; set; }
        public string ImageName { get; set; }
        public CategoryDto Category { get; set; }
        public DateTime  CreationDate { get; set; }
        public int Visit{ get; set; }
    }
}
