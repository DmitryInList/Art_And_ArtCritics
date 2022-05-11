// ------------------------------------------------------------------------------------------------------------
// ---- popov 04.05.2021 ----
// ------------------------------------------------------------------------------------------------------------
// три варианта однотипных команд:
// - команда отображения подробной информации об одной статье
// - команда отображения подробной информации об одном отзыве на статью
// - комнада отображения подробной информации об одном искусствоведе
//
// независимо используются в нескольких разных местах и при этом везде одинаковы.
// По-этому я решил выделить их определение в отдельный служебный класс - чтобы избежать 
// дублирования кода...
// ------------------------------------------------------------------------------------------------------------

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Base_For_MVVM;
using Art_DataBase_Analytical_MVVM.Model.Data;


namespace Art_DataBase_Analytical_MVVM.ViewModel
{
    public class CommonCommandDefenitions
    {
        // статический метод, создающий команду для отображения подробной информации об одной статье
        public static LambdaCommand CreateArticleDetailsCommand()
        {
            return new LambdaCommand
                (
                    (object o) =>
                    {
                        IArtArticleInfo TheArticle = (IArtArticleInfo)o;
                        if(TheArticle != null)
                        {
                            var NextModel = new ShowArticleDetailsDialogViewModel(TheArticle);
                            MyDialogService.ShowDialog<ShowArticleDetailsDialogViewModel>(NextModel);
                        }
                    }
                );
        }

        // ---------------------------------------------------------------------------------------------------
        // статический метод, создающий команду для отображения подробной информации об одном отзыве на статью
        public static LambdaCommand CreateFeedbackDetailsCommand()
        {
            return new LambdaCommand
                (
                    (object o) =>
                    {
                        IArtFeedbackInfo TheFeedback = (IArtFeedbackInfo)o;
                        if(TheFeedback != null)
                        {
                            var NextModel = new ShowFeedbackDetailsDialogViewModel(TheFeedback);
                            MyDialogService.ShowDialog<ShowFeedbackDetailsDialogViewModel>(NextModel);
                        }
                    }
                );
        }

        // ---------------------------------------------------------------------------------------------------
        // статический метод, создающий команду для отображения подробной информации об одном искусствоведе
        public static LambdaCommand CreateCriticDetailsCommand()
        {
            return new LambdaCommand
                (
                    (object o) =>
                    {
                        IArtCriticInfo TheCritic = (IArtCriticInfo)o;
                        if(TheCritic != null)
                        {
                            var NextModel = new ShowCriticDetailsDialogViewModel(TheCritic);
                            MyDialogService.ShowDialog<ShowCriticDetailsDialogViewModel>(NextModel);
                        }
                    }
                );
        }
    }
}
