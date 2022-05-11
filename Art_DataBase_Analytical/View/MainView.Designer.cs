namespace Art_DataBase_Analytical.View
{
    partial class MainView
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(MainView));
            this.panel1 = new System.Windows.Forms.Panel();
            this.button_RefreshData = new System.Windows.Forms.Button();
            this.button_Close = new System.Windows.Forms.Button();
            this.tabControl1 = new System.Windows.Forms.TabControl();
            this.tabPage1 = new System.Windows.Forms.TabPage();
            this.canvasInformation10 = new Art_DataBase_Analytical.View.UserComponents.CanvasInformation();
            this.canvasInformation9 = new Art_DataBase_Analytical.View.UserComponents.CanvasInformation();
            this.canvasInformation8 = new Art_DataBase_Analytical.View.UserComponents.CanvasInformation();
            this.canvasInformation7 = new Art_DataBase_Analytical.View.UserComponents.CanvasInformation();
            this.canvasInformation6 = new Art_DataBase_Analytical.View.UserComponents.CanvasInformation();
            this.canvasInformation5 = new Art_DataBase_Analytical.View.UserComponents.CanvasInformation();
            this.canvasInformation4 = new Art_DataBase_Analytical.View.UserComponents.CanvasInformation();
            this.canvasInformation3 = new Art_DataBase_Analytical.View.UserComponents.CanvasInformation();
            this.canvasInformation2 = new Art_DataBase_Analytical.View.UserComponents.CanvasInformation();
            this.canvasInformation1 = new Art_DataBase_Analytical.View.UserComponents.CanvasInformation();
            this.panel3 = new System.Windows.Forms.Panel();
            this.button_Forward = new System.Windows.Forms.Button();
            this.button_Backward = new System.Windows.Forms.Button();
            this.tabPage2 = new System.Windows.Forms.TabPage();
            this.criticsInformation1 = new Art_DataBase_Analytical.View.UserComponents.CriticsInformation();
            this.panel1.SuspendLayout();
            this.tabControl1.SuspendLayout();
            this.tabPage1.SuspendLayout();
            this.panel3.SuspendLayout();
            this.tabPage2.SuspendLayout();
            this.SuspendLayout();
            // 
            // panel1
            // 
            this.panel1.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.panel1.Controls.Add(this.button_RefreshData);
            this.panel1.Controls.Add(this.button_Close);
            this.panel1.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.panel1.Location = new System.Drawing.Point(0, 563);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(1069, 43);
            this.panel1.TabIndex = 13;
            // 
            // button_RefreshData
            // 
            this.button_RefreshData.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.button_RefreshData.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.button_RefreshData.Location = new System.Drawing.Point(705, 8);
            this.button_RefreshData.Name = "button_RefreshData";
            this.button_RefreshData.Size = new System.Drawing.Size(150, 25);
            this.button_RefreshData.TabIndex = 1;
            this.button_RefreshData.Text = "Обновить";
            this.button_RefreshData.UseVisualStyleBackColor = true;
            this.button_RefreshData.Click += new System.EventHandler(this.button_RefreshData_Click);
            // 
            // button_Close
            // 
            this.button_Close.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.button_Close.Location = new System.Drawing.Point(903, 8);
            this.button_Close.Name = "button_Close";
            this.button_Close.Size = new System.Drawing.Size(150, 25);
            this.button_Close.TabIndex = 0;
            this.button_Close.Text = "Закрыть";
            this.button_Close.UseVisualStyleBackColor = true;
            this.button_Close.Click += new System.EventHandler(this.button_Close_Click);
            // 
            // tabControl1
            // 
            this.tabControl1.Controls.Add(this.tabPage1);
            this.tabControl1.Controls.Add(this.tabPage2);
            this.tabControl1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tabControl1.Location = new System.Drawing.Point(0, 0);
            this.tabControl1.Name = "tabControl1";
            this.tabControl1.SelectedIndex = 0;
            this.tabControl1.Size = new System.Drawing.Size(1069, 563);
            this.tabControl1.TabIndex = 14;
            // 
            // tabPage1
            // 
            this.tabPage1.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.tabPage1.Controls.Add(this.canvasInformation10);
            this.tabPage1.Controls.Add(this.canvasInformation9);
            this.tabPage1.Controls.Add(this.canvasInformation8);
            this.tabPage1.Controls.Add(this.canvasInformation7);
            this.tabPage1.Controls.Add(this.canvasInformation6);
            this.tabPage1.Controls.Add(this.canvasInformation5);
            this.tabPage1.Controls.Add(this.canvasInformation4);
            this.tabPage1.Controls.Add(this.canvasInformation3);
            this.tabPage1.Controls.Add(this.canvasInformation2);
            this.tabPage1.Controls.Add(this.canvasInformation1);
            this.tabPage1.Controls.Add(this.panel3);
            this.tabPage1.Location = new System.Drawing.Point(4, 22);
            this.tabPage1.Name = "tabPage1";
            this.tabPage1.Padding = new System.Windows.Forms.Padding(3);
            this.tabPage1.Size = new System.Drawing.Size(1061, 537);
            this.tabPage1.TabIndex = 0;
            this.tabPage1.Text = "Данные о картинах";
            this.tabPage1.UseVisualStyleBackColor = true;
            // 
            // canvasInformation10
            // 
            this.canvasInformation10.DataArrayIndex = 9;
            this.canvasInformation10.ImageClickMustHave = true;
            this.canvasInformation10.Location = new System.Drawing.Point(846, 244);
            this.canvasInformation10.Name = "canvasInformation10";
            this.canvasInformation10.Size = new System.Drawing.Size(210, 240);
            this.canvasInformation10.TabIndex = 21;
            // 
            // canvasInformation9
            // 
            this.canvasInformation9.DataArrayIndex = 8;
            this.canvasInformation9.ImageClickMustHave = true;
            this.canvasInformation9.Location = new System.Drawing.Point(635, 244);
            this.canvasInformation9.Name = "canvasInformation9";
            this.canvasInformation9.Size = new System.Drawing.Size(210, 240);
            this.canvasInformation9.TabIndex = 20;
            // 
            // canvasInformation8
            // 
            this.canvasInformation8.DataArrayIndex = 7;
            this.canvasInformation8.ImageClickMustHave = true;
            this.canvasInformation8.Location = new System.Drawing.Point(424, 244);
            this.canvasInformation8.Name = "canvasInformation8";
            this.canvasInformation8.Size = new System.Drawing.Size(210, 240);
            this.canvasInformation8.TabIndex = 19;
            // 
            // canvasInformation7
            // 
            this.canvasInformation7.DataArrayIndex = 6;
            this.canvasInformation7.ImageClickMustHave = true;
            this.canvasInformation7.Location = new System.Drawing.Point(213, 244);
            this.canvasInformation7.Name = "canvasInformation7";
            this.canvasInformation7.Size = new System.Drawing.Size(210, 240);
            this.canvasInformation7.TabIndex = 18;
            // 
            // canvasInformation6
            // 
            this.canvasInformation6.DataArrayIndex = 5;
            this.canvasInformation6.ImageClickMustHave = true;
            this.canvasInformation6.Location = new System.Drawing.Point(2, 244);
            this.canvasInformation6.Name = "canvasInformation6";
            this.canvasInformation6.Size = new System.Drawing.Size(210, 240);
            this.canvasInformation6.TabIndex = 17;
            // 
            // canvasInformation5
            // 
            this.canvasInformation5.DataArrayIndex = 4;
            this.canvasInformation5.ImageClickMustHave = true;
            this.canvasInformation5.Location = new System.Drawing.Point(846, 2);
            this.canvasInformation5.Name = "canvasInformation5";
            this.canvasInformation5.Size = new System.Drawing.Size(210, 240);
            this.canvasInformation5.TabIndex = 16;
            // 
            // canvasInformation4
            // 
            this.canvasInformation4.DataArrayIndex = 3;
            this.canvasInformation4.ImageClickMustHave = true;
            this.canvasInformation4.Location = new System.Drawing.Point(635, 2);
            this.canvasInformation4.Name = "canvasInformation4";
            this.canvasInformation4.Size = new System.Drawing.Size(210, 240);
            this.canvasInformation4.TabIndex = 15;
            // 
            // canvasInformation3
            // 
            this.canvasInformation3.DataArrayIndex = 2;
            this.canvasInformation3.ImageClickMustHave = true;
            this.canvasInformation3.Location = new System.Drawing.Point(424, 2);
            this.canvasInformation3.Name = "canvasInformation3";
            this.canvasInformation3.Size = new System.Drawing.Size(210, 240);
            this.canvasInformation3.TabIndex = 14;
            // 
            // canvasInformation2
            // 
            this.canvasInformation2.DataArrayIndex = 1;
            this.canvasInformation2.ImageClickMustHave = true;
            this.canvasInformation2.Location = new System.Drawing.Point(213, 2);
            this.canvasInformation2.Name = "canvasInformation2";
            this.canvasInformation2.Size = new System.Drawing.Size(210, 240);
            this.canvasInformation2.TabIndex = 13;
            // 
            // canvasInformation1
            // 
            this.canvasInformation1.DataArrayIndex = 0;
            this.canvasInformation1.ImageClickMustHave = true;
            this.canvasInformation1.Location = new System.Drawing.Point(2, 2);
            this.canvasInformation1.Name = "canvasInformation1";
            this.canvasInformation1.Size = new System.Drawing.Size(210, 240);
            this.canvasInformation1.TabIndex = 12;
            // 
            // panel3
            // 
            this.panel3.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.panel3.Controls.Add(this.button_Forward);
            this.panel3.Controls.Add(this.button_Backward);
            this.panel3.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.panel3.Location = new System.Drawing.Point(3, 489);
            this.panel3.Name = "panel3";
            this.panel3.Size = new System.Drawing.Size(1053, 43);
            this.panel3.TabIndex = 11;
            // 
            // button_Forward
            // 
            this.button_Forward.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.button_Forward.Location = new System.Drawing.Point(559, 8);
            this.button_Forward.Name = "button_Forward";
            this.button_Forward.Size = new System.Drawing.Size(150, 25);
            this.button_Forward.TabIndex = 2;
            this.button_Forward.Text = "Вперед >>";
            this.button_Forward.UseVisualStyleBackColor = true;
            this.button_Forward.Click += new System.EventHandler(this.button_Forward_Click);
            // 
            // button_Backward
            // 
            this.button_Backward.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.button_Backward.Location = new System.Drawing.Point(349, 8);
            this.button_Backward.Name = "button_Backward";
            this.button_Backward.Size = new System.Drawing.Size(150, 25);
            this.button_Backward.TabIndex = 1;
            this.button_Backward.Text = "<< Назад";
            this.button_Backward.UseVisualStyleBackColor = true;
            this.button_Backward.Click += new System.EventHandler(this.button_Backward_Click);
            // 
            // tabPage2
            // 
            this.tabPage2.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.tabPage2.Controls.Add(this.criticsInformation1);
            this.tabPage2.Location = new System.Drawing.Point(4, 22);
            this.tabPage2.Name = "tabPage2";
            this.tabPage2.Padding = new System.Windows.Forms.Padding(3);
            this.tabPage2.Size = new System.Drawing.Size(1061, 537);
            this.tabPage2.TabIndex = 1;
            this.tabPage2.Text = "Данные об искусствоведах";
            this.tabPage2.UseVisualStyleBackColor = true;
            // 
            // criticsInformation1
            // 
            this.criticsInformation1.DataGridClickMustHave = true;
            this.criticsInformation1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.criticsInformation1.Location = new System.Drawing.Point(3, 3);
            this.criticsInformation1.Name = "criticsInformation1";
            this.criticsInformation1.Size = new System.Drawing.Size(1053, 529);
            this.criticsInformation1.TabIndex = 0;
            // 
            // MainView
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1069, 606);
            this.Controls.Add(this.tabControl1);
            this.Controls.Add(this.panel1);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog;
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.MaximumSize = new System.Drawing.Size(1085, 645);
            this.MinimumSize = new System.Drawing.Size(1085, 645);
            this.Name = "MainView";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Аналитическая обработка данных из БД \"Искусство и Искусствоведы\".";
            this.Load += new System.EventHandler(this.MainView_Load);
            this.panel1.ResumeLayout(false);
            this.tabControl1.ResumeLayout(false);
            this.tabPage1.ResumeLayout(false);
            this.panel3.ResumeLayout(false);
            this.tabPage2.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.Button button_RefreshData;
        private System.Windows.Forms.Button button_Close;
        private System.Windows.Forms.TabControl tabControl1;
        private System.Windows.Forms.TabPage tabPage1;
        private System.Windows.Forms.Panel panel3;
        private System.Windows.Forms.Button button_Forward;
        private System.Windows.Forms.Button button_Backward;
        private System.Windows.Forms.TabPage tabPage2;
        private UserComponents.CriticsInformation criticsInformation1;
        private UserComponents.CanvasInformation canvasInformation4;
        private UserComponents.CanvasInformation canvasInformation3;
        private UserComponents.CanvasInformation canvasInformation2;
        private UserComponents.CanvasInformation canvasInformation1;
        private UserComponents.CanvasInformation canvasInformation10;
        private UserComponents.CanvasInformation canvasInformation9;
        private UserComponents.CanvasInformation canvasInformation8;
        private UserComponents.CanvasInformation canvasInformation7;
        private UserComponents.CanvasInformation canvasInformation6;
        private UserComponents.CanvasInformation canvasInformation5;
    }
}

