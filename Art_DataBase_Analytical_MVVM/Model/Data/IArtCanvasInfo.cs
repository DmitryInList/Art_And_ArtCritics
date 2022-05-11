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
using System.Windows.Media.Imaging;

namespace Art_DataBase_Analytical_MVVM.Model.Data
{
    public interface IArtCanvasInfo: IArtObject
    {
        // наименование картины в БД "Искусство и Искусствоведы".
        string Name { get; }

        // графическое содержимое картины (генерируется в момент первого отображения 
        // этой картины в главном потоке программы).
        BitmapImage CanvasImage { get; }

        // итоговая оценка этой картины, взятая из посвященной ей статьи с самым высоким рейтингом.
        double Grade { get; set; }

        // перечень статей, посвященных этой картине
        IEnumerable<IArtArticleInfo> Articles { get; }
        // добавить еще одну статью этой картине
        void AddNextOneArticle(IArtArticleInfo a);
    }
}
