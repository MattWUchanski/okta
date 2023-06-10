using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Cors;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Hosting;
using System.Collections.Generic;
using System.Linq;
using System.Security.Claims;
using WebApplicationOkta1.Models;


namespace WebApplicationOkta1.Controllers
{
    [EnableCors("AllowAll")]
    [ApiController]
    [Route("api")]
    public class InfoController : ControllerBase
    {
        // GET: api/whoami
        [Authorize]
        [HttpGet]
        [Route("whoami")]
        public Dictionary<string, string> GetAuthorized()
        {
            var principal = HttpContext.User.Identity as ClaimsIdentity;
            return principal.Claims
               .GroupBy(claim => claim.Type)
               .ToDictionary(claim => claim.Key, claim => claim.First().Value);
        }

        // GET: api/posts
        [Authorize]
        [HttpGet]
        [Route("posts")]
        public IActionResult GetPosts()
        {
            var posts = new List<Post>
            {
                new Post { Id = 1, Title = "Post 1", Content = "This is the content for post 1" },
                new Post { Id = 2, Title = "Post 2", Content = "This is the content for post 2" },
                new Post { Id = 3, Title = "Post 3", Content = "This is the content for post 3" },
                new Post { Id = 4, Title = "Post 4", Content = "This is the content for post 4" }
        };

            return Ok(posts);
        }
    }

}
