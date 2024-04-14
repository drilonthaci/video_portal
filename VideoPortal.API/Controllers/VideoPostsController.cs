﻿using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using VideoPortal.API.Models;
using VideoPortal.API.Models.DTO;
using VideoPortal.API.Repositories.Implementation;
using VideoPortal.API.Repositories.Interface;

namespace VideoPortal.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class VideoPostsController : ControllerBase
    {

        private readonly IVideoPostRepository videoPostRepository;

        public VideoPostsController(IVideoPostRepository videoPostRepository)
        {
            this.videoPostRepository = videoPostRepository;
        }


        // POST: /api/videoposts
        [HttpPost]
        public async Task<IActionResult> CreateVideoPost([FromBody] CreateVideoPostRequestDto request)
        {
            var videoPost = new VideoPost
            {

                Title = request.Title,
                ShortDescription = request.ShortDescription,
                Content = request.Content,
                ImageUrl = request.ImageUrl,
                PublishedDate = request.PublishedDate,
                Publisher = request.Publisher,
                IsVisible = request.IsVisible,


     
               
            };

            videoPost = await videoPostRepository.CreateAsync(videoPost);

            var response = new CreateVideoPostResponseDto
            {
                Id = videoPost.Id,
                Publisher = videoPost.Publisher,
                Content = videoPost.Content,
                ImageUrl = videoPost.ImageUrl,
                IsVisible = videoPost.IsVisible,
                PublishedDate = videoPost.PublishedDate,
                ShortDescription = videoPost.ShortDescription,
                Title = videoPost.Title,
            };

            return Ok(response);
        }



        // GET: /api/blogposts
        [HttpGet]
        public async Task<IActionResult> GetAllVideoPosts()
        {
            var blogPosts = await videoPostRepository.GetAllAsync();

            // Domain model to DTO
            var response = new List<CreateVideoPostResponseDto>();
            foreach (var blogPost in blogPosts)
            {
                response.Add(new CreateVideoPostResponseDto
                {
                    Id = blogPost.Id,
                    Publisher = blogPost.Publisher,
                    Content = blogPost.Content,
                    ImageUrl = blogPost.ImageUrl,
                    IsVisible = blogPost.IsVisible,
                    PublishedDate = blogPost.PublishedDate,
                    ShortDescription = blogPost.ShortDescription,
                    Title = blogPost.Title,
                });
            }

            return Ok(response);
        }
    }
}
