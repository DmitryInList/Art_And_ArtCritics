using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Windows.Forms;

using Put_Image_In_DataBase.View;
using Put_Image_In_DataBase.Controller;
using Put_Image_In_DataBase.Model;

namespace Put_Image_In_DataBase
{
    static class Program
    {
        /// <summary>
        /// The main entry point for the application.
        /// </summary>
        [STAThread]
        static void Main()
        {
            Application.EnableVisualStyles();
            Application.SetCompatibleTextRenderingDefault(false);

            // Определяем Модель и Контроллер - и сразу же связываем их друг с другом.
            Put_Image_In_DataBase.Controller.Controller CNT = new Controller.Controller(new Put_Image_In_DataBase.Model.Model());

            // При создании главного окна передаем ему ссылку на Контроллер.
            Application.Run(new MainView(CNT));
        }
    }
}
