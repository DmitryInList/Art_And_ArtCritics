namespace Art_DataBase_Analytical.View
{
    partial class CanvasArticlesDetails
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(CanvasArticlesDetails));
            this.panel2 = new System.Windows.Forms.Panel();
            this.button_Close = new System.Windows.Forms.Button();
            this.panel1 = new System.Windows.Forms.Panel();
            this.articlesInformation1 = new Art_DataBase_Analytical.View.UserComponents.ArticlesInformation();
            this.canvasInformation1 = new Art_DataBase_Analytical.View.UserComponents.CanvasInformation();
            this.panel2.SuspendLayout();
            this.panel1.SuspendLayout();
            this.SuspendLayout();
            // 
            // panel2
            // 
            this.panel2.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.panel2.Controls.Add(this.button_Close);
            this.panel2.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.panel2.Location = new System.Drawing.Point(0, 638);
            this.panel2.Name = "panel2";
            this.panel2.Size = new System.Drawing.Size(784, 43);
            this.panel2.TabIndex = 3;
            // 
            // button_Close
            // 
            this.button_Close.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.button_Close.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.button_Close.Location = new System.Drawing.Point(619, 8);
            this.button_Close.Name = "button_Close";
            this.button_Close.Size = new System.Drawing.Size(150, 25);
            this.button_Close.TabIndex = 1;
            this.button_Close.Text = "Закрыть";
            this.button_Close.UseVisualStyleBackColor = true;
            this.button_Close.Click += new System.EventHandler(this.button_Close_Click);
            // 
            // panel1
            // 
            this.panel1.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.panel1.Controls.Add(this.articlesInformation1);
            this.panel1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.panel1.Location = new System.Drawing.Point(0, 300);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(784, 338);
            this.panel1.TabIndex = 5;
            // 
            // articlesInformation1
            // 
            this.articlesInformation1.DataGridClickMustHave = true;
            this.articlesInformation1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.articlesInformation1.Location = new System.Drawing.Point(0, 0);
            this.articlesInformation1.Name = "articlesInformation1";
            this.articlesInformation1.Size = new System.Drawing.Size(782, 336);
            this.articlesInformation1.TabIndex = 0;
            // 
            // canvasInformation1
            // 
            this.canvasInformation1.DataArrayIndex = 0;
            this.canvasInformation1.Dock = System.Windows.Forms.DockStyle.Top;
            this.canvasInformation1.ImageClickMustHave = false;
            this.canvasInformation1.Location = new System.Drawing.Point(0, 0);
            this.canvasInformation1.Name = "canvasInformation1";
            this.canvasInformation1.Size = new System.Drawing.Size(784, 300);
            this.canvasInformation1.TabIndex = 4;
            // 
            // CanvasArticlesDetails
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 15F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(784, 681);
            this.Controls.Add(this.panel1);
            this.Controls.Add(this.canvasInformation1);
            this.Controls.Add(this.panel2);
            this.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Name = "CanvasArticlesDetails";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Перечень всех статей, посвященных этой картине.";
            this.Load += new System.EventHandler(this.CanvasArticlesDetails_Load);
            this.panel2.ResumeLayout(false);
            this.panel1.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Panel panel2;
        private System.Windows.Forms.Button button_Close;
        private Art_DataBase_Analytical.View.UserComponents.CanvasInformation canvasInformation1;
        private System.Windows.Forms.Panel panel1;
        private Art_DataBase_Analytical.View.UserComponents.ArticlesInformation articlesInformation1;
    }
}