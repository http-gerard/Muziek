using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ProjectMuziek_DALS.Data.Repositories;
using ProjectMuziek_Model;

namespace ProjectMuziek_DALS.Data.UnitOfWork
{
    public interface IUnitOfWorks : IDisposable
    {
        IRepository<Lied> LiedRepo { get; }
        IRepository<Zanger> ZangerRepo { get; }
        IRepository<Gebruiker> GebruikerRepo { get; }
        IRepository<Genre> GenreRepo { get; }
        IRepository<BeluisterdLied> BeluisterdLiedRepo { get; }
        int Save();
    }
}
