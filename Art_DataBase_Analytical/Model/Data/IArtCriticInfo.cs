// ----------------------------------------------------------------------------------------------------------
// ---- popov 25.02.2021 ----
// ----------------------------------------------------------------------------------------------------------
// Информация об одном искусствоведе из БД "Искусство и Искусствоведы".
// ----------------------------------------------------------------------------------------------------------
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Art_DataBase_Analytical.Model.Data
{
    public interface IArtCriticInfo: IArtObject
    {
        /*
        // Идентификатор искусствоведа
        int ID { get; }
        */

        // Фамилия искусствоведа
        string LastName { get; }

        // Имя искусствоведа
        string FirstName { get; }

        // Отчество искусствоведа
        string Patronymic { get; }

        // статус искусствоведа
        string Status { get; }

        // Значимость (вес) мнения искусствоведа
        int Weight { get; }

        // Количество статей, в которых этот искусствовед выступил соавтором
        int ArticlesCount { get; }

        // Количество критических отзывов, написанных этим искусствоведом.
        int FeedbacksCount { get; }

        // перечень стататей, в которых этот искусствовед был соавтором
        IEnumerable<IArtArticleInfo> Articles { get; }
        // Добавить еще одну статью этому искусствоведу
        void AddNextOneArticle(IArtArticleInfo a);

        // перечень критических отзывов, написанных этим искусстсвоведом.
        IEnumerable<IArtFeedbackInfo> Feedbacks { get; }
        // Добавить еще один критический отзыв этому искусствоведу.
        void AddNextOneFeedback(IArtFeedbackInfo f);
    }
}
