// ----------------------------------------------------------------------------------------------------------
// ---- popov 28.04.2021 ----
// ----------------------------------------------------------------------------------------------------------
// Узкоспециализированная модель представления, предназначенная для работы с 
// диалоговым окном, которое будет отображать подробные данные об одной картине
// из БД "Искусство и Искусствоведды".
// Здесь же будут обрабатываться события щелчка кнопках "Закрыть" и "Подробнее"
// ----------------------------------------------------------------------------------------------------------

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Art_DataBase_Analytical_MVVM.Model.Data;
using Base_For_MVVM;
using System.Windows.Input;
using System.Windows;

namespace Art_DataBase_Analytical_MVVM.ViewModel
{   
    public class ShowCanvasDialogViewModel : BaseCanvasDialogViewModel
    {
        // модель представления, соответствующая следующему окну (картина + все статьи, посвященные картине)
        private ShowCanvasArticlesDialogViewModel NextModel = null;

        // ==================================================================================================
        // ==== Команды ====
        // ==================================================================================================
        // ---- команда нажатия на кнопку "Подробнее" ----
        public ICommand ButtonOneClickCommand { get; set; }
        private void OnButtonOneClickCommandExecute(object o)
        {
            if(NextModel == null)
            {
                NextModel = new ShowCanvasArticlesDialogViewModel(TheCanvas);
                MyDialogService.ShowDialog<ShowCanvasArticlesDialogViewModel>(NextModel);
            }
        }
        
        // ==================================================================================================
        public ShowCanvasDialogViewModel(IArtCanvasInfo ac)
        {
            TheCanvas = ac;
            ButtonOneClickCommand = new LambdaCommand(OnButtonOneClickCommandExecute);            
        }
    }
}
