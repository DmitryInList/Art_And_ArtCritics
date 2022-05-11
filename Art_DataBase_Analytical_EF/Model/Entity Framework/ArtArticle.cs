// ----------------------------------------------------------------------------------------------------------
// ---- popov 12.03.2021 ----
// ----------------------------------------------------------------------------------------------------------
// Служебный класс, представляющий данные из таблицы "Статьи, посвященные картинам" (ArtArticle).
// ----------------------------------------------------------------------------------------------------------

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;


namespace Art_DataBase_Analytic_EF.Model.EntityFramework
{
    [Table("ArtArticle")]
    public class ArtArticle
    {   
        public ArtArticle()
        {
            this.ArtCoAuthors = new HashSet<ArtCoAuthors>();
            this.ArtFeedback = new HashSet<ArtFeedback>();
        }

        [Key]
        public int Article_ID { get; set; }
        [ForeignKey("ArtCanvases")]
        public int Article_Canvas { get; set; }
        public string Article_Resume { get; set; }
        public System.DateTime Article_Date { get; set; }
        public string Faction { get; set; }

        public virtual ArtCanvases ArtCanvases { get; set; }        
        public virtual ICollection<ArtCoAuthors> ArtCoAuthors { get; set; }        
        public virtual ICollection<ArtFeedback> ArtFeedback { get; set; }
    }
}
