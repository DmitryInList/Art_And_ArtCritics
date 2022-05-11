// -----------------------------------------------------------------------------------------------------------
// ---- popov 12.03.2021 ----
// -----------------------------------------------------------------------------------------------------------
// Служебный класс, представляющий данные из таблицы "Соавторы статей" (ArtCoAuthors).
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
    [Table("ArtCoAuthors")]
    public class ArtCoAuthors
    {
        [Key]
        public int Coauthor_ID { get; set; }
        [ForeignKey("ArtCritics")]
        public int Critic { get; set; }
        [ForeignKey("ArtArticle")]
        public int Article { get; set; }
        public Nullable<int> Grade { get; set; }

        public virtual ArtArticle ArtArticle { get; set; }
        public virtual ArtCritics ArtCritics { get; set; }
    }
}
