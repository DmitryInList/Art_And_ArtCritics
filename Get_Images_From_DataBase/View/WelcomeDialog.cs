﻿// -------------------------------------------------------------------------------------------------
// ---- popov 09.02.2021 ----
// -------------------------------------------------------------------------------------------------
// предварительный диалог, который открывается ПЕРЕД главным окном. Его цель - 
// информировать пользователя о том, что в настоящий момент ведется загрузка необходимых
// исходных данных из БД - а это может быть реально длительный процесс...
// -------------------------------------------------------------------------------------------------

using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

using System.IO;
// для отладки
using System.Threading;

using Get_Images_From_DataBase.Controller;

namespace Get_Images_From_DataBase.View
{
    public partial class WelcomeDialog : Form
    {
        // ссылка на объект Контроллер
        static Controller.IController MyController;

        // ВНИМАНИЕ!!!
        // Файл Waiting_for_completion.gif должен лежать в одной папке с EXE-файлом программы!!!
        static string GifFileName = "Waiting_for_completion.gif";

        // =========================================================================================
        // ==== Инфраструктура для отображения анимированного GIF-файла ====
        // =========================================================================================        
        Bitmap animatedImage = null;

        bool currentlyAnimating = false;

        private void AnimmateImage()
        {
            // страхуемся на тот случай, если GIF-файла не окажется на месте или он будет поврежден
            if (animatedImage == null)
                return;

            // Это действие должно выполняться только один раз...
            if(!currentlyAnimating)
            {
                ImageAnimator.Animate(animatedImage, new EventHandler(this.OnFrameChanged));
                currentlyAnimating = true;
            }
        }

        private void OnFrameChanged(object o, EventArgs e)
        {
            this.Invalidate();
        }
        // =========================================================================================        

        // -----------------------------------------------------------------------------------------------------
        // ---- флаг того, удалось ли нормально загрузить данные из БД, или нет ----
        // -----------------------------------------------------------------------------------------------------
        // значение по-умочланию - обязательно FALSE. Это страховка на тот случай, если
        // коварный пользователь вдруг принудительно закроет диалог чтения данных из БД - 
        // до того, как все данные будут нормально прочитаны из этой самой БД...
        // В таком случае главное окно программы сразу поймет, что данные получены НЕ БЫЛИ - 
        // и автоматически прекратит работу...
        bool bDataLoadingResult = false; // по-умолчанию - именно FALSE!!!

        // -----------------------------------------------------------------------------------------------------
        public WelcomeDialog()
        {
            InitializeComponent();
            // избавляемся от неприятного мерцания при перерисовке GIF-анимации...
            DoubleBuffered = true;
        }
        // -----------------------------------------------------------------------------------------------------

        // -----------------------------------------------------------------------------------------------------
        // ---- команда, которая запускает предварительное диалоговое окно ----
        // -----------------------------------------------------------------------------------------------------
        // ВНМАНИЕ!!! 
        // Эта команда может вызываться из главного окна многократно - и потому 
        // она ДОЛЖНА быть  статической - а отображаемый в ней диалог должен 
        // кажый раз создаваться и инициализироваться ЗАНОВО!
        //
        // Иначе при повторном вызове команды происходит ошибка
        // при выполнении операции Show - мол, диалог уже уничтожен...
        // -----------------------------------------------------------------------------------------------------
        public static bool Run(Controller.IController Ctr)
        {
            // фиксируем ссылку на главную Контроллер
            MyController = Ctr;

            // теперь каждый экземпляр диалога заново определяет флаг того, 
            // были данные нормально прочитаны из БД - или нет.
            WelcomeDialog NextDialog = new WelcomeDialog();
            NextDialog.ShowDialog();
            return NextDialog.bDataLoadingResult;
        }        

        // ==========================================================================================
        // в обработчике рисования формы будем размещать анимированный GIF-файл
        // ==========================================================================================
        private void WelcomeDialog_Paint(object sender, PaintEventArgs e)
        {
            // страхуемся на тот случай, если GIF-файла не окажется на месте или он будет поврежден
            if (animatedImage == null)
                return; 

            // инициализируем анимированную картинку данными из GIF-файла
            AnimmateImage();

            // Готовимся к воспроизведению анимации на поверхности нашей формы
            ImageAnimator.UpdateFrames();

            // Размещаем на форме объект, внутри которого воспроизводится анимация
            e.Graphics.DrawImage(animatedImage, new Point(186, 125));
        }        

        // =====================================================================================================
        // ==== При загрузке диалога асинхронно запустим операцию чтения данных из БД ====
        // =====================================================================================================
        private async void WelcomeDialog_Load(object sender, EventArgs e)
        {
            if(File.Exists(GifFileName))
            {
                try
                {
                    animatedImage = new Bitmap(GifFileName);
                }
                catch(Exception ex)
                {
                    animatedImage = null;
                }
            }

            bDataLoadingResult = await LoadDataFromDataBase();
            this.Close();
        }
        // =====================================================================================================

        // =====================================================================================================
        // ==== Метод для асинхронного чтения данных из БД ====
        // =====================================================================================================
        public Task<bool> LoadDataFromDataBase()
        {
            return Task.Run<bool>(() =>
            {
                // Наша учебная база данных - очень маленькая, и грузится слишком быстро.
                // так что я, пожалуй, добавлю пару секунд величественного ожидания -
                // для большей солидности...                
                Thread.Sleep(2000);
                return MyController.TryTakeAllCanvasesFromDataBase(); 
            });
        }
    }
}
