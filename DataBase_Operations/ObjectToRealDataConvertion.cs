// ----------------------------------------------------------------------------------------------------------
// ---- popov 24.02.2021 ----
// ----------------------------------------------------------------------------------------------------------
// класс расширения для класса OBJECT - он содержит методы расширения,
// которые преобразуют содержимое OBJECT к тем типам данных, которые
// встречаются среди полей базы данных "Искусство и Искусствоведы":
// - int
// - double
// - byte[]
// - string
// - DateTime
// ----------------------------------------------------------------------------------------------------------

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


namespace DataBase_Operations
{
    public static class ObjectToRealDataConvertion
    {
        // -----------------------------------------------------------------------------------------------
        // метод расширения класса OBJECT, который преобразует объект в массив байт,
        // который - как мы надеемся - содержит изображение.
        public static byte[] GetByteArray(this object _object)
        {
            if(_object is DBNull)
            {
                return null;
            }            
            return _object as byte[];
        }

        // -----------------------------------------------------------------------------------------------
        // метод расширения, пребразующий OBJECT в int
        public static int GetInt(this object _object)
        {
            if (_object is DBNull)
            {
                return 0;
            }
            return Convert.ToInt32(_object); 
        }

        // -----------------------------------------------------------------------------------------------
        // метод расширения, преобразующий OBJECT в double
        public static double GetDouble(this object _object)
        {
            if (_object is DBNull)
            {
                return 0;
            }
            return Convert.ToDouble(_object);
        }

        // -----------------------------------------------------------------------------------------------
        // метод расширения, преобразующий OBJECT в string
        public static string GetString(this object _object)
        {
            if (_object is DBNull)
            {
                return "";
            }
            return Convert.ToString(_object);
        }

        // -----------------------------------------------------------------------------------------------
        // метод расширения, преобразующий OBJECT в DateTime?
        public static DateTime? GetDateTime(this object _object)
        {
            if (_object is DBNull)
            {
                return null;
            }
            return (DateTime?)Convert.ToDateTime(_object);
        }
    }
}
