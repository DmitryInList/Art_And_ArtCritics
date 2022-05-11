// -------------------------------------------------------------------------------------------------------
// ---- popov 21.02.2021 ----
// -------------------------------------------------------------------------------------------------------
// В этом окне будет отображаться информация о выбранной картине - 
// с возможностью ее сохранить в графический файл.
// -------------------------------------------------------------------------------------------------------

using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

using Get_Images_From_DataBase.Model.Data;
using Get_Images_From_DataBase.EventArguments;

namespace Get_Images_From_DataBase.View
{
    public partial class CanvasDetailsDialog : Form
    {
        // объект, содержащий все исходные данные об изображении.
        IArtCanvas ImageData;

        // событие, которое генерирует это диалоговое окно для того, чтобы отобразить 
        // подробные данные об изображении
        private event EventHandler<ArtCanvasEventArgs> ShowCanvas;

        public CanvasDetailsDialog(IArtCanvas IData)
        {
            InitializeComponent();
            ImageData = IData;
            ShowCanvas += canvasInformation1.RefreshCanvasInfo;
        }

        private void CanvasDetailsDialog_Load(object sender, EventArgs e)
        {
            ShowCanvas?.Invoke(this, new ArtCanvasEventArgs(ImageData));
            this.textBox_Format.Text = ImageData.FileExtention;
        }

        private void button_Close_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void button_Save_Click(object sender, EventArgs e)
        {
            saveFileDialog1.FileName = ImageData.CanvasName;
            if (saveFileDialog1.ShowDialog() == DialogResult.OK)
            {
                if(ImageData.SaveCanvasToGraphicFile(saveFileDialog1.FileName))
                {
                    MessageBox.Show("Изображение сохранено в файл по имени: '" + ImageData.FileNameToSave + "'!", "Изображение успешно сохранено", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
            }
        }
    }
}
