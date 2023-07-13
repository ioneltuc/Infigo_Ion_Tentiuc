namespace CMSPlus.Domain.Models.CommentModels
{
    public class CommentCreateModel : BaseCommentModel
    {
        public string FullName { get; set; }
        public string Body { get; set; }
        public int TopicId { get; set; }
    }
}