// --------------------------------------------------------------------------------------------------------
// ---- popov 06.04.2021 ----
// --------------------------------------------------------------------------------------------------------
// Набор базовых средств для облегчения реализации программы в соответствии с шаблоном MVVM.
// --------------------------------------------------------------------------------------------------------

using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;
using System.Windows;

namespace Base_For_MVVM
{
    // --------------------------------------------------------------------------------
    // ---- 1. Основа для моделей представления (ViewModel) ----
    // --------------------------------------------------------------------------------
    // Для того, чтобы стал доступен класс DependencyObject 
    // необходимо добавить ссылку на сборку WindowsBase
    //
    public abstract class BaseViewModel: INotifyPropertyChanged
    {
        public event PropertyChangedEventHandler PropertyChanged;
        protected virtual void OnPropertyChanged([CallerMemberName] string PropertyName = null)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(PropertyName));
        }
    }
}
