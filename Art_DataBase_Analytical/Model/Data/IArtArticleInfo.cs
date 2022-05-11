// ---------------------------------------------------------------------------------------------------------
// ---- popov 25.02.2021 ----
// ---------------------------------------------------------------------------------------------------------
// Информация об одной статье, описывающей картину, из БД "Искусство и Искусствоведы".
// ---------------------------------------------------------------------------------------------------------
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Art_DataBase_Analytical.Model.Data
{
    public interface IArtArticleInfo: IArtObject
    {
        /*
        // идентификатор статьи
        int ID { get; }
        */

        // текст статьи
        string Resume { get; }

        // дата публикации статьи (строка, а не DateTime)
        string Date { get; }

        // совокупная оценка картины, данная в статье
        double Grade { get; }

        // рейтинг самой этой статьи
        int Rating { get; }

        // ссылка на картину, которую описывает данная статья
        IArtCanvasInfo Canvas { get; set; }

        // перечень соавторов этой статьи
        IEnumerable<IArtCriticInfo> CoAuthors { get; }
        // добавить в статью еще одного соавтора
        void AddNextOneCoAuthor(IArtCriticInfo ca);

        // перечень критических отзывов на эту статью
        IEnumerable<IArtFeedbackInfo> Feedbacks { get; }
        // добавить в статью еще один критический отзыв
        void AddNextOneFeedback(IArtFeedbackInfo f);
    }
}
