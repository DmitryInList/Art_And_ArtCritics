// --------------------------------------------------------------------------------------------------------
// ---- popov 25.02.2021 ----
// --------------------------------------------------------------------------------------------------------
// Информация об одной картине из БД "Искусство и Искусствоведы".
// --------------------------------------------------------------------------------------------------------

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using System.Drawing;

namespace Art_DataBase_Analytical.Model.Data
{
    public interface IArtCanvasInfo: IArtObject
    {
        /*
        // идентификатор картины.
        int ID { get; }
        */

        // наименование картины в БД "Искусство и Искусствоведы".
        string Name { get; }

        // графическое содержимое картины (генерируется в момент первого отображения 
        // этой картины в главном потоке программы).
        Image CanvasImage { get; }

        // итоговая оценка этой картины, взятая из посвященной ей статьи с самым высоким рейтингом.
        double Grade { get; }

        // перечень статей, посвященных этой картине
        IEnumerable<IArtArticleInfo> Articles { get; }
        // добавить еще одну статью этой картине
        void AddNextOneArticle(IArtArticleInfo a);
    }
}
