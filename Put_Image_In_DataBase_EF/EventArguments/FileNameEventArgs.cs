// ----------------------------------------------------------------------------------------------
// ---- popov 19.02.2021 ----
// ----------------------------------------------------------------------------------------------
// Аргумент события для передачи имени файла из Представления в Контроллер -
// для создания первичного объекта, хранящего Изображение.
// ----------------------------------------------------------------------------------------------

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Put_Image_In_DataBase_EF.EventArguments
{
    public class FileNameEventArgs:  EventArgs
    {
        private string m_FileName;
        public string FileName
        {
            get { return m_FileName; }
        }

        public FileNameEventArgs(string FN)
        {
            m_FileName = FN;
        }
    }
}
