// ---------------------------------------------------------------------------------------------------------
// ---- popov 06.04.2021 ----
// ---------------------------------------------------------------------------------------------------------
// Служебный класс для чтения строки подключения из файла настроек
// ---------------------------------------------------------------------------------------------------------

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using System.IO;

namespace Get_Images_From_DataBase_MVVM.Model.ConnectionString
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
            m_FullSettingsPath = System.AppDomain.CurrentDomain.BaseDirectory + "\\" + m_SettingFileName;
            if (File.Exists(m_FullSettingsPath))
            {
                m_ConnectionString = File.ReadAllText(m_FullSettingsPath);
            }
        }
    }
}
