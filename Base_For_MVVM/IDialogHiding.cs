using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Base_For_MVVM
{
    // --------------------------------------------------------------------------------
    // ---- 4. Интерфейс для сокрытия работы с диалоговыми окнами из ViewModel ----
    // ----    Цель такого подхода - разорвать (или хотя бы ослабить) связь 
    // ----    между двумя структурными блоками программы: ViewModel и View. 
    // --------------------------------------------------------------------------------
    public interface IDialogHiding<T> where T: DialogBaseViewModel
    {
        bool? ShowDialog(T datacontext);
    }
}
