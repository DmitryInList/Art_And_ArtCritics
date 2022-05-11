// -------------------------------------------------------------------------------------------------------
// ---- popov 03.05.2021 ----
// -------------------------------------------------------------------------------------------------------
// Специализированная модель представления для работы с диалогом, в котором
// будет отображена детальная информация об одном искусствоведе:
// - данные искусствоведа
// - перечень всех статей, в которых этот искусствовед был соавтором
// - перечень всех критических отзывов на статьи, данных этим искусстсвоведом
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
    public class ShowCriticDetailsDialogViewModel : BaseCanvasDialogViewModel
    {
        // ==================================================================================================
        // ==== Команды ====
        // ==================================================================================================
        // ---- команда двойной щелчек мышью на строке в таблице статей, в которых этот искусствовед был соавтором ----
        public ICommand ArticleListClickCommand { get; set; }        

        // -------------------------------------------------------------------------------------------------
        // ---- команда двойной щелчек мышью на строке в таблице критических отзывов, данных этим искусствоведом ----
        public ICommand FeedbackListClickCommand { get; set; }        

        // ==================================================================================================

        public ShowCriticDetailsDialogViewModel(IArtCriticInfo ci)
        {
            //  никакой картины в этой модели представления нет.
            CriticsList = new List<IArtCriticInfo> { ci };
            ArticlesList = ci.Articles;
            FeedbacksList = ci.Feedbacks;
            ArticleListClickCommand = CommonCommandDefenitions.CreateArticleDetailsCommand();
            FeedbackListClickCommand = CommonCommandDefenitions.CreateFeedbackDetailsCommand();
        }
    }
}
