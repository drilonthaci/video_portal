﻿namespace VideoPortal.API.Services.Interface
{
    public interface ILikeService
    {
        Task AddLikeAsync(Guid videoPostId, Guid userId);
    }
}
