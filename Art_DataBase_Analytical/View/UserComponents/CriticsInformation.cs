// ---------------------------------------------------------------------------------------------------------
// ---- popov 02.03.2021 ----
// ---------------------------------------------------------------------------------------------------------
// Компонент для отображения данных об искусствоведах из БД "Искусство и Искусствоведы".
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
using Art_DataBase_Analytical.View;

namespace Art_DataBase_Analytical.View.UserComponents
{
    public partial class CriticsInformation : UserControl
    {
        // надо ли обрабатывать двойной щелчек мышью по компоненту DataGridView
        private bool m_DataGridClickMustHave = true;
        public bool DataGridClickMustHave
        {
            get { return m_DataGridClickMustHave; }
            set { m_DataGridClickMustHave = value; }
        }

        // текущий массив данных - список элементов типа IArtCriticInfo
        private IEnumerable<IArtCriticInfo> CurrentData = null;

        public CriticsInformation()
        {
            InitializeComponent();
            dataGridView1.AutoGenerateColumns = false;            
        }

        // ----------------------------------------------------------------------
        // при двойном щелчке на DataGrid будет отображаться подробная информация 
        // о выбранном искусствоведе
        private void dataGridView1_DoubleClick(object sender, EventArgs e)
        {
            if((CurrentData != null) && (dataGridView1.SelectedRows.Count != 0))
            {
                if(this.DataGridClickMustHave)
                {
                    // Отображаем подробную информацию о выбранном Искусствоведе:
                    // ---- popov 05.05.2022 ----
                    // перешел от List<T> к IEnumerable<T> - для сокрытия деталей реализации
                    CriticDetails CurrentCritic = new CriticDetails(CurrentData.ElementAt(dataGridView1.SelectedRows[0].Index));
                    CurrentCritic.ShowDialog();
                }
            }
        }

        // --------------------------------------------------------------------------------------------------------
        // ---- обработчики событий, генерируемых тем окном приложения, в котором находится данный компонент ----
        // --------------------------------------------------------------------------------------------------------
        public void RefreshArtCriticsData(object o, ArtCriticEventArgs e)
        {
            dataGridView1.DataSource = null;
            CurrentData = e.DataList;
            dataGridView1.DataSource = CurrentData;
            dataGridView1.Refresh();
            dataGridView1.ClearSelection();
        }

        public void CleanArtCriticsData(object o, EventArgs e)
        {
            dataGridView1.DataSource = null;
            CurrentData = null;
            dataGridView1.Refresh();
            dataGridView1.ClearSelection();
        }
    }
}
