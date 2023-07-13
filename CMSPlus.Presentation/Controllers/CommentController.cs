using AutoMapper;
using CMSPlus.Domain.Entities;
using CMSPlus.Domain.Models.CommentModels;
using CMSPlus.Services.Interfaces;
using Microsoft.AspNetCore.Mvc;

namespace CMSPlus.Presentation.Controllers
{
    public class CommentController : Controller
    {
        private readonly ICommentService _commentService;
        private readonly ITopicService _topicService;
        private readonly IMapper _mapper;

        public CommentController(ICommentService commentService, ITopicService topicService, IMapper mapper)
        {
            _commentService = commentService;
            _topicService = topicService;
            _mapper = mapper;
        }

        //[HttpGet("{id}")]
        //public async Task<IActionResult> Index(int id)
        //{
        //    var commentsByTopicId = await _commentService.GetAllByTopicId(id);
        //    var commentsToDisplay = _mapper.Map<IEnumerable<CommentEntity>, IEnumerable<CommentModel>>(commentsByTopicId);
        //    return View(commentsToDisplay);
        //}

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
            var topic = await _topicService.GetById(comment.TopicId);
            var commentEntity = _mapper.Map<CommentCreateModel, CommentEntity>(comment);
            await _topicService.AddNewComment(commentEntity, topic.Id);     
            return RedirectToAction("Index", "Topic");
        }
    }
}