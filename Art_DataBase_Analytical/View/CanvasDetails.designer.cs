namespace Art_DataBase_Analytical.View
{
    partial class CanvasDetails
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(CanvasDetails));
            this.panel2 = new System.Windows.Forms.Panel();
            this.button_Close = new System.Windows.Forms.Button();
            this.textBox_Grade = new System.Windows.Forms.TextBox();
            this.label1 = new System.Windows.Forms.Label();
            this.button_Details = new System.Windows.Forms.Button();
            this.canvasInformation1 = new Art_DataBase_Analytical.View.UserComponents.CanvasInformation();
            this.panel2.SuspendLayout();
            this.SuspendLayout();
            // 
            // panel2
            // 
            this.panel2.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.panel2.Controls.Add(this.textBox_Grade);
            this.panel2.Controls.Add(this.label1);
            this.panel2.Controls.Add(this.button_Close);
            this.panel2.Controls.Add(this.button_Details);
            this.panel2.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.panel2.Location = new System.Drawing.Point(0, 518);
            this.panel2.Name = "panel2";
            this.panel2.Size = new System.Drawing.Size(784, 43);
            this.panel2.TabIndex = 3;
            // 
            // button_Close
            // 
            this.button_Close.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.button_Close.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.button_Close.Location = new System.Drawing.Point(619, 7);
            this.button_Close.Name = "button_Close";
            this.button_Close.Size = new System.Drawing.Size(150, 25);
            this.button_Close.TabIndex = 1;
            this.button_Close.Text = "Закрыть";
            this.button_Close.UseVisualStyleBackColor = true;
            this.button_Close.Click += new System.EventHandler(this.button_Close_Click);
            // 
            // textBox_Grade
            // 
            this.textBox_Grade.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.textBox_Grade.Location = new System.Drawing.Point(172, 9);
            this.textBox_Grade.Name = "textBox_Grade";
            this.textBox_Grade.ReadOnly = true;
            this.textBox_Grade.Size = new System.Drawing.Size(45, 21);
            this.textBox_Grade.TabIndex = 3;
            this.textBox_Grade.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            // 
            // label1
            // 
            this.label1.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(6, 9);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(163, 15);
            this.label1.TabIndex = 2;
            this.label1.Text = "Итоговая оценка картины:";
            // 
            // button_Details
            // 
            this.button_Details.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.button_Details.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.button_Details.Location = new System.Drawing.Point(421, 7);
            this.button_Details.Name = "button_Details";
            this.button_Details.Size = new System.Drawing.Size(150, 25);
            this.button_Details.TabIndex = 1;
            this.button_Details.Text = "Подробнее...";
            this.button_Details.UseVisualStyleBackColor = true;
            this.button_Details.Click += new System.EventHandler(this.button_Details_Click);
            // 
            // canvasInformation1
            // 
            this.canvasInformation1.DataArrayIndex = 0;
            this.canvasInformation1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.canvasInformation1.ImageClickMustHave = false;
            this.canvasInformation1.Location = new System.Drawing.Point(0, 0);
            this.canvasInformation1.Name = "canvasInformation1";
            this.canvasInformation1.Size = new System.Drawing.Size(784, 518);
            this.canvasInformation1.TabIndex = 5;
            // 
            // CanvasDetails
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 15F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(784, 561);
            this.Controls.Add(this.canvasInformation1);
            this.Controls.Add(this.panel2);
            this.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.MinimumSize = new System.Drawing.Size(600, 500);
            this.Name = "CanvasDetails";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Подробная информация о картине.";
            this.Load += new System.EventHandler(this.CanvasDetails_Load);
            this.panel2.ResumeLayout(false);
            this.panel2.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Panel panel2;
        private System.Windows.Forms.Button button_Close;
        private System.Windows.Forms.TextBox textBox_Grade;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Button button_Details;
        private Art_DataBase_Analytical.View.UserComponents.CanvasInformation canvasInformation1;
    }
}