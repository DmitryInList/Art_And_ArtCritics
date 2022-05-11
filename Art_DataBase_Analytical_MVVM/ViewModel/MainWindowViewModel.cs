// ------------------------------------------------------------------------------------------------------------
// ---- popov 28.04.2021 ----
// ------------------------------------------------------------------------------------------------------------
// Модель представления для взаимодейтсвия с главным окном программы.
// ------------------------------------------------------------------------------------------------------------

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Base_For_MVVM;
using Art_DataBase_Analytical_MVVM.Model;
using Art_DataBase_Analytical_MVVM.Model.Data;
using System.Windows;
using System.Windows.Input;



namespace Art_DataBase_Analytical_MVVM.ViewModel
{
    public class MainWindowViewModel: BaseViewModel
    {
        // ссылка на Модель
        private IModel _CurrentModel;
        public IModel CurrentModel
        {
            get { return _CurrentModel; }
            set
            {
                _CurrentModel = value;
            }
        }

        // максимальное число одновременно отображаемых картин из БД "Искусство и Искусствоведы"
        private int _CountOfCanvases;
        public int CountOfCanvases
        {
            get { return _CountOfCanvases; }
            set
            {
                _CountOfCanvases = value;
            }
        }

        // ---------------------------------------------------------------------------------------------------
        // ---- Основные рабочие свойства модели представления ----
        // ---------------------------------------------------------------------------------------------------
        // Подмножество отображаемых в текущий момент картин
        private List<OneCanvasViewModel> m_CurrentDataPart = new List<OneCanvasViewModel>();
        public List<OneCanvasViewModel> CurrentDataPart
        {
            get { return m_CurrentDataPart; }
            set
            {
                m_CurrentDataPart = value;
                OnPropertyChanged();
            }
        }

        // множество всех найденных искусствоведов
        private List<IArtCriticInfo> m_CriticsList = new List<IArtCriticInfo>();
        public List<IArtCriticInfo> CriticsList
        {
            get { return m_CriticsList; }
            set
            {
                m_CriticsList = value;
                OnPropertyChanged();
            }
        }

        // служебная процедура для очистки подмножества картин, отображаемых в данный момент
        private void ClearCurrentDataPart(bool ClearCritics = false)
        {
            // ---- popov 05.05.2022 ----
            // Теперь все делается проще...
            /*
            List<OneCanvasViewModel> BufferList = new List<OneCanvasViewModel>();
            for (int i = 0; i < CountOfCanvases; i++)
            {
                BufferList.Add(new OneCanvasViewModel(null));
            }
            CurrentDataPart = BufferList;

            // ---- popov 03.05.2021 ----
            if(ClearCritics)
            {
                // очистить отображаемый список искусствоведов - только при загрузке новых данных из БД
                CriticsList = null;
            }
            */
            CurrentDataPart = null;
            if (ClearCritics)
            {
                // очистить отображаемый список искусствоведов - только при загрузке новых данных из БД
                CriticsList = null;
            }
        }

        // --------------------------------------------------------------------------------------------------
        // ---- Служебные и управляющие переменные и методы ----
        // --------------------------------------------------------------------------------------------------
        // начальный и конечный индексы, определяющие 
        // текущее размещение блока отображаемых данных на списке всех данных.
        private int StartIndex = 0;
        private int StopIndex = 0;

        // флаг того, что можно продолжать продвигаться НАЗАД
        private bool CanGoBackward = true;
        // флаг того, что можно продолжать продвигаться ВПЕРЕД
        private bool CanGoForward = true;

        // ссылка на объект, скрывающий работу с диалоговым окном загрузки данных из БД "Искусство и Искусствоведы"
        //private IDialogHiding<LoadDataFromDBViewModel> DataBaseLoader = new LoadDataDialogHider<LoadDataFromDBViewModel>();

        // узкоспециализированная модель представления, предназначенная для работы с 
        // диалоговым окном загрузки исходных данных из БД "Искусство и Искусствоведы"
        private LoadDataFromDBViewModel LoadDBViewModel;

        // ---------------------------------------------------------------------------------------------------------
        // ---- получение первоначвального расположения индексов - сразу после загрузки данных из БД ----
        // ---------------------------------------------------------------------------------------------------------
        private bool TakeStartIndexPosition()
        {
            StartIndex = 0;
            if (CurrentModel.AllArtCanvases.Count() == 0)
            {
                // никуда двигаться нельзя - нет исходных данных
                CanGoBackward = false;
                CanGoForward = false;
                return false;
            }

            GetNextStopIndex();

            // можно двигаться вперед или назад (по мере возможности)
            CanGoBackward = true;
            CanGoForward = true;
            return true;
        }

        // ---------------------------------------------------------------------------------------------------------
        // ---- Получение закрывающего индекса ----
        // ---------------------------------------------------------------------------------------------------------
        private void GetNextStopIndex()
        {
            if ((StartIndex + CountOfCanvases) >= CurrentModel.AllArtCanvases.Count())
            {
                StopIndex = CurrentModel.AllArtCanvases.Count();
            }
            else
            {
                StopIndex = (StartIndex + CountOfCanvases);
            }
        }

        // ---------------------------------------------------------------------------------------------------------
        // ----  Попытаться сдвинуться вперед по глобальному списку объектов данных ----
        // ---------------------------------------------------------------------------------------------------------
        private bool TryShiftForward()
        {
            if ((StartIndex + CountOfCanvases) >= CurrentModel.AllArtCanvases.Count())
            {
                CanGoForward = false;
                return false; // дальше вперед нельзя
            }


            StartIndex = (StartIndex + CountOfCanvases);
            GetNextStopIndex();

            // если мы все-таки продвинулись вперед - то теперь уж точно
            // можно двигаться назад...
            CanGoBackward = true;
            return true;
        }

        // ---------------------------------------------------------------------------------------------------------
        // ---- Попытатся сдинутся назад по глобальному списку объектов данных ----
        // ---------------------------------------------------------------------------------------------------------
        private bool TryShiftBackward()
        {
            if ((StartIndex - CountOfCanvases) < 0)
            {
                CanGoBackward = false;
                return false; // дальше назад нельзя
            }


            StartIndex = (StartIndex - CountOfCanvases);
            GetNextStopIndex();

            // если мы все-таки продвинулись назад - то теперь уж точно
            // можно двигаться вперед...
            CanGoForward = true;
            return true;
        }

        // ---------------------------------------------------------------------------------------------------------
        // ---- Получить данные из глобального списка в локальный список - в соответствии с текущими индексами ----
        // ---------------------------------------------------------------------------------------------------------
        private void TakeDataIntoLocalListFromGlobal()
        {
            ClearCurrentDataPart();
            // ---- popov 05.05.2022 ----
            // Теперь это реализуется при помощи LINQ-запросов:
            /*
            int CurrentIndex = 0;
            for (int i = StartIndex; i < StopIndex; i++)
            {
                CurrentDataPart[CurrentIndex++].TheCanvas = CurrentModel.AllArtCanvases[i];
            }
            */
            CurrentDataPart = CurrentModel.AllArtCanvases
                                    .Skip(StartIndex)
                                    .Take(CountOfCanvases)
                                    .Select(ac => new OneCanvasViewModel(ac))
                                    .ToList();
        }


        // ==================================================================================================
        // ==== Команды ====
        // ==================================================================================================
        // 1. Загрузить данные из БД "Искусство и исксствоведы"
        public ICommand LoadDataFromDB { get; set; }
        private void OnLoadDataFromDBExecute(object o)
        {
            if (LoadDBViewModel == null)
                LoadDBViewModel = new LoadDataFromDBViewModel(CurrentModel);

            // надо сбросить старые изображения - чтобы они не были видны пока данные рузятся
            ClearCurrentDataPart(true);
                        
            // Еще более глубокое разделение между Моделью Представления и самим Представлением...            
            if (MyDialogService.ShowDialog<LoadDataFromDBViewModel>(LoadDBViewModel) != true)
            {
                MessageBox.Show("Не удалось получить исходные данные из БД 'Искусство и Искусствоведы'!", "Нет исходных данных!", MessageBoxButton.OK, MessageBoxImage.Exclamation);
                // принудительно закрываем программу - ловить больше нечего
                Application.Current.Shutdown();
                return;
            }

            // значит какие-то данные были получены
            if (TakeStartIndexPosition())
            {
                TakeDataIntoLocalListFromGlobal();
            }
            // ---- popov 29.04.2021 ----
            // заново получаем данные обо всех искусствоведах
            CriticsList = CurrentModel.AllArtCritics.ToList();
        }

        // ------------------------------------------------------
        // 2. Сдвинутся Вперед.
        public ICommand MoveForwardCommand { get; set; }
        private bool MoveForwardCommandCanExecute(object o)
        {
            return CanGoForward;
        }
        public void OnMoveForwardCommandExecute(object o)
        {
            if (TryShiftForward())
            {
                TakeDataIntoLocalListFromGlobal();
            }
        }

        // ------------------------------------------------------
        // 3. Сдвинутся Назад.
        public ICommand MoveBackwardCommand { get; set; }
        private bool MoveBackwardCommandCanExecute(object o)
        {
            return CanGoBackward;
        }
        private void OnMoveBackwardCommandExecute(object o)
        {
            if (TryShiftBackward())
            {
                TakeDataIntoLocalListFromGlobal();
            }
        }

        // ------------------------------------------------------
        // 4. Закрыть приложение.
        public ICommand CloseApplicationCommand { get; set; }
        private void OnCloseApplicationCommandExecute(object o)
        {
            if (MessageBox.Show("Вы действительно хотите выйти из программы?", "Подтвердите завершение работы", MessageBoxButton.YesNo, MessageBoxImage.Question) == MessageBoxResult.Yes)
            {
                Application.Current.Shutdown();
            }
        }

        // ------------------------------------------------------
        // 5. Щелчок на искусствоведе в списке всех искусствоведов
        public ICommand ArtCriticListClickCommand { get; set; }        
        // ==================================================================================================

        public MainWindowViewModel(IModel M, int ccnt)
        {
            CurrentModel = M;

            CountOfCanvases = ccnt;

            // команда загрузки данных
            LoadDataFromDB = new LambdaCommand(OnLoadDataFromDBExecute);

            // команда перемещения вперед
            MoveForwardCommand = new LambdaCommand(OnMoveForwardCommandExecute, MoveForwardCommandCanExecute);

            // команда перемещения назад
            MoveBackwardCommand = new LambdaCommand(OnMoveBackwardCommandExecute, MoveBackwardCommandCanExecute);

            // команда закрытия приложения
            CloseApplicationCommand = new LambdaCommand(OnCloseApplicationCommandExecute);

            // команда щелчка по строке с данными одного искусствоведа
            ArtCriticListClickCommand = CommonCommandDefenitions.CreateCriticDetailsCommand();

            // сразу при создании модели представления запустим первичное получение данных
            // из БД "Искусство и Искусствоведы"
            OnLoadDataFromDBExecute(null);
        }
    }
}
