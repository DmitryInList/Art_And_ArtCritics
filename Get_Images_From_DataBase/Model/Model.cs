// ----------------------------------------------------------------------------------------------------------
// ---- popov 20.02.2021 ----
// ----------------------------------------------------------------------------------------------------------
// Все данные программы - здесь. А так же организация доступа к БД
// ----------------------------------------------------------------------------------------------------------


using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Get_Images_From_DataBase.Model.Data;
using DataBase_Operations;

// ДЛЯ ОТЛАДКИ
using System.Windows.Forms;

namespace Get_Images_From_DataBase.Model
{
    public class Model: IModel
    {
        // объект для доступа к БД "Искусство и Искусствоведы"
        private DataBaseOperator DB_Operator = new DataBaseOperator();

        // Набор данных о Картинах, прочитанный из БД "Искусство и Искусствоведы"
        private List<IArtCanvas> m_AllCanvases = new List<IArtCanvas>();

        // ---- popov 05.05.2022 ----
        // Реализация интефейса IModel
        public IEnumerable<IArtCanvas> AllCanvases
        {
            get { return m_AllCanvases; }
        }

        // прочитать данные из БД
        public bool ReadAllCanvasFromDataBase()
        {
            m_AllCanvases.Clear();

            // формируем запрос на добавление новой строки и его параметры
            string commandText = "SELECT Canvas_Name, Canvas_Screen, Canvas_Format FROM ArtCanvases";
            string[] paramNames =  {
                                        "Canvas_Name",
                                        "Canvas_Screen",
                                        "Canvas_Format"
                                   };

            // этот метод сначала сам выполняет подключение к БД, а затем - если
            // подключение прошло нормально,- читает уазанные ему данные из БД.
            // Если что-то пошло не так, возвращается значение NULL.
            List<IReturnedObject> DB_Objects = DB_Operator.GetInfoFromDataBase(commandText, paramNames);
            if(DB_Objects == null)
            {
                return false; // не удалось прочитать данные из БД
            }

            foreach (IReturnedObject obj in DB_Objects)
            {
                m_AllCanvases.Add(new ArtCanvas(obj.Fields[0].GetString(),     // "Canvas_Name"
                                                obj.Fields[1].GetByteArray(),  // "Canvas_Screen"
                                                obj.Fields[2].GetString()));   // "Canvas_Format"
            }
            return true;
        }
    }
}
