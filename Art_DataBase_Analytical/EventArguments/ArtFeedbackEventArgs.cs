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

using Art_DataBase_Analytical.Model.Data;

namespace Art_DataBase_Analytical.EventArguments
{
    public class ArtFeedbackEventArgs: EventArgs
    {
        private IEnumerable<IArtFeedbackInfo> m_DataList;
        public IEnumerable<IArtFeedbackInfo> DataList
        {
            get { return m_DataList; }
        }

        public ArtFeedbackEventArgs(IEnumerable<IArtFeedbackInfo> DL)
        {
            m_DataList = DL;
        }

        public ArtFeedbackEventArgs(IArtFeedbackInfo obj)
        {
            m_DataList = new List<IArtFeedbackInfo> { obj };
        }
    }
}
