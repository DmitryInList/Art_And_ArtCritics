// ---------------------------------------------------------------------------------------------------------
// ---- popov 08.04.2021 ----
// ---------------------------------------------------------------------------------------------------------
// Новая точка входа в программу (работа программы теперь начинается отсюда)
// ---------------------------------------------------------------------------------------------------------

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Art_DataBase_Analytical_MVVM;
using Art_DataBase_Analytical_MVVM.Model;

using Art_DataBase_Analytical_MVVM.ViewModel;

using Art_DataBase_Analytical_MVVM.View.DialogHiders;
using Art_DataBase_Analytical_MVVM.View.WindowMediator;
using System.Windows;

using Base_For_MVVM;

namespace Art_DataBase_Analytical_MVVM.ApplicationInput
{
    public class NewApplicationInput
    {
        [STAThread]
        static void Main(string[] args)
        {
            Application app = new Application();

            // ----------------------------------------------------------------------------------------------
            // ---- popov 22.04.2021 ----
            // ----------------------------------------------------------------------------------------------
            // регистрируем соответствие между типами моделей представления, предназначенных для
            // работы с диалоговыми окнами - и типами объектов для сокрытия соответствкющих им
            // диалоговых окнон...
            // ----------------------------------------------------------------------------------------------            
            // пара: Модель Представления загрузки данных ---> Диалог загрузки данных из БД.
            MyDialogService.Register<LoadDataFromDBViewModel, LoadDataDialogHider<LoadDataFromDBViewModel>>();            
            // пара: Модель Представления одной картины ---> Диалог отображения одной карины.            
            MyDialogService.Register<ShowCanvasDialogViewModel, CanvasDetailsDialogHider<ShowCanvasDialogViewModel>>();
            // пара: Модель Представления одной картины + Перечень статей ---> Диалог отображения подробных данных об одной картине.
            MyDialogService.Register<ShowCanvasArticlesDialogViewModel, CanvasArticlesDialogHider<ShowCanvasArticlesDialogViewModel>>();
            // пара: Модель Представления одной статьи + Перечень соавторов + Перечень критических отзывов ---> Диалог отображения подробных данных о статье
            MyDialogService.Register<ShowArticleDetailsDialogViewModel, ArticleDetailsDialogHider<ShowArticleDetailsDialogViewModel>>();
            // пара: Модель Представления одного отзыва + все сопуствующие данные ---> Диалог отображения подробных данных об отзыве.
            MyDialogService.Register<ShowFeedbackDetailsDialogViewModel, FeedbackDetailsDialogHider<ShowFeedbackDetailsDialogViewModel>>();
            // пара: Модель Представления одного искусствоведа ---> Диалог отображения подробных данных об искусствоведе
            MyDialogService.Register<ShowCriticDetailsDialogViewModel, CriticDetailsDialogHider<ShowCriticDetailsDialogViewModel>>();
            // ----------------------------------------------------------------------------------------------


            // поскольку я ввел альтернативную точку входа в программу, оказалось
            // что я теперь не могу использовать стандартную привязку файлов ресурсов
            // в разметке файла App.xaml...
            // При этом привязку к фалам ресурсов придется делать явно и прямо в коде
            Application.Current.Resources.MergedDictionaries.Add(new ResourceDictionary() { Source = new Uri("/Art_DataBase_Analytical_MVVM;component/StylesResource.xaml", UriKind.Relative) });

            MainWindow wnd = new MainWindow();

            // получаем определенное в главном окне максимальное число
            // картин, которые одноврвменно могут быть отображены в этом окне
            MainWindowMediator mwm = wnd.Tag as MainWindowMediator;
            int MaxCanvasRealValue = 1; // значение по-умолчанию, если забыли задать этот параметр
            if (mwm != null)
            {
                MaxCanvasRealValue = mwm.CanvasMaxCount;
            }

            
            MainWindowViewModel MWvm = new MainWindowViewModel(new Model.Model(), MaxCanvasRealValue);
            // фиксируем контекст данных
            wnd.DataContext = MWvm;            

            app.Run(wnd);
        }
    }
}
