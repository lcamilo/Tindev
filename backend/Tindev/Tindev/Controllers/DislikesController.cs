using System.Collections.Generic;
using Microsoft.AspNetCore.Mvc;
using Tindev.Interfaces;
using Tindev.Models;

namespace Tindev.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class DislikesController : ControllerBase
    {

        private readonly IDislikeRepository _dislikeRepository;

        public DislikesController(IDislikeRepository dislikeRepository)
        {
            _dislikeRepository = dislikeRepository;
        }

        [HttpGet]
        public IEnumerable<Dislike> Get()
        {
            return _dislikeRepository.GetAll();
        }
    }
}
