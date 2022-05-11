// ---------------------------------------------------------------------------------------------------------
// ---- popov 30.04.2021 ----
// ---------------------------------------------------------------------------------------------------------
// Специализированный класс, скрывающий работу с диалоговым окном, которое
// отображает информацию об одной статье (картина, которой посвящена статья + 
// сама статья + перечень искусствоведов-соавторов + перечень критических отзывов на эту статью)
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
    public class ArticleDetailsDialogHider<T> : IDialogHiding<T> where T : DialogBaseViewModel
    {
        public bool? ShowDialog(T datacontext)
        {
            ArticleDetailsDialog Dlg = new ArticleDetailsDialog();
            Dlg.DataContext = datacontext;            
            Dlg.ShowDialog();
            return datacontext.bResult;
        }
    }
}
