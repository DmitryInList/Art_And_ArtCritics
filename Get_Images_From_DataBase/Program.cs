using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Windows.Forms;
using Get_Images_From_DataBase.View;
using Get_Images_From_DataBase.Controller;
using Get_Images_From_DataBase.Model;

namespace Get_Images_From_DataBase
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

            Model.IModel TheModel = new Model.Model();
            Controller.IController TheController = new Controller.Controller(TheModel);
            Application.Run(new MainView(TheController));
        }
    }
}
