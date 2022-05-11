// ---------------------------------------------------------------------------------------------------------
// ---- popov 29.04.2021 ----
// ---------------------------------------------------------------------------------------------------------
// Специализированный класс, скрывающий работу с диалоговым окном, которое
// отображает детальную информацию об одной картине (картина + оценка картины)
// ---------------------------------------------------------------------------------------------------------

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Base_For_MVVM;
using Art_DataBase_Analytical_MVVM.View;

namespace Art_DataBase_Analytical_MVVM.View.DialogHiders
{
    public class CanvasDetailsDialogHider<T> : IDialogHiding<T> where T : DialogBaseViewModel
    {
        public bool? ShowDialog(T datacontext)
        {
            CanvasDetailsDialog Dlg = new CanvasDetailsDialog();
            Dlg.DataContext = datacontext;            
            Dlg.ShowDialog();
            return datacontext.bResult;
        }

    }
}
