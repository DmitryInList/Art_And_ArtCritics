// ----------------------------------------------------------------------------------------------------------
// ---- popov 10.03.2021 ----
// ----------------------------------------------------------------------------------------------------------
// Теперь в Модели для доступа к БД используется технология Entity Framework.
// ----------------------------------------------------------------------------------------------------------

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Put_Image_In_DataBase_EF.Model.Data;
using System.Drawing;
using Put_Image_In_DataBase_EF.Model.ConnectionString;
using Put_Image_In_DataBase_EF.Model.EntityFramework;

using System.Windows.Forms;

namespace Put_Image_In_DataBase_EF.Model
{
    public class Model: IModel
    {
        // объект для работы со строкой подключения
        CS_Reader ConnStr = new CS_Reader();

        // =====================================================================================
        // ======== Реализация IModel ========
        // =====================================================================================
        // текущий объект данных (только один - поскольку картины загружаются в БД по одной)
        ICanvasInfo CurrentCanvasInfo = null;
        public ICanvasInfo DataObject
        {
            get { return CurrentCanvasInfo; }
        }
        
        // --------------------------------------------------------------------------------------------------------------
        // построить заново объект данных
        public void RebuildData(string FileName, string Ext)
        {
            // изначально сбрасываем предыдущие данные
            CurrentCanvasInfo = null;
            try
            {
                // назание картины в БД пока еще не известно. Оно определяется только в момент сохранения картины в БД
                Image Img = Image.FromFile(FileName);
                CurrentCanvasInfo = new CanvasInfo(FileName, "", Ext, Img);
            }
            catch (Exception ex)
            { }
        }

        // --------------------------------------------------------------------------------------------------------------
        // сохранить в БД текущий объект данных - объект будет созранен под именем CName
        public bool PutCanvasToDB(string CName)
        {
            if (CurrentCanvasInfo == null)
                return false;

            CurrentCanvasInfo.CanvasName = CName;
           
            bool bResult = true;
            try
            {
                // Здесь вызывается именно наш конструктор, принимающий на вход строу подключения!!!
                using (Art_And_ArtCriticsEntities db = new Art_And_ArtCriticsEntities(ConnStr.ConnectionString))                
                {
                    db.ArtCanvases.Add(new ArtCanvases
                    {
                        Canvas_Id = 0,
                        Canvas_Name = CurrentCanvasInfo.CanvasName,
                        Canvas_Format = CurrentCanvasInfo.GraphicalFileType,
                        Canvas_Screen = CurrentCanvasInfo.GetImageAsByteArray()
                    });
                    db.SaveChanges();
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
