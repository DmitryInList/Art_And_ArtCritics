// --------------------------------------------------------------------------------------------------
// ---- popov 14.02.2021 ----
// --------------------------------------------------------------------------------------------------
// Итоговая версия служебной программы для помещения изображений из
// графических файлов (JPG, BMP, GIF, PNG) в базу данных "Искусство и Искусствоведы",-
// там изображения картин хранятся в виде битовых полей.
// --------------------------------------------------------------------------------------------------
// Для того, чтоб прочитать изображения из базы данных "Искусство и Искусствоведы"
// написана другая служебная программа...
// --------------------------------------------------------------------------------------------------
// Представление - набор всех пользовательских интерфесов программы.
// --------------------------------------------------------------------------------------------------

using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

using Put_Image_In_DataBase.Controller;
using Put_Image_In_DataBase.EventArguments;
using Put_Image_In_DataBase.Model.Data;

namespace Put_Image_In_DataBase.View
{
    public partial class MainView : Form, IView
    {
        // ---------------------------------------------------------------------------
        // Ссылка на Контроллер, с которым взаимодейтсвует представление.
        IController MyController = null;
        // ---------------------------------------------------------------------------

        public MainView(IController Cnt)
        {
            InitializeComponent();
            MyController = Cnt;

            // ---------------------------------------------------------------
            // ---- Подписываем Представление на события Контроллера ----
            // ---------------------------------------------------------------
            MyController.ClearAllComponents += CleanVisualData;
            MyController.ShowNewCanvas += RefreshCanvasImage;
            MyController.CanvasReport += SaveCanvasReport;

            // ---------------------------------------------------------------
            // ---- Подписываем Контроллер на события Представления ----
            // ---------------------------------------------------------------
            TakeNewFile += MyController.CreateCanvas;
            CanvasToDataBase += MyController.PutCanvasInDB;

        }

        // --------------------------------------------------------------------------------------------------
        // ---- При загрузке окна подкючиться к БД "Искусство и Искусствоведы" ----
        // --------------------------------------------------------------------------------------------------
        private void MainView_Load(object sender, EventArgs e)
        {
            if (!MyController.TryConnectToDataBase())
            {
                MessageBox.Show("Не удалось подключится к Базе Данных!", "Ошибка работы с данными", MessageBoxButtons.OK, MessageBoxIcon.Error); 
                this.Close();
                return;
            }
        }

        // --------------------------------------------------------------------------------------------------
        // ---- При закрытии окна отключиться от БД "Искусство и Искусствоведы" ----
        // --------------------------------------------------------------------------------------------------
        private void MainView_FormClosing(object sender, FormClosingEventArgs e)
        {
            MyController.TryDisconnectFromDataBase();
        }

        // --------------------------------------------------------------------------------------------------
        // ---- Загрузить новую картину из файла ----
        // --------------------------------------------------------------------------------------------------
        private void button_Path_Click(object sender, EventArgs e)
        {
            // Предлагаем контроллеру временно разместить в памяти очередную картину
            if(openFileDialog1.ShowDialog() == DialogResult.OK)
            {
                TakeNewFile?.Invoke(this, new FileNameEventArgs(openFileDialog1.FileName));
            }            
        }

        // --------------------------------------------------------------------------------------------------
        // ---- Завершить работу с программой  ----
        // --------------------------------------------------------------------------------------------------
        private void button_Exit_Click(object sender, EventArgs e)
        {
            if (MessageBox.Show("Вы действительно хотите завершить работу с программой?", "Завершить работу с программой?", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
            {
                this.Close();
            }
        }        

        // --------------------------------------------------------------------------------------------------
        // ---- Поместить картину в БД "Искусство и Искусствоведы" ----
        // --------------------------------------------------------------------------------------------------
        private void button_PutToDB_Click(object sender, EventArgs e)
        {
            if(CanvasImage != null)
            {
                if (HasCanvasName())
                {
                    // Имя, под которым картина будет сохранена в БД, становится известна
                    // только в момент запуска процедуры сохаранения картины в БД.                    
                    CanvasToDataBase?.Invoke(this, new CanvasNameEventArgs(CanvasNameInDB));
                }
            }
            else
            {
                MessageBox.Show("Нет исходных данных для сохранения в БД!", "Ошибка исходных данных", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
            }
        }

        // --------------------------------------------------------------------------------------------------
        // Перейти в поле ввода "Название картины" - на тот случай, если пользователь
        // забыл его ввести.
        private bool HasCanvasName()
        {
            if (string.IsNullOrEmpty(CanvasNameInDB))
            {
                MessageBox.Show("Вы не определили имя, под которым картина будет сохранена в БД!", "Ошибка исходных данных", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                textBox_CanvasName.Focus();
                return false;
            }
            return true;
        }

        // --------------------------------------------------------------------------------------------------
        // Путь к графическому файлу, из которого читается картина для БД "Искусство и Искусствоведы"...
        public string PathToFile
        {
            get { return textBox_Path.Text; }
            set { textBox_Path.Text = value; }
        }

        // Имя картины, под которым она должна сохраняться в БД "Искусство и Искусствоведы"
        public string CanvasNameInDB
        {
            get { return textBox_CanvasName.Text; }
            set { textBox_CanvasName.Text = value; }
        }
        
        // Графическое мзображение кртины
        public Image CanvasImage
        {
            get { return pictureBox1.Image; }
            set { pictureBox1.Image = value; }
        }

        // ================================================================================
        // ==== Реализация IView ====
        // ================================================================================
        // получить первичные данные о картине из указанного графического файла
        public event EventHandler<FileNameEventArgs> TakeNewFile;

        // сохранить готовый набор данных о Картине в Базе Данных "Искусство и Искусствоведы"
        public event EventHandler<CanvasNameEventArgs> CanvasToDataBase;

        // очистить все визуальные компоненты
        public void CleanVisualData(object o, EventArgs e)
        {   
            PathToFile = "";
            CanvasNameInDB = "";
            CanvasImage = null;
        }

        // отобразить данные о изображении из объекта
        public void RefreshCanvasImage(object o, CanvasInfoEventArgs e)
        {
            if (e.TheCanvasInfo == null)
            {
                MessageBox.Show("Не удалось прочитать изображение из графического файла!", "Ошибка выполнения", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                return;
            }
            PathToFile = e.TheCanvasInfo.GraphicalFileName;
            CanvasImage = e.TheCanvasInfo.CanvasToShow;
        }

        // отчет о том, удалось сохранить Картину в БД "Искусство и Искусствоведы", или нет.
        public void SaveCanvasReport(object o, CanvasResultEventArgs e)
        {
            if (e.SavingResult)
            {
                MessageBox.Show("Картина под названием '" + e.CanvasName + "' - успешно сохранена в Базу Данных!", "Отчет о выполнении", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
            else
            {
                MessageBox.Show("Не удалось сохранить в Базу Данных картину под названием '" + e.CanvasName + "'!", "Ошибка выполнения", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
        // ================================================================================
    }
}
