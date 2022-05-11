// ---------------------------------------------------------------------------------------------------------
// ---- popov 03.05.2021 ----
// ---------------------------------------------------------------------------------------------------------
// Специализированный класс, скрывающий работу с диалоговым окном, которое
// отображает подробные данные об одном искусствоведе
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
    public class CriticDetailsDialogHider<T> : IDialogHiding<T> where T : DialogBaseViewModel
    {
        public bool? ShowDialog(T datacontext)
        {
            CriticDetailsDialog Dlg = new CriticDetailsDialog();
            Dlg.DataContext = datacontext;            
            Dlg.ShowDialog();
            return datacontext.bResult;
        }
    }
}
