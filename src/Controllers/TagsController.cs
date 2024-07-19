using Blog_API.Models;
using Blog_API.Services.Interfaces;
using Microsoft.AspNetCore.Mvc;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace Blog_API.Controllers
{
    [Route("api/[controller]/v1")]
    [ApiController]
    public class TagsController(ITagService tagService) : ControllerBase
    {
        private readonly ITagService _tagService = tagService;

        // GET: api/<TagsController>
        [HttpGet]
        public async Task<IActionResult> Get()
        {
            var tags = await _tagService.GetAllTagsAsync();

            return Ok(tags);
        }

        // GET api/<TagsController>/5
        [HttpGet("tagId/{tagId}")]
        public async Task<IActionResult> GetByTagId(Guid tagId)
        {
            var tag = await _tagService.GetByTagIdAsync(tagId);

            if (tag == null)
                return NotFound("Tag not found");

            return Ok(tag);
        }

        [HttpGet("tagName/{tagName}")]
        public async Task<IActionResult> GetByTagName(string tagName)
        {
            var tag = await _tagService.GetByTagNameAsync(tagName);

            if (tag == null)
                return NotFound("Tag not found");

            return Ok(tag);
        }

        // POST api/<TagsController>
        [HttpPost]
        public async Task<IActionResult> Post([FromBody] Tag tag)
        {
            var tagExist = await _tagService.GetByTagNameAsync(tag.TagName);

            if (tagExist != null)
                return BadRequest("The tag already exists");

            var createdTag = await _tagService.CreateTagAsync(tag);

            if (createdTag == null)
                return BadRequest("The tag was not created");

            return Ok(createdTag);
        }

        // PUT api/<TagsController>/5
        [HttpPut("{tagId}")]
        public async Task<IActionResult> Put(Guid tagId, [FromBody] Tag tag)
        {
            var tagToUpdate = await _tagService.GetByTagIdAsync(tagId);

            if (tagToUpdate == null)
                return NotFound("Tag not found");

            var updatedTag = await _tagService.UpdateTagAsync(tag);

            return Ok(updatedTag);
        }

        // DELETE api/<TagsController>/5
        [HttpDelete("{tagId}")]
        public async Task<IActionResult> Delete(Guid tagId)
        {
            var tagToDelete = await _tagService.GetByTagIdAsync(tagId);

            if (tagToDelete == null)
                return NotFound("Tag not found");

            var deletedTag = await _tagService.DeleteTagAsync(tagId);

            return Ok(deletedTag);
        }
    }
}