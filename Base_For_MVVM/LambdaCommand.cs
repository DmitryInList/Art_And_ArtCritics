﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Base_For_MVVM
{
    // --------------------------------------------------------------------------------
    // ---- 3. Полнофункциональная реализация команды MVVM ----
    // --------------------------------------------------------------------------------
    public class LambdaCommand : BaseCommand
    {
        private readonly Action<object> _Execute;
        private readonly Func<object, bool> _CanExecute;

        public LambdaCommand(Action<object> execute, Func<object, bool> canExecute = null)
        {
            _Execute = execute;
            if (_Execute == null)
            {
                throw new ArgumentNullException(nameof(execute));
            }
            _CanExecute = canExecute;
        }

        public override bool CanExecute(object parameter)
        {
            return _CanExecute?.Invoke(parameter) ?? true;
        }

        public override void Execute(object parameter)
        {
            _Execute(parameter);
        }
    }
}
