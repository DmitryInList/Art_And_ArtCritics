// ---------------------------------------------------------------------------------------------------------
// ---- popov 06.04.2021 ----
// ---------------------------------------------------------------------------------------------------------
// служебная модель представления, стоящая за окном, отображаемым во время 
// загрузки данных из БД "Искусство и Искусствоведы"
// ---------------------------------------------------------------------------------------------------------

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Base_For_MVVM;
using Get_Images_From_DataBase_MVVM.Model;
using System.Windows;
using System.Windows.Input;
using System.Threading;

namespace Get_Images_From_DataBase_MVVM.ViewModel
{
    public class LoadDataFromDBViewModel: DialogBaseViewModel
    {
        // ссылка на модель
        private IModel MyModel;        

        // --------------------------------------------------------------------------------
        // ---- Загрузка данных о картинах из БД "Искусство и Искусствоведы" ----
        // --------------------------------------------------------------------------------
        private Task<bool> TryLoadDataFromDB()
        {
            return Task<bool>.Run(() => 
                {
                    // Наша учебная база данных - очень маленькая, и грузится слишком быстро.
                    // так что я, пожалуй, добавлю пару секунд величественного ожидания -
                    // для большей солидности...                
                    Thread.Sleep(2000);
                    return MyModel.ReadAllCanvasFromDataBase();
                });
        }
        // --------------------------------------------------------------------------------

        // ===============================================================================================
        // ==== Команды ====
        // ===============================================================================================
        public ICommand LoadDialogCommand { get; set; }
        // Команда загрузки данных из БД "Искусство и Искусствоведы"        
        private async void OnTakeDataFromDB(object o)
        {   
            Window W = (Window)o;            
            if (W != null)
            {   
                bResult = await TryLoadDataFromDB();                
                W.Close();
            }
        }
        // ===============================================================================================

        public LoadDataFromDBViewModel(IModel M)
        {
            MyModel = M;            
            LoadDialogCommand = new LambdaCommand(OnTakeDataFromDB);
        }
    }
}
