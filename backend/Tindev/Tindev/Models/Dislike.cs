using System;

namespace Tindev.Models
{
    public class Dislike
    {
        public Guid DislikeId { get; set; }
        public Guid DesenvolvedorId { get; set; }
        public Desenvolvedor Desenvolvedor { get; set; }

        public Guid AlvoId { get; set; }
        public Desenvolvedor Alvo { get; set; }
    }
}