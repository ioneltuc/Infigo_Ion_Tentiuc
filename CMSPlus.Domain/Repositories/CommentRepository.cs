using CMSPlus.Domain.Entities;
using CMSPlus.Domain.Interfaces;
using CMSPlus.Domain.Persistance;
using Microsoft.EntityFrameworkCore;

namespace CMSPlus.Domain.Repositories
{
    public class CommentRepository : Repository<CommentEntity>, ICommentRepository
    {
        public CommentRepository(ApplicationDbContext context) : base(context)
        {
        }

        public async Task<IEnumerable<CommentEntity>> GetAllByTopicId(int id)
        {
            var result = await _dbSet.Where(comment => comment.TopicId == id).ToListAsync();
            return result;
        }
    }
}