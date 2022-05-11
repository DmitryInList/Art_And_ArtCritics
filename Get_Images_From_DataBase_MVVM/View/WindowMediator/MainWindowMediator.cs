// ----------------------------------------------------------------------------------------------------------
// ---- popov 08.04.2021 ----
// ----------------------------------------------------------------------------------------------------------
// Это сугубо служебный класс. Его единственная задача - быть посредником в
// передаче настроек (введенных в XAML-разметке) от главного окна к модели представления,
// соответствующей главному окну программы.
// ----------------------------------------------------------------------------------------------------------

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;

namespace Get_Images_From_DataBase_MVVM.View.WindowMediator
{                                   
    public class MainWindowMediator: DependencyObject
    {

        // В это свойство главное окно программы будет записывать максимальное число картин,
        // которые можно одновременно отобразить в пространстве главного окна.
        public int CanvasMaxCount
        {
            get { return (int)GetValue(CanvasMaxCountProperty); }
            set { SetValue(CanvasMaxCountProperty, value); }
        }

        // Using a DependencyProperty as the backing store for CanvasMaxCount.  This enables animation, styling, binding, etc...
        public static readonly DependencyProperty CanvasMaxCountProperty =
            DependencyProperty.Register("CanvasMaxCount", typeof(int), typeof(MainWindowMediator), new PropertyMetadata(0));


    }
}
