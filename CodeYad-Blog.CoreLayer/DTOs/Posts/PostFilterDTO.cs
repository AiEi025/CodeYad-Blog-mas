using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CodeYad_Blog.CoreLayer.DTOs.Posts
{
    public class PostFilterDTO
    {
        public int PageCount { get; set; }
        public List<PostDTO> Posts { get; set; }

        public PostFilterParams PostParams { get; set; }
    }
    public class PostFilterParams
    {
        public int PageId { get; set; }
        public int Take { get; set; }
        public string Title { get; set; }
        public string CategorySlug { get; set; }
    }
}
