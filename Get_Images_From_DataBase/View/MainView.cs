// ----------------------------------------------------------------------------------------------------------
// ---- popov 20.02.2021 ----
// ----------------------------------------------------------------------------------------------------------
// Служебная программа для просмотра картин из Базы Данных "Искусство и Искусствоведы".
// Каждую картину можно посмотреть на большом экране и, в случае надобности, сохранить ее 
// в грачическом файле. При этом формат файла автоматически устанавливается таким,
// каким он был в изначальном изображении, когда-то загруженном в БД "Искусство и Искусствоведы".
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

using Get_Images_From_DataBase.EventArguments;
using Get_Images_From_DataBase.Controller;

namespace Get_Images_From_DataBase.View
{
    public partial class MainView : Form, IView
    {
        // ссылка на Контроллер
        Controller.IController MyController;

        // максимальное число одновременно отображаемых картин.        
        private int m_MaxDataBlockCount = 10;
        public int MaxDataBlockCount
        {
            get { return m_MaxDataBlockCount; }
        }

        // ---------------------------------------------------------------------------------
        // ---- Cобытия Представления ----
        // ---------------------------------------------------------------------------------
        // главное окно загружено - необходимо передать для отображения первый блок данных
        public event EventHandler LoadFirstDataBlock;

        // нажата кнопка "Вперед >>" - необходимо передать для отображения следующий блок данных
        public event EventHandler LoadForwardDataBlock;

        // нажата кнопка "<< Назад" - необходимо передать для отображения предыдущий блок данных
        public event EventHandler LoadBackwardDataBlock;

        // ---------------------------------------------------------------------------------
        // ---- Обработчики событий Контроллера ----
        // ---------------------------------------------------------------------------------
        // очистить все визуальные данные
        public void ClearAllData(object o, EventArgs e)
        {
            ClearCanvasData?.Invoke(this, null);
        }

        // отобразить очередной блок информации (набор картин) в главном окне
        public void RefreshAllData(object o, ArtCanvasEventArgs e)
        {
            ShowCanvasData?.Invoke(this, e);
        }

        // обе кнопки Вперед и Назад - доступны.
        public void ForwardBackwardEnabled(object o, EventArgs e)
        {
            button_Backward.Enabled = true;
            button_Forward.Enabled = true;
        }

        // Кнопка Вперед - доступна, а Назад - нет.
        public void BackwardDisabled(object o, EventArgs e)
        {
            button_Forward.Enabled = true;
            button_Backward.Enabled = false;
            button_Forward.Focus();
        }

        // Кнопка Назад - доступна, а Вперед - нет.
        public void ForwardDisabled(object o, EventArgs e)
        {
            button_Backward.Enabled = true;
            button_Forward.Enabled = false;
            button_Backward.Focus();
        }

        // ================================================================================================
        // события для внутреннего употребления (очистка и заполнение данных)
        private event EventHandler ClearCanvasData;
        private event EventHandler<ArtCanvasEventArgs> ShowCanvasData;
        // ================================================================================================

        public MainView(Controller.IController Cnt)
        {
            InitializeComponent();

            // Фиксируем ссылку на контроллер
            MyController = Cnt;

            // Передаем в Контроллер максимальное число одновременно отображаемых картин
            MyController.MaxDataBlockCount = this.MaxDataBlockCount;

            // -----------------------------------------------------------------------
            // ---- Подписываем Представление на события Контроллера ----
            // -----------------------------------------------------------------------
            MyController.ClearAllCanvases += this.ClearAllData;
            MyController.RefreshAllCanvases += this.RefreshAllData;
            MyController.BothButtonsEnabled += this.ForwardBackwardEnabled;
            MyController.BackwardDisabled += this.BackwardDisabled;
            MyController.ForwardDisabled += this.ForwardDisabled;

            // -----------------------------------------------------------------------
            // ---- Подписываем Контроллер на события Представления ----
            // -----------------------------------------------------------------------
            this.LoadFirstDataBlock += MyController.LoadFirstCanvasBlock;
            this.LoadForwardDataBlock += MyController.LoadForwardCanvasBlock;
            this.LoadBackwardDataBlock += MyController.LoadBackwardCanvasBlock;

            SubscribeOnCleanDataEvent();
            SubscribeOnRefreshDataEvent();
        }

        // ------------------------------------------------------------------------------------------------
        // Подписываем визуальные компоненты типа CanvasInformationDialog
        // на события главного окна программы
        // ------------------------------------------------------------------------------------------------
        // подписаться на событие очистки данных
        public void SubscribeOnCleanDataEvent()
        {
            ClearCanvasData += canvasInformation1.CleanCanvasInfo;
            ClearCanvasData += canvasInformation2.CleanCanvasInfo;
            ClearCanvasData += canvasInformation3.CleanCanvasInfo;
            ClearCanvasData += canvasInformation4.CleanCanvasInfo;
            ClearCanvasData += canvasInformation5.CleanCanvasInfo;
            ClearCanvasData += canvasInformation6.CleanCanvasInfo;
            ClearCanvasData += canvasInformation7.CleanCanvasInfo;
            ClearCanvasData += canvasInformation8.CleanCanvasInfo;
            ClearCanvasData += canvasInformation9.CleanCanvasInfo;
            ClearCanvasData += canvasInformation10.CleanCanvasInfo;
        }

        // ------------------------------------------------------------------------------------------------
        // подписаться на событие обновления данных
        public void SubscribeOnRefreshDataEvent()
        {
            ShowCanvasData += canvasInformation1.RefreshCanvasInfo;
            ShowCanvasData += canvasInformation2.RefreshCanvasInfo;
            ShowCanvasData += canvasInformation3.RefreshCanvasInfo;
            ShowCanvasData += canvasInformation4.RefreshCanvasInfo;
            ShowCanvasData += canvasInformation5.RefreshCanvasInfo;
            ShowCanvasData += canvasInformation6.RefreshCanvasInfo;
            ShowCanvasData += canvasInformation7.RefreshCanvasInfo;
            ShowCanvasData += canvasInformation8.RefreshCanvasInfo;
            ShowCanvasData += canvasInformation9.RefreshCanvasInfo;
            ShowCanvasData += canvasInformation10.RefreshCanvasInfo;
        }

        // ------------------------------------------------------------------------------------------------
        private void button_Close_Click(object sender, EventArgs e)
        {
            if (MessageBox.Show("Вы действительно хотите завершить работу с программой?", "Завершение работы", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
            {
                this.Close();
            }
        }

        // ------------------------------------------------------------------------------------------------
        // При загрузке окна требуем отобразить первый блок данных
        private void MainView_Load(object sender, EventArgs e)
        {   
            // загрузка всех картин из БД "Искусство и Искусствоведы" - в параллельном потоке
            LoadAllDataFromDB();
        }

        // ------------------------------------------------------------------------------------------------
        // При попытке перейти назад требуем отобразить предыдущий блок данных
        private void button_Backward_Click(object sender, EventArgs e)
        {   
            LoadBackwardDataBlock?.Invoke(this, null);
        }

        // ------------------------------------------------------------------------------------------------
        // При попытке перейти вперед требуем отобразить следующий блок данных
        private void button_Forward_Click(object sender, EventArgs e)
        {   
            LoadForwardDataBlock?.Invoke(this, null);
        }

        // ------------------------------------------------------------------------------------------------
        // Загрузка данных из БД - это в общем случае длительная 
        // процедура, которая может завершится ошибкой и которую 
        // надо запустить на выполнение в параллельном потоке
        private void LoadAllDataFromDB()
        {
            ClearCanvasData?.Invoke(this, null);
            if (!WelcomeDialog.Run(MyController))            
            {
                CrashClose();
                return;
            }
            LoadFirstDataBlock?.Invoke(this, null);
        }        

        // ------------------------------------------------------------------------------------------------
        // В том случае, если не удалось подключиться к БД "Искусство и Искусствоведы"
        // надо сразу же прервать работу программы 
        private void CrashClose()
        {
            MessageBox.Show("Не удалось подключиться и получить данные из БД 'Искусство и Искусствоведы'!", "Ошибка работы с базой данных", MessageBoxButtons.OK, MessageBoxIcon.Error); 
            this.Close();
        }

        // -------------------------------------------------------------------------------------------------
        // Обновить данные - получить все данные из БД заново
        private void button_RefreshData_Click(object sender, EventArgs e)
        {
            LoadAllDataFromDB();
        }
    }
}
