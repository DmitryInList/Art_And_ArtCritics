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

namespace Put_Image_In_DataBase_EF.Model
{
    public interface IModel
    {
        // текущий объект данных (только один - поскольку картины загружаются в БД по одной)
        ICanvasInfo DataObject { get; }
        
        // построить заново объект данных
        void RebuildData(string FileName, string Ext);

        // сохранить в БД текущий объект данных - объект будет созранен под именем CName
        bool PutCanvasToDB(string CName);
    }
}
