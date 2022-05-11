// ----------------------------------------------------------------------------------------------------------
// ---- popov 12.03.2021 ----
// ----------------------------------------------------------------------------------------------------------
// Центральный класс, описывающий БД "Искусство и Искусствоведы".
// ----------------------------------------------------------------------------------------------------------

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using System.Data.Entity;

namespace Art_DataBase_Analytic_EF.Model.EntityFramework
{
    public class Art_And_ArtCriticsEntities : DbContext
    {
        public Art_And_ArtCriticsEntities(string ConnectionString)
            : base(ConnectionString)
        {
        }

        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);
        }

        public virtual DbSet<ArtArticle> ArtArticle { get; set; }
        public virtual DbSet<ArtCanvases> ArtCanvases { get; set; }
        public virtual DbSet<ArtCoAuthors> ArtCoAuthors { get; set; }
        public virtual DbSet<ArtCriticCategory> ArtCriticCategory { get; set; }
        public virtual DbSet<ArtCritics> ArtCritics { get; set; }
        public virtual DbSet<ArtFeedback> ArtFeedback { get; set; }
        public virtual DbSet<ArtScore> ArtScore { get; set; }
    }
}
