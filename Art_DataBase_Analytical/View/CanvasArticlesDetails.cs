// ----------------------------------------------------------------------------------------------------------
// ---- popov 04.03.2021 ----
// ----------------------------------------------------------------------------------------------------------
// Диалоговое окно, отображающее перечень всех статей, посвященных одной картине:
// - Собственно графическое содержание картины.
// - Перечень всех статей, посвященных этой картине.
// ----------------------------------------------------------------------------------------------------------


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
    public partial class CanvasArticlesDetails : Form
    {
        // Объект, содержащий данные об одном Критическом отзыве.
        IArtCanvasInfo CanvasData;

        // события, обработчики которых находятся в дочерних элементах управления
        private event EventHandler<ArtCanvasEventArgs> ShowCanvas;        
        private event EventHandler<ArtArticleEventArgs> ShowArticles;

        public CanvasArticlesDetails(IArtCanvasInfo obj)
        {
            InitializeComponent();
            CanvasData = obj;
            ShowCanvas += canvasInformation1.RefreshCanvasInfo;
            ShowArticles += articlesInformation1.RefreshArtArticleData;
        }

        private void CanvasArticlesDetails_Load(object sender, EventArgs e)
        {
            ShowCanvas?.Invoke(this, new ArtCanvasEventArgs(CanvasData));
            ShowArticles?.Invoke(this, new ArtArticleEventArgs(CanvasData.Articles));
        }

        private void button_Close_Click(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}
