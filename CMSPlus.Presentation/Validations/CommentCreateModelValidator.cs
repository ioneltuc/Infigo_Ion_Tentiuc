using CMSPlus.Domain.Models.CommentModels;
using FluentValidation;

namespace CMSPlus.Presentation.Validations
{
    public class CommentCreateModelValidator : AbstractValidator<CommentCreateModel>
    {
        public CommentCreateModelValidator()
        {
            RuleFor(comment => comment.FullName).NotEmpty();
            RuleFor(comment => comment.Body).NotEmpty();
        }
    }
}