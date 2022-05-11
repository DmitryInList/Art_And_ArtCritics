// -----------------------------------------------------------------------------------------------------------
// ---- popov 06.04.2021 ----
// -----------------------------------------------------------------------------------------------------------
// Служебный класс EntityFramework для связи с БД "Искусство и Искусствоведы".
// -----------------------------------------------------------------------------------------------------------

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using System.Data.Entity;

namespace Get_Images_From_DataBase_MVVM.Model.EntityFramework
{
    public class Art_And_ArtCriticsEntities : DbContext
    {
        public Art_And_ArtCriticsEntities()
            : base("name=Art_And_ArtCriticsEntities")
        {
        }

        // специальный конструктор с переданной извне строкой подключения
        public Art_And_ArtCriticsEntities(string ConnectionString)
            : base(ConnectionString)
        { }

        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);
        }

        public virtual DbSet<ArtCanvases> ArtCanvases { get; set; }
    }
}
