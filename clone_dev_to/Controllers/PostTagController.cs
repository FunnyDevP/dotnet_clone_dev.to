using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using clone_dev_to.DTO;
using clone_dev_to.Services.Interfaces;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace clone_dev_to.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class PostTagController : ControllerBase
    {
        private readonly IPostTagService _service;

        public PostTagController(IPostTagService service)
        {
            _service = service;
        }

        [HttpGet]
        public IActionResult GetAll()
        {
            var result = _service.GetAll();
            if (result.Count == 0)
            {
                return Ok(new ResponseSuccess<List<PostTagDto>>(new List<PostTagDto>()));
            }

            var successResp = new ResponseSuccess<List<PostTagDto>>(result);
            return Ok(successResp);
        }
    }
}