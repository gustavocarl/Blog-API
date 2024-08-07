﻿using PostCentral.Models;

namespace PostCentral.Repositories.Interfaces;

public interface ITagRepository
{
    Task<List<Tag>> GetAllTagsAsync();

    Task<Tag?> GetByIdAsync(Guid tagId);

    Task<Tag?> GetByTagNameAsync(string tagName);

    Task<Tag?> AddTagAsync(Tag tag);

    Task<Tag?> UpdateTagAsync(Tag tag);

    Task<Tag?> DeleteTagAsync(Guid tagId);
}