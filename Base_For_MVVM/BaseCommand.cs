using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;

namespace Base_For_MVVM
{
    // --------------------------------------------------------------------------------
    // ---- 2. Основа для команд (Command) ----
    // --------------------------------------------------------------------------------
    public abstract class BaseCommand : ICommand
    {
        public event EventHandler CanExecuteChanged
        {
            // Для того, чтобы стал доступен класс CommandManager
            // необходимо добавить в проект ссылку на сборку PresentationCore...
            add => CommandManager.RequerySuggested += value;
            remove => CommandManager.RequerySuggested -= value;
        }
        public abstract bool CanExecute(object parameter);
        public abstract void Execute(object parameter);
    }
}
