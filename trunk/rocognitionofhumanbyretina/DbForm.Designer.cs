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
            this.dataGridView1 = new System.Windows.Forms.DataGridView();
            this.idDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.firstNameDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.secondNameDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.figureCorneaDataGridViewImageColumn = new System.Windows.Forms.DataGridViewImageColumn();
            this.figureDeployedCorneaDataGridViewImageColumn = new System.Windows.Forms.DataGridViewImageColumn();
            this.tokenOneDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.tokenTwoDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.testBindingSource = new System.Windows.Forms.BindingSource(this.components);
            this.database1DataSet = new rocognitionofhumanbyretina.Database1DataSet();
            this.database1DataSetBindingSource = new System.Windows.Forms.BindingSource(this.components);
            this.testTableAdapter = new rocognitionofhumanbyretina.Database1DataSetTableAdapters.testTableAdapter();
            this.tableAdapterManager = new rocognitionofhumanbyretina.Database1DataSetTableAdapters.TableAdapterManager();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.testBindingSource)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.database1DataSet)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.database1DataSetBindingSource)).BeginInit();
            this.SuspendLayout();
            // 
            // closeButton
            // 
            this.closeButton.Location = new System.Drawing.Point(681, 383);
            this.closeButton.Name = "closeButton";
            this.closeButton.Size = new System.Drawing.Size(75, 23);
            this.closeButton.TabIndex = 1;
            this.closeButton.Text = "Close";
            this.closeButton.UseVisualStyleBackColor = true;
            this.closeButton.Click += new System.EventHandler(this.closeButton_Click);
            // 
            // dataGridView1
            // 
            this.dataGridView1.AutoGenerateColumns = false;
            this.dataGridView1.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dataGridView1.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.idDataGridViewTextBoxColumn,
            this.firstNameDataGridViewTextBoxColumn,
            this.secondNameDataGridViewTextBoxColumn,
            this.figureCorneaDataGridViewImageColumn,
            this.figureDeployedCorneaDataGridViewImageColumn,
            this.tokenOneDataGridViewTextBoxColumn,
            this.tokenTwoDataGridViewTextBoxColumn});
            this.dataGridView1.DataSource = this.testBindingSource;
            this.dataGridView1.Location = new System.Drawing.Point(12, 12);
            this.dataGridView1.Name = "dataGridView1";
            this.dataGridView1.Size = new System.Drawing.Size(744, 150);
            this.dataGridView1.TabIndex = 2;
            // 
            // idDataGridViewTextBoxColumn
            // 
            this.idDataGridViewTextBoxColumn.DataPropertyName = "id";
            this.idDataGridViewTextBoxColumn.HeaderText = "id";
            this.idDataGridViewTextBoxColumn.Name = "idDataGridViewTextBoxColumn";
            // 
            // firstNameDataGridViewTextBoxColumn
            // 
            this.firstNameDataGridViewTextBoxColumn.DataPropertyName = "firstName";
            this.firstNameDataGridViewTextBoxColumn.HeaderText = "firstName";
            this.firstNameDataGridViewTextBoxColumn.Name = "firstNameDataGridViewTextBoxColumn";
            // 
            // secondNameDataGridViewTextBoxColumn
            // 
            this.secondNameDataGridViewTextBoxColumn.DataPropertyName = "secondName";
            this.secondNameDataGridViewTextBoxColumn.HeaderText = "secondName";
            this.secondNameDataGridViewTextBoxColumn.Name = "secondNameDataGridViewTextBoxColumn";
            // 
            // figureCorneaDataGridViewImageColumn
            // 
            this.figureCorneaDataGridViewImageColumn.DataPropertyName = "figureCornea";
            this.figureCorneaDataGridViewImageColumn.HeaderText = "figureCornea";
            this.figureCorneaDataGridViewImageColumn.Name = "figureCorneaDataGridViewImageColumn";
            // 
            // figureDeployedCorneaDataGridViewImageColumn
            // 
            this.figureDeployedCorneaDataGridViewImageColumn.DataPropertyName = "figureDeployedCornea";
            this.figureDeployedCorneaDataGridViewImageColumn.HeaderText = "figureDeployedCornea";
            this.figureDeployedCorneaDataGridViewImageColumn.Name = "figureDeployedCorneaDataGridViewImageColumn";
            // 
            // tokenOneDataGridViewTextBoxColumn
            // 
            this.tokenOneDataGridViewTextBoxColumn.DataPropertyName = "tokenOne";
            this.tokenOneDataGridViewTextBoxColumn.HeaderText = "tokenOne";
            this.tokenOneDataGridViewTextBoxColumn.Name = "tokenOneDataGridViewTextBoxColumn";
            // 
            // tokenTwoDataGridViewTextBoxColumn
            // 
            this.tokenTwoDataGridViewTextBoxColumn.DataPropertyName = "tokenTwo";
            this.tokenTwoDataGridViewTextBoxColumn.HeaderText = "tokenTwo";
            this.tokenTwoDataGridViewTextBoxColumn.Name = "tokenTwoDataGridViewTextBoxColumn";
            // 
            // testBindingSource
            // 
            this.testBindingSource.DataMember = "test";
            this.testBindingSource.DataSource = this.database1DataSet;
            // 
            // database1DataSet
            // 
            this.database1DataSet.DataSetName = "Database1DataSet";
            this.database1DataSet.SchemaSerializationMode = System.Data.SchemaSerializationMode.IncludeSchema;
            // 
            // database1DataSetBindingSource
            // 
            this.database1DataSetBindingSource.DataSource = this.database1DataSet;
            this.database1DataSetBindingSource.Position = 0;
            // 
            // testTableAdapter
            // 
            this.testTableAdapter.ClearBeforeFill = true;
            // 
            // tableAdapterManager
            // 
            this.tableAdapterManager.BackupDataSetBeforeUpdate = false;
            this.tableAdapterManager.testTableAdapter = this.testTableAdapter;
            this.tableAdapterManager.UpdateOrder = rocognitionofhumanbyretina.Database1DataSetTableAdapters.TableAdapterManager.UpdateOrderOption.InsertUpdateDelete;
            // 
            // DbForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(770, 415);
            this.Controls.Add(this.dataGridView1);
            this.Controls.Add(this.closeButton);
            this.Name = "DbForm";
            this.Text = "FormDb";
            this.Load += new System.EventHandler(this.DbForm_Load);
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.testBindingSource)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.database1DataSet)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.database1DataSetBindingSource)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private Database1DataSet database1DataSet;
        private System.Windows.Forms.Button closeButton;
        private System.Windows.Forms.DataGridView dataGridView1;
        private System.Windows.Forms.BindingSource database1DataSetBindingSource;
        private System.Windows.Forms.BindingSource testBindingSource;
        private rocognitionofhumanbyretina.Database1DataSetTableAdapters.testTableAdapter testTableAdapter;
        private rocognitionofhumanbyretina.Database1DataSetTableAdapters.TableAdapterManager tableAdapterManager;
        private System.Windows.Forms.DataGridViewTextBoxColumn idDataGridViewTextBoxColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn firstNameDataGridViewTextBoxColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn secondNameDataGridViewTextBoxColumn;
        private System.Windows.Forms.DataGridViewImageColumn figureCorneaDataGridViewImageColumn;
        private System.Windows.Forms.DataGridViewImageColumn figureDeployedCorneaDataGridViewImageColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn tokenOneDataGridViewTextBoxColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn tokenTwoDataGridViewTextBoxColumn;
    }
}