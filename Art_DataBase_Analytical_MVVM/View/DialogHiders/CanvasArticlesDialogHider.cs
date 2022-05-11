// ---------------------------------------------------------------------------------------------------------
// ---- popov 30.04.2021 ----
// ---------------------------------------------------------------------------------------------------------
// Специализированный класс, скрывающий работу с диалоговым окном, которое
// отображает информацию о картине и о статьях, посвященных этой картине (картина + перечень статей)
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
    public class CanvasArticlesDialogHider<T> : IDialogHiding<T> where T : DialogBaseViewModel
    {
        public bool? ShowDialog(T datacontext)
        {
            CanvasArticlesDialog Dlg = new CanvasArticlesDialog();
            Dlg.DataContext = datacontext;            
            Dlg.ShowDialog();
            return datacontext.bResult;
        }
    }
}
