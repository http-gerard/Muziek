using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.Entity;
using System.Data.Entity.Design;
using System.Data.EntityClient;
using ProjectMuziek_Model;



namespace ProjectMuziek_DALS
{
    public class ProjectMuziekEntities : DbContext
    {
        public ProjectMuziekEntities() : base("name=ProjectMuziekDatabase")
        {

        }


        public DbSet<Zanger> Zangers { get; set; }
        public DbSet<Lied> Lieds { get; set; }
        public DbSet<Gebruiker> Gebruikers { get; set; }
        public DbSet<Genre> Genres { get; set; }
        public DbSet<BeluisterdLied> BeluisterdLieds { get; set; }
    }
}
