// --------------------------------------------------------------------------------------------------------
// ---- popov 25.02.2021 ----
// --------------------------------------------------------------------------------------------------------
// Модель - изолированная часть программы, в которой собраны все данные.
// --------------------------------------------------------------------------------------------------------

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Art_DataBase_Analytic_EF.Model.Data;

namespace Art_DataBase_Analytic_EF.Model
{
    public interface IModel
    {
        // ---- popov 05.05.2022 ----
        // Перешел от List<T> к IEnumerable<T> - для сокрытия деталей реализации

        // массив данных обо всех Искусствоведах из БД "Искусство и Искусствоведы"
        IEnumerable<IArtCriticInfo> AllArtCritics { get; }

        // массив данных обо всех Картинах из БД "Искусство и Искусствоведы"
        IEnumerable<IArtCanvasInfo> AllArtCanvases { get; }

        // прочитать данные из БД (подключение к БД "Искусство и Искусствоведы" выполняется здесь же)
        bool ReadAllCanvasFromDataBase();
    }
}
