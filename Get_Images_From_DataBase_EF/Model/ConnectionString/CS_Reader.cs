// ---------------------------------------------------------------------------------------------------------
// ---- popov 10.03.2021 ----
// ---------------------------------------------------------------------------------------------------------
// Служебный класс для чтения строки подключения из файла настроек
// ---------------------------------------------------------------------------------------------------------

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using System.IO;
using System.Windows.Forms;

namespace Get_Images_From_DataBase_EF.Model.ConnectionString
{
    public class CS_Reader
    {
        // Имя файла настройки, содержащего актуальную строку подключения
        // Этот файл должен быть расположен вместе с исполняемым файлом программы,
        // котрая будет использовать эту библиотеку классов...        
        private string m_SettingFileName = "Строка подключения.txt";

        // Полный путь к файлу настройки "Строка подключения.txt"
        private string m_FullSettingsPath = "";

        // Строка подключения к базе данных - динамически читается из файла настройки
        private string m_ConnectionString = "";
        public string ConnectionString
        {
            get { return m_ConnectionString; }
        }

        public CS_Reader()
        {
            m_FullSettingsPath = Application.StartupPath + "\\" + m_SettingFileName;
            if(File.Exists(m_FullSettingsPath))
            {
                m_ConnectionString = File.ReadAllText(m_FullSettingsPath);
            }
        }
    }
}
