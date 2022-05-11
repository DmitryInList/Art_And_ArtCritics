// ---------------------------------------------------------------------------------------------------------
// ---- popov 26.02.2021 ----
// ---------------------------------------------------------------------------------------------------------
// Информация об одном критическом отзыве на статью, описывающкю картину, из 
// БД "Искусство и Искусствоведы".
// ---------------------------------------------------------------------------------------------------------

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Art_DataBase_Analytical.Model.Data
{
    public class ArtFeedbackInfo: IArtFeedbackInfo
    {
        // идентификатор критического отзыва
        private int mID = 0;
        public int ID
        {
            get { return mID; }
        }

        // качественная характеристика статьи
        private string mScoreText = "";
        public  string ScoreText
        {
            get { return mScoreText; }
        }

        // количественная характеристика статьи
        private int mScoreValue = 0;
        public int ScoreValue
        {
            get { return mScoreValue; }
        }

        // содержимое (текст) отзыва
        private string mContent = "";
        public string Content
        {
            get { return mContent; }
        }

        // дата публикации отзыва (строка, а не DateTime)
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

        // ссылка на искусствоведа, который был автором этого критического отзыва.
        private IArtCriticInfo mAuthor = null;
        public IArtCriticInfo Author
        {
            get { return mAuthor; }
            set { mAuthor = value; }
        }

        // ссылка на статью, к которой относится этот критический отзыв.
        private IArtArticleInfo mArticle = null;
        public IArtArticleInfo Article
        {
            get { return mArticle; }
            set { mArticle = value; }
        }

        public ArtFeedbackInfo(int i, string c, DateTime? d, string st, int sv)
        {
            mID = i;
            mContent = c;
            mDate = d;
            mScoreText = st;
            mScoreValue = sv;
        }
    }
}
