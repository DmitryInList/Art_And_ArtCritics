// ----------------------------------------------------------------------------------------------------------
// ---- popov 01.03.2021 ----
// ----------------------------------------------------------------------------------------------------------
// Контроллер - изолированная часть программы, содержащая (в идеальном случае) всю бизнесс-логику.
// ----------------------------------------------------------------------------------------------------------

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Art_DataBase_Analytical.EventArguments;

namespace Art_DataBase_Analytical.Controller
{
    public interface IController
    {
        // максимальное число одновременно отображаемых блоков данных о картинах        
        int MaxDataBlockCount { get; set; }

        // Получение всех исходных данных из БД (подключение к БД "Искусство и Искусствоведы" выполняется здесь же)
        bool TryTakeAllCanvasesFromDataBase();

        // -------------------------------------------------------------------------
        // ---- Обоработчики событий Представления ----
        // -------------------------------------------------------------------------
        // передать для отображения первый блок данных 
        void LoadFirstCanvasBlock(object o, EventArgs e);

        // передать для отображения следующий блок данных
        void LoadForwardCanvasBlock(object o, EventArgs e);

        // передать для отображения предыдущий блок данных
        void LoadBackwardCanvasBlock(object o, EventArgs e);

        // ---------------------------------------------------------------------------
        //  ---- События Контроллера ----
        // ---------------------------------------------------------------------------
        // очистить все текущие изображения картин в главном окне
        event EventHandler ClearAllCanvases;

        // отобразить блок из нескольких картин в главном окне
        event EventHandler<ArtCanvasEventArgs> RefreshAllCanvases;

        // отобразить полный набор данных обо всех искусствоведах
        event EventHandler<ArtCriticEventArgs> ShowAllCritics;

        // Обе кнопки (Вперед и Назад) доступны.
        event EventHandler BothButtonsEnabled;

        // Кнопка Вперед - доступна, а кнопка Назад - нет.
        event EventHandler BackwardDisabled;

        // Кнопка Назад - доступна, а кнопка Вперед - нет.
        event EventHandler ForwardDisabled;
    }
}
