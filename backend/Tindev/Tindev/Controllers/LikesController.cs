using System;
using System.Collections.Generic;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using Tindev.Interfaces;
using Tindev.Models;

namespace Tindev.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class LikesController : ControllerBase
    {
        private readonly ILikeRepository _likeRepository;

        public LikesController(ILikeRepository likeRepository)
        {
            _likeRepository = likeRepository;
        }

        [HttpGet]
        public IEnumerable<Like> Get()
        {
            return _likeRepository.GetAll();
        }

        [HttpPost]
        public Like Post([FromBody]Guid alvoId)
        {
            var like = new Like()
            {
                DesenvolvedorId = Guid.Parse(Request.Headers["desenvolvedorId"]),
                AlvoId = alvoId
            };

            _likeRepository.Add(like);

            return like;
        }
    }
}
