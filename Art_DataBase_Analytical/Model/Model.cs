// ----------------------------------------------------------------------------------------------------------
// ---- popov 26.02.2021 ----
// ----------------------------------------------------------------------------------------------------------
// Здесь хранится вся информация из БД "Искусство и Искусствоведы"
// При этом аналитическая обработка произведена уже на стороне SQL-сервара.
// ----------------------------------------------------------------------------------------------------------

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Art_DataBase_Analytical.Model.Data;
using Art_DataBase_Analytical.Model.SQL_Text;
using DataBase_Operations;

using System.Windows.Forms;

namespace Art_DataBase_Analytical.Model
{
    public class Model: IModel
    {
        // объект для доступа к БД "Искусство и Искусствоведы"
        private DataBaseOperator DB_Operator = new DataBaseOperator();

        // массив данных обо всех Искусствоведах
        private List<IArtCriticInfo> mAllArtCritics = new List<IArtCriticInfo>();
        public IEnumerable<IArtCriticInfo> AllArtCritics
        {
            get { return mAllArtCritics; }
        }

        // массив данных обо всех Картинах
        private List<IArtCanvasInfo> mAllArtCanvases = new List<IArtCanvasInfo>();
        public IEnumerable<IArtCanvasInfo> AllArtCanvases
        {
            get { return mAllArtCanvases; }
        }

        // массив данных обо всех Статьях, отписывающих Картины
        private List<IArtArticleInfo> mAllArtArticls = new List<IArtArticleInfo>();

        // массив данных обо всех Отзывах на Статьи
        private List<IArtFeedbackInfo> mAllArtFeedbacks = new List<IArtFeedbackInfo>();

        // ссылка на массив данных о критиках - как объектах типа IArtObject
        private List<IArtObject> BufferArtCritics = new List<IArtObject>();
        // ссылка на масив данных об отзывах - как объектах типа IArtObject
        private List<IArtObject> BufferArtFeedbacks = new List<IArtObject>();
        // ссылка на массив данных о статьях - как объектах типа IArtObject
        private List<IArtObject> BufferArtArticles = new List<IArtObject>();
        // ссылка на массив данных о картинах - как объектах типа IArtObject
        private List<IArtObject> BufferArtCanvases = new List<IArtObject>();

        public void RebuildBufferArtLists()
        {
            BufferArtCritics.Clear();
            BufferArtCritics.AddRange(mAllArtCritics);

            BufferArtFeedbacks.Clear();
            BufferArtFeedbacks.AddRange(mAllArtFeedbacks);

            BufferArtArticles.Clear();
            BufferArtArticles.AddRange(mAllArtArticls);

            BufferArtCanvases.Clear();
            BufferArtCanvases.AddRange(mAllArtCanvases);
        }

        // ==================================================================================================
        // Метод получения одного объекта из массива по идентфиикатору этого объекта
        public IArtObject GetOneArtObject(List<IArtObject> lst, int id)
        {
            return lst.FirstOrDefault(x => (x.ID == id));
        }
        // Метод обновления одного объекта (получить новый объект или повторно использовать переданный)
        public IArtObject RefreshOneArtObject(List<IArtObject> lst, int id, IArtObject obj)
        {
            if(obj == null)
                return GetOneArtObject(lst, id);
            if(obj.ID != id)
                return GetOneArtObject(lst, id);
            return obj;
        }

        // -------------------------------------------------------------------------------------------------        
        // -------------------------------------------------------------------------------------------------
        // -------------------------------------------------------------------------------------------------
        public bool ReadAllCanvasFromDataBase()
        {
            if (DB_Operator.TryConnectToDataBase())
            {
                // ----------------------------------------------------------------------
                // ---- 1. Получение всех данных об объектах ----
                // ----------------------------------------------------------------------
                // ---- 1.1. Получаем данные обо всех Искусствоведах ----
                ReadAllArtCritics();

                // ---- 1.2. Получаем данные обо всех Картинах ----
                ReadAllArtCanvases();

                // ---- 1.3. Получаем данные обо всех Статьях, описывающих картины ----
                ReadAllArtArticls();

                // ---- 1.4. Получаем данные обо всех Отзывах  на статьи ----
                ReadAllFeedbacks();

                // ----------------------------------------------------------------------
                // перестраиваем служебные массивы объектов IArtObject
                RebuildBufferArtLists();

                // ----------------------------------------------------------------------
                // ---- 2. Установление связей между объектами ----
                // ----------------------------------------------------------------------
                // ---- 2.1. Устанавливаем связи между Искусствоведами и Отзывами. ----                
                MakeArtCriticArtFeedbackRelation();

                // ---- 2.2. Устанавливаем связи между Статьями и Отзывами. ----                
                MakeArtArticleArtFeedbackRelation();

                // ---- 2.3. Устанавливаем связи между Сатьями и Искусствоведами. ----                
                MakeArtArticleArtCriticRelation();

                // ---- 2.4. Устанавливаем связи между Картинами и Статьями. ----                
                MakeArtCanvasArtAtricleRelation();

                // ---- 2.5. Устанавливаем связи между Искусствоведами и Сатьями. ----
                MakeArtCriticArtArticleRelation();

                // ----------------------------------------------------------------------
                // закрываем соединение с БД
                DB_Operator.DisconnectFromDataBase();
                return true;
            }
            else
            {
                return false;
            }            
        }

        // -----------------------------------------------------------------------------------
        // Получение всех данных обо всех Искусствоведах.
        private void ReadAllArtCritics()
        {
            mAllArtCritics.Clear();

            string[] ColumnNames =
                { "Critic_ID", "Critic_LastName", "Critic_FirstName", "Critic_Patronymic", "Category_Name", "Category_Weight", "ArticleCount", "FeedbackCount" };

            List<IReturnedObject> InitialResult = DB_Operator.TrySelectSomeRowsFromDataBase(SQL_Texts.SQL_Report_4, ColumnNames);
            foreach (IReturnedObject obj in InitialResult)
            {
                IArtCriticInfo NextObject = new ArtCriticInfo
                    (
                        obj.Fields[0].GetInt(),    // идентификатор искусствоведа
                        obj.Fields[1].GetString(), // фамилия
                        obj.Fields[2].GetString(), // имя
                        obj.Fields[3].GetString(), // отчетство
                        obj.Fields[4].GetString(), // статус
                        obj.Fields[5].GetInt(),    // вес мнения искусствоведа
                        obj.Fields[6].GetInt(),    // Число статей, где этот искусствовед был соавтором
                        obj.Fields[7].GetInt()     // Число отзывов, написанных этим искусствоведом
                    );
                mAllArtCritics.Add(NextObject);
            }
        }

        // -----------------------------------------------------------------------------------
        // Получение всех данных обо всех Картинах.
        private void ReadAllArtCanvases()
        {
            mAllArtCanvases.Clear();

            string[] ColumnNames =
                { "Canvas_Id", "Canvas_Name", "Canvas_Screen", "Canvas_Grade" };

            List<IReturnedObject> InitialResult = DB_Operator.TrySelectSomeRowsFromDataBase(SQL_Texts.SQL_Report_13, ColumnNames);
            foreach (IReturnedObject obj in InitialResult)
            {
                IArtCanvasInfo NextObject = new ArtCanvasInfo
                    (
                        obj.Fields[0].GetInt(),       // идентификатор картины
                        obj.Fields[1].GetString(),    // наименование
                        obj.Fields[2].GetByteArray(), // битовое поле, содержащее графические данные
                        obj.Fields[3].GetDouble()     // оценка картины
                    );
                mAllArtCanvases.Add(NextObject);
            }
        }

        // -----------------------------------------------------------------------------------
        // Получение всех данных обо всех Статьях, описывающих картины.        
        private void ReadAllArtArticls()
        {
            mAllArtArticls.Clear();

            string[] ColumnNames =
                { "Article_ID", "Article_Resume", "Article_Date", "Article_Grade", "Article_Rating" };

            List<IReturnedObject> InitialResult = DB_Operator.TrySelectSomeRowsFromDataBase(SQL_Texts.SQL_Report_11, ColumnNames);
            foreach (IReturnedObject obj in InitialResult)
            {
                IArtArticleInfo NextObject = new ArtArticleInfo
                    (
                        obj.Fields[0].GetInt(),      // идентификатор статьи
                        obj.Fields[1].GetString(),   // содержимое статьи
                        obj.Fields[2].GetDateTime(), // дата публикации
                        obj.Fields[3].GetDouble(),   // оценка карины, данная в статье
                        obj.Fields[4].GetInt()       // рейтинг самой статьи
                    );
                mAllArtArticls.Add(NextObject);
            }
        }

        // -----------------------------------------------------------------------------------
        // Получение всех данных обо всех Отзывах на статьи.        
        private void ReadAllFeedbacks()
        {
            mAllArtFeedbacks.Clear();

            string[] ColumnNames =
                { "Feedback_ID", "Feedback_Resume", "Feedback_Date", "Score_Text", "Score_Weight" };

            List<IReturnedObject> InitialResult = DB_Operator.TrySelectSomeRowsFromDataBase(SQL_Texts.SQL_Report_8, ColumnNames);
            foreach (IReturnedObject obj in InitialResult)
            {
                IArtFeedbackInfo NextObject = new ArtFeedbackInfo
                    (
                        obj.Fields[0].GetInt(),      // идентификатор отзыва
                        obj.Fields[1].GetString(),   // содержание отзыва
                        obj.Fields[2].GetDateTime(), // дата публикации отзыва
                        obj.Fields[3].GetString(),   // качественная оценка статьи (типа хорошо/плохо)
                        obj.Fields[4].GetInt()       // количественная оценка статьи
                    );
                mAllArtFeedbacks.Add(NextObject);
            }
        }

        // ------------------------------------------------------------------------------------
        // Установление связи между Искусствоведами и Отзывами.
        private void MakeArtCriticArtFeedbackRelation()
        {
            // связываем искусствоведа и озыв - один и тот же искусствовед может 
            // быть автором  многих разных отзывов
            IArtCriticInfo CurrentCritic = null;
            IArtFeedbackInfo CurrentFeedback = null;

            string[] ColumnNames =
                { "Critic", "Feedback_ID" };

            List<IReturnedObject> InitialResult = DB_Operator.TrySelectSomeRowsFromDataBase(SQL_Texts.SQL_Report_14, ColumnNames);
            foreach (IReturnedObject obj in InitialResult)
            {   
                CurrentCritic = RefreshOneArtObject(BufferArtCritics, obj.Fields[0].GetInt(), CurrentCritic) as IArtCriticInfo;
                CurrentFeedback = GetOneArtObject(BufferArtFeedbacks, obj.Fields[1].GetInt()) as IArtFeedbackInfo;                
                if(CurrentFeedback != null)
                {
                    CurrentCritic?.AddNextOneFeedback(CurrentFeedback);
                }
            }
        }

        // ------------------------------------------------------------------------------------
        // Установление связи между Статьями и Отзывами.
        private void MakeArtArticleArtFeedbackRelation()
        {
            // к одной и той же статье может быть много разных отзывов
            IArtArticleInfo CurrentArticle = null;
            IArtFeedbackInfo CurrentFeedback = null;

            string[] ColumnNames =
                { "Article", "Feedback_ID" };
            List<IReturnedObject> InitialResult = DB_Operator.TrySelectSomeRowsFromDataBase(SQL_Texts.SQL_Report_15, ColumnNames);
            foreach (IReturnedObject obj in InitialResult)
            {
                CurrentArticle = RefreshOneArtObject(BufferArtArticles, obj.Fields[0].GetInt(), CurrentArticle) as IArtArticleInfo;
                CurrentFeedback = GetOneArtObject(BufferArtFeedbacks, obj.Fields[1].GetInt()) as IArtFeedbackInfo; 
                if(CurrentFeedback != null)
                {
                    CurrentArticle?.AddNextOneFeedback(CurrentFeedback);
                }
            }
        }

        // ------------------------------------------------------------------------------------
        // Установление связи между Сатьями и Искусствоведами.
        private void MakeArtArticleArtCriticRelation()
        {
            // для одной статьи много разных искусствоведов могут быть соавторами.
            IArtArticleInfo CurrentArticle = null;
            IArtCriticInfo CurrentCritic = null;

            string[] ColumnNames =
                { "Article", "Critic_ID" }; //"Critic" };
            List<IReturnedObject> InitialResult = DB_Operator.TrySelectSomeRowsFromDataBase(SQL_Texts.SQL_Report_16, ColumnNames);
            foreach (IReturnedObject obj in InitialResult)
            {
                CurrentArticle = RefreshOneArtObject(BufferArtArticles, obj.Fields[0].GetInt(), CurrentArticle) as IArtArticleInfo;
                CurrentCritic = GetOneArtObject(BufferArtCritics, obj.Fields[1].GetInt()) as IArtCriticInfo;
                if(CurrentCritic != null)
                {
                    CurrentArticle?.AddNextOneCoAuthor(CurrentCritic);
                }
            }
        }

        // ------------------------------------------------------------------------------------
        // Установление связи между Картинами и Статьями.
        private void MakeArtCanvasArtAtricleRelation()
        {
            // на одну картину может быть написано много статей
            IArtCanvasInfo CurrentCanvas = null;
            IArtArticleInfo CurrentArticle = null;

            string[] ColumnNames =
                { "Article_Canvas", "Article_ID" };
            List<IReturnedObject> InitialResult = DB_Operator.TrySelectSomeRowsFromDataBase(SQL_Texts.SQL_Report_17, ColumnNames);
            foreach(IReturnedObject obj in InitialResult)
            {
                CurrentCanvas = RefreshOneArtObject(BufferArtCanvases, obj.Fields[0].GetInt(), CurrentCanvas) as IArtCanvasInfo;
                CurrentArticle = GetOneArtObject(BufferArtArticles, obj.Fields[1].GetInt()) as IArtArticleInfo;
                if(CurrentArticle != null)
                {
                    CurrentCanvas?.AddNextOneArticle(CurrentArticle);
                }
            }
        }

        // ------------------------------------------------------------------------------------
        // Установление связи между Искусствоведами и Сатьями.
        private void MakeArtCriticArtArticleRelation()
        {
            // для одной статьи много разных искусствоведов могут быть соавторами.
            IArtArticleInfo CurrentArticle = null;
            IArtCriticInfo CurrentCritic = null;

            string[] ColumnNames =
                { "Critic", "Article" };
            List<IReturnedObject> InitialResult = DB_Operator.TrySelectSomeRowsFromDataBase(SQL_Texts.SQL_Report_18, ColumnNames);
            foreach (IReturnedObject obj in InitialResult)
            {
                CurrentCritic = GetOneArtObject(BufferArtCritics, obj.Fields[0].GetInt()) as IArtCriticInfo;
                CurrentArticle = RefreshOneArtObject(BufferArtArticles, obj.Fields[1].GetInt(), CurrentArticle) as IArtArticleInfo;                
                if (CurrentArticle != null)
                {
                    CurrentCritic?.AddNextOneArticle(CurrentArticle);
                }
            }
        }
    }
}
