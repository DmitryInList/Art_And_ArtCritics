// -----------------------------------------------------------------------------------------------------------
// ---- popov 11.03.2021 ----
// -----------------------------------------------------------------------------------------------------------
// Служебный класс EntityFramework для связи с БД "Искусство и Искусствоведы".
// -----------------------------------------------------------------------------------------------------------

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using System.Data.Entity;
using System.Data.Entity.Infrastructure;

namespace Get_Images_From_DataBase_EF.Model.EntityFramework
{
    public class Art_And_ArtCriticsEntities: DbContext
    {
        // ---- popov 11.02.2021 ----
        // почему-то со строкой подключения из CONFIG-файла категорически не хочет работать...
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
