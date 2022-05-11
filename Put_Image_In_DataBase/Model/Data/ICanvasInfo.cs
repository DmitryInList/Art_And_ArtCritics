﻿// --------------------------------------------------------------------------------------------------
// ---- popov 14.02.2021 ----
// --------------------------------------------------------------------------------------------------
// Интерфейс для класса, предсталяющего данные об одной картине в тот момент, когда
// она ВРЕМЕННО сохраняется в памяти - перд тем, ак поместить ее в БД "Искусство и Искусствоведы"...
// --------------------------------------------------------------------------------------------------

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using System.Drawing;

namespace Put_Image_In_DataBase.Model.Data
{
    public interface ICanvasInfo
    {
        // Имя исходного графического файла, из которого прочитана Картина
        string GraphicalFileName { get; set; }

        // Имя картины в БД
        string CanvasName { get; set; }

        // Тип графического файла из которого была взята картина
        string GraphicalFileType { get; set; }

        // Изображение для отображения в окне программы
        Image CanvasToShow { get; set; }

        // Получить изображение в виде двоичного поля - для сохранения в БД
        byte[] GetImageAsByteArray();
    }
}
