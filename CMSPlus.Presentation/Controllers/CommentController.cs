using AutoMapper;
using CMSPlus.Domain.Entities;
using CMSPlus.Domain.Models.CommentModels;
using CMSPlus.Services.Interfaces;
using FluentValidation;
using FluentValidation.AspNetCore;
using Microsoft.AspNetCore.Mvc;

namespace CMSPlus.Presentation.Controllers
{
    public class CommentController : Controller
    {
        private readonly ICommentService _commentService;
        private readonly ITopicService _topicService;
        private readonly IMapper _mapper;
        private readonly IValidator<CommentCreateModel> _createModelValidator;

        public CommentController(ICommentService commentService, ITopicService topicService, IMapper mapper, IValidator<CommentCreateModel> createModelValidator)
        {
            _commentService = commentService;
            _topicService = topicService;
            _mapper = mapper;
            _createModelValidator = createModelValidator;
        }

        [HttpPost]
        [ActionName("Delete")]
        public async Task<IActionResult> DeleteById(int id)
        {
            await _commentService.Delete(id);
            return RedirectToAction("Index", "Topic");
        }

        [HttpGet]
        public IActionResult Create()
        {
            return View();
        }

        [HttpPost]
        public async Task<IActionResult> Create(CommentCreateModel comment)
        {
            var validationResult = await _createModelValidator.ValidateAsync(comment);
            if(!validationResult.IsValid)
            {
                validationResult.AddToModelState(this.ModelState);
                return View(comment);
            }
            var topic = await _topicService.GetById(comment.TopicId);
            var commentEntity = _mapper.Map<CommentCreateModel, CommentEntity>(comment);
            await _topicService.AddNewComment(commentEntity, topic.Id);     
            return RedirectToAction("Index", "Topic");
        }
    }
}