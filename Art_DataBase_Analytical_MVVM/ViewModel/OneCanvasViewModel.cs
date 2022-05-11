// ------------------------------------------------------------------------------------------------------------
// ---- popov 18.04.2021 ----
// ------------------------------------------------------------------------------------------------------------
// Специализированная модель представления для работы с элементом управления 
// (UserControl), который отображает графическое содержимое картины и ее наименование 
// в БД "Искусство и Искусствоведы".
// ------------------------------------------------------------------------------------------------------------

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Base_For_MVVM;
using Art_DataBase_Analytical_MVVM.Model.Data;
using System.Windows.Input;
using System.Windows.Media.Imaging;

namespace Art_DataBase_Analytical_MVVM.ViewModel
{
    public class OneCanvasViewModel: BaseViewModel
    {
        private IArtCanvasInfo _TheCanvas;
        public IArtCanvasInfo TheCanvas
        {
            get { return _TheCanvas; }
            set
            {
                _TheCanvas = value;
                OnPropertyChanged();
            }
        }

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
            MyDialogService.ShowDialog<ShowCanvasDialogViewModel>(NextModel);
        }
        // ==================================================================================================

        public OneCanvasViewModel(IArtCanvasInfo ac)
        {
            TheCanvas = ac;
            ShowCanvasDialogCommand = new LambdaCommand(OnShowCanvasDialogCommandExecute);
        }
    }
}
