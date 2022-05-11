// ----------------------------------------------------------------------------------------------------------
// ---- popov 04.03.2021 ----
// ----------------------------------------------------------------------------------------------------------
// Диалоговое окно, отображающее подробные данные об одной картине:
// - Собственно графическое содержание картины.
// - Итоговая оценка, дагнная картине по результатам анализа всех статей,
//   посвященных этой картине.
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
    public partial class CanvasDetails : Form
    {
        // Объект, содержащий данные об одном Критическом отзыве.
        IArtCanvasInfo CanvasData;

        // события, обработчики которых находятся в дочерних элементах управления
        private event EventHandler<ArtCanvasEventArgs> ShowCanvas;

        public CanvasDetails(IArtCanvasInfo obj)
        {
            InitializeComponent();
            CanvasData = obj;
            ShowCanvas += canvasInformation1.RefreshCanvasInfo;
        }

        private void CanvasDetails_Load(object sender, EventArgs e)
        {
            ShowCanvas?.Invoke(this, new ArtCanvasEventArgs(CanvasData));
            textBox_Grade.Text = CanvasData.Grade.ToString();
        }

        private void button_Close_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void button_Details_Click(object sender, EventArgs e)
        {
            CanvasArticlesDetails CanvasArticleDialog = new CanvasArticlesDetails(CanvasData);
            CanvasArticleDialog.ShowDialog();
        }
    }
}
