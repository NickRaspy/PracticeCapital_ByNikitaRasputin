namespace PracticeCapital_ByNikitaRasputin
{
    partial class Form1
    {
        /// <summary>
        /// Обязательная переменная конструктора.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Освободить все используемые ресурсы.
        /// </summary>
        /// <param name="disposing">истинно, если управляемый ресурс должен быть удален; иначе ложно.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Код, автоматически созданный конструктором форм Windows

        /// <summary>
        /// Требуемый метод для поддержки конструктора — не изменяйте 
        /// содержимое этого метода с помощью редактора кода.
        /// </summary>
        private void InitializeComponent()
        {
            this.dataGridView1 = new System.Windows.Forms.DataGridView();
            this.tableButton = new System.Windows.Forms.Button();
            this.secondaryTableButton = new System.Windows.Forms.Button();
            this.webDataButton = new System.Windows.Forms.Button();
            this.dataSaveButton = new System.Windows.Forms.Button();
            this.analysisButton = new System.Windows.Forms.Button();
            this.columnClearButton = new System.Windows.Forms.Button();
            this.columnBox = new System.Windows.Forms.ComboBox();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView1)).BeginInit();
            this.SuspendLayout();
            // 
            // dataGridView1
            // 
            this.dataGridView1.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dataGridView1.Location = new System.Drawing.Point(12, 12);
            this.dataGridView1.Name = "dataGridView1";
            this.dataGridView1.Size = new System.Drawing.Size(591, 498);
            this.dataGridView1.TabIndex = 0;
            // 
            // tableButton
            // 
            this.tableButton.Location = new System.Drawing.Point(624, 12);
            this.tableButton.Name = "tableButton";
            this.tableButton.Size = new System.Drawing.Size(132, 53);
            this.tableButton.TabIndex = 1;
            this.tableButton.Text = "Подключить редактируемую таблицу";
            this.tableButton.UseVisualStyleBackColor = true;
            this.tableButton.Click += new System.EventHandler(this.tableButton_Click);
            // 
            // secondaryTableButton
            // 
            this.secondaryTableButton.Enabled = false;
            this.secondaryTableButton.Location = new System.Drawing.Point(624, 71);
            this.secondaryTableButton.Name = "secondaryTableButton";
            this.secondaryTableButton.Size = new System.Drawing.Size(132, 53);
            this.secondaryTableButton.TabIndex = 2;
            this.secondaryTableButton.Text = "Добавить данные из внешей таблицы";
            this.secondaryTableButton.UseVisualStyleBackColor = true;
            this.secondaryTableButton.Click += new System.EventHandler(this.secondaryTableButton_Click);
            // 
            // webDataButton
            // 
            this.webDataButton.Enabled = false;
            this.webDataButton.Location = new System.Drawing.Point(624, 130);
            this.webDataButton.Name = "webDataButton";
            this.webDataButton.Size = new System.Drawing.Size(132, 48);
            this.webDataButton.TabIndex = 3;
            this.webDataButton.Text = "Добавить данные из внешних источников";
            this.webDataButton.UseVisualStyleBackColor = true;
            this.webDataButton.Click += new System.EventHandler(this.button1_Click);
            // 
            // dataSaveButton
            // 
            this.dataSaveButton.Enabled = false;
            this.dataSaveButton.Location = new System.Drawing.Point(624, 457);
            this.dataSaveButton.Name = "dataSaveButton";
            this.dataSaveButton.Size = new System.Drawing.Size(132, 53);
            this.dataSaveButton.TabIndex = 4;
            this.dataSaveButton.Text = "Сохранить данные в таблицу\r\n";
            this.dataSaveButton.UseVisualStyleBackColor = true;
            this.dataSaveButton.Click += new System.EventHandler(this.button1_Click_1);
            // 
            // analysisButton
            // 
            this.analysisButton.Enabled = false;
            this.analysisButton.Location = new System.Drawing.Point(624, 301);
            this.analysisButton.Name = "analysisButton";
            this.analysisButton.Size = new System.Drawing.Size(132, 48);
            this.analysisButton.TabIndex = 5;
            this.analysisButton.Text = "Анализ данных";
            this.analysisButton.UseVisualStyleBackColor = true;
            this.analysisButton.Click += new System.EventHandler(this.analysisButton_Click);
            // 
            // columnClearButton
            // 
            this.columnClearButton.Enabled = false;
            this.columnClearButton.Location = new System.Drawing.Point(624, 259);
            this.columnClearButton.Name = "columnClearButton";
            this.columnClearButton.Size = new System.Drawing.Size(132, 36);
            this.columnClearButton.TabIndex = 6;
            this.columnClearButton.Text = "Очистить цвета столбца";
            this.columnClearButton.UseVisualStyleBackColor = true;
            this.columnClearButton.Click += new System.EventHandler(this.columnClearButton_Click);
            // 
            // columnBox
            // 
            this.columnBox.FormattingEnabled = true;
            this.columnBox.Location = new System.Drawing.Point(624, 232);
            this.columnBox.Name = "columnBox";
            this.columnBox.Size = new System.Drawing.Size(132, 21);
            this.columnBox.TabIndex = 7;
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(768, 522);
            this.Controls.Add(this.columnBox);
            this.Controls.Add(this.columnClearButton);
            this.Controls.Add(this.analysisButton);
            this.Controls.Add(this.dataSaveButton);
            this.Controls.Add(this.webDataButton);
            this.Controls.Add(this.secondaryTableButton);
            this.Controls.Add(this.tableButton);
            this.Controls.Add(this.dataGridView1);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.MaximizeBox = false;
            this.Name = "Form1";
            this.Text = "Сбор данных об контрагентах и их анализ";
            this.Load += new System.EventHandler(this.Form1_Load);
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView1)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion
        private System.Windows.Forms.Button tableButton;
        public System.Windows.Forms.DataGridView dataGridView1;
        public System.Windows.Forms.Button secondaryTableButton;
        public System.Windows.Forms.Button webDataButton;
        public System.Windows.Forms.Button dataSaveButton;
        public System.Windows.Forms.Button analysisButton;
        public System.Windows.Forms.Button columnClearButton;
        private System.Windows.Forms.ComboBox columnBox;
    }
}

