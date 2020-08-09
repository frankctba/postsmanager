using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using PostsManager.PostsApi.Models.v1_0;
using PostsManager.PostsApi.Repositories.v1_0;

namespace PostsManager.PostsApi.Controllers.v2_0
{
    [ApiController]
    [ApiVersion("2")]
    [Route("api/v{version:apiVersion}/[controller]")]
    public class PostsController : ControllerBase
    {
        private IPostsRepository _postsRepository;

        public PostsController(IPostsRepository postsRepository)
        {
            this._postsRepository = postsRepository;
        }

        [HttpGet]
        [ProducesResponseType(typeof(PostsModel), StatusCodes.Status200OK)]
        public ActionResult<PostsModel> GetAll()
        {
            return Ok(_postsRepository.GetPosts());
        }
    }
}
