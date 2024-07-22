using PostCentral.Models;
using PostCentral.Services.Interfaces;
using Microsoft.AspNetCore.Mvc;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace PostCentral.Controllers
{
    [Route("api/[controller]/v1")]
    [ApiController]
    public class CommentController(ICommentService commentService) : ControllerBase
    {
        private readonly ICommentService _commentService = commentService;

        // GET: api/<CommentController>
        [HttpGet]
        public async Task<IActionResult> Get()
        {
            var comments = await _commentService.GetAllCommentsAsync();

            return Ok(comments);
        }

        [HttpGet("postId/{postId}")]
        public async Task<IActionResult> GetByPostId(Guid postId)
        {
            var commentsByPost = await _commentService.GetByPostIdAsync(postId);

            if (commentsByPost == null)
                return NotFound("Comment not found");

            return Ok(commentsByPost);
        }

        [HttpGet("userId/{userId}")]
        public async Task<IActionResult> GetByUserId(Guid userId)
        {
            var commentsByUserId = await _commentService.GetByUserIdAsync(userId);

            if (commentsByUserId == null)
                return NotFound("Comment not found");

            return Ok(commentsByUserId);
        }

        // GET api/<CommentController>/5
        [HttpGet("id/{commentId}")]
        public async Task<IActionResult> Get(Guid commentId)
        {
            var comment = await _commentService.GetByIdAsync(commentId);

            if (comment == null)
                return NotFound("Comment not found");

            return Ok(commentId);
        }

        // POST api/<CommentController>
        [HttpPost]
        public async Task<IActionResult> Post([FromBody] Comment comment)
        {
            var createComment = await _commentService.CreateCommentAsync(comment);

            if (createComment == null)
                return BadRequest("Comment not created");

            return Ok(createComment);
        }

        // PUT api/<CommentController>/5
        [HttpPut("{commentId}")]
        public async Task<IActionResult> Put(Guid commentId, [FromBody] Comment comment)
        {
            var commentForUpdate = await _commentService.GetByIdAsync(commentId);

            if (commentForUpdate == null)
                return NotFound("Comment not found");

            var updateComment = await _commentService.UpdateCommentAsync(comment);

            if (updateComment == null)
                return NotFound("Comment not updated");

            return Ok(updateComment);
        }

        // DELETE api/<CommentController>/5
        [HttpDelete("{commentId}")]
        public async Task<IActionResult> Delete(Guid commentId)
        {
            var commentForRemove = await _commentService.DeleteCommentAsync(commentId);

            if (commentForRemove == null)
                return NotFound("Comment not found");

            return Ok(commentForRemove);
        }
    }
}