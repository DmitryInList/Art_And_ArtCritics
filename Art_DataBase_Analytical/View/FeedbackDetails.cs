// ---------------------------------------------------------------------------------------------------------
// ---- popov 03.03.2021 ----
// ---------------------------------------------------------------------------------------------------------
// Диалоговое окно, отображающее подробные данные об одном критическом отзыве на статью:
// - Картина, к которой относится статья.
// - Статья, описывающая эту картину.
// - Критический отзыв на эту статью.
// - Искусствовед-автор этого критического отзыва.
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

using Art_DataBase_Analytical.EventArguments;
using Art_DataBase_Analytical.Model.Data;

namespace Art_DataBase_Analytical.View
{
    public partial class FeedbackDetails : Form
    {
        // Объект, содержащий данные об одном Критическом отзыве.
        IArtFeedbackInfo FeedbackData;

        // события, обработчики которых находятся в дочерних элементах управления
        private event EventHandler<ArtCanvasEventArgs> ShowCanvas;
        private event EventHandler<ArtCriticEventArgs> ShowCritic;
        private event EventHandler<ArtArticleEventArgs> ShowArticles;
        private event EventHandler<ArtFeedbackEventArgs> ShowFeedbacks;

        public FeedbackDetails(IArtFeedbackInfo fd)
        {
            InitializeComponent();
            FeedbackData = fd;
            ShowCanvas += canvasInformation1.RefreshCanvasInfo;
            ShowCritic += criticsInformation1.RefreshArtCriticsData;
            ShowArticles += articlesInformation1.RefreshArtArticleData;
            ShowFeedbacks += feedbacksInformation1.RefreshArtFeedbackData;
        }

        private void FeedbackDetails_Load(object sender, EventArgs e)
        {
            ShowCanvas?.Invoke(this, new ArtCanvasEventArgs(FeedbackData.Article.Canvas));
            ShowCritic?.Invoke(this, new ArtCriticEventArgs(FeedbackData.Author));
            ShowArticles?.Invoke(this, new ArtArticleEventArgs(FeedbackData.Article));
            ShowFeedbacks?.Invoke(this, new ArtFeedbackEventArgs(FeedbackData));
        }

        private void button_Close_Click(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}
