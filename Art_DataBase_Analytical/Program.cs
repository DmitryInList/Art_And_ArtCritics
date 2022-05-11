using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Windows.Forms;

using Art_DataBase_Analytical.View;
using Art_DataBase_Analytical.Model;
using Art_DataBase_Analytical.Controller;

namespace Art_DataBase_Analytical
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
