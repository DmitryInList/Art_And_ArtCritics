// ---------------------------------------------------------------------------------------------------------
// ---- popov 02.05.2021 ----
// ---------------------------------------------------------------------------------------------------------
// Специализированный класс, скрывающий работу с диалоговым окном, которое
// отображает всю информацию об одном критическом отзыве на статью:
// - картина, которой посвящена статья
// - статья, посвященная этой картине
// - критический отзыв на статью, рассматриваемый в этом диалоге
// - искусствовед-автор этого критического отзыва.
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
    public class FeedbackDetailsDialogHider<T> : IDialogHiding<T> where T : DialogBaseViewModel
    {
        public bool? ShowDialog(T datacontext)
        {
            FeedbackDetailsDialog Dlg = new FeedbackDetailsDialog();
            Dlg.DataContext = datacontext;            
            Dlg.ShowDialog();
            return datacontext.bResult;
        }
    }
}
