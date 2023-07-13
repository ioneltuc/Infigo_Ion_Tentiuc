using CMSPlus.Domain.Entities;

namespace CMSPlus.Domain.Interfaces
{
    public interface ICommentRepository : IRepository<CommentEntity>
    {
        Task<IEnumerable<CommentEntity>> GetAllByTopicId(int id);
    }
}