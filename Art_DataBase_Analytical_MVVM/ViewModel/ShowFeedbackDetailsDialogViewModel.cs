// ------------------------------------------------------------------------------------------------------
// ---- popov 01.05.2021 ----
// ------------------------------------------------------------------------------------------------------
// Специализированная модель представления для работы с диалогом, в котором
// будет отображена детальная информация об одном критическом отзыве на статью.
// Этот диалог я считаю терминальным - то есть из него нельзя перейти ни в какой другой 
// диалог. Это сделано для того чтобы уменьшить сложность.
// ------------------------------------------------------------------------------------------------------

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
    public class ShowFeedbackDetailsDialogViewModel: BaseCanvasDialogViewModel
    {
        // никаких команд здесь нет - поскольку никакой логики в диалоге не предусмотреннно
        // (это чисто информационный терминальный диалог - без возможности перейти к каким-то 
        // другим диалогам)...

        public ShowFeedbackDetailsDialogViewModel(IArtFeedbackInfo fi)
        {
            TheCanvas = fi.Article.Canvas;
            ArticlesList = new List<IArtArticleInfo> { fi.Article };
            CriticsList = new List<IArtCriticInfo> { fi.Author };
            FeedbacksList = new List<IArtFeedbackInfo> { fi };
        }
    }
}
