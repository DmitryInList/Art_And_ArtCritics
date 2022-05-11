namespace Art_DataBase_Analytic_EF.View
{
    partial class ArticleDetails
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(ArticleDetails));
            this.panel2 = new System.Windows.Forms.Panel();
            this.button_Close = new System.Windows.Forms.Button();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.groupBox4 = new System.Windows.Forms.GroupBox();
            this.splitContainer1 = new System.Windows.Forms.SplitContainer();
            this.groupBox2 = new System.Windows.Forms.GroupBox();
            this.groupBox3 = new System.Windows.Forms.GroupBox();
            this.criticsInformation1 = new Art_DataBase_Analytic_EF.View.UserComponents.CriticsInformation();
            this.feedbacksInformation1 = new Art_DataBase_Analytic_EF.View.UserComponents.FeedbacksInformation();
            this.articlesInformation1 = new Art_DataBase_Analytic_EF.View.UserComponents.ArticlesInformation();
            this.canvasInformation1 = new Art_DataBase_Analytic_EF.View.UserComponents.CanvasInformation();
            this.panel2.SuspendLayout();
            this.groupBox1.SuspendLayout();
            this.groupBox4.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.splitContainer1)).BeginInit();
            this.splitContainer1.Panel1.SuspendLayout();
            this.splitContainer1.Panel2.SuspendLayout();
            this.splitContainer1.SuspendLayout();
            this.groupBox2.SuspendLayout();
            this.groupBox3.SuspendLayout();
            this.SuspendLayout();
            // 
            // panel2
            // 
            this.panel2.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.panel2.Controls.Add(this.button_Close);
            this.panel2.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.panel2.Location = new System.Drawing.Point(0, 653);
            this.panel2.Name = "panel2";
            this.panel2.Size = new System.Drawing.Size(984, 43);
            this.panel2.TabIndex = 2;
            // 
            // button_Close
            // 
            this.button_Close.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.button_Close.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.button_Close.Location = new System.Drawing.Point(819, 8);
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
            this.groupBox1.Location = new System.Drawing.Point(2, 3);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(980, 280);
            this.groupBox1.TabIndex = 5;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "Картина, которой посвящена статья:";
            // 
            // groupBox4
            // 
            this.groupBox4.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.groupBox4.Controls.Add(this.articlesInformation1);
            this.groupBox4.Location = new System.Drawing.Point(2, 282);
            this.groupBox4.Name = "groupBox4";
            this.groupBox4.Size = new System.Drawing.Size(980, 83);
            this.groupBox4.TabIndex = 8;
            this.groupBox4.TabStop = false;
            this.groupBox4.Text = "Статья, посвященная этой картине:";
            // 
            // splitContainer1
            // 
            this.splitContainer1.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.splitContainer1.Location = new System.Drawing.Point(2, 365);
            this.splitContainer1.Name = "splitContainer1";
            // 
            // splitContainer1.Panel1
            // 
            this.splitContainer1.Panel1.Controls.Add(this.groupBox2);
            // 
            // splitContainer1.Panel2
            // 
            this.splitContainer1.Panel2.Controls.Add(this.groupBox3);
            this.splitContainer1.Size = new System.Drawing.Size(980, 285);
            this.splitContainer1.SplitterDistance = 482;
            this.splitContainer1.SplitterWidth = 5;
            this.splitContainer1.TabIndex = 9;
            // 
            // groupBox2
            // 
            this.groupBox2.Controls.Add(this.criticsInformation1);
            this.groupBox2.Dock = System.Windows.Forms.DockStyle.Fill;
            this.groupBox2.Location = new System.Drawing.Point(0, 0);
            this.groupBox2.Name = "groupBox2";
            this.groupBox2.Size = new System.Drawing.Size(482, 285);
            this.groupBox2.TabIndex = 0;
            this.groupBox2.TabStop = false;
            this.groupBox2.Text = "Перечень искусствоведов-соавторов этой статьи:";
            // 
            // groupBox3
            // 
            this.groupBox3.Controls.Add(this.feedbacksInformation1);
            this.groupBox3.Dock = System.Windows.Forms.DockStyle.Fill;
            this.groupBox3.Location = new System.Drawing.Point(0, 0);
            this.groupBox3.Name = "groupBox3";
            this.groupBox3.Size = new System.Drawing.Size(493, 285);
            this.groupBox3.TabIndex = 0;
            this.groupBox3.TabStop = false;
            this.groupBox3.Text = "Перечень критических отзывов на эту статью:";
            // 
            // criticsInformation1
            // 
            this.criticsInformation1.DataGridClickMustHave = true;
            this.criticsInformation1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.criticsInformation1.Location = new System.Drawing.Point(3, 17);
            this.criticsInformation1.Name = "criticsInformation1";
            this.criticsInformation1.Size = new System.Drawing.Size(476, 265);
            this.criticsInformation1.TabIndex = 0;
            // 
            // feedbacksInformation1
            // 
            this.feedbacksInformation1.DataGridClickMustHave = true;
            this.feedbacksInformation1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.feedbacksInformation1.Location = new System.Drawing.Point(3, 17);
            this.feedbacksInformation1.Name = "feedbacksInformation1";
            this.feedbacksInformation1.Size = new System.Drawing.Size(487, 265);
            this.feedbacksInformation1.TabIndex = 0;
            // 
            // articlesInformation1
            // 
            this.articlesInformation1.DataGridClickMustHave = false;
            this.articlesInformation1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.articlesInformation1.Enabled = false;
            this.articlesInformation1.Location = new System.Drawing.Point(3, 17);
            this.articlesInformation1.Name = "articlesInformation1";
            this.articlesInformation1.Size = new System.Drawing.Size(974, 63);
            this.articlesInformation1.TabIndex = 8;
            // 
            // canvasInformation1
            // 
            this.canvasInformation1.DataArrayIndex = 0;
            this.canvasInformation1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.canvasInformation1.ImageClickMustHave = false;
            this.canvasInformation1.Location = new System.Drawing.Point(3, 17);
            this.canvasInformation1.Name = "canvasInformation1";
            this.canvasInformation1.Size = new System.Drawing.Size(974, 260);
            this.canvasInformation1.TabIndex = 3;
            // 
            // ArticleDetails
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 15F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(984, 696);
            this.Controls.Add(this.splitContainer1);
            this.Controls.Add(this.groupBox4);
            this.Controls.Add(this.groupBox1);
            this.Controls.Add(this.panel2);
            this.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.MinimumSize = new System.Drawing.Size(600, 400);
            this.Name = "ArticleDetails";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Подробная информация о статье, посвященной картине.";
            this.Load += new System.EventHandler(this.ArticleDetails_Load);
            this.panel2.ResumeLayout(false);
            this.groupBox1.ResumeLayout(false);
            this.groupBox4.ResumeLayout(false);
            this.splitContainer1.Panel1.ResumeLayout(false);
            this.splitContainer1.Panel2.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.splitContainer1)).EndInit();
            this.splitContainer1.ResumeLayout(false);
            this.groupBox2.ResumeLayout(false);
            this.groupBox3.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Panel panel2;
        private System.Windows.Forms.Button button_Close;
        private System.Windows.Forms.GroupBox groupBox1;
        private Art_DataBase_Analytic_EF.View.UserComponents.CanvasInformation canvasInformation1;
        private System.Windows.Forms.GroupBox groupBox4;
        private Art_DataBase_Analytic_EF.View.UserComponents.ArticlesInformation articlesInformation1;
        private System.Windows.Forms.SplitContainer splitContainer1;
        private System.Windows.Forms.GroupBox groupBox2;
        private System.Windows.Forms.GroupBox groupBox3;
        private Art_DataBase_Analytic_EF.View.UserComponents.CriticsInformation criticsInformation1;
        private Art_DataBase_Analytic_EF.View.UserComponents.FeedbacksInformation feedbacksInformation1;
    }
}