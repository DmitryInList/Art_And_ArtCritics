// ----------------------------------------------------------------------------------------------------------
// ---- popov 17.02.2021 ----
// ----------------------------------------------------------------------------------------------------------
// Все данные программы - здесь. А так же организация доступа к БД
// ----------------------------------------------------------------------------------------------------------

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Put_Image_In_DataBase.Model.Data;
using System.Drawing;
using DataBase_Operations;

namespace Put_Image_In_DataBase.Model
{
    public class Model: IModel
    {
        // объект для доступа к БД "Искусство и Искусствоведы"
        private DataBaseOperator DB_Operator = new DataBaseOperator();

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
        // подключиться к БД
        public bool ConnectToDataBase()
        {   
            return DB_Operator.TryConnectToDataBase();
        }

        // отключиться от БД
        public void DisconnectFromDataBase()
        {
            DB_Operator.DisconnectFromDataBase();
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

            // формируем запрос на добавление новой строки и его параметры
            string commandText = "INSERT INTO ArtCanvases (Canvas_Name, Canvas_Screen, Canvas_Format) VALUES(@Canvas_Name, @Canvas_Screen, @Canvas_Format)";
            string[] paramNames =  {
                                        "@Canvas_Name",
                                        "@Canvas_Screen",
                                        "@Canvas_Format"
                                   };
            object[] paramValues = {
                                        CurrentCanvasInfo.CanvasName,
                                        CurrentCanvasInfo.GetImageAsByteArray(),
                                        CurrentCanvasInfo.GraphicalFileType
                                   };

            return DB_Operator.TryModyfyInformationInDataBase(commandText, paramNames, paramValues);
        }
    }
}
