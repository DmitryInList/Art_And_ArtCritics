// ---- popov 20.02.2021 ----
// -------------------------------------

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Get_Images_From_DataBase.Model.Data;

namespace Get_Images_From_DataBase.EventArguments
{
    public class ArtCanvasEventArgs: EventArgs
    {
        private List<IArtCanvas> m_DataList;
        public List<IArtCanvas> DataList
        {
            get { return m_DataList; }
        }

        public ArtCanvasEventArgs(List<IArtCanvas> DL)
        {
            m_DataList = DL;
        }

        public ArtCanvasEventArgs(IArtCanvas obj)
        {
            m_DataList = new List<IArtCanvas> { obj };
        }
    }
}
