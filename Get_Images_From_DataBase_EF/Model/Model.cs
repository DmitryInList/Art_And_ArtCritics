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

using Get_Images_From_DataBase_EF.Model.Data;
using Get_Images_From_DataBase_EF.Model.ConnectionString;
using Get_Images_From_DataBase_EF.Model.EntityFramework;

using System.Windows.Forms;

namespace Get_Images_From_DataBase_EF.Model
{
    public class Model: IModel
    {
        // объект для работы со строкой подключения
        CS_Reader ConnStr = new CS_Reader();

        // Набор данных о Картинах, прочитанный из БД "Искусство и Искусствоведы"
        private List<IArtCanvas> m_AllCanvases = new List<IArtCanvas>();

        // ---- popov 05.05.2022 ----
        // Реализация IModel
        public IEnumerable<IArtCanvas> AllCanvases
        {
            get { return m_AllCanvases; }
        }

        // прочитать данные из БД
        public bool ReadAllCanvasFromDataBase()
        {
            m_AllCanvases.Clear();

            bool bResult = true;

            try
            {
                // Здесь вызывается именно наш конструктор, принимающий на вход строку подключения!!!
                using (Art_And_ArtCriticsEntities db = new Art_And_ArtCriticsEntities(ConnStr.ConnectionString))
                {
                    m_AllCanvases.AddRange
                        (
                            db.ArtCanvases.Select(x => new ArtCanvas
                            {
                                CanvasName = x.Canvas_Name,
                                CanvasData = x.Canvas_Screen,
                                FileExtention = x.Canvas_Format
                            }).ToList<IArtCanvas>()
                        );
                }
            }
            catch(Exception ex)
            {
                bResult = false;
                MessageBox.Show("Ошибка работы с базой данных: " + Environment.NewLine + "'" + ex.Message + "'!", "Ошибка выполнения!", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            return bResult;
        }
    }
}
