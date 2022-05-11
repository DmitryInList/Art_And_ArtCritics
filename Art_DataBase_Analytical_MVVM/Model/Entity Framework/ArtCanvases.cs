// -----------------------------------------------------------------------------------------------------------
// ---- popov 12.03.2021 ----
// -----------------------------------------------------------------------------------------------------------
// Служебный класс, представляющий данные из таблицы "Картины" (ArtCanvases).
// -----------------------------------------------------------------------------------------------------------

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Art_DataBase_Analytical_MVVM.Model.EntityFramework
{
    [Table("ArtCanvases")]
    public class ArtCanvases
    {   
        public ArtCanvases()
        {
            this.ArtArticle = new HashSet<ArtArticle>();
        }

        [Key]        
        public int Canvas_Id { get; set; }
        public string Canvas_Name { get; set; }
        public byte[] Canvas_Screen { get; set; }
        public string Canvas_Format { get; set; }
        
        public virtual ICollection<ArtArticle> ArtArticle { get; set; }
    }
}
