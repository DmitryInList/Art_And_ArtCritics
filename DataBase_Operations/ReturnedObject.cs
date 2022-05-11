// ---------------------------------------------------------------------------------------------------------
// ---- popov  17.02.2021 ----
// ---------------------------------------------------------------------------------------------------------
// Все запрошенные данные из одной строки в БД
// По результатам успешного выполнения запроса SELECT возвращается сразу много таких объектов.
// ---------------------------------------------------------------------------------------------------------

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataBase_Operations
{
    public class ReturnedObject: IReturnedObject
    {
        private int FieldsCount = 0;

        private object[] mFields = null;
        public object[] Fields
        {
            get { return mFields; }
        }

        public ReturnedObject(int Count)
        {
            FieldsCount = Count;
            mFields = new object[FieldsCount];
        }
    }
}
