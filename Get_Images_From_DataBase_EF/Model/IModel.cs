// ----------------------------------------------------------------------------------------
// ---- popov 20.02.2021 ----
// ----------------------------------------------------------------------------------------
// Модель - здесь (в идеальном случае) все данные программы.
// ----------------------------------------------------------------------------------------

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Get_Images_From_DataBase_EF.Model.Data;

namespace Get_Images_From_DataBase_EF.Model
{
    public interface IModel
    {
        // Набор данных о Картинах, прочитанный из БД "Искусство и Искусствоведы"
        IEnumerable<IArtCanvas> AllCanvases { get; }

        // прочитать данные из БД (подключение к БД "Искусство и Искусствоведы" выполняется здесь же)
        bool ReadAllCanvasFromDataBase();
    }
}
