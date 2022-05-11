// ----------------------------------------------------------------------------------------------
// ---- popov 19.02.2021 ----
// ----------------------------------------------------------------------------------------------
// Аргумент события для передачи из Представления в Контроллер
// названия, под которым текущая картина должна быть сохранена в БД "Искусство и Искусствоведы"
// ----------------------------------------------------------------------------------------------


using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Put_Image_In_DataBase.EventArguments
{
    public class CanvasNameEventArgs: EventArgs
    {
        private string m_NewCanvasName;
        public string NewCanvasName
        {
            get { return m_NewCanvasName; }
        }

        public CanvasNameEventArgs(string CN)
        {
            m_NewCanvasName = CN;
        }
    }
}
