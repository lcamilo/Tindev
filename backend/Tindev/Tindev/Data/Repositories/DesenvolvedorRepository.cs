using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using Microsoft.VisualBasic;
using Tindev.Interfaces;
using Tindev.Models;

namespace Tindev.Data.Repositories
{
    public class DesenvolvedorRepository: RepositoryBase<Desenvolvedor>, IDesenvolvedorRepository
    {
        public Desenvolvedor GetByUserName(string userName)
        {
            return DbSet.FirstOrDefault(x => x.UserName == userName);
        }

        public IEnumerable<Desenvolvedor> GetAll(Guid desenvolvedorId)
        {
            var likes = Contexto.Set<Like>().Where(l => l.DesenvolvedorId == desenvolvedorId);
            var dislikes = Contexto.Set<Dislike>().Where(l => l.DesenvolvedorId == desenvolvedorId);
            return DbSet.Include(d => d.Likes).Include(d => d.Dislikes).Where(x =>
                x.DesenvolvedorId != desenvolvedorId && !likes.Any(l => l.AlvoId == x.DesenvolvedorId) &&
                !dislikes.Any(l => l.AlvoId == x.DesenvolvedorId));
        }
        
    }



}