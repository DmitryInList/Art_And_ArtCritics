// --------------------------------------------------------------------------------------------------------
// ---- popov 06.04.2021 ----
// --------------------------------------------------------------------------------------------------------
// Узкоспециализированная модель представления, предназначенная для работы с 
// диалоговым окном, которое будет отображать подробные данные об одной картине
// из БД "Искусство и Искусствоведды", а так же давать пользователю возможность
// сохранить любую картину в файл.
// --------------------------------------------------------------------------------------------------------

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Microsoft.Win32;

using Base_For_MVVM;
using Get_Images_From_DataBase_MVVM.Model.Data;
using Get_Images_From_DataBase_MVVM.View.DialogHiders;
using System.Windows;
using System.Windows.Input;

namespace Get_Images_From_DataBase_MVVM.ViewModel
{
    public class ShowCanvasDialogViewModel: DialogBaseViewModel
    {
        private IArtCanvas m_TheCanvas;
        public IArtCanvas TheCanvas
        {
            get { return m_TheCanvas; }
            set
            {
                m_TheCanvas = value;
                OnPropertyChanged();
            }
        }

        // ==================================================================================================
        // ==== Команды ====
        // ==================================================================================================
        // команда сохранения изображения в файл - средствами IArtCanvas
        public ICommand ButtonOneClickCommand { get; set; }
        private void OnButtonOneClickCommandExecute(object o)
        {
            var dlg = new SaveFileDialog()
            {
                Title = "Сохранение изображения",
                Filter = "Графические файлы (*.jpg)|*.jpg|(*.bmp)|*.bmp|(*.gif)|*.gif|(*.png)|*.png"                
            };
            // Имеются три варианта того, что вернет ShowDialog():
            // - TRUE - если пользователь нажал "OK".
            // - FALSE - если пользователь нажал "Отмена"
            // - NULL - если пользователь нажал "[X]"
            if (dlg.ShowDialog() == true)
            {
                bool? bResult = TheCanvas?.SaveCanvasToGraphicFile(dlg.FileName);                
                if(bResult == true)
                {
                    string ResultFile = TheCanvas?.FileNameToSave;
                    MessageBox.Show("Изображение сохранено в файл по имени: '" + ResultFile + "'!", "Изображение успешно сохранено", MessageBoxButton.OK, MessageBoxImage.Information);
                }
            }
        }

        // ------------------------------------------------------------------------
        // команда закрытия диалогового окна
        public ICommand ButtonTwoClickCommand { get; set; }
        private void OnButtonTwoClickCommandExecute(object o)
        {
            Window w = (Window)o;
            if(w != null)
            {
                w.Close();
            }
        }

        // ==================================================================================================
        public ShowCanvasDialogViewModel(IArtCanvas ac)
        {
            m_TheCanvas = ac;
            ButtonOneClickCommand = new LambdaCommand(OnButtonOneClickCommandExecute);
            ButtonTwoClickCommand = new LambdaCommand(OnButtonTwoClickCommandExecute);
        }
    }
}
