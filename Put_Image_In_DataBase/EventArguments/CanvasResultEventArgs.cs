// ----------------------------------------------------------------------------------------------
// ---- popov 19.02.2021 ----
// ----------------------------------------------------------------------------------------------
// Аргумент события для передачи из Контроллера в Представление
// информации о результате сохранения Картины в БД "Искусство и Искусствоведы"
// ----------------------------------------------------------------------------------------------


using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Put_Image_In_DataBase.EventArguments
{
    public class CanvasResultEventArgs: EventArgs
    {
        private string m_CanvasName;
        public string CanvasName
        {
            get { return m_CanvasName; }
        }

        private bool m_SavingResult;
        public bool SavingResult
        {
            get { return m_SavingResult; }
        }

        public CanvasResultEventArgs(string CN, bool SR)
        {
            m_CanvasName = CN;
            m_SavingResult = SR;
        }
    }
}
