namespace rocognitionofhumanbyretina
{
    partial class DbForm
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
            this.components = new System.ComponentModel.Container();
            this.closeButton = new System.Windows.Forms.Button();
            this.testBindingSource = new System.Windows.Forms.BindingSource(this.components);
            this.database1DataSetBindingSource = new System.Windows.Forms.BindingSource(this.components);
            this.dataGridView2 = new System.Windows.Forms.DataGridView();
            this.Имя = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Фамилия = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Отчество = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Показать_глаза = new System.Windows.Forms.DataGridViewButtonColumn();
            this.listView1 = new System.Windows.Forms.ListView();
            this.listView2 = new System.Windows.Forms.ListView();
            this.label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.tabControl1 = new System.Windows.Forms.TabControl();
            this.tabPage1 = new System.Windows.Forms.TabPage();
            this.button1 = new System.Windows.Forms.Button();
            this.textBox3 = new System.Windows.Forms.TextBox();
            this.label5 = new System.Windows.Forms.Label();
            this.textBox2 = new System.Windows.Forms.TextBox();
            this.label4 = new System.Windows.Forms.Label();
            this.textBox1 = new System.Windows.Forms.TextBox();
            this.label3 = new System.Windows.Forms.Label();
            this.tabPage2 = new System.Windows.Forms.TabPage();
            this.button2 = new System.Windows.Forms.Button();
            this.comboBox2 = new System.Windows.Forms.ComboBox();
            this.label8 = new System.Windows.Forms.Label();
            this.comboBox1 = new System.Windows.Forms.ComboBox();
            this.radioButton2 = new System.Windows.Forms.RadioButton();
            this.radioButton1 = new System.Windows.Forms.RadioButton();
            this.label7 = new System.Windows.Forms.Label();
            this.pictureBox2 = new System.Windows.Forms.PictureBox();
            this.label6 = new System.Windows.Forms.Label();
            this.pictureBox1 = new System.Windows.Forms.PictureBox();
            this.peopleDBDataSet = new rocognitionofhumanbyretina.resources.PeopleDBDataSet();
            this.humanBindingSource = new System.Windows.Forms.BindingSource(this.components);
            this.openFileDialog1 = new System.Windows.Forms.OpenFileDialog();
            this.listView3 = new System.Windows.Forms.ListView();
            this.label9 = new System.Windows.Forms.Label();
            this.Column1 = new System.Windows.Forms.DataGridViewButtonColumn();
            ((System.ComponentModel.ISupportInitialize)(this.testBindingSource)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.database1DataSetBindingSource)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView2)).BeginInit();
            this.groupBox1.SuspendLayout();
            this.tabControl1.SuspendLayout();
            this.tabPage1.SuspendLayout();
            this.tabPage2.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox2)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.peopleDBDataSet)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.humanBindingSource)).BeginInit();
            this.SuspendLayout();
            // 
            // closeButton
            // 
            this.closeButton.Location = new System.Drawing.Point(12, 529);
            this.closeButton.Name = "closeButton";
            this.closeButton.Size = new System.Drawing.Size(75, 23);
            this.closeButton.TabIndex = 1;
            this.closeButton.Text = "Закрыть";
            this.closeButton.UseVisualStyleBackColor = true;
            this.closeButton.Click += new System.EventHandler(this.closeButton_Click);
            // 
            // dataGridView2
            // 
            this.dataGridView2.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dataGridView2.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.Имя,
            this.Фамилия,
            this.Отчество,
            this.Показать_глаза,
            this.Column1});
            this.dataGridView2.Location = new System.Drawing.Point(12, 28);
            this.dataGridView2.Name = "dataGridView2";
            this.dataGridView2.Size = new System.Drawing.Size(547, 277);
            this.dataGridView2.TabIndex = 4;
            this.dataGridView2.CellContentClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.dataGridView2_CellContentClick);
            // 
            // Имя
            // 
            this.Имя.HeaderText = "Имя";
            this.Имя.Name = "Имя";
            // 
            // Фамилия
            // 
            this.Фамилия.HeaderText = "Фамилия";
            this.Фамилия.Name = "Фамилия";
            // 
            // Отчество
            // 
            this.Отчество.HeaderText = "Отчество";
            this.Отчество.Name = "Отчество";
            // 
            // Показать_глаза
            // 
            this.Показать_глаза.HeaderText = "Показать изображения глаз";
            this.Показать_глаза.Name = "Показать_глаза";
            // 
            // listView1
            // 
            this.listView1.Location = new System.Drawing.Point(590, 28);
            this.listView1.Name = "listView1";
            this.listView1.Size = new System.Drawing.Size(311, 122);
            this.listView1.TabIndex = 5;
            this.listView1.UseCompatibleStateImageBehavior = false;
            // 
            // listView2
            // 
            this.listView2.Location = new System.Drawing.Point(590, 177);
            this.listView2.Name = "listView2";
            this.listView2.Size = new System.Drawing.Size(311, 128);
            this.listView2.TabIndex = 6;
            this.listView2.UseCompatibleStateImageBehavior = false;
            this.listView2.SelectedIndexChanged += new System.EventHandler(this.listView2_SelectedIndexChanged);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(587, 12);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(37, 13);
            this.label1.TabIndex = 7;
            this.label1.Text = "Глаза";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(587, 161);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(54, 13);
            this.label2.TabIndex = 8;
            this.label2.Text = "Шаблоны";
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.tabControl1);
            this.groupBox1.Location = new System.Drawing.Point(12, 311);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(311, 219);
            this.groupBox1.TabIndex = 0;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "Добавление записи:";
            // 
            // tabControl1
            // 
            this.tabControl1.Controls.Add(this.tabPage1);
            this.tabControl1.Controls.Add(this.tabPage2);
            this.tabControl1.Location = new System.Drawing.Point(6, 19);
            this.tabControl1.Name = "tabControl1";
            this.tabControl1.SelectedIndex = 0;
            this.tabControl1.Size = new System.Drawing.Size(299, 194);
            this.tabControl1.TabIndex = 0;
            // 
            // tabPage1
            // 
            this.tabPage1.Controls.Add(this.button1);
            this.tabPage1.Controls.Add(this.textBox3);
            this.tabPage1.Controls.Add(this.label5);
            this.tabPage1.Controls.Add(this.textBox2);
            this.tabPage1.Controls.Add(this.label4);
            this.tabPage1.Controls.Add(this.textBox1);
            this.tabPage1.Controls.Add(this.label3);
            this.tabPage1.Location = new System.Drawing.Point(4, 22);
            this.tabPage1.Name = "tabPage1";
            this.tabPage1.Padding = new System.Windows.Forms.Padding(3);
            this.tabPage1.Size = new System.Drawing.Size(291, 168);
            this.tabPage1.TabIndex = 0;
            this.tabPage1.Text = "Человек";
            this.tabPage1.UseVisualStyleBackColor = true;
            // 
            // button1
            // 
            this.button1.Location = new System.Drawing.Point(9, 141);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(75, 23);
            this.button1.TabIndex = 6;
            this.button1.Text = "Добавить";
            this.button1.UseVisualStyleBackColor = true;
            this.button1.Click += new System.EventHandler(this.button1_Click);
            // 
            // textBox3
            // 
            this.textBox3.Location = new System.Drawing.Point(9, 115);
            this.textBox3.Name = "textBox3";
            this.textBox3.Size = new System.Drawing.Size(100, 20);
            this.textBox3.TabIndex = 5;
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(6, 99);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(54, 13);
            this.label5.TabIndex = 4;
            this.label5.Text = "Отчество";
            // 
            // textBox2
            // 
            this.textBox2.Location = new System.Drawing.Point(9, 72);
            this.textBox2.Name = "textBox2";
            this.textBox2.Size = new System.Drawing.Size(100, 20);
            this.textBox2.TabIndex = 3;
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(6, 56);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(56, 13);
            this.label4.TabIndex = 2;
            this.label4.Text = "Фамилия";
            // 
            // textBox1
            // 
            this.textBox1.Location = new System.Drawing.Point(9, 30);
            this.textBox1.Name = "textBox1";
            this.textBox1.Size = new System.Drawing.Size(100, 20);
            this.textBox1.TabIndex = 1;
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(6, 14);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(29, 13);
            this.label3.TabIndex = 0;
            this.label3.Text = "Имя";
            // 
            // tabPage2
            // 
            this.tabPage2.Controls.Add(this.button2);
            this.tabPage2.Controls.Add(this.comboBox2);
            this.tabPage2.Controls.Add(this.label8);
            this.tabPage2.Controls.Add(this.comboBox1);
            this.tabPage2.Controls.Add(this.radioButton2);
            this.tabPage2.Controls.Add(this.radioButton1);
            this.tabPage2.Controls.Add(this.label7);
            this.tabPage2.Controls.Add(this.pictureBox2);
            this.tabPage2.Controls.Add(this.label6);
            this.tabPage2.Controls.Add(this.pictureBox1);
            this.tabPage2.Location = new System.Drawing.Point(4, 22);
            this.tabPage2.Name = "tabPage2";
            this.tabPage2.Padding = new System.Windows.Forms.Padding(3);
            this.tabPage2.Size = new System.Drawing.Size(291, 168);
            this.tabPage2.TabIndex = 1;
            this.tabPage2.Text = "Изображения и признаки";
            this.tabPage2.UseVisualStyleBackColor = true;
            // 
            // button2
            // 
            this.button2.Location = new System.Drawing.Point(20, 139);
            this.button2.Name = "button2";
            this.button2.Size = new System.Drawing.Size(75, 23);
            this.button2.TabIndex = 9;
            this.button2.Text = "Добавить";
            this.button2.UseVisualStyleBackColor = true;
            this.button2.Click += new System.EventHandler(this.button2_Click);
            // 
            // comboBox2
            // 
            this.comboBox2.FormattingEnabled = true;
            this.comboBox2.Location = new System.Drawing.Point(77, 101);
            this.comboBox2.Name = "comboBox2";
            this.comboBox2.Size = new System.Drawing.Size(109, 21);
            this.comboBox2.TabIndex = 8;
            this.comboBox2.SelectedIndexChanged += new System.EventHandler(this.comboBox2_SelectedIndexChanged);
            // 
            // label8
            // 
            this.label8.AutoSize = true;
            this.label8.Location = new System.Drawing.Point(17, 82);
            this.label8.Name = "label8";
            this.label8.Size = new System.Drawing.Size(54, 13);
            this.label8.TabIndex = 7;
            this.label8.Text = "Человек:";
            // 
            // comboBox1
            // 
            this.comboBox1.FormattingEnabled = true;
            this.comboBox1.Location = new System.Drawing.Point(20, 101);
            this.comboBox1.Name = "comboBox1";
            this.comboBox1.Size = new System.Drawing.Size(51, 21);
            this.comboBox1.TabIndex = 6;
            this.comboBox1.SelectedIndexChanged += new System.EventHandler(this.comboBox1_SelectedIndexChanged);
            // 
            // radioButton2
            // 
            this.radioButton2.AutoSize = true;
            this.radioButton2.Location = new System.Drawing.Point(20, 43);
            this.radioButton2.Name = "radioButton2";
            this.radioButton2.Size = new System.Drawing.Size(91, 17);
            this.radioButton2.TabIndex = 5;
            this.radioButton2.Text = "Правый глаз";
            this.radioButton2.UseVisualStyleBackColor = true;
            // 
            // radioButton1
            // 
            this.radioButton1.AutoSize = true;
            this.radioButton1.Checked = true;
            this.radioButton1.Location = new System.Drawing.Point(20, 20);
            this.radioButton1.Name = "radioButton1";
            this.radioButton1.Size = new System.Drawing.Size(85, 17);
            this.radioButton1.TabIndex = 4;
            this.radioButton1.TabStop = true;
            this.radioButton1.Text = "Левый глаз";
            this.radioButton1.UseVisualStyleBackColor = true;
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.Location = new System.Drawing.Point(189, 85);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(46, 13);
            this.label7.TabIndex = 3;
            this.label7.Text = "Шаблон";
            // 
            // pictureBox2
            // 
            this.pictureBox2.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.pictureBox2.Location = new System.Drawing.Point(192, 101);
            this.pictureBox2.Name = "pictureBox2";
            this.pictureBox2.Size = new System.Drawing.Size(73, 61);
            this.pictureBox2.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.pictureBox2.TabIndex = 2;
            this.pictureBox2.TabStop = false;
            this.pictureBox2.Click += new System.EventHandler(this.pictureBox2_Click);
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Location = new System.Drawing.Point(189, 4);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(31, 13);
            this.label6.TabIndex = 1;
            this.label6.Text = "Глаз";
            // 
            // pictureBox1
            // 
            this.pictureBox1.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.pictureBox1.Location = new System.Drawing.Point(192, 20);
            this.pictureBox1.Name = "pictureBox1";
            this.pictureBox1.Size = new System.Drawing.Size(73, 61);
            this.pictureBox1.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.pictureBox1.TabIndex = 0;
            this.pictureBox1.TabStop = false;
            this.pictureBox1.Click += new System.EventHandler(this.pictureBox1_Click);
            // 
            // peopleDBDataSet
            // 
            this.peopleDBDataSet.DataSetName = "PeopleDBDataSet";
            this.peopleDBDataSet.SchemaSerializationMode = System.Data.SchemaSerializationMode.IncludeSchema;
            // 
            // humanBindingSource
            // 
            this.humanBindingSource.DataMember = "Human";
            this.humanBindingSource.DataSource = this.peopleDBDataSet;
            // 
            // openFileDialog1
            // 
            this.openFileDialog1.FileName = "openFileDialog1";
            // 
            // listView3
            // 
            this.listView3.Location = new System.Drawing.Point(590, 330);
            this.listView3.Name = "listView3";
            this.listView3.Size = new System.Drawing.Size(311, 181);
            this.listView3.TabIndex = 9;
            this.listView3.UseCompatibleStateImageBehavior = false;
            // 
            // label9
            // 
            this.label9.AutoSize = true;
            this.label9.Location = new System.Drawing.Point(587, 314);
            this.label9.Name = "label9";
            this.label9.Size = new System.Drawing.Size(90, 13);
            this.label9.TabIndex = 10;
            this.label9.Text = "Коды по Габору:";
            // 
            // Column1
            // 
            this.Column1.HeaderText = "Удалить запись вместе с изображениями";
            this.Column1.Name = "Column1";
            // 
            // DbForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1086, 552);
            this.Controls.Add(this.label9);
            this.Controls.Add(this.listView3);
            this.Controls.Add(this.groupBox1);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.listView2);
            this.Controls.Add(this.listView1);
            this.Controls.Add(this.dataGridView2);
            this.Controls.Add(this.closeButton);
            this.Name = "DbForm";
            this.Text = "FormDb";
            this.Load += new System.EventHandler(this.DbForm_Load);
            ((System.ComponentModel.ISupportInitialize)(this.testBindingSource)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.database1DataSetBindingSource)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView2)).EndInit();
            this.groupBox1.ResumeLayout(false);
            this.tabControl1.ResumeLayout(false);
            this.tabPage1.ResumeLayout(false);
            this.tabPage1.PerformLayout();
            this.tabPage2.ResumeLayout(false);
            this.tabPage2.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox2)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.peopleDBDataSet)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.humanBindingSource)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

     //   private Database1DataSet database1DataSet;
        private System.Windows.Forms.Button closeButton;
        private System.Windows.Forms.BindingSource database1DataSetBindingSource;
        private System.Windows.Forms.BindingSource testBindingSource;
     //   private rocognitionofhumanbyretina.Database1DataSetTableAdapters.testTableAdapter testTableAdapter;
        //   private rocognitionofhumanbyretina.Database1DataSetTableAdapters.TableAdapterManager tableAdapterManager;
        private System.Windows.Forms.DataGridView dataGridView2;
        private System.Windows.Forms.ListView listView1;
        private System.Windows.Forms.ListView listView2;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.DataGridViewTextBoxColumn Имя;
        private System.Windows.Forms.DataGridViewTextBoxColumn Фамилия;
        private System.Windows.Forms.DataGridViewTextBoxColumn Отчество;
        private System.Windows.Forms.DataGridViewButtonColumn Показать_глаза;
        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.TabControl tabControl1;
        private System.Windows.Forms.TabPage tabPage1;
        private System.Windows.Forms.Button button1;
        private System.Windows.Forms.TextBox textBox3;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.TextBox textBox2;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.TextBox textBox1;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.TabPage tabPage2;
        private System.Windows.Forms.Label label8;
        private System.Windows.Forms.ComboBox comboBox1;
        private System.Windows.Forms.BindingSource humanBindingSource;
        private rocognitionofhumanbyretina.resources.PeopleDBDataSet peopleDBDataSet;
        private System.Windows.Forms.RadioButton radioButton2;
        private System.Windows.Forms.RadioButton radioButton1;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.PictureBox pictureBox2;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.PictureBox pictureBox1;
        private System.Windows.Forms.ComboBox comboBox2;
        private System.Windows.Forms.Button button2;
        private System.Windows.Forms.OpenFileDialog openFileDialog1;
        private System.Windows.Forms.ListView listView3;
        private System.Windows.Forms.Label label9;
        private System.Windows.Forms.DataGridViewButtonColumn Column1;
    }
}