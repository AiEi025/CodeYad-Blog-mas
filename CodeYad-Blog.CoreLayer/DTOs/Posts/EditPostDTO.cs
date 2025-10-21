namespace CodeYad_Blog.CoreLayer.DTOs.Posts
{
    public class EditPostDTO
    {
        public int CategoryId { get; set; }
        public string Title { get; set; }
        public string Slug { get; set; }
        public string Description { get; set; }
        public int PostId { get; set; }
    }
}
