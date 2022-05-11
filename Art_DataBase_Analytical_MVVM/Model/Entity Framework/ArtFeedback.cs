// -----------------------------------------------------------------------------------------------------------
// ---- popov 12.03.2021 ----
// -----------------------------------------------------------------------------------------------------------
// Служебный класс, представляющий данные из таблицы "Отзывы искусствоведов на статьи" (ArtFeedback).
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
    [Table("ArtFeedback")]
    public class ArtFeedback
    {
        [Key]
        public int Feedback_ID { get; set; }
        [ForeignKey("ArtArticle")]
        public int Article { get; set; }
        [ForeignKey("ArtCritics")]
        public int Critic { get; set; }
        [ForeignKey("ArtScore")]
        public int Score { get; set; }
        public string Feedback_Resume { get; set; }
        public Nullable<System.DateTime> Feedback_Date { get; set; }

        public virtual ArtArticle ArtArticle { get; set; }
        public virtual ArtCritics ArtCritics { get; set; }
        public virtual ArtScore ArtScore { get; set; }
    }
}
