// --------------------------------------------------------------------------------------------------------
// ---- popov 07.04.2021 ----
// --------------------------------------------------------------------------------------------------------
// Дилоговое окно, которое своим появлением сигнализирует о том, 
// что в данный момент происходит загрузка данных из БД "Искусство и Искусствоведы"...
// --------------------------------------------------------------------------------------------------------

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Shapes;

namespace Get_Images_From_DataBase_MVVM.View
{
    /// <summary>
    /// Interaction logic for WelcomeDialog.xaml
    /// </summary>
    public partial class WelcomeDialog : Window
    {
        public WelcomeDialog()
        {
            InitializeComponent();
        }

        // Мне необходимо зациклить проигрывание GIF-файла - чтобы он не прекращал крутиться...
        private void MyGif_MediaEnded(object sender, RoutedEventArgs e)
        {
            MyGif.Position = new TimeSpan(0, 0, 1);
            MyGif.Play();
        }
    }
}
