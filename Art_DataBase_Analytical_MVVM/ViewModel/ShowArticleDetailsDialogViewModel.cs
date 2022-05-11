// -------------------------------------------------------------------------------------------------------
// ---- popov 30.04.2021 ----
// -------------------------------------------------------------------------------------------------------
// Специализированная модель представления для работы с диалогом, в котором
// будет отображена детальная информация об одной статье:
// - картина, которой посвящена статья
// - сама статья, рассматриваемая в этом диалоге
// - перечень кртитических отзывов на статью
// - перечень искусствоведов-соавторов этой статьи
// -------------------------------------------------------------------------------------------------------

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using System.Windows;
using System.Windows.Input;
using Art_DataBase_Analytical_MVVM.Model.Data;
using Base_For_MVVM;


namespace Art_DataBase_Analytical_MVVM.ViewModel
{
    public class ShowArticleDetailsDialogViewModel: BaseCanvasDialogViewModel
    {
        // ==================================================================================================
        // ==== Команды ====
        // ==================================================================================================
        // ---- команда двойной щелчек мышью на строке в таблице искусствоведов-соавторов этой статьи ----        
        public ICommand ArtCriticListClickCommand { get; set; }        

        // -------------------------------------------------------------------------------------------------
        // ---- команда двойной щелчек мышью на строке в таблице критических отзывов на эту статью ----
        public ICommand FeedbackListClickCommand { get; set; }        

        // ==================================================================================================
        public ShowArticleDetailsDialogViewModel(IArtArticleInfo ai)
        {
            TheCanvas = ai.Canvas;
            ArticlesList = new List<IArtArticleInfo> { ai };
            FeedbacksList = ai.Feedbacks;
            CriticsList = ai.CoAuthors;
            ArtCriticListClickCommand = CommonCommandDefenitions.CreateCriticDetailsCommand();
            FeedbackListClickCommand = CommonCommandDefenitions.CreateFeedbackDetailsCommand();
        }
    }
}
