using AutoMapper;
using CMSPlus.Domain.Entities;
using CMSPlus.Domain.Models.CommentModels;

namespace CMSPlus.Presentation.AutoMapperProfiles
{
    public class CommentProfile : Profile
    {
        public CommentProfile()
        {
            CreateMap<CommentEntity, CommentModel>().ReverseMap();
            CreateMap<CommentEntity, CommentCreateModel>().ReverseMap();
        }
    }
}
