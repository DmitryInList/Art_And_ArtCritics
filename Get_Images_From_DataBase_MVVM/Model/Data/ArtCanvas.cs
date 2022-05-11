// ----------------------------------------------------------------------------------------------------------
// ---- popov 06.04.2021 ----
// ----------------------------------------------------------------------------------------------------------
// Представление картины из БД "Искусство и Искусствоведы" в памяти
// ----------------------------------------------------------------------------------------------------------

using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Media.Imaging;

namespace Get_Images_From_DataBase_MVVM.Model.Data
{
    public class ArtCanvas: IArtCanvas
    {
        // ------------------------------------------------------------
        // ---- Варианты поддерживаемых графических файлов ----
        // ------------------------------------------------------------
        private const string JPG_Format_1 = "jpg";
        private const string JPG_Format_2 = "jpeg";
        private const string BMP_Format = "bmp";
        private const string PNG_Format = "png";
        private const string GIF_Format = "gif";
        // ------------------------------------------------------------

        // Наименование картины в БД
        private string m_CanvasName;
        public string CanvasName
        {
            get { return m_CanvasName; }
            set { m_CanvasName = value; }
        }

        // двоичные данные из БД, составляющие содержимое картины.
        private byte[] m_CanvasData;
        public byte[] CanvasData
        {
            get { return m_CanvasData; }
            set { m_CanvasData = value; }
        }

        // Собственно, само графическое содержание картины - его придется создавать
        // отдельно и независимо от получения набора байт, описывающих содержимое картины, из БД 
        // (только в главном потоке программы, когда потребуется его отобразить)
        private BitmapImage m_CanvasImage = null;
        public BitmapImage CanvasImage
        {
            get
            {
                if (CanvasData == null)
                    return null;

                if (m_CanvasImage == null)
                {
                    m_CanvasImage = new BitmapImage();
                    m_CanvasImage.BeginInit();
                    m_CanvasImage.StreamSource = new MemoryStream(CanvasData);
                    m_CanvasImage.EndInit();
                }
                return m_CanvasImage;
            }
        }

        // Расширение файла, в котором изначально был соранен файл с картиной
        private string m_FileExtention;
        public string FileExtention
        {
            get { return m_FileExtention; }
            set { m_FileExtention = value; }
        }

        // Полное наименование файла, в который произведено сохранение данных
        private string m_FileNameToSave;
        public string FileNameToSave
        {
            get { return m_FileNameToSave; }
        }

        // сохранение изображения в файл - в соответствии с типом исходного файла (jpg, bmp, png, gif):
        public bool SaveCanvasToGraphicFile(string FileName)
        {
            bool bResult = false;
            try
            {
                string sPath = Path.GetDirectoryName(FileName) + "\\";
                m_FileNameToSave = sPath + Path.GetFileNameWithoutExtension(FileName) + "." + FileExtention;
                BitmapEncoder encoder = null;

                using (var fileStream = new FileStream(m_FileNameToSave, FileMode.Create))
                {
                    switch (FileExtention)
                    {
                        case JPG_Format_1:
                        case JPG_Format_2:
                            {
                                encoder = new JpegBitmapEncoder();
                                break;
                            }
                        case BMP_Format:
                            {
                                encoder = new BmpBitmapEncoder();
                                break;
                            }
                        case PNG_Format:
                            {
                                encoder = new PngBitmapEncoder();
                                break;
                            }
                        case GIF_Format:
                            {
                                encoder = new GifBitmapEncoder();
                                break;
                            }
                        default:
                            {
                                // если расширение не известно - НЕ сохраняем файл                                
                                break;
                            }
                    }
                    encoder?.Frames.Add(BitmapFrame.Create(m_CanvasImage));
                    encoder?.Save(fileStream);
                }
                bResult = true;
            }
            catch(Exception ex)
            {
                MessageBox.Show("При попытке сохранить изображение возникла ошибка: '" + ex.Message + "'!", "Ошибка выполнения", MessageBoxButton.OK, MessageBoxImage.Error);
                bResult = false;
            }
            return bResult;
        }

        // ---------------------------------------------------------------------------------------
        // данные сюда передаются из БД "Искусство и Искуствоведы"
        public ArtCanvas(string sName, byte[] bData, string sExt)
        {
            m_CanvasName = sName;
            m_CanvasData = bData;
            m_FileExtention = sExt;
        }

        public ArtCanvas()
        { }
    }
}
