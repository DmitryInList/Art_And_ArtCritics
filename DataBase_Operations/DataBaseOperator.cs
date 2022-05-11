// ----------------------------------------------------------------------------------------------------
// ---- popov 17.02.2021 ----
// ----------------------------------------------------------------------------------------------------
// Библиотека классов для:
//  - Подключения к Базе Данных
//  - Добавления|Удаления|Изменения записи в Базе Данных
//  - Получения набора данных из Базы Данных
//  - Отключения от Базы Данных
// ----------------------------------------------------------------------------------------------------

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using System.IO;
using System.Data.SqlClient;
using System.Data;
using System.Windows.Forms;


namespace DataBase_Operations
{
    public class DataBaseOperator
    {
        // Имя файла настройки, содержащего актуальную строку подключения
        // Этот файл должен быть расположен вместе с исполняемым файлом программы,
        // котрая будет использовать эту библиотеку классов...        
        private string SettingFileName = "Строка подключения.txt";

        // Строка подключения к базе данных - динамически читается из файла настройки
        private string ConnectionString = "";

        // Полный путь к файлу настройки "Строка подключения.txt"
        private string FullSettingsPath = "";

        // Объект для подключения к БД
        private SqlConnection MySqlConnection = null;

        // -----------------------------------------------------------------------------------------
        // Попытка подключиться к БД
        public bool TryConnectToDataBase()
        {
            FullSettingsPath = Application.StartupPath + "\\" + SettingFileName;
            if(!File.Exists(FullSettingsPath))
            {
                return false;
            }
            ConnectionString = File.ReadAllText(FullSettingsPath);

            try
            {
                MySqlConnection = new SqlConnection(ConnectionString);
                MySqlConnection.Open();
            }
            catch(Exception ex)
            {
                MessageBox.Show("При попытке подключиться к БД возникла ошибка: '" + ex.Message + "'!", "Ошибка выполнения!", MessageBoxButtons.OK, MessageBoxIcon.Error); 
                return false;
            }
            return true;
        }

        // -------------------------------------------------------------------------------------------------
        // Попытка отключиться от БД
        public void DisconnectFromDataBase()
        {
            if (MySqlConnection != null)
            {
                if (MySqlConnection.State == ConnectionState.Open)
                {
                    MySqlConnection.Close();
                }
            }
        }

        // --------------------------------------------------------------------------------------------------
        // Попытка Добавить/Изменить/Удалить строку в БД - по запросу INSERT/UPDETE/DELETE.
        // На вход передается:
        //  - commandText = запрос на Добавление/Изменение/Удаление строки (с параметрами)
        //  - ParamNames = массив имен параметров, использованных в commandText
        //  - ParamValues = массив значений параметров, которые будут внесены в новую строку в БД
        public bool TryModyfyInformationInDataBase(string commandText, string[] ParamNames, object[] ParamValues)
        {
            try
            {
                using (var MySqlCommand = new SqlCommand(commandText, MySqlConnection))
                {
                    for (int i = 0; i < ParamNames.Length; i++)
                    {
                        MySqlCommand.Parameters.AddWithValue(ParamNames[i], ParamValues[i]);
                    }
                    // Запускаем команду на добавление
                    MySqlCommand.ExecuteNonQuery();
                }                    
            }
            catch(Exception ex)
            {
                MessageBox.Show("При попытке добавления новой строки в БД возникла ошибка: '" + ex.Message + "'!", "Ошибка выполнения!", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return false;
            }
            return true;
        }

        // --------------------------------------------------------------------------------------------------
        // Получить набор строк - по запросу SELECT
        public List<IReturnedObject> TrySelectSomeRowsFromDataBase(string commandText, string[] ColumnNames)
        {
            List<IReturnedObject> Result = new List<IReturnedObject>();
            try
            {
                using (var MyCommand = new SqlCommand(commandText, MySqlConnection))
                {
                    using (var MyReader = MyCommand.ExecuteReader())
                    {
                        while (MyReader.Read())
                        {
                            IReturnedObject NextObject = new ReturnedObject(ColumnNames.Length);
                            for (int i = 0; i < ColumnNames.Length; i++)
                            {
                                NextObject.Fields[i] = MyReader[ColumnNames[i]];
                            }
                            Result.Add(NextObject);
                        }
                    }
                }
            }
            catch(Exception ex)
            {
                MessageBox.Show("При попытке чтения данных из БД возникла ошибка: '" + ex.Message + "'!", "Ошибка выполнения!", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return null;
            }
            return Result;
        }

        // ------------------------------------------------------------------------------------------------
        // Получение данных в рамках однократного подключения, которое закрывается
        // сразу же после получения данных из БД...
        // Получить набор строк - по запросу SELECT
        public List<IReturnedObject> GetInfoFromDataBase(string commandText, string[] ColumnNames)
        {
            List<IReturnedObject> Result = new List<IReturnedObject>();

            // подключение создается и открывается непосредственно перед чтением данных
            // а после получения данных - подключение автоматически закрывается...
            FullSettingsPath = Application.StartupPath + "\\" + SettingFileName;
            if (!File.Exists(FullSettingsPath))
            {
                return null;
            }
            ConnectionString = File.ReadAllText(FullSettingsPath);
            using (var localConnection = new SqlConnection(ConnectionString))
            {
                try
                {
                    localConnection.Open();
                    using (var MyCommand = new SqlCommand(commandText, localConnection))
                    {
                        using (var MyReader = MyCommand.ExecuteReader())
                        {
                            while (MyReader.Read())
                            {
                                IReturnedObject NextObject = new ReturnedObject(ColumnNames.Length);
                                for (int i = 0; i < ColumnNames.Length; i++)
                                {
                                    NextObject.Fields[i] = MyReader[ColumnNames[i]];
                                }
                                Result.Add(NextObject);
                            }
                        }
                    }
                }
                catch(Exception ex)
                {
                    MessageBox.Show("При попытке доступа к данным из БД возникла ошибка: '" + ex.Message + "'!", "Ошибка выполнения!", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    return null;
                }
            }
            return Result;
        }
    }
}
