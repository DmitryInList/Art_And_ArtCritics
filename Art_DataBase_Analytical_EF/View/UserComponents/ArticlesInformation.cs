// ---------------------------------------------------------------------------------------------------------
// ---- popov 02.03.2021 ----
// ---------------------------------------------------------------------------------------------------------
// Компонент для отображения данных о статьях, описывающих картины, из БД "Искусство и Искусствоведы".
// ---------------------------------------------------------------------------------------------------------


using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

using Art_DataBase_Analytic_EF.Model.Data;
using Art_DataBase_Analytic_EF.EventArguments;


namespace Art_DataBase_Analytic_EF.View.UserComponents
{
    public partial class ArticlesInformation : UserControl
    {
        // надо ли обрабатывать двойной щелчек мышью по компоненту DataGridView
        private bool m_DataGridClickMustHave = true;
        public bool DataGridClickMustHave
        {
            get { return m_DataGridClickMustHave; }
            set { m_DataGridClickMustHave = value; }
        }

        // текущий массив данных - список элементов типа IArtArticleInfo
        private IEnumerable<IArtArticleInfo> CurrentData = null;

        public ArticlesInformation()
        {
            InitializeComponent();
            dataGridView1.AutoGenerateColumns = false;            
        }

        // ----------------------------------------------------------------------
        // при двойном щелчке на DataGrid будет отображаться подробная информация 
        // о выбранной статье
        private void dataGridView1_DoubleClick(object sender, EventArgs e)
        {
            if ((CurrentData != null) && (dataGridView1.SelectedRows.Count != 0))
            {
                if (this.DataGridClickMustHave)
                {   
                    ArticleDetails ArticleDlg = new ArticleDetails(CurrentData.ElementAt(dataGridView1.SelectedRows[0].Index));
                    ArticleDlg.ShowDialog();                 
                }
            }
        }

        // --------------------------------------------------------------------------------------------------------
        // ---- обработчики событий, генерируемых тем окном приложения, в котором находится данный компонент ----
        // --------------------------------------------------------------------------------------------------------
        public void RefreshArtArticleData(object o, ArtArticleEventArgs e)
        {
            dataGridView1.DataSource = null;
            CurrentData = e.DataList;
            dataGridView1.DataSource = CurrentData;
            dataGridView1.Refresh();
            dataGridView1.ClearSelection();
        }
    }
}
