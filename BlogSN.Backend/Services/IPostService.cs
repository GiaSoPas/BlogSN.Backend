﻿using BlogSN.Models;

namespace BlogSN.Backend.Services;

public interface IPostService
{
    public Task<IEnumerable<Post>> GetPosts(CancellationToken cancellationToken);

    public Task CreatePost(Post post, CancellationToken cancellationToken);

    public Task<Post> GetPostById(int id, CancellationToken cancellationToken);

    public Task DeletePostById(int id, CancellationToken cancellationToken);

    public Task UpdatePostById(int id, Post post, CancellationToken cancellationToken);

}