// ----------------------------------------------------------------------------------------------------------
// ---- popov 17.02.2021 ----
// ----------------------------------------------------------------------------------------------------------
// Модель, в которой хранятся данные программы и которая организует доступ к БД.
// ----------------------------------------------------------------------------------------------------------

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Put_Image_In_DataBase.Model.Data;
using System.Drawing;

namespace Put_Image_In_DataBase.Model
{
    public interface IModel
    {
        // текущий объект данных (только один - поскольку картины загружаются в БД по одной)
        ICanvasInfo DataObject { get; }        

        // подключиться к БД
        bool ConnectToDataBase();

        // отключиться от БД
        void DisconnectFromDataBase();

        // построить заново объект данных
        void RebuildData(string FileName, string Ext);

        // сохранить в БД текущий объект данных - объект будет созранен под именем CName
        bool PutCanvasToDB(string CName);
    }
}
