using System;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using PostsManager.PostsApi.Models.v1_0;
using PostsManager.PostsApi.Repositories.v1_0;

namespace PostsManager.PostsApi.Controllers.v1_0
{
    [ApiController]
    [ApiVersion("1")]
    [Route("api/v{version:apiVersion}/[controller]")]
    public class PostsController : ControllerBase
    {
        private IPostsRepository _postsRepository;

        public PostsController(IPostsRepository postsRepository)
        {
            this._postsRepository = postsRepository;
        }

        [HttpGet("{id}")]
        [ProducesResponseType(typeof(PostsModel), StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        public ActionResult<PostsModel> GetById(string id)
        {
            if (!Int32.TryParse(id, out Int32 postId))
                return BadRequest("Invalid Id was provided");

            var post = _postsRepository.GetPostById(postId);

            if (post == null)
                return NotFound();
            
            return Ok(post);
        }

        [HttpGet]
        [ProducesResponseType(typeof(PostsModel), StatusCodes.Status200OK)]
        public ActionResult<PostsModel> GetAll()
        {
            return Ok(_postsRepository.GetPosts());
        }

        [HttpPost]
        [ProducesResponseType(typeof(PostsModel), StatusCodes.Status201Created)]        
        public IActionResult Add([FromBody] PostsModel postModel)
        {
            var postCreated = this._postsRepository.Add(postModel);

            return Created(new Uri($"{Request.Path}/{postCreated.Id}", UriKind.Relative), postCreated);
            //return CreatedAtAction("Add", new { postId = postCreated.Id }, postCreated);
        }
        
        [HttpPut]
        [ProducesResponseType(typeof(PostsModel), StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        public IActionResult Update([FromQuery]string id, [FromBody]PostsModel postModel)
        {
            if (!Int32.TryParse(id, out Int32 postId))
                return BadRequest("Post can not be updated. Reason: Invalid Id was provided");

            var post = _postsRepository.GetPostById(postId);

            if (post == null)
                return NotFound();

            this._postsRepository.Update(postId, postModel);

            return Ok();
        }

        [HttpDelete]
        [ProducesResponseType(typeof(PostsModel), StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        public IActionResult Delete([FromQuery]string id)
        {
            if (!Int32.TryParse(id, out Int32 postId))
                return BadRequest("Post can not be removed. Reason: Invalid Id was provided");

            var post = _postsRepository.GetPostById(postId);

            if (post == null)
                return NotFound();

            this._postsRepository.Delete(postId);

            return Ok();
        }

    }
}
