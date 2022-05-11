// ----------------------------------------------------------------------------------------------------------
// ---- popov 17.02.2021 ----
// ----------------------------------------------------------------------------------------------------------
// Контроллер. Управляет взаиможействием пользовательского 
// интерфейса из Представления с данными из Модели.
// ----------------------------------------------------------------------------------------------------------

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Put_Image_In_DataBase_EF.View;
using Put_Image_In_DataBase_EF.Model;
using System.IO;
using Put_Image_In_DataBase_EF.EventArguments;

namespace Put_Image_In_DataBase_EF.Controller
{
    public class Controller: IController
    {   
        // Объект Модели (там все данные программы)
        private IModel ModelObject;

        public Controller(IModel M)
        {
            ModelObject = M;
        }

        // -----------------------------------------------------------------------------------------------
        // -------- Реализация IController --------
        // -----------------------------------------------------------------------------------------------
        // очистить все визуальные компоненты
        public event EventHandler ClearAllComponents;

        // отобразить данные о изображении из объекта
        public event EventHandler<CanvasInfoEventArgs> ShowNewCanvas;

        // отчет о том, удалось сохранить Картину в БД "Искусство и Искусствоведы", или нет.
        public event EventHandler<CanvasResultEventArgs> CanvasReport;

        // -----------------------------------------------------------------------------------------------
        // Временное сохранение картины в памяти (и ее отображение в главном окне)
        public void CreateCanvas(object o, FileNameEventArgs e)
        {
            // очищаем старые графические данные 
            ClearAllComponents?.Invoke(this, null);
            if(File.Exists(e.FileName))
            {
                ModelObject.RebuildData(e.FileName, Path.GetExtension(e.FileName));
                ShowNewCanvas?.Invoke(this, new CanvasInfoEventArgs(ModelObject.DataObject));
            }
            else
            {
                // отображение пустого объекта данных - это штатный вариант использования Представления,
                // который говорит о том, что Модели не удалось прочитать информацию из графического файла.
                ShowNewCanvas?.Invoke(this, new CanvasInfoEventArgs(null));
            }
        }

        // -----------------------------------------------------------------------------------------------
        // Передача текущей картины в БД "Искусство и Искусствоведы"
        public void PutCanvasInDB(object o, CanvasNameEventArgs e)
        {
            if(ModelObject.PutCanvasToDB(e.NewCanvasName))
            {
                // Да, удалось сохранить картину в БД "Искусство и Искусствоведы"...
                CanvasReport?.Invoke(this, new CanvasResultEventArgs(e.NewCanvasName, true));
            }
            else
            {
                // Нет, не удалось сохранить картину в БД "Искусство и Искусствоведы"...
                CanvasReport?.Invoke(this, new CanvasResultEventArgs(e.NewCanvasName, false));
            }
        }
        // -----------------------------------------------------------------------------------------------
    }
}
