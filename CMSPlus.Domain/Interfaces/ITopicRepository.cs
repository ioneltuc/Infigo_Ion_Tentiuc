using CMSPlus.Domain.Entities;

namespace CMSPlus.Domain.Interfaces;

public interface ITopicRepository:IRepository<TopicEntity>
{
    public Task<TopicEntity?> GetBySystemName(string systemName);
    Task AddNewComment(CommentEntity comment, int topicId);
}