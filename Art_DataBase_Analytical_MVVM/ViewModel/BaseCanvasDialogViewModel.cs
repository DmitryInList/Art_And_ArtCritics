// ------------------------------------------------------------------------------------------------------------
// ---- popov 30.04.2021 ----
// ------------------------------------------------------------------------------------------------------------
// Базовый класс для всех моделей представления, которые будут
// соответствовать диалоговым окнам, в которых (помимо прочих данных)
// будет отображаться графическое содержимое картины и ее наименование...
// ------------------------------------------------------------------------------------------------------------

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Base_For_MVVM;
using Art_DataBase_Analytical_MVVM.Model.Data;
using System.Windows.Input;
using System.Windows;


namespace Art_DataBase_Analytical_MVVM.ViewModel
{
    public class BaseCanvasDialogViewModel: DialogBaseViewModel
    {
        // ---------------------------------------------------------------------------------------------------
        // ---- 1. данные о самой картине ----
        private IArtCanvasInfo m_TheCanvas;
        public IArtCanvasInfo TheCanvas
        {
            get { return m_TheCanvas; }
            set
            {
                m_TheCanvas = value;
                OnPropertyChanged();
            }
        }

        // ---------------------------------------------------------------------------------------------------
        // ---- 2. данные о массиве статей, посвященных картине ----
        private IEnumerable<IArtArticleInfo> m_ArticlesList;
        public IEnumerable<IArtArticleInfo> ArticlesList
        {
            get { return m_ArticlesList; }
            set
            {
                m_ArticlesList = value;
                OnPropertyChanged();
            }
        }

        // ---------------------------------------------------------------------------------------------------
        // ---- 3. данные о массиве отзывов на статью посвященную картине ----
        private IEnumerable<IArtFeedbackInfo> m_FeedbacksList;
        public IEnumerable<IArtFeedbackInfo> FeedbacksList
        {
            get { return m_FeedbacksList; }
            set
            {
                m_FeedbacksList = value;
                OnPropertyChanged();
            }
        }

        // ---------------------------------------------------------------------------------------------------
        // ---- 4. данные о массиве искусствоведов-соавторов статьи, посвященной картине ----
        private IEnumerable<IArtCriticInfo> m_CriticsList;
        public IEnumerable<IArtCriticInfo> CriticsList
        {
            get { return m_CriticsList; }
            set
            {
                m_CriticsList = value;
                OnPropertyChanged();
            }
        }

        // ==================================================================================================
        // ==== Команды ====
        // ==================================================================================================
        // ------------------------------------------------------------------------
        // ---- команда закрытия диалогового окна ----
        // ------------------------------------------------------------------------
        public ICommand ButtonTwoClickCommand { get; set; }
        private void OnButtonTwoClickCommandExecute(object o)
        {
            Window w = (Window)o;
            if (w != null)
            {
                w.Close();
            }
        }
        // ==================================================================================================

        public BaseCanvasDialogViewModel()
        {
            ButtonTwoClickCommand = new LambdaCommand(OnButtonTwoClickCommandExecute);
        }
    }
}
