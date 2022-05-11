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
    public class ArtArticleEventArgs: EventArgs
    {
        private IEnumerable<IArtArticleInfo> m_DataList;
        public IEnumerable<IArtArticleInfo> DataList
        {
            get { return m_DataList; }
        }

        public ArtArticleEventArgs(IEnumerable<IArtArticleInfo> DL)
        {
            m_DataList = DL;
        }

        public ArtArticleEventArgs(IArtArticleInfo obj)
        {
            m_DataList = new List<IArtArticleInfo> { obj };
        }
    }
}
