using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ProjectMuziek_DALS.Data.Repositories;
using ProjectMuziek_Model;

namespace ProjectMuziek_DALS.Data.UnitOfWork
{
    public class UnitOfWorks : IUnitOfWorks
    {
        #region attributen
        private IRepository<Lied> _liedRepo;
        private IRepository<Zanger> _zangerRepo;
        private IRepository<Gebruiker> _gebruikerRepo;
        private IRepository<Genre> _genreRepo;
        private IRepository<BeluisterdLied> _beluisterdLiedRepo;
        #endregion

        public UnitOfWorks(ProjectMuziekEntities projectMuziekEntities)
        {
            this.ProjectMuziekEntities = projectMuziekEntities;

        }
        private ProjectMuziekEntities ProjectMuziekEntities { get; }

        #region repositories
        public IRepository<Lied> LiedRepo
        {
            get
            {
                if (_liedRepo == null)
                {
                    _liedRepo = new Repository<Lied>(this.ProjectMuziekEntities);
                }
                return _liedRepo;
            }
        }
        public IRepository<Zanger> ZangerRepo
        {
            get
            {
                if (_zangerRepo == null)
                {
                    _zangerRepo = new Repository<Zanger>(this.ProjectMuziekEntities);
                }
                return _zangerRepo;
            }
        }
        public IRepository<Gebruiker> GebruikerRepo
        {
            get
            {
                if (_gebruikerRepo == null)
                {
                    _gebruikerRepo = new Repository<Gebruiker>(this.ProjectMuziekEntities);
                }
                return _gebruikerRepo;
            }
        }

        public IRepository<Genre> GenreRepo
        {
            get
            {
                if (_genreRepo == null)
                {
                    _genreRepo = new Repository<Genre>(this.ProjectMuziekEntities);
                }
                return _genreRepo;
            }
        }

       


        public IRepository<BeluisterdLied> BeluisterdLiedRepo
        {
            get
            {
                if (_beluisterdLiedRepo == null)
                {
                    _beluisterdLiedRepo = new Repository<BeluisterdLied>(this.ProjectMuziekEntities);
                }
                return _beluisterdLiedRepo;
            }
        }

        #endregion

        public void Dispose()
        {
            ProjectMuziekEntities.Dispose();
        }

        public int Save()
        {
            return ProjectMuziekEntities.SaveChanges();
        }
    }
}
