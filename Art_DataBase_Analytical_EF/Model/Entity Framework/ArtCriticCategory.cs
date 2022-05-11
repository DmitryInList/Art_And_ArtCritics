// -----------------------------------------------------------------------------------------------------------
// ---- popov 12.03.2021 ----
// -----------------------------------------------------------------------------------------------------------
// Служебный класс, представляющий данные из таблицы "Ранги искусствоведов" (ArtCriticCategory).
// -----------------------------------------------------------------------------------------------------------

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Art_DataBase_Analytic_EF.Model.EntityFramework
{
    [Table("ArtCriticCategory")]
    public class ArtCriticCategory
    {   
        public ArtCriticCategory()
        {
            this.ArtCritics = new HashSet<ArtCritics>();
        }

        [Key]
        public int Category_ID { get; set; }
        public string Category_Name { get; set; }
        public int Category_Weight { get; set; }
        
        public virtual ICollection<ArtCritics> ArtCritics { get; set; }
    }
}
