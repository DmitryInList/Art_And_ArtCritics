// ---------------------------------------------------------------------------------------------------------
// ---- popov 03.03.2021 ----
// ---------------------------------------------------------------------------------------------------------
// Диалоговое окно, отображающее подробные данные об одном искусствоведе:
// - Информация о самом искусствоведе.
// - Перечень статей, в которых этот искусствовед был соавтором.
// - Перечень критических отзывов на статьи, написанных этим искусствоведом.
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
    public partial class CriticDetails : Form
    {
        // Объект, содержащий данные об одном Искусствоведе.
        IArtCriticInfo CriticData;

        // события, обработчики которых находятся в дочерних элементах управления
        private event EventHandler<ArtCriticEventArgs> ShowCritic;
        private event EventHandler<ArtArticleEventArgs> ShowArticles;
        private event EventHandler<ArtFeedbackEventArgs> ShowFeedbacks;

        public CriticDetails(IArtCriticInfo cd)
        {
            InitializeComponent();
            CriticData = cd;
            ShowCritic += this.criticsInformation1.RefreshArtCriticsData;
            ShowArticles += this.articlesInformation1.RefreshArtArticleData;
            ShowFeedbacks += this.feedbacksInformation1.RefreshArtFeedbackData;
        }

        // При загрузке окна вызываем события пользовательских элементов укправления -
        // каждое со своими данными, получаемыми из общего источника (Искусствоведа)
        private void CriticDetails_Load(object sender, EventArgs e)
        {
            ShowCritic?.Invoke(this, new ArtCriticEventArgs(CriticData));
            ShowArticles?.Invoke(this, new ArtArticleEventArgs(CriticData.Articles));
            ShowFeedbacks?.Invoke(this, new ArtFeedbackEventArgs(CriticData.Feedbacks));
        }

        private void button_Close_Click(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}
