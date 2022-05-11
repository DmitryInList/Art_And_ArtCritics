// ---------------------------------------------------------------------------------------------------------
// ---- popov 04.03.2021 ----
// ---------------------------------------------------------------------------------------------------------
// Диалоговое окно, отображающее подробные данные об одной статье, посвященной картине:
// - Картина, которой посвящена эта статья.
// - Данные самой статьи.
// - Перечень искусствоведов-соавторов этой статьи.
// - Перечень критических отзывов на эту статью.
// ---------------------------------------------------------------------------------------------------------
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

using Art_DataBase_Analytic_EF.EventArguments;
using Art_DataBase_Analytic_EF.Model.Data;

namespace Art_DataBase_Analytic_EF.View
{
    public partial class ArticleDetails : Form
    {
        // Объект, содержащий данные об одном Критическом отзыве.
        IArtArticleInfo ArticleData;

        // события, обработчики которых находятся в дочерних элементах управления
        private event EventHandler<ArtCanvasEventArgs> ShowCanvas;
        private event EventHandler<ArtCriticEventArgs> ShowCritic;
        private event EventHandler<ArtArticleEventArgs> ShowArticles;
        private event EventHandler<ArtFeedbackEventArgs> ShowFeedbacks;

        public ArticleDetails(IArtArticleInfo ad)
        {
            InitializeComponent();
            ArticleData = ad;
            ShowCanvas += canvasInformation1.RefreshCanvasInfo;
            ShowCritic += criticsInformation1.RefreshArtCriticsData;
            ShowArticles += articlesInformation1.RefreshArtArticleData;
            ShowFeedbacks += feedbacksInformation1.RefreshArtFeedbackData;
        }

        private void ArticleDetails_Load(object sender, EventArgs e)
        {
            ShowCanvas?.Invoke(this, new ArtCanvasEventArgs(ArticleData.Canvas));
            ShowCritic?.Invoke(this, new ArtCriticEventArgs(ArticleData.CoAuthors));
            ShowArticles?.Invoke(this, new ArtArticleEventArgs(ArticleData));
            ShowFeedbacks?.Invoke(this, new ArtFeedbackEventArgs(ArticleData.Feedbacks));
        }

        private void button_Close_Click(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}
