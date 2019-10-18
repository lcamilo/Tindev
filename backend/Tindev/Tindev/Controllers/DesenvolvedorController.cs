using System;
using System.Collections.Generic;
using System.Dynamic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Security.Cryptography;
using System.Text;
using System.Text.Json.Serialization;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;
using Tindev.Interfaces;
using Tindev.Models;

namespace Tindev.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class DesenvolvedorController : ControllerBase
    {
        private readonly IDesenvolvedorRepository _desenvolvedorRepository;

        public DesenvolvedorController(IDesenvolvedorRepository desenvolvedorRepository)
        {
            _desenvolvedorRepository = desenvolvedorRepository;
        }

        [HttpGet]
        public IEnumerable<Desenvolvedor> Get()
        {
            var desenvolvedorId = Guid.Parse(Request.Headers["desenvolvedorId"]);

            return _desenvolvedorRepository.GetAll(desenvolvedorId).OrderBy(x=> RandomNumberGenerator.GetInt32(1,Int32.MaxValue));
        }

        [HttpPost]
        public Desenvolvedor Post(Desenvolvedor desenvolvedor)
        {
            var desenv = _desenvolvedorRepository.GetByUserName(desenvolvedor.UserName);
            if (desenv == null)
            {
                desenv = desenvolvedor;
                //obter dados do github

                HttpClient client = new HttpClient();
                client.DefaultRequestHeaders.Accept.Clear();
                client.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));
                client.DefaultRequestHeaders.Add("User-Agent", "Mozilla/5.0 (Windows NT 10.0; Win64; x64) AppleWebKit/537.36 (KHTML, like Gecko) Chrome/77.0.3865.90 Safari/537.36");

                var textResposta =  client.GetStringAsync($"https://api.github.com/users/{desenvolvedor.UserName}").Result;
                var resposta = JsonConvert.DeserializeObject<dynamic>(textResposta);

                desenv = new Desenvolvedor() {
                    UserName = desenvolvedor.UserName,
                    Avatar = resposta.avatar_url,
                    Bio = resposta.bio,
                    Nome = resposta.name,
                    Email = resposta.email,
                    Empresa = resposta.company,
                    Blog = resposta.blog,
                    Localizacao = resposta.location
                };

                _desenvolvedorRepository.Add(desenv);
            }

            return desenv;
        }
    }
}
