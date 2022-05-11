// ---------------------------------------------------------------------------------------------------------
// ---- popov 10.04.2021 ----
// ---------------------------------------------------------------------------------------------------------
// Специализированный класс, скрывающий работу с диалоговым окном, которое
// отображает подробные данные о картине...
// ---------------------------------------------------------------------------------------------------------


using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Base_For_MVVM;
using System.Threading.Tasks;
using Get_Images_From_DataBase_MVVM.View;

namespace Get_Images_From_DataBase_MVVM.View.DialogHiders
{
    public class CanvasDetailsDialogHider<T>: IDialogHiding<T> where T : DialogBaseViewModel
    {
        public bool? ShowDialog(T datacontext)
        {
            CanvasDetailsDialog Dlg = new CanvasDetailsDialog();
            Dlg.DataContext = datacontext;
            // в процессе загрузки происходит чтение данных из БД "Искусство и Искусствоведы"
            Dlg.ShowDialog();
            return datacontext.bResult;
        }
    }
}
