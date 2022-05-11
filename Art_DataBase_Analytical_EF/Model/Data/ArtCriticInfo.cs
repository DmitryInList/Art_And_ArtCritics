// ----------------------------------------------------------------------------------------------------------
// ---- popov 26.02.2021 ----
// ----------------------------------------------------------------------------------------------------------
// Информация об одном искусствоведе из БД "Искусство и Искусствоведы".
// ----------------------------------------------------------------------------------------------------------


using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Art_DataBase_Analytic_EF.Model.Data
{
    public class ArtCriticInfo: IArtCriticInfo
    {
        // Идентификатор искусствоведа
        private int mID = 0;
        public int ID
        {
            get { return mID; }
        }

        // Фамилия искусствоведа
        private string mLastName = "";
        public string LastName
        {
            get { return mLastName; }
        }

        // Имя искусствоведа
        private string mFirstName = "";
        public string FirstName
        {
            get { return mFirstName; }
        }

        // Отчество искусствоведа
        private string mPatronymic = "";
        public string Patronymic
        {
            get { return mPatronymic; }
        }

        // статус искусствоведа
        private string mStatus = "";
        public string Status
        {
            get { return mStatus; }
        }

        // Значимость (вес) мнения искусствоведа
        private int mWeight = 0;
        public int Weight
        {
            get { return mWeight; }
        }

        // Количество статей, в которых этот искусствовед выступил соавтором
        private int mArticlesCount = 0;
        public int ArticlesCount
        {
            get { return mArticlesCount; }
        }

        // Количество критических отзывов, написанных этим искусствоведом.
        private int mFeedbacksCount = 0;
        public int FeedbacksCount
        {
            get { return mFeedbacksCount; }
        }

        // перечень стататей, в которых этот искусствовед был соавтором
        private List<IArtArticleInfo> mArticles = new List<IArtArticleInfo>();
        public IEnumerable<IArtArticleInfo> Articles
        {
            get { return mArticles; }
        }
        // Добавить еще одну статью этому искусствоведу
        public void AddNextOneArticle(IArtArticleInfo a)
        {   
            mArticles.Add(a);
        }

        // перечень критических отзывов, написанных этим искусстсвоведом.
        private List<IArtFeedbackInfo> mFeedbacks = new List<IArtFeedbackInfo>();
        public IEnumerable<IArtFeedbackInfo> Feedbacks
        {
            get { return mFeedbacks; }
        }
        // Добавить еще один критический отзыв этому искусствоведу.
        public void AddNextOneFeedback(IArtFeedbackInfo f)
        {
            mFeedbacks.Add(f);
            f.Author = this;
        }

        public ArtCriticInfo(int i, string ln, string fn, string p, string s, int w, int ac, int fc)
        {
            mID = i;
            mLastName = ln;
            mFirstName = fn;
            mPatronymic = p;
            mStatus = s;
            mWeight = w;
            mArticlesCount = ac;
            mFeedbacksCount = fc;
        }
    }
}
