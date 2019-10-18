using System;

namespace Tindev.Models
{
    public class Like
    {
        public Guid LikeId { get; set; }
        public Guid DesenvolvedorId { get; set; }
        public Desenvolvedor Desenvolvedor { get; set; }

        public Guid AlvoId { get; set; }
        public Desenvolvedor Alvo { get; set; }

        public Like()
        {
            LikeId = Guid.NewGuid();
        }
    }
}