// -----------------------------------------------------------------------------------------------
// ---- popov 20.02.2021 ----
// -----------------------------------------------------------------------------------------------
// Компонент для отображения графического содержания кртины и ее описания 
// в БД "Искусство и Искусствоведы".
// -----------------------------------------------------------------------------------------------

using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

using Get_Images_From_DataBase.EventArguments;
using Get_Images_From_DataBase.Model.Data;

namespace Get_Images_From_DataBase.View.UserComponents
{
    public partial class CanvasInformation : UserControl
    {
        // надо ли обрабатывать двойной щелчек мышью по компоненту ImageBox
        bool m_ImageClickMustHave = true;
        public bool ImageClickMustHave
        {
            get { return m_ImageClickMustHave; }
            set { m_ImageClickMustHave = value; }
        }

        // каков номер этого компонента (индекс в переданном массив ес данными)
        int m_DataArrayIndex = 0;
        public int DataArrayIndex
        {
            get { return m_DataArrayIndex; }
            set { m_DataArrayIndex = value; }
        }

        public CanvasInformation()
        {
            InitializeComponent();
        }

        // -------------------------------------------------------------------------------------------------
        // ---- обработчики событий, генерируемых главным окном приложения ----
        // -------------------------------------------------------------------------------------------------
        public void CleanCanvasInfo(object o, EventArgs e)
        {
            label_CanvasName.Text = "";
            pictureBox_Canvas.Image = null;
            this.Tag = null;
        }

        public void RefreshCanvasInfo(object o, ArtCanvasEventArgs e)
        {
            if (DataArrayIndex < e.DataList.Count)
            {
                label_CanvasName.Text = e.DataList[DataArrayIndex].CanvasName;
                pictureBox_Canvas.Image = e.DataList[DataArrayIndex].CanvasImage;
                this.Tag = e.DataList[DataArrayIndex];
            }
        }
        // -------------------------------------------------------------------------------------------------
        // По двойному щелчку на изображении - в некоторых случаях - будет открываться 
        // специальное окно с подробными данными о Картине.
        private void pictureBox_Canvas_DoubleClick(object sender, EventArgs e)
        {
            if (this.Tag != null)
            {
                if (this.ImageClickMustHave)
                {
                    CanvasDetailsDialog CanvasDetail = new CanvasDetailsDialog(this.Tag as IArtCanvas);
                    CanvasDetail.ShowDialog();
                }
            }
        }
        // -------------------------------------------------------------------------------------------------
    }
}
