// ---------------------------------------------------------------------------------------------------------
// ---- popov 01.03.2021 ----
// ---------------------------------------------------------------------------------------------------------
// Один из служебных классов для передачи параметров в события обмена данными с пользовательским интерфейсом.
// ---------------------------------------------------------------------------------------------------------

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Art_DataBase_Analytic_EF.Model.Data;

namespace Art_DataBase_Analytic_EF.EventArguments
{
    public class ArtCanvasEventArgs: EventArgs
    {
        private IEnumerable<IArtCanvasInfo> m_DataList;
        public IEnumerable<IArtCanvasInfo> DataList
        {
            get { return m_DataList; }
        }

        public ArtCanvasEventArgs(IEnumerable<IArtCanvasInfo> DL)
        {
            m_DataList = DL;
        }

        public ArtCanvasEventArgs(IArtCanvasInfo obj)
        {
            m_DataList = new List<IArtCanvasInfo> { obj };
        }
    }
}
