// ---------------------------------------------------------------------------------------------------------
// ---- popov 02.03.2021 ----
// ---------------------------------------------------------------------------------------------------------
// Компонент для отображения данных о критических отзывах на статьи из БД "Искусство и Искусствоведы".
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

using Art_DataBase_Analytical.Model.Data;
using Art_DataBase_Analytical.EventArguments;

namespace Art_DataBase_Analytical.View.UserComponents
{
    public partial class FeedbacksInformation : UserControl
    {
        // надо ли обрабатывать двойной щелчек мышью по компоненту DataGridView
        private bool m_DataGridClickMustHave = true;
        public bool DataGridClickMustHave
        {
            get { return m_DataGridClickMustHave; }
            set { m_DataGridClickMustHave = value; }
        }

        // текущий массив данных - список элементов типа IArtFeedbackInfo
        private IEnumerable<IArtFeedbackInfo> CurrentData = null;

        public FeedbacksInformation()
        {
            InitializeComponent();
            dataGridView1.AutoGenerateColumns = false;            
        }

        private void dataGridView1_DoubleClick(object sender, EventArgs e)
        {
            if ((CurrentData != null) && (dataGridView1.SelectedRows.Count != 0))
            {
                if (this.DataGridClickMustHave)
                {
                    // ---- popov 05.05.2022 ----
                    // перешел от List<T> к IEnumerable<T> - для сокрытия деталей реализации
                    FeedbackDetails FeedbackData = new FeedbackDetails(CurrentData.ElementAt(dataGridView1.SelectedRows[0].Index));
                    FeedbackData.ShowDialog();
                }
            }
        }

        // --------------------------------------------------------------------------------------------------------
        // ---- обработчики событий, генерируемых тем окном приложения, в котором находится данный компонент ----
        // --------------------------------------------------------------------------------------------------------
        public void RefreshArtFeedbackData(object o, ArtFeedbackEventArgs e)
        {
            dataGridView1.DataSource = null;
            CurrentData = e.DataList;
            dataGridView1.DataSource = CurrentData;
            dataGridView1.Refresh();
            dataGridView1.ClearSelection();
        }
    }
}
