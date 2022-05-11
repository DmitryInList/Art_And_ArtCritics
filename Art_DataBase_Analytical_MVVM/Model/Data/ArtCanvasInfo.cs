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
using System.Windows;
using System.Windows.Media.Imaging;

namespace Art_DataBase_Analytical_MVVM.Model.Data
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

        // Собственно, само графическое содержание картины - его придется создавать
        // отдельно и независимо от получения набора байт, описывающих содержимое картины, из БД 
        // (только в главном потоке программы, когда потребуется его отобразить)
        private BitmapImage m_CanvasImage = null;
        public BitmapImage CanvasImage
        {
            get
            {
                if (mCanvasData == null)
                    return null;

                if (m_CanvasImage == null)
                {
                    m_CanvasImage = new BitmapImage();
                    m_CanvasImage.BeginInit();
                    m_CanvasImage.StreamSource = new MemoryStream(mCanvasData);
                    m_CanvasImage.EndInit();
                }
                return m_CanvasImage;
            }
        }

        // итоговая оценка этой картины, взятая из посвященной ей статьи с самым высоким рейтингом.
        private double mGrade = 0;
        public double Grade
        {
            get { return mGrade; }
            set { mGrade = value; }
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
