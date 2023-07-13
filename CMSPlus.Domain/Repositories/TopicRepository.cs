using CMSPlus.Domain.Entities;
using CMSPlus.Domain.Interfaces;
using CMSPlus.Domain.Persistance;
using Microsoft.EntityFrameworkCore;

namespace CMSPlus.Domain.Repositories;

public class TopicRepository : Repository<TopicEntity>, ITopicRepository
{
    public TopicRepository(ApplicationDbContext context) : base(context)
    {
    }

    public async Task<TopicEntity?> GetBySystemName(string systemName)
    {
        var result = await _dbSet.Where(topic => topic.SystemName == systemName).Include(topic => topic.Comments).FirstOrDefaultAsync();
        return result;
    }

    public async Task AddNewComment(CommentEntity comment, int topicId)
    {
        var topic = await _dbSet.SingleOrDefaultAsync(topic => topic.Id == topicId);
        topic.Comments.Add(comment);
        await Save();
    }
}