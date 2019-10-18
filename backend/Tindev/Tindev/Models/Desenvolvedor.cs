using System;
using System.Collections.Generic;

namespace Tindev.Models
{
    public class Desenvolvedor
    {
        public Guid DesenvolvedorId { get; set; }

        public string Nome { get; set; }
        public string UserName { get; set; }
        public string Bio { get; set; }
        public string Avatar { get; set; }
        public string Empresa { get; set; }
        public string Blog { get; set; }
        public string Localizacao { get; set; }
        public string Email { get; set; }

        public virtual ICollection<Like> Likes { get; set; }
        public virtual ICollection<Dislike> Dislikes { get; set; }

        //"repos_url": "https://api.github.com/users/lcamilo/repos",

        public Desenvolvedor()
        {
            DesenvolvedorId = Guid.NewGuid();
        }
    }
}