// ---------------------------------------------------------------------------------------------------------
// ---- popov 06.04.2021 ----
// ---------------------------------------------------------------------------------------------------------
// Специализированный класс, скрывающий работу с диалоговым окном, которое
// будет отображаться во время загрузки данных из БД "Искусство и Искусствоведы"
// ---------------------------------------------------------------------------------------------------------

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using Base_For_MVVM;
using Get_Images_From_DataBase_MVVM.View;

namespace Get_Images_From_DataBase_MVVM.View.DialogHiders
{
    public class LoadDataDialogHider<T> : IDialogHiding<T> where T: DialogBaseViewModel
    {
        public bool? ShowDialog(T datacontext)
        {   
            WelcomeDialog Dlg = new WelcomeDialog();
            Dlg.DataContext = datacontext;
            // в процессе загрузки происходит чтение данных из БД "Искусство и Искусствоведы"
            Dlg.ShowDialog();            
            return datacontext.bResult;
        }
    }
}
