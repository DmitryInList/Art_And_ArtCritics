// ---------------------------------------------------------------------------------------------------
// ---- popov 14.02.2020 ----
// ---------------------------------------------------------------------------------------------------
// Класс для временного хранения изображения - перед его загрузкой в БД "Искусство и Искусствоведы"...
// ---------------------------------------------------------------------------------------------------
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using System.Drawing;
using System.IO;

namespace Put_Image_In_DataBase.Model.Data
{
    public class CanvasInfo: ICanvasInfo
    {
        const string JPEG_Type_1 = "jpg";
        const string JPEG_Type_2 = "jpeg";
        const string BMP_Type = "bmp";
        const string PNG_Type = "png";
        const string GIF_Type = "gif";

        public CanvasInfo(string FileName, string CN, string FT, Image CTS)
        {
            GraphicalFileName = FileName;
            CanvasName = CN;
            GraphicalFileType = FT;
            CanvasToShow = CTS;
        }

        // --------------------------------------------------------------------
        // ---- Реализация ICanvasInfo ----
        // --------------------------------------------------------------------
        // Имя исходного графического файла, из которого прочитана Картина
        public string GraphicalFileName { get; set; }

        // Имя картины в БД
        public string CanvasName { get; set; }

        // Тип графического файла из которого была взята картина
        string m_GraphicalFileType = "";
        public string GraphicalFileType
        {
            get { return m_GraphicalFileType; }
            set { m_GraphicalFileType = value.ToLower(); }
        }

        // Изображение для отображения в окне программы
        public Image CanvasToShow { get; set; }

        // ----------------------------------------------------------------------------
        // Метод для получения типа файла, который будет использован в процессе
        // преобразования изображения из Image в byte[].
        private System.Drawing.Imaging.ImageFormat GetImageFormat()
        {
            switch(GraphicalFileType)
            {
                case JPEG_Type_1: case JPEG_Type_2:
                    return System.Drawing.Imaging.ImageFormat.Jpeg;

                case BMP_Type:
                    return System.Drawing.Imaging.ImageFormat.Bmp;

                case PNG_Type:
                    return System.Drawing.Imaging.ImageFormat.Png;

                case GIF_Type:
                    return System.Drawing.Imaging.ImageFormat.Gif;

                    // по умолчанию - формат JPEG, как самый распространенный...
                default: return System.Drawing.Imaging.ImageFormat.Jpeg;
            }
        }

        // ----------------------------------------------------------------------------
        // Получить изображение в виде двоичного поля - для сохранения в БД
        public byte[] GetImageAsByteArray()
        {
            using (MemoryStream ms = new MemoryStream())
            {
                CanvasToShow.Save(ms, GetImageFormat());
                return ms.ToArray();
            }         
        }
    }
}
