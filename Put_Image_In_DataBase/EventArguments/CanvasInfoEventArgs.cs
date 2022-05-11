// ----------------------------------------------------------------------------------------------
// ---- popov 19.02.2021 ----
// ----------------------------------------------------------------------------------------------
// Аргумент события для передачи из Контроллера в Представление
// визуального содержимого кратины, которая была прочитана из графического файла.
// ----------------------------------------------------------------------------------------------


using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Put_Image_In_DataBase.Model.Data;

namespace Put_Image_In_DataBase.EventArguments
{
    public class CanvasInfoEventArgs: EventArgs
    {
        private ICanvasInfo m_TheCanvasInfo;
        public ICanvasInfo TheCanvasInfo
        {
            get { return m_TheCanvasInfo; }
        }

        public CanvasInfoEventArgs(ICanvasInfo obj)
        {
            m_TheCanvasInfo = obj;
        }
    }
}
