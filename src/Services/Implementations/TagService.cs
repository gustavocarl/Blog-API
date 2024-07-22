using PostCentral.Models;
using PostCentral.Repositories.Interfaces;
using PostCentral.Services.Interfaces;

namespace PostCentral.Services.Implementations;

public class TagService(ITagRepository tagRepository) : ITagService
{
    private readonly ITagRepository _tagRepository = tagRepository;

    public async Task<List<Tag>> GetAllTagsAsync()
    {
        return await _tagRepository.GetAllTagsAsync();
    }

    public async Task<Tag?> GetByTagIdAsync(Guid tagId)
    {
        return await _tagRepository.GetByIdAsync(tagId);
    }

    public async Task<Tag?> GetByTagNameAsync(string tagName)
    {
        return await _tagRepository.GetByTagNameAsync(tagName);
    }

    public async Task<Tag?> CreateTagAsync(Tag tag)
    {
        var tagNameExist = await _tagRepository.GetByTagNameAsync(tag.TagName);

        if (tagNameExist != null)
            return null;

        return await _tagRepository.AddTagAsync(tag);
    }

    public async Task<Tag?> UpdateTagAsync(Tag tag)
    {
        var tagForUpdate = _tagRepository.GetByTagNameAsync(tag.TagName);

        if (tagForUpdate == null)
            return null;

        return await _tagRepository.UpdateTagAsync(tag);
    }

    public async Task<Tag?> DeleteTagAsync(Guid tagId)
    {
        var tagForDelete = await _tagRepository.GetByIdAsync(tagId);

        if (tagForDelete == null)
            return null;

        return await _tagRepository.DeleteTagAsync(tagId);
    }
}