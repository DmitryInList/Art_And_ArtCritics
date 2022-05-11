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

namespace Art_DataBase_Analytical_MVVM.Model.Data
{
    public class ArtArticleInfo: IArtArticleInfo
    {
        // идентификатор статьи
        private int mID = 0;
        public int ID
        {
            get { return mID; }
        }

        // текст статьи
        private string mResume = "";
        public string Resume
        {
            get { return mResume; }
        }

        // дата публикации статьи (строка, а не DateTime)
        private DateTime? mDate = null;
        public string Date
        {
            get
            {
                if (mDate == null)
                    return "";
                return mDate.Value.ToLongDateString();
            }
        }

        // совокупная оценка картины, данная в статье
        private double mGrade = 0;
        public double Grade
        {
            get { return mGrade; }
        }

        // рейтинг самой этой статьи
        private int mRating = 0;
        public int Rating
        {
            get { return mRating; }
        }

        // ссылка на картину, которую описывает данная статья
        private IArtCanvasInfo mCanvas = null;
        public IArtCanvasInfo Canvas
        {
            get { return mCanvas; }
            set { mCanvas = value; }
        }

        // перечень соавторов этой статьи
        private List<IArtCriticInfo> mCoAuthors = new List<IArtCriticInfo>();
        public IEnumerable<IArtCriticInfo> CoAuthors
        {
            get { return mCoAuthors; }
        }

        // добавить в статью еще одного соавтора
        public void AddNextOneCoAuthor(IArtCriticInfo ca)
        {
            mCoAuthors.Add(ca);
            // ---- popov 03.03.2021 ----
            // НЕТ! Этого делать не надо:
            // При фиксации соавтора в статье предполагается, что искусствоведы
            // будут отсортированны по убыванию их  статуса.
            // При фиксации статьи в исексстововеде предполагается, что статьи
            // будут отсортированны поубыванию их рейтинга.
            //
            // В рамках одной операции такие условия одновременно обеспечить трудно -  
            // так что взаимная фиксация статьи и искусствоведа-соавтора будут 
            // выполняться в двух независимых операциях.
            //ca.AddNextOneArticle(this);
        }

        // перечень критических отзывов на эту статью
        private List<IArtFeedbackInfo> mFeedbacks = new List<IArtFeedbackInfo>();
        public IEnumerable<IArtFeedbackInfo> Feedbacks
        {
            get { return mFeedbacks; }
        }
        // добавить в статью еще один критический отзыв
        public void AddNextOneFeedback(IArtFeedbackInfo f)
        {
            mFeedbacks.Add(f);
            f.Article = this;
        }

        public ArtArticleInfo(int i, string r, DateTime? d, double g, int rt)
        {
            mID = i;
            mResume = r;
            mDate = d;
            mGrade = g;
            mRating = rt;
        }
    }
}
