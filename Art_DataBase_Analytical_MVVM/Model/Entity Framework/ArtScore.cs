// -----------------------------------------------------------------------------------------------------------
// ---- popov 12.03.2021 ----
// -----------------------------------------------------------------------------------------------------------
// Служебный класс, представляющий данные из таблицы "Оценка статьи, данная в отзыве на статью" (ArtScore).
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
    [Table("ArtScore")]
    public class ArtScore
    {   
        public ArtScore()
        {
            this.ArtFeedback = new HashSet<ArtFeedback>();
        }

        [Key]
        public int Score_ID { get; set; }
        public string Score_Text { get; set; }
        public int Score_Value { get; set; }
                
        public virtual ICollection<ArtFeedback> ArtFeedback { get; set; }
    }
}
