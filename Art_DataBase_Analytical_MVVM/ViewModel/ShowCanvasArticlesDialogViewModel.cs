// ------------------------------------------------------------------------------------------------------------
// ---- popov 29.04.2021 ----
// ------------------------------------------------------------------------------------------------------------
// Специализированная модель представления для работы с диалогом, в котором
// будет одновременно отображаться как картина, так и перечень всех статей,
// посвященных этой карине.
// Унаследован от ShowCanvasDialogViewModel - поскольку логически имеет с ним много общего.
// ------------------------------------------------------------------------------------------------------------

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
    public class ShowCanvasArticlesDialogViewModel : BaseCanvasDialogViewModel
    {
        // ==================================================================================================
        // ==== Команды ====
        // ==================================================================================================
        // ---- команда двойной щелчек мышью на строке в таблице статей ----
        public ICommand ArticleListClickCommand { get; set; }
        
        // ==================================================================================================

        public ShowCanvasArticlesDialogViewModel(IArtCanvasInfo ac)
        {
            TheCanvas = ac;
            ArticlesList = ac.Articles;
            ArticleListClickCommand = CommonCommandDefenitions.CreateArticleDetailsCommand();
        }
    }
}
