namespace Art_DataBase_Analytic_EF.View
{
    partial class FeedbackDetails
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(FeedbackDetails));
            this.panel2 = new System.Windows.Forms.Panel();
            this.button_Close = new System.Windows.Forms.Button();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.canvasInformation1 = new Art_DataBase_Analytic_EF.View.UserComponents.CanvasInformation();
            this.groupBox2 = new System.Windows.Forms.GroupBox();
            this.criticsInformation1 = new Art_DataBase_Analytic_EF.View.UserComponents.CriticsInformation();
            this.groupBox3 = new System.Windows.Forms.GroupBox();
            this.feedbacksInformation1 = new Art_DataBase_Analytic_EF.View.UserComponents.FeedbacksInformation();
            this.groupBox4 = new System.Windows.Forms.GroupBox();
            this.articlesInformation1 = new Art_DataBase_Analytic_EF.View.UserComponents.ArticlesInformation();
            this.panel2.SuspendLayout();
            this.groupBox1.SuspendLayout();
            this.groupBox2.SuspendLayout();
            this.groupBox3.SuspendLayout();
            this.groupBox4.SuspendLayout();
            this.SuspendLayout();
            // 
            // panel2
            // 
            this.panel2.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.panel2.Controls.Add(this.button_Close);
            this.panel2.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.panel2.Location = new System.Drawing.Point(0, 538);
            this.panel2.Name = "panel2";
            this.panel2.Size = new System.Drawing.Size(834, 43);
            this.panel2.TabIndex = 2;
            // 
            // button_Close
            // 
            this.button_Close.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.button_Close.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.button_Close.Location = new System.Drawing.Point(669, 7);
            this.button_Close.Name = "button_Close";
            this.button_Close.Size = new System.Drawing.Size(150, 25);
            this.button_Close.TabIndex = 1;
            this.button_Close.Text = "Закрыть";
            this.button_Close.UseVisualStyleBackColor = true;
            this.button_Close.Click += new System.EventHandler(this.button_Close_Click);
            // 
            // groupBox1
            // 
            this.groupBox1.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.groupBox1.Controls.Add(this.canvasInformation1);
            this.groupBox1.Location = new System.Drawing.Point(3, 3);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(827, 280);
            this.groupBox1.TabIndex = 4;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "Картина, которой посвящена статья:";
            // 
            // canvasInformation1
            // 
            this.canvasInformation1.DataArrayIndex = 0;
            this.canvasInformation1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.canvasInformation1.ImageClickMustHave = false;
            this.canvasInformation1.Location = new System.Drawing.Point(3, 17);
            this.canvasInformation1.Name = "canvasInformation1";
            this.canvasInformation1.Size = new System.Drawing.Size(821, 260);
            this.canvasInformation1.TabIndex = 3;
            // 
            // groupBox2
            // 
            this.groupBox2.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.groupBox2.Controls.Add(this.criticsInformation1);
            this.groupBox2.Location = new System.Drawing.Point(3, 449);
            this.groupBox2.Name = "groupBox2";
            this.groupBox2.Size = new System.Drawing.Size(827, 83);
            this.groupBox2.TabIndex = 5;
            this.groupBox2.TabStop = false;
            this.groupBox2.Text = "Искусствовед, автор этого критического отзыва:";
            // 
            // criticsInformation1
            // 
            this.criticsInformation1.DataGridClickMustHave = false;
            this.criticsInformation1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.criticsInformation1.Enabled = false;
            this.criticsInformation1.Location = new System.Drawing.Point(3, 17);
            this.criticsInformation1.Name = "criticsInformation1";
            this.criticsInformation1.Size = new System.Drawing.Size(821, 63);
            this.criticsInformation1.TabIndex = 6;
            // 
            // groupBox3
            // 
            this.groupBox3.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.groupBox3.Controls.Add(this.feedbacksInformation1);
            this.groupBox3.Location = new System.Drawing.Point(3, 366);
            this.groupBox3.Name = "groupBox3";
            this.groupBox3.Size = new System.Drawing.Size(827, 83);
            this.groupBox3.TabIndex = 6;
            this.groupBox3.TabStop = false;
            this.groupBox3.Text = "Критический отзыв на эту статью:";
            // 
            // feedbacksInformation1
            // 
            this.feedbacksInformation1.DataGridClickMustHave = false;
            this.feedbacksInformation1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.feedbacksInformation1.Enabled = false;
            this.feedbacksInformation1.Location = new System.Drawing.Point(3, 17);
            this.feedbacksInformation1.Name = "feedbacksInformation1";
            this.feedbacksInformation1.Size = new System.Drawing.Size(821, 63);
            this.feedbacksInformation1.TabIndex = 7;
            // 
            // groupBox4
            // 
            this.groupBox4.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.groupBox4.Controls.Add(this.articlesInformation1);
            this.groupBox4.Location = new System.Drawing.Point(3, 283);
            this.groupBox4.Name = "groupBox4";
            this.groupBox4.Size = new System.Drawing.Size(827, 83);
            this.groupBox4.TabIndex = 7;
            this.groupBox4.TabStop = false;
            this.groupBox4.Text = "Статья, посвященная этой картине:";
            // 
            // articlesInformation1
            // 
            this.articlesInformation1.DataGridClickMustHave = true;
            this.articlesInformation1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.articlesInformation1.Enabled = false;
            this.articlesInformation1.Location = new System.Drawing.Point(3, 17);
            this.articlesInformation1.Name = "articlesInformation1";
            this.articlesInformation1.Size = new System.Drawing.Size(821, 63);
            this.articlesInformation1.TabIndex = 8;
            // 
            // FeedbackDetails
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 15F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(834, 581);
            this.Controls.Add(this.groupBox4);
            this.Controls.Add(this.groupBox3);
            this.Controls.Add(this.groupBox2);
            this.Controls.Add(this.groupBox1);
            this.Controls.Add(this.panel2);
            this.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog;
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.MaximizeBox = false;
            this.MaximumSize = new System.Drawing.Size(850, 620);
            this.MinimizeBox = false;
            this.MinimumSize = new System.Drawing.Size(850, 620);
            this.Name = "FeedbackDetails";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Подробная информация о критическом отзыве на статью.";
            this.Load += new System.EventHandler(this.FeedbackDetails_Load);
            this.panel2.ResumeLayout(false);
            this.groupBox1.ResumeLayout(false);
            this.groupBox2.ResumeLayout(false);
            this.groupBox3.ResumeLayout(false);
            this.groupBox4.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Panel panel2;
        private System.Windows.Forms.Button button_Close;
        private Art_DataBase_Analytic_EF.View.UserComponents.CanvasInformation canvasInformation1;
        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.GroupBox groupBox2;
        private Art_DataBase_Analytic_EF.View.UserComponents.CriticsInformation criticsInformation1;
        private System.Windows.Forms.GroupBox groupBox3;
        private Art_DataBase_Analytic_EF.View.UserComponents.FeedbacksInformation feedbacksInformation1;
        private System.Windows.Forms.GroupBox groupBox4;
        private Art_DataBase_Analytic_EF.View.UserComponents.ArticlesInformation articlesInformation1;
    }
}