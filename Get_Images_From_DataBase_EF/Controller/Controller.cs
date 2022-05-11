// ----------------------------------------------------------------------------------------------------------
// ---- popov 21.02.2021 ----
// ----------------------------------------------------------------------------------------------------------
// Контроллер - изолированная часть программы, содержащая (в идеальном случае) всю бизнесс-логику.
// ----------------------------------------------------------------------------------------------------------

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Get_Images_From_DataBase_EF.Model;
using Get_Images_From_DataBase_EF.Model.Data;
using Get_Images_From_DataBase_EF.EventArguments;

namespace Get_Images_From_DataBase_EF.Controller
{
    public class Controller: IController
    {
        // ссылка на Модель
        private IModel myModel;        

        //  максимальное число одновременно отображаемых блоков данных
        private int m_MaxDataBlockCount;
        public int MaxDataBlockCount
        {
            get { return m_MaxDataBlockCount; }
            set { m_MaxDataBlockCount = value; }
        }        

        // ---------------------------------------------------------------------------
        //  ---- События Контроллера ----
        // ---------------------------------------------------------------------------
        // очистить все текущие изображения картин в главном окне
        public event EventHandler ClearAllCanvases;

        // отобразить блок из нескольких картин в главном окне
        public event EventHandler<ArtCanvasEventArgs> RefreshAllCanvases;

        // Обе кнопки (Вперед и Назад) доступны.
        public event EventHandler BothButtonsEnabled;

        // Кнопка Вперед - доступна, а кнопка Назад - нет.
        public event EventHandler BackwardDisabled;

        // Кнопка Назад - доступна, а кнопка Вперед - нет.
        public event EventHandler ForwardDisabled;

        // ---------------------------------------------------------------------------
        // текущее подмножество данных, которые отображаются пользователю.
        private List<IArtCanvas> m_CurrentDataPart = new List<IArtCanvas>();
        public List<IArtCanvas> CurrentDataPart
        {
            get { return m_CurrentDataPart; }
        }

        // начальный и конечный индексы, определяющие 
        // текущее размещение блока отображаемых данных на списке всех данных.
        private int StartIndex = 0;
        private int StopIndex = 0;

        // =================================================================================
        public Controller(IModel M)
        {
            myModel = M;
        }        

        // ---------------------------------------------------------------------------------------------------------
        // ---- получение первоначвального расположения индексов - сразу после загрузки данных из БД ----
        // ---------------------------------------------------------------------------------------------------------
        private bool TakeStartIndexPosition()
        {
            StartIndex = 0;
            if (myModel.AllCanvases.Count() == 0)
                return false;

            GetNextStopIndex();
            return true;
        }

        // ---------------------------------------------------------------------------------------------------------
        // ---- Получение закрывающего индекса ----
        // ---------------------------------------------------------------------------------------------------------
        private void GetNextStopIndex()
        {
            if ((StartIndex + MaxDataBlockCount) >= myModel.AllCanvases.Count())
            {
                StopIndex = myModel.AllCanvases.Count();
            }
            else
            {
                StopIndex = (StartIndex + MaxDataBlockCount);
            }
        }

        // ---------------------------------------------------------------------------------------------------------
        // ----  Попытаться сдвинуться вперед по глобальному списку объектов данных ----
        // ---------------------------------------------------------------------------------------------------------
        private bool TryShiftForward()
        {
            if ((StartIndex + MaxDataBlockCount) >= myModel.AllCanvases.Count())
                return false; // дальше вперед нельзя

            StartIndex = (StartIndex + MaxDataBlockCount);
            GetNextStopIndex();

            return true;
        }

        // ---------------------------------------------------------------------------------------------------------
        // ---- Попытатся сдинутся назад по глобальному списку объектов данных ----
        // ---------------------------------------------------------------------------------------------------------
        private bool TryShiftBackward()
        {
            if ((StartIndex - MaxDataBlockCount) < 0)
                return false; // дальше назад нельзя

            StartIndex = (StartIndex - MaxDataBlockCount);
            GetNextStopIndex();

            return true;
        }

        // ---------------------------------------------------------------------------------------------------------
        // ---- Получить данные из глобального списка в локальный список - в соответствии с текущими индексами ----
        // ---------------------------------------------------------------------------------------------------------
        private void TakeDataIntoLocalListFromGlobal()
        {
            m_CurrentDataPart.Clear();

            // ---- popov 05.05.2022 ----
            // Теперь это реализовано при помощи LINQ-запросов:
            m_CurrentDataPart.AddRange(myModel.AllCanvases
                                            .Skip(StartIndex)
                                            .Take(MaxDataBlockCount)
                                            .ToList());
            /*
            for (int i = StartIndex; i < StopIndex; i++)
            {
                m_CurrentDataPart.Add(myModel.AllCanvases[i]);
            }
            */
        }

        // -------------------------------------------------------------------------------------------------
        // Получение всех исходных данных из БД (Подключение к БД "Искусство и Искусствоведы" 
        // выполняется здесь же)
        public bool TryTakeAllCanvasesFromDataBase()
        {
            return myModel.ReadAllCanvasFromDataBase();
        }

        // -------------------------------------------------------------------------
        // ---- Обоработчики событий Представления ----
        // -------------------------------------------------------------------------
        // передать для отображения первый блок данных 
        public void LoadFirstCanvasBlock(object o, EventArgs e)
        {
            // формируем первоначальное подмножество данных для отображения
            if (TakeStartIndexPosition())
            {
                TakeDataIntoLocalListFromGlobal();
                // посылаем сообщение Представлению - пора обнавлять главное окно программы
                RefreshAllCanvases?.Invoke(this, new ArtCanvasEventArgs(CurrentDataPart));
            }
            BothButtonsEnabled?.Invoke(this, null);
        }

        // передать для отображения следующий блок данных
        public void LoadForwardCanvasBlock(object o, EventArgs e)
        {
            if (TryShiftForward())
            {   
                ClearAllCanvases?.Invoke(this, null);
                TakeDataIntoLocalListFromGlobal();
                // посылаем сообщение Представлению - пора обнавлять главное окно программы
                RefreshAllCanvases?.Invoke(this, new ArtCanvasEventArgs(CurrentDataPart));
                BothButtonsEnabled?.Invoke(this, null);
            }
            else
            {
                // кнопка Вперед - не доступна
                ForwardDisabled?.Invoke(this, null);
            }
        }

        // передать для отображения предыдущий блок данных
        public void LoadBackwardCanvasBlock(object o, EventArgs e)
        {
            if (TryShiftBackward())
            {
                ClearAllCanvases?.Invoke(this, null);
                TakeDataIntoLocalListFromGlobal();
                // посылаем сообщение Представлению - пора обнавлять главное окно программы
                RefreshAllCanvases?.Invoke(this, new ArtCanvasEventArgs(CurrentDataPart));
                BothButtonsEnabled?.Invoke(this, null);
            }
            else
            {
                // Кнопка Назад - недоступна
                BackwardDisabled?.Invoke(this, null);
            }
        }
    }
}
