// --------------------------------------------------------------------------------------------------------
// ---- popov 25.02.2021 ----
// --------------------------------------------------------------------------------------------------------
// Информация об одной картине из БД "Искусство и Искусствоведы".
// --------------------------------------------------------------------------------------------------------

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using System.Drawing;
using System.IO;

namespace Art_DataBase_Analytical.Model.Data
{
    public class ArtCanvasInfo: IArtCanvasInfo
    {
        // идентификатор картины.
        private int mID = 0;
        public int ID
        {
            get { return mID; }
        }

        // наименование картины в БД "Искусство и Искусствоведы".
        private string mName = "";
        public string Name
        {
            get { return mName; }
        }

        // графическое содержимое картины (генерируется в момент первого отображения 
        // этой картины в главном потоке программы).
        private byte[] mCanvasData = null;
        private Image mCanvasImage = null;
        public Image CanvasImage
        {
            get
            {
                if(mCanvasData == null)
                    return null;
                if(mCanvasImage == null)
                {
                    mCanvasImage = Image.FromStream(new MemoryStream(mCanvasData));
                }
                return mCanvasImage;
            }
        }

        // итоговая оценка этой картины, взятая из посвященной ей статьи с самым высоким рейтингом.
        private double mGrade = 0;
        public double Grade
        {
            get { return mGrade; }
        }

        // перечень статей, посвященных этой картине
        private List<IArtArticleInfo> mArticles = new List<IArtArticleInfo>();
        public IEnumerable<IArtArticleInfo> Articles
        {
            get { return mArticles; }
        }
        // добавить еще одну статью этой картине
        public void AddNextOneArticle(IArtArticleInfo a)
        {
            mArticles.Add(a);
            a.Canvas = this;
        }

        public ArtCanvasInfo(int i, string n, byte[] cd, double g)
        {
            mID = i;
            mName = n;
            mCanvasData = cd;
            mGrade = g;
        }
    }
}
