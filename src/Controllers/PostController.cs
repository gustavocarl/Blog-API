using Blog_API.Models;
using Blog_API.Services.Interfaces;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace Blog_API.Controllers
{
    [Route("api/[controller]/v1")]
    [ApiController]
    public class PostController(IPostService postService, IPostTagsService postTagsService) : ControllerBase
    {
        private readonly IPostService _postService = postService;
        private readonly IPostTagsService _postTagsService = postTagsService;

        // GET: api/<PostController>
        [HttpGet]
        [Authorize(Roles = "Admin, Author, Editor, Contribuitor, Subscriber")]
        public async Task<IActionResult> Get()
        {
            var posts = await _postService.GetAllPostsAsync();
            return Ok(posts);
        }

        // GET api/<PostController>/5
        [HttpGet("id/{id}")]
        [Authorize(Roles = "Admin, Author, Editor, Contribuitor, Subscriber")]
        public async Task<IActionResult> GetById(Guid id)
        {
            var post = await _postService.GetPostByIdAsync(id);

            if (post == null)
                return NotFound("Post not found");

            return Ok(post);
        }

        [HttpGet("title/{title}")]
        [Authorize(Roles = "Admin, Author, Editor, Contribuitor, Subscriber")]
        public async Task<IActionResult> GetByTitle(string title)
        {
            var post = await _postService.GetPostByTitleAsync(title);

            if (post == null)
                return NotFound("Post not found");

            return Ok(post);
        }

        [HttpGet("author/{authorId}")]
        [Authorize(Roles = "Admin, Author, Editor, Contribuitor, Subscriber")]
        public async Task<IActionResult> GetByTitle(Guid authorId)
        {
            var posts = await _postService.GetPostByAuthorAsync(authorId);

            return Ok(posts);
        }

        // POST api/<PostController>
        [HttpPost]
        [Authorize(Roles = "Admin, Author ")]
        public async Task<IActionResult> Post([FromBody] Post post, [FromQuery]List<Guid> tagIds)
        {
            var createPost = await _postService.CreatePostAsync(post);

            if (createPost == null)
                return BadRequest("Post not created.");

            foreach(var tagId in tagIds)
            {
                var postTags = new PostTags
                {
                    PostId = createPost.Id,
                    TagId = tagId
                };
                await  _postTagsService.CreatePostTagsAsync(postTags);
            }

            return Ok(createPost);
        }

        // PUT api/<PostController>/5
        [HttpPut("{postId}")]
        [Authorize(Roles = "Admin, Author, Editor")]
        public async Task<IActionResult> Put(Guid postId, [FromBody] Post post)
        {
            var postToUpdate = await _postService.GetPostByIdAsync(postId);

            if (postToUpdate == null)
                return NotFound("Post not found");

            var updatedPost = await _postService.UpdatePostAsync(post);

            if (updatedPost == null)
                return BadRequest("Post not update");

            return Ok(updatedPost);
        }

        // DELETE api/<PostController>/5
        [HttpDelete("{postId}")]
        [Authorize(Roles = "Admin, Author")]
        public async Task<IActionResult> Delete(Guid postId)
        {
            var removedPost = await _postService.DeletePostAsync(postId);

            if (removedPost == null)
                return NotFound("Post not found");

            return Ok(removedPost);
        }
    }
}