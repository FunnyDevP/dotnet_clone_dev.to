using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using clone_dev_to.DTO;
using clone_dev_to.Models;
using clone_dev_to.Repositories;
using clone_dev_to.Services.Interfaces;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace clone_dev_to.Controllers
{
    [Route("api/posts")]
    [ApiController]
    public class PostController : ControllerBase
    {
        private readonly IPostService _postService;

        public PostController(IPostService postService)
        {
            _postService = postService;
        }

        [HttpGet]
        public IActionResult GetAll()
        {
            var postData = _postService.GetAll();
            Thread.Sleep(1000);
            return postData.Count == 0
                ? Ok(new ResponseSuccess<List<PostDto>>(new List<PostDto>()))
                : Ok(new ResponseSuccess<List<PostDto>>(postData));

        }
    }
}