// ----------------------------------------------------------------------------------------------------------
// ---- popov 11.03.2021 ----
// ----------------------------------------------------------------------------------------------------------
// Класс EntityFramework для взаимодействия с таблицей ArtCanvases из БД "Искусство и Искусствоведы".
// ----------------------------------------------------------------------------------------------------------

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Put_Image_In_DataBase_EF.Model.EntityFramework
{
    [Table("ArtCanvases")]
    public class ArtCanvases
    {
        [Key]
        public int Canvas_Id { get; set; }
        public string Canvas_Name { get; set; }
        public byte[] Canvas_Screen { get; set; }
        public string Canvas_Format { get; set; }
    }
}
