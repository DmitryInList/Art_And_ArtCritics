// -----------------------------------------------------------------------------------------------------------
// ---- popov 12.03.2021 ----
// -----------------------------------------------------------------------------------------------------------
// Служебный класс, представляющий данные из таблицы "Искусствоведы" (ArtCritics).
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
    [Table("ArtCritics")]
    public class ArtCritics
    {   
        public ArtCritics()
        {
            this.ArtCoAuthors = new HashSet<ArtCoAuthors>();
            this.ArtFeedback = new HashSet<ArtFeedback>();
        }

        [Key]
        public int Critic_ID { get; set; }
        public string Critic_LastName { get; set; }
        public string Critic_FirstName { get; set; }
        public string Critic_Patronymic { get; set; }
        [ForeignKey("ArtCriticCategory")]
        public int Critic_Category { get; set; }
        
        public virtual ICollection<ArtCoAuthors> ArtCoAuthors { get; set; }
        public virtual ArtCriticCategory ArtCriticCategory { get; set; }        
        public virtual ICollection<ArtFeedback> ArtFeedback { get; set; }
    }
}
