using System;
using System.Collections.Generic;
using Tindev.Models;

namespace Tindev.Interfaces
{
    public interface IDesenvolvedorRepository :IRepositoryBase<Desenvolvedor>
    {
        Desenvolvedor GetByUserName(string userName);

        IEnumerable<Desenvolvedor> GetAll(Guid desenvolvedorId);

    }
}