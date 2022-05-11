// ---------------------------------------------------------------------------------------------------------
// ---- popov 25.02.2021 ----
// ---------------------------------------------------------------------------------------------------------
// Программа для аналитической обработки данных из Базы Данных "Искусство и Искусствоведы".
// Обработка состоит в следующем:
//
// 1) Для всех искусствоведов определяется их статус и, соответственно, значимость (вес) их мнения.
//
// 2) Для каждого искусствоведа вычисляется количество статей, в которых он был соавтором, а так же
//    количество критических отзывов, которые он написал.
//
// 3) Для каждого критического отзыва на статью определяется целочисленная оценка статьи - 
//    это делается исходя из двух параметров: качественной оценки, данной в самом отзыве, и
//    значимости (веса) мнения того искусствоведа, который был автором этого отзыва (в отличие от
//    статей, где может быть много соавторов, у каждого критического отзыва только один автор).
//
// 4) Для каждой статьи, описывающей картину, определяется оценка картины - как среднее значение
//    от оценок, данных каждым из соавторов этой статьи. А так же рейтинг самой этой статьи - как
//    сумма оценок статьи, данных во всех критических отзывах, связанных с этой статьей.
//
// 5) Для каждой картины определяется ее оценка, данная искусствоведами - как оценка, данная в статье,
//    посвященной этой картине, и имеющей самый высокий рейтинг (среди множествва других статей, так же
//    посвященных этой картине).
// ---------------------------------------------------------------------------------------------------------
// Это первый полнофункциональный вариант программы для аналитической обработки данных
// из БД "Искусство и Искусствоведы".
// Он написан с использованием Windows Forms для формирования пользовательского интерфейса и
// ADO.NET для организации доступа к данным из БД.
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

using Art_DataBase_Analytical.Controller;
using Art_DataBase_Analytical.EventArguments;

namespace Art_DataBase_Analytical.View
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

        // отобразить полный набор данных обо всех искусствоведах
        public void ShowAllCritics(object o, ArtCriticEventArgs e)
        {
            ShowCriticData?.Invoke(this, e);
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
        private event EventHandler<ArtCriticEventArgs> ShowCriticData;

        // ---- popov 06.03.2021 ----
        // Флаг того, что очистка таблицы с данными Искусствоведов установленна.
        private bool m_ClearCritics = false;
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
            MyController.ShowAllCritics += this.ShowAllCritics;
            MyController.BothButtonsEnabled += this.ForwardBackwardEnabled;
            MyController.BackwardDisabled += this.BackwardDisabled;
            MyController.ForwardDisabled += this.ForwardDisabled;

            // -----------------------------------------------------------------------
            // ---- Подписываем Контроллер на события Представления ----
            // -----------------------------------------------------------------------
            this.LoadFirstDataBlock += MyController.LoadFirstCanvasBlock;
            this.LoadForwardDataBlock += MyController.LoadForwardCanvasBlock;
            this.LoadBackwardDataBlock += MyController.LoadBackwardCanvasBlock;

            // -------------------------------------------------------------------------------------
            // привязываем обработчики событий компонентов для отображения картин
            SubscribeOnCleanDataEvent();
            SubscribeOnRefreshDataEvent();

            // -------------------------------------------------------------------------------------
            // привязываем обработчик события для компонента для отображения данных искусствоведов
            this.ShowCriticData += criticsInformation1.RefreshArtCriticsData;
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

        // --------------------------------------------------------------------------------------
        // ---- popov 06.03.2021 ----
        // --------------------------------------------------------------------------------------
        // Установить/Разорвать связь между событием очистки данных и
        // его обработчиком в таблице с данными Искусствоведов.
        // --------------------------------------------------------------------------------------
        // Установить связь с обработчиком событий в таблице Искусствоведов
        private void AddCriticsEventRelation()
        {
            m_ClearCritics = true;
            ClearCanvasData += criticsInformation1.CleanArtCriticsData;
        }

        // --------------------------------------------------------------------------------------
        // Разорвать связь с обработчиком событий в таблице Искусствоведов
        private void RemoveCriticsEventRelation()
        {
            if (m_ClearCritics)
            {
                m_ClearCritics = false;
                ClearCanvasData -= criticsInformation1.CleanArtCriticsData;
            }
        }
        // --------------------------------------------------------------------------------------
        // ------------------------------------------------------------------------------------------------
        // Загрузка данных из БД - это в общем случае длительная 
        // процедура, которая может завершится ошибкой и которую 
        // надо запустить на выполнение в параллельном потоке
        private void LoadAllDataFromDB()
        {
            AddCriticsEventRelation();
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

        // ------------------------------------------------------------------------------------------------
        // При загрузке окна требуем отобразить первый блок данных
        private void MainView_Load(object sender, EventArgs e)
        {
            // загрузка всех данных о картинах, искусствоведах и т.д., - 
            // из БД "Искусство и Искусствоведы" - в параллеьнром потоке
            LoadAllDataFromDB();
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
        // Обновить данные - получить все данные из БД заново
        private void button_RefreshData_Click(object sender, EventArgs e)
        {
            LoadAllDataFromDB();
        }

        // ------------------------------------------------------------------------------------------------
        // При попытке перейти назад требуем отобразить предыдущий блок данных
        private void button_Backward_Click(object sender, EventArgs e)
        {
            RemoveCriticsEventRelation();
            LoadBackwardDataBlock?.Invoke(this, null);
        }

        // ------------------------------------------------------------------------------------------------
        // При попытке перейти вперед требуем отобразить следующий блок данных
        private void button_Forward_Click(object sender, EventArgs e)
        {
            RemoveCriticsEventRelation();
            LoadForwardDataBlock?.Invoke(this, null);
        }
    }
}
