// ---------------------------------------------------------------------------------------------------------
// ---- popov 07.04.2021 ----
// ---------------------------------------------------------------------------------------------------------
// Базовый класс для узкоспециализированных моделей представления, ориентированных
// на работу с конкретными диалогами программ, работающих с БД "Искусство и Искусствоведы"
// ---------------------------------------------------------------------------------------------------------
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;

namespace Base_For_MVVM
{
    public abstract class DialogBaseViewModel: BaseViewModel
    {
        // результат работы в диалоговом окне: TRUE, если операция выполнена успешно
        private bool m_bResult = false;
        public bool bResult
        {
            get { return m_bResult; }
            set
            {
                m_bResult = value;
                OnPropertyChanged();
            }
        }
    }
}
