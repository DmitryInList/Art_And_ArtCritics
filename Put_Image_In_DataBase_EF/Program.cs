using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Windows.Forms;

using Put_Image_In_DataBase_EF.View;
using Put_Image_In_DataBase_EF.Controller;
using Put_Image_In_DataBase_EF.Model;

namespace Put_Image_In_DataBase_EF
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
            Controller.Controller CNT = new Controller.Controller(new Model.Model());

            Application.Run(new MainView(CNT));
        }
    }
}
