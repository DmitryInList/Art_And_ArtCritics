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

using Art_DataBase_Analytic_EF.Model.Data;
using Art_DataBase_Analytic_EF.Model.EntityFramework;
using Art_DataBase_Analytic_EF.Model.ConnectionString;

using System.Windows.Forms;

namespace Art_DataBase_Analytic_EF.Model
{
    public class Model: IModel
    {
        // объект для работы со строкой подключения
        CS_Reader ConnStr = new CS_Reader();

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
            bool bResult = true;
            try
            {
                using (Art_And_ArtCriticsEntities db = new Art_And_ArtCriticsEntities(ConnStr.ConnectionString))
                {
                    // ----------------------------------------------------------------------
                    // ---- 1. Получение всех данных об объектах ----
                    // ----------------------------------------------------------------------
                    // ---- 1.1. Получаем данные обо всех Искусствоведах ----
                    dynamic ArtCriticsData = ReadAllArtCritics(db);

                    // ---- 1.2. Получаем данные обо всех Картинах ----
                    dynamic ArtCanvasesData = ReadAllArtCanvases(db);

                    // ---- 1.3. Получаем данные обо всех Статьях, описывающих картины ----
                    dynamic ArtArticleData = ReadAllArtArticls(db);

                    // ---- 1.4. Получаем данные обо всех Отзывах  на статьи ----
                    dynamic ArtFeedbackData = ReadAllFeedbacks(db);

                    // ----------------------------------------------------------------------
                    // ---- перестраиваем служебные массивы объектов IArtObject ----
                    // ----------------------------------------------------------------------
                    RebuildBufferArtLists();
                    // ----------------------------------------------------------------------

                    // ----------------------------------------------------------------------
                    // ---- 2. Установление связей между объектами ----
                    // ----------------------------------------------------------------------
                    // ---- 2.1. Устанавливаем связи между Искусствоведами и Отзывами. ----                
                    MakeArtCriticArtFeedbackRelation(ArtCriticsData);

                    // ---- 2.2. Устанавливаем связи между Статьями и Отзывами. ----                
                    MakeArtArticleArtFeedbackRelation(ArtArticleData);

                    // ---- 2.3. Устанавливаем связи между Сатьями и Искусствоведами. ----                
                    MakeArtArticleArtCriticRelation(ArtArticleData);

                    // ---- 2.4. Устанавливаем связи между Картинами и Статьями. ----                
                    MakeArtCanvasArtAtricleRelation(ArtCanvasesData);

                    // ---- 2.5. Устанавливаем связи между Искусствоведами и Статьями. ----
                    MakeArtCriticArtArticleRelation(ArtCriticsData);
                }                    
            }
            catch (Exception ex)
            {
                MessageBox.Show("Ошибка работы с Базой Данных: " + Environment.NewLine + "'" + ex.Message + "'!", "Ошибка выполнения!", MessageBoxButtons.OK, MessageBoxIcon.Error);
                bResult = false;
            }
            return bResult;
        }

        // -----------------------------------------------------------------------------------
        // Получение всех данных обо всех Искусствоведах.
        private dynamic ReadAllArtCritics(Art_And_ArtCriticsEntities db)
        {
            // -----------------------------------------------------------------------------
            // Получаем сырые данные из БД
            var ArtCriticsData = db.ArtCritics.Include("ArtCoAuthors")
                                .Include("ArtFeedback")
                                .Include("ArtCriticCategory")
                                .Select(x =>
                                new
                                {
                                    ID = x.Critic_ID,
                                    LastName = x.Critic_LastName,
                                    FirstName = x.Critic_FirstName,
                                    Patronymic = x.Critic_Patronymic,
                                    CategoryText = x.ArtCriticCategory.Category_Name,
                                    CategoryWeight = x.ArtCriticCategory.Category_Weight,
                                    ArticleCount = x.ArtCoAuthors.Count(),
                                    FeedbackCount = x.ArtFeedback.Count(),
                                        // идентификаторы всех статей этого искусствоведа
                                        ArticleIds = x.ArtCoAuthors.Select(y => y.Article),
                                        // идентификаторы всех отзывов этого искусствоведа
                                        FeedbackIds = x.ArtFeedback.Select(z => z.Feedback_ID)
                                })
                                .OrderByDescending(n => n.CategoryWeight)
                                .ThenBy(m => m.LastName)
                                .ThenBy(m => m.FirstName)
                                .ThenBy(m => m.Patronymic);

            // -----------------------------------------------------------------------------
            // фиксируем финальные данные для отображения в итоговом отчете
            mAllArtCritics.Clear();
            foreach (var obj in ArtCriticsData)
            {
                IArtCriticInfo NextObject = new ArtCriticInfo
                (
                    obj.ID,               // идентификатор искусствоведа
                    obj.LastName,         // фамилия
                    obj.FirstName,        // имя
                    obj.Patronymic,       // отчетство
                    obj.CategoryText,     // статус
                    obj.CategoryWeight,   // вес мнения искусствоведа
                    obj.ArticleCount,     // Число статей, где этот искусствовед был соавтором
                    obj.FeedbackCount     // Число отзывов, написанных этим искусствоведом
                );
                mAllArtCritics.Add(NextObject);
            }

            // -----------------------------------------------------------------------------
            // Эти - прочитанные из БД - данные нам еще понадобятся для
            // установления связей между итоговыми объектами данных 
            // (картинами, статьями, искусствоведами и отзывами)
            return ArtCriticsData;
        }

        // -----------------------------------------------------------------------------------
        // Получение всех данных обо всех Картинах.
        private dynamic ReadAllArtCanvases(Art_And_ArtCriticsEntities db)
        {
            // -----------------------------------------------------------------------------
            // Получаем сырые данные из БД
            var ArtCanvasesData = db.ArtCanvases.Include("ArtArticle")
                                  .Include("ArtArticle.ArtCoAuthors")
                                  .Include("ArtArticle.ArtFeedback")
                                  .Include("ArtArticle.ArtFeedback.ArtScore")
                                  .Include("ArtArticle.ArtFeedback.ArtCritics")
                                  .Include("ArtArticle.ArtFeedback.ArtCritics.ArtCriticCategory")
                                  .Select(x =>
                                    new
                                    {
                                        ID = x.Canvas_Id,
                                        Name = x.Canvas_Name,
                                        CanvasScreen = x.Canvas_Screen,
                                        GradeAndRating = x.ArtArticle
                                                          .Select(y =>
                                                          new
                                                          {
                                                              Grade = y.ArtCoAuthors
                                                                       .Where(z => z.Grade.HasValue)
                                                                       .Select(z => z.Grade)
                                                                       .Average(),
                                                              Rating = y.ArtFeedback
                                                                        .Select(z => (z.ArtScore.Score_Value * z.ArtCritics.ArtCriticCategory.Category_Weight))
                                                                        .Sum()
                                                          })
                                                          .OrderByDescending(z => z.Rating)
                                                          .FirstOrDefault(),
                                            // идентификаторы всех статей, посвященных этой картине
                                            ArticlesIds = x.ArtArticle
                                                       .Select(y => y.Article_ID)
                                    })
                                    .OrderByDescending(z => z.GradeAndRating.Grade.HasValue ?
                                                            z.GradeAndRating.Grade.Value : 0)
                                    .ThenBy(z => z.Name);

            // -----------------------------------------------------------------------------
            // фиксируем финальные данные для отображения в итоговом отчете
            mAllArtCanvases.Clear();
            foreach (var obj in ArtCanvasesData)
            {
                // определяем оценку картины
                double dGrade = 0;
                if (obj.GradeAndRating != null)
                {
                    dGrade = obj.GradeAndRating.Grade.HasValue ? Math.Round(obj.GradeAndRating.Grade.Value, 2) : 0;
                }

                IArtCanvasInfo NextObject = new ArtCanvasInfo
                (
                    obj.ID,           // идентификатор картины
                    obj.Name,         // наименование
                    obj.CanvasScreen, // битовое поле, содержащее графические данные
                    dGrade            // оценка картины
                );
                mAllArtCanvases.Add(NextObject);
            }

            // -----------------------------------------------------------------------------
            // Эти - прочитанные из БД - данные нам еще понадобятся для
            // установления связей между итоговыми объектами данных 
            // (картинами, статьями, искусствоведами и отзывами)
            return ArtCanvasesData;            
        }

        // -----------------------------------------------------------------------------------
        // Получение всех данных обо всех Статьях, описывающих картины.        
        private dynamic ReadAllArtArticls(Art_And_ArtCriticsEntities db)
        {
            // -----------------------------------------------------------------------------
            // Получаем сырые данные из БД
            var ArtArticleData = db.ArtArticle.Include("ArtCoAuthors")
                                 .Include("ArtFeedback")
                                 .Include("ArtFeedback.ArtScore")
                                 .Include("ArtFeedback.ArtCritics")
                                 .Include("ArtFeedback.ArtCritics.ArtCriticCategory")
                                 .Select(x =>
                                    new
                                    {
                                        ID = x.Article_ID,
                                        Date = x.Article_Date,
                                        Text = x.Article_Resume,
                                        // оценка картины в статье - это среднее значение оценок,
                                        // данных всеми соавторами данной статьи
                                        Grade = x.ArtCoAuthors
                                                 .Where(y => y.Grade.HasValue)
                                                 .Select(y => y.Grade)
                                                 .Average(),
                                        // Рейтинг статьи - сумма всех оценок (как положительных, так и отрицательных), 
                                        // данных этой статье во всех критических отзывах на данную статью
                                        Rating = x.ArtFeedback
                                                .Select(y => (y.ArtScore.Score_Value * y.ArtCritics.ArtCriticCategory.Category_Weight))
                                                .Sum(),
                                        // идентфиикаторы всех искусствоведов-соавторов этой статьи
                                        CoAuthorIds = x.ArtCoAuthors
                                                    .Select(y => y.Critic),
                                        // идентификаторы всех критических отзывов на эту статью
                                        FeedbackIds = x.ArtFeedback
                                                    .Select(y => y.Feedback_ID)
                                    })
                                    .OrderByDescending(y => y.Rating)
                                    .ThenBy(y => y.Date);

            // -----------------------------------------------------------------------------
            // фиксируем финальные данные для отображения в итоговом отчете
            mAllArtArticls.Clear();
            foreach (var obj in ArtArticleData)
            {
                IArtArticleInfo NextObject = new ArtArticleInfo
                (
                    obj.ID,                                    // идентификатор статьи
                    obj.Text,                                  // содержимое статьи
                    obj.Date,                                  // дата публикации
                    obj.Grade != null ? Math.Round(obj.Grade.Value, 2) : 0,   // оценка карины, данная в статье
                    obj.Rating                                 // рейтинг самой статьи
                );
                mAllArtArticls.Add(NextObject);
            }

            // -----------------------------------------------------------------------------
            // Эти - прочитанные из БД - данные нам еще понадобятся для
            // установления связей между итоговыми объектами данных 
            // (картинами, статьями, искусствоведами и отзывами)
            return ArtArticleData;            
        }

        // -----------------------------------------------------------------------------------
        // Получение всех данных обо всех Отзывах на статьи.        
        private dynamic ReadAllFeedbacks(Art_And_ArtCriticsEntities db)
        {
            // -----------------------------------------------------------------------------
            // Получаем сырые данные из БД
            var ArtFeedbackData = db.ArtFeedback.Include("ArtArticle")
                                  .Include("ArtCritics")
                                  .Include("ArtCritics.ArtCriticCategory")
                                  .Include("ArtScore")
                                  .Select(x =>
                                    new
                                    {
                                        ID = x.Feedback_ID,
                                        Date = x.Feedback_Date,
                                        Text = x.Feedback_Resume,
                                        ScoreText = x.ArtScore.Score_Text,
                                        ScoreWight = (x.ArtScore.Score_Value * x.ArtCritics.ArtCriticCategory.Category_Weight),
                                            // идентификатор связанной статьи
                                            ArticleID = x.Article,
                                            // идентификатор связанного искусствоведа
                                            CriticID = x.Critic
                                    })
                                    .OrderByDescending(y => y.ScoreWight)
                                    .ThenBy(y => y.Date);

            // -----------------------------------------------------------------------------
            // фиксируем финальные данные для отображения в итоговом отчете
            mAllArtFeedbacks.Clear();
            foreach (var obj in ArtFeedbackData)
            {
                IArtFeedbackInfo NextObject = new ArtFeedbackInfo
                (
                    obj.ID,              // идентификатор отзыва
                    obj.Text,            // содержание отзыва
                    obj.Date,            // дата публикации отзыва
                    obj.ScoreText,       // качественная оценка статьи (типа хорошо/плохо)
                    obj.ScoreWight       // количественная оценка статьи
                );
                mAllArtFeedbacks.Add(NextObject);
            }

            // -----------------------------------------------------------------------------
            // Эти - прочитанные из БД - данные нам еще понадобятся для
            // установления связей между итоговыми объектами данных 
            // (картинами, статьями, искусствоведами и отзывами)
            return ArtFeedbackData;            
        }

        // ------------------------------------------------------------------------------------
        // Установление связи между Искусствоведами и Отзывами.
        // На вход передается массив сырых данных об искусствоведах - где в каждом
        // объекте имеется вложенный массив идентификаторов отзывов этого искусствоведа...
        private void MakeArtCriticArtFeedbackRelation(dynamic ArtCriticsData)
        {   
            // связываем искусствоведа и отзыв - один и тот же искусствовед может 
            // быть автором  многих разных отзывов. Но у каждого отзыва только один автор.
            IArtCriticInfo CurrentCritic = null;
            IArtFeedbackInfo CurrentFeedback = null;

            // Отзывы уже упорядоченны должным образом - и каждый искусствовед должен получить
            // свои отзывы именно в упорядоченном виде...
            foreach (IArtObject ao in BufferArtFeedbacks)
            {
                foreach (var artCrit in ArtCriticsData)
                {
                    bool bFound = false;
                    foreach (var fid in artCrit.FeedbackIds)
                    {
                        if (ao.ID == fid)
                        {
                            // нашли как искусстввоеда, так и отзыв.
                            CurrentCritic = RefreshOneArtObject(BufferArtCritics, artCrit.ID, CurrentCritic) as IArtCriticInfo;
                            CurrentFeedback = GetOneArtObject(BufferArtFeedbacks, ao.ID) as IArtFeedbackInfo;

                            if (CurrentFeedback != null)
                            {
                                CurrentCritic?.AddNextOneFeedback(CurrentFeedback);
                            }

                            bFound = true;
                            break;
                        }                        
                    }
                    if (bFound)
                        break;
                }
            }
        }

        // ------------------------------------------------------------------------------------
        // Установление связи между Статьями и Отзывами.
        // На вход передается массив сырых данных о статьях - где в каждом
        // объекте имеется вложенный массив идентификаторов отзывов на эту статью...
        private void MakeArtArticleArtFeedbackRelation(dynamic ArtArticleData)
        {   
            // к одной и той же статье может быть много разных отзывов.
            // но каждый отзыв может быть написан только на одну статью
            IArtArticleInfo CurrentArticle = null;
            IArtFeedbackInfo CurrentFeedback = null;

            // Отзывы уже упорядоченны должным образом - и каждая статья должна получить
            // свои отзывы именно в упорядоченном виде...
            foreach (IArtObject ao in BufferArtFeedbacks)
            {
                foreach (var artArt in ArtArticleData)
                {
                    bool bFound = false;
                    foreach (var fid in artArt.FeedbackIds)
                    {
                        if (ao.ID == fid)
                        {
                            // нашли как статью, так и отзыв
                            CurrentArticle = RefreshOneArtObject(BufferArtArticles, artArt.ID, CurrentArticle) as IArtArticleInfo;
                            CurrentFeedback = GetOneArtObject(BufferArtFeedbacks, ao.ID) as IArtFeedbackInfo;

                            if (CurrentFeedback != null)
                            {
                                CurrentArticle?.AddNextOneFeedback(CurrentFeedback);
                            }

                            bFound = true;
                            break;
                        }
                    }
                    if (bFound)
                        break;
                }
            }
        }

        // ------------------------------------------------------------------------------------
        // Установление связи между Сатьями и Искусствоведами.
        // На вход передается массив сырых данных о статьях - где в каждом
        // объекте имеется вложенный массив идентификаторов искусствоведов-соавторов этой статьи...
        private void MakeArtArticleArtCriticRelation(dynamic ArtArticleData)
        {   
            // для одной статьи много разных искусствоведов могут быть соавторами.
            // при этом один и тот же искусствовед может быть соавтором во многих разных статьях.
            IArtArticleInfo CurrentArticle = null;
            IArtCriticInfo CurrentCritic = null;

            // Искусствоведы уже упорядоченны должным образом - и каждая статья должна получить
            // своих искусствоведов именно в упорядоченном виде...
            foreach (IArtObject ao in BufferArtCritics)
            {
                foreach (var artArt in ArtArticleData)
                {   
                    foreach (var fid in artArt.CoAuthorIds)
                    {
                        if (ao.ID == fid)
                        {
                            // нашли как статью, так и искусствоведа-соавтора этой статьи
                            CurrentArticle = RefreshOneArtObject(BufferArtArticles, artArt.ID, CurrentArticle) as IArtArticleInfo;
                            CurrentCritic = GetOneArtObject(BufferArtCritics, ao.ID) as IArtCriticInfo;

                            if (CurrentCritic != null)
                            {
                                CurrentArticle?.AddNextOneCoAuthor(CurrentCritic);
                            }
                            
                            break;
                        }
                    }
                }
            }
        }

        // ------------------------------------------------------------------------------------
        // Установление связи между Картинами и Статьями.
        // На вход передается массив сырых данных о картинах - где в каждом
        // объекте имеется вложенный массив идентификаторов статей, посвященных этой картине...
        private void MakeArtCanvasArtAtricleRelation(dynamic ArtCanvasesData)
        {   
            // на одну картину может быть написано много статей.
            // но каждая статья может быть посвящена только одной картине.
            IArtCanvasInfo CurrentCanvas = null;
            IArtArticleInfo CurrentArticle = null;

            // Статьи уже упорядоченны должным образом - и каждая картина должна получить
            // свои статьи именно в упорядоченном виде...
            foreach (IArtObject ao in BufferArtArticles)
            {
                foreach (var artCnv in ArtCanvasesData)
                {
                    bool bFound = false;
                    foreach (var fid in artCnv.ArticlesIds)
                    {
                        if (ao.ID == fid)
                        {
                            // нашли как картину, так и статью, посвященную этой картине
                            CurrentCanvas = RefreshOneArtObject(BufferArtCanvases, artCnv.ID, CurrentCanvas) as IArtCanvasInfo;
                            CurrentArticle = GetOneArtObject(BufferArtArticles, ao.ID) as IArtArticleInfo;

                            if (CurrentArticle != null)
                            {
                                CurrentCanvas?.AddNextOneArticle(CurrentArticle);
                            }

                            bFound = true;
                            break;
                        }
                    }
                    if (bFound)
                        break;
                }
            }
        }

        // ------------------------------------------------------------------------------------
        // Установление связи между Искусствоведами и Сатьями.
        // На вход передается массив сырых данных об искусстввоедах - где в каждом
        // объекте имеется вложенный массив идентификаторов статей, в которых 
        // этот искусствовед выступал как соавтор...
        private void MakeArtCriticArtArticleRelation(dynamic ArtCriticsData)
        {   
            // для одной статьи много разных искусствоведов могут быть соавторами.
            // при этом один и тот же искусствовед может быть соавтором многих разных статей.
            IArtArticleInfo CurrentArticle = null;
            IArtCriticInfo CurrentCritic = null;

            // Статьи уже упорядоченны должным образом - и каждый скусствовед должен получить
            // свои статьи именно в упорядоченном виде...
            foreach (IArtObject ao in BufferArtArticles)
            {
                foreach (var artCrit in ArtCriticsData)
                {   
                    foreach (var fid in artCrit.ArticleIds)
                    {
                        if (ao.ID == fid)
                        {
                            // нашли как искусствоведа, так и статью, соавтором которой он был
                            CurrentCritic = GetOneArtObject(BufferArtCritics, artCrit.ID) as IArtCriticInfo;
                            CurrentArticle = RefreshOneArtObject(BufferArtArticles, ao.ID, CurrentArticle) as IArtArticleInfo;

                            if (CurrentArticle != null)
                            {
                                CurrentCritic?.AddNextOneArticle(CurrentArticle);
                            }
                            
                            break;
                        }
                    }
                }
            }
        }
    }
}
