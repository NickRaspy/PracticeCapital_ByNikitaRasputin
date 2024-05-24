namespace PracticeCapital_ByNikitaRasputin
{
    partial class AddRemoveColumns
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
            this.completeButton = new System.Windows.Forms.Button();
            this.deleteButton = new System.Windows.Forms.Button();
            this.columnNamesTable = new System.Windows.Forms.DataGridView();
            this.columnName = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.columnType = new System.Windows.Forms.DataGridViewComboBoxColumn();
            ((System.ComponentModel.ISupportInitialize)(this.columnNamesTable)).BeginInit();
            this.SuspendLayout();
            // 
            // completeButton
            // 
            this.completeButton.Location = new System.Drawing.Point(143, 143);
            this.completeButton.Name = "completeButton";
            this.completeButton.Size = new System.Drawing.Size(75, 23);
            this.completeButton.TabIndex = 4;
            this.completeButton.Text = "Готово";
            this.completeButton.UseVisualStyleBackColor = true;
            this.completeButton.Click += new System.EventHandler(this.completeButton_Click);
            // 
            // deleteButton
            // 
            this.deleteButton.Location = new System.Drawing.Point(12, 143);
            this.deleteButton.Name = "deleteButton";
            this.deleteButton.Size = new System.Drawing.Size(75, 23);
            this.deleteButton.TabIndex = 5;
            this.deleteButton.Text = "Удалить";
            this.deleteButton.UseVisualStyleBackColor = true;
            this.deleteButton.Click += new System.EventHandler(this.deleteButton_Click);
            // 
            // columnNamesTable
            // 
            this.columnNamesTable.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.columnNamesTable.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.columnName,
            this.columnType});
            this.columnNamesTable.Location = new System.Drawing.Point(12, 12);
            this.columnNamesTable.Name = "columnNamesTable";
            this.columnNamesTable.RowHeadersVisible = false;
            this.columnNamesTable.Size = new System.Drawing.Size(206, 125);
            this.columnNamesTable.TabIndex = 6;
            this.columnNamesTable.KeyDown += new System.Windows.Forms.KeyEventHandler(this.columnNamesTable_KeyDown);
            // 
            // columnName
            // 
            this.columnName.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.Fill;
            this.columnName.HeaderText = "Название столбца";
            this.columnName.Name = "columnName";
            // 
            // columnType
            // 
            this.columnType.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.Fill;
            this.columnType.HeaderText = "Тип данных";
            this.columnType.Items.AddRange(new object[] {
            "Текстовый",
            "Числовой"});
            this.columnType.Name = "columnType";
            // 
            // AddRemoveColumns
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(224, 171);
            this.Controls.Add(this.columnNamesTable);
            this.Controls.Add(this.deleteButton);
            this.Controls.Add(this.completeButton);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog;
            this.MaximizeBox = false;
            this.Name = "AddRemoveColumns";
            this.Text = "Добавить/удалить столбцы данных";
            this.FormClosed += new System.Windows.Forms.FormClosedEventHandler(this.AddRemoveColumns_FormClosed);
            this.Load += new System.EventHandler(this.AddRemoveColumns_Load);
            ((System.ComponentModel.ISupportInitialize)(this.columnNamesTable)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion
        private System.Windows.Forms.Button completeButton;
        private System.Windows.Forms.Button deleteButton;
        private System.Windows.Forms.DataGridView columnNamesTable;
        private System.Windows.Forms.DataGridViewTextBoxColumn columnName;
        private System.Windows.Forms.DataGridViewComboBoxColumn columnType;
    }
}