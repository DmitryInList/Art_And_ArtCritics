// ----------------------------------------------------------------------------------------------------------
// ---- popov 08.04.2021 ----
// ----------------------------------------------------------------------------------------------------------
// Специализированная модель представления для работы с элементом управления 
// (UserControl), который отображает графическое содержимое картины и ее наименование 
// в БД "Искусство и Искусствоведы".
// ----------------------------------------------------------------------------------------------------------


using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Input;
using Base_For_MVVM;
using Get_Images_From_DataBase_MVVM.Model.Data;
using Get_Images_From_DataBase_MVVM.View.DialogHiders;


namespace Get_Images_From_DataBase_MVVM.ViewModel
{
    public class OneCanvasViewModel: BaseViewModel
    {
        private IArtCanvas _TheCanvas;
        public IArtCanvas TheCanvas
        {
            get { return _TheCanvas; }
            set
            {
                _TheCanvas = value;
                OnPropertyChanged();
            }
        }

        //private IDialogHiding<ShowCanvasDialogViewModel> ShowCanvasHider = new CanvasDetailsDialogHider<ShowCanvasDialogViewModel>();
        private ShowCanvasDialogViewModel NextModel = null;

        // ==================================================================================================
        // ==== Команды ====
        // ==================================================================================================
        // При щелчке на изображении будет открываться диалоговое окно
        // отображающее подробные данные о картине...
        public ICommand ShowCanvasDialogCommand { get; set; }
        private void OnShowCanvasDialogCommandExecute(object o)
        {
            if (NextModel == null)
            {
                NextModel = new ShowCanvasDialogViewModel(TheCanvas);
            }

            // ---- popov 22.04.2021 ----
            // Еще более глубокое разделение между Моделью Представления и самим Представлением
            //ShowCanvasHider.ShowDialog(NextModel);
            MyDialogService.ShowDialog<ShowCanvasDialogViewModel>(NextModel);
        }
        // ==================================================================================================

        public OneCanvasViewModel(IArtCanvas c)
        {
            TheCanvas = c;
            ShowCanvasDialogCommand = new LambdaCommand(OnShowCanvasDialogCommandExecute);
        }
    }
}
