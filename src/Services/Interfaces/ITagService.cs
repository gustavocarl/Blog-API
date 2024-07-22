using PostCentral.Models;

namespace PostCentral.Services.Interfaces;

public interface ITagService
{
    Task<List<Tag>> GetAllTagsAsync();

    Task<Tag?> GetByTagIdAsync(Guid tagId);

    Task<Tag?> GetByTagNameAsync(string tagName);

    Task<Tag?> CreateTagAsync(Tag tag);

    Task<Tag?> UpdateTagAsync(Tag tag);

    Task<Tag?> DeleteTagAsync(Guid tagId);
}