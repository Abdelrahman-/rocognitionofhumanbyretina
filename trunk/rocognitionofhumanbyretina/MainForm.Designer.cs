namespace rocognitionofhumanbyretina
{
    partial class MainForm
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
            this.pictureBoxMain = new System.Windows.Forms.PictureBox();
            this.closeButton = new System.Windows.Forms.Button();
            this.openButton = new System.Windows.Forms.Button();
            this.openFileDialog = new System.Windows.Forms.OpenFileDialog();
            this.dbButton = new System.Windows.Forms.Button();
            this.startButton = new System.Windows.Forms.Button();
            this.radioButton1D = new System.Windows.Forms.RadioButton();
            this.radioButton2D = new System.Windows.Forms.RadioButton();
            this.graphButton = new System.Windows.Forms.Button();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBoxMain)).BeginInit();
            this.SuspendLayout();
            // 
            // pictureBoxMain
            // 
            this.pictureBoxMain.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.pictureBoxMain.Location = new System.Drawing.Point(12, 12);
            this.pictureBoxMain.Name = "pictureBoxMain";
            this.pictureBoxMain.Size = new System.Drawing.Size(305, 247);
            this.pictureBoxMain.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.pictureBoxMain.TabIndex = 0;
            this.pictureBoxMain.TabStop = false;
            this.pictureBoxMain.MouseMove += new System.Windows.Forms.MouseEventHandler(this.pictureBoxMain_MouseMove);
            this.pictureBoxMain.MouseDown += new System.Windows.Forms.MouseEventHandler(this.pictureBoxMain_MouseDown);
            this.pictureBoxMain.Paint += new System.Windows.Forms.PaintEventHandler(this.pictureBoxMain_Paint);
            this.pictureBoxMain.MouseUp += new System.Windows.Forms.MouseEventHandler(this.pictureBoxMain_MouseUp);
            // 
            // closeButton
            // 
            this.closeButton.Location = new System.Drawing.Point(332, 236);
            this.closeButton.Name = "closeButton";
            this.closeButton.Size = new System.Drawing.Size(86, 23);
            this.closeButton.TabIndex = 1;
            this.closeButton.Text = "Выход";
            this.closeButton.UseVisualStyleBackColor = true;
            this.closeButton.Click += new System.EventHandler(this.closeButton_Click);
            // 
            // openButton
            // 
            this.openButton.Location = new System.Drawing.Point(332, 12);
            this.openButton.Name = "openButton";
            this.openButton.Size = new System.Drawing.Size(86, 23);
            this.openButton.TabIndex = 2;
            this.openButton.Text = "Открыть";
            this.openButton.UseVisualStyleBackColor = true;
            this.openButton.Click += new System.EventHandler(this.openButton_Click);
            // 
            // openFileDialog
            // 
            this.openFileDialog.DefaultExt = "bmp";
            this.openFileDialog.Filter = "All files|*.*|Bitmap|*.bmp";
            // 
            // dbButton
            // 
            this.dbButton.Location = new System.Drawing.Point(332, 164);
            this.dbButton.Name = "dbButton";
            this.dbButton.Size = new System.Drawing.Size(86, 23);
            this.dbButton.TabIndex = 4;
            this.dbButton.Text = "База данных";
            this.dbButton.UseVisualStyleBackColor = true;
            this.dbButton.Click += new System.EventHandler(this.dbButton_Click);
            // 
            // startButton
            // 
            this.startButton.Location = new System.Drawing.Point(332, 98);
            this.startButton.Name = "startButton";
            this.startButton.Size = new System.Drawing.Size(86, 25);
            this.startButton.TabIndex = 9;
            this.startButton.Text = "Распознать";
            this.startButton.UseVisualStyleBackColor = true;
            this.startButton.Click += new System.EventHandler(this.startButton_Click_1);
            // 
            // radioButton1D
            // 
            this.radioButton1D.AutoSize = true;
            this.radioButton1D.Checked = true;
            this.radioButton1D.Location = new System.Drawing.Point(332, 41);
            this.radioButton1D.Name = "radioButton1D";
            this.radioButton1D.Size = new System.Drawing.Size(39, 17);
            this.radioButton1D.TabIndex = 10;
            this.radioButton1D.TabStop = true;
            this.radioButton1D.Text = "1D";
            this.radioButton1D.UseVisualStyleBackColor = true;
            // 
            // radioButton2D
            // 
            this.radioButton2D.AutoSize = true;
            this.radioButton2D.Location = new System.Drawing.Point(332, 71);
            this.radioButton2D.Name = "radioButton2D";
            this.radioButton2D.Size = new System.Drawing.Size(39, 17);
            this.radioButton2D.TabIndex = 11;
            this.radioButton2D.Text = "2D";
            this.radioButton2D.UseVisualStyleBackColor = true;
            // 
            // graphButton
            // 
            this.graphButton.Location = new System.Drawing.Point(332, 193);
            this.graphButton.Name = "graphButton";
            this.graphButton.Size = new System.Drawing.Size(86, 23);
            this.graphButton.TabIndex = 8;
            this.graphButton.Text = "График";
            this.graphButton.UseVisualStyleBackColor = true;
            this.graphButton.Click += new System.EventHandler(this.graphButton_Click);
            // 
            // MainForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(447, 277);
            this.Controls.Add(this.radioButton2D);
            this.Controls.Add(this.radioButton1D);
            this.Controls.Add(this.startButton);
            this.Controls.Add(this.graphButton);
            this.Controls.Add(this.dbButton);
            this.Controls.Add(this.openButton);
            this.Controls.Add(this.closeButton);
            this.Controls.Add(this.pictureBoxMain);
            this.Name = "MainForm";
            this.Text = "Курсовой проект, Хоружий С.В., Труш А.С.";
            ((System.ComponentModel.ISupportInitialize)(this.pictureBoxMain)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.PictureBox pictureBoxMain;
        private System.Windows.Forms.Button closeButton;
        private System.Windows.Forms.Button openButton;
        private System.Windows.Forms.OpenFileDialog openFileDialog;
        private System.Windows.Forms.Button dbButton;
        private System.Windows.Forms.Button startButton;
        private System.Windows.Forms.RadioButton radioButton1D;
        private System.Windows.Forms.RadioButton radioButton2D;
        private System.Windows.Forms.Button graphButton;
    }
}

