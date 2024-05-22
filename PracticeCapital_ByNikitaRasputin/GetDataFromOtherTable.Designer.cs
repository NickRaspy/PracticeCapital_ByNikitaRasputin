namespace PracticeCapital_ByNikitaRasputin
{
    partial class GetDataFromOtherTable
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
            this.sheetNumBox = new System.Windows.Forms.NumericUpDown();
            this.indentsNumeric = new System.Windows.Forms.NumericUpDown();
            this.label1 = new System.Windows.Forms.Label();
            this.searchButton = new System.Windows.Forms.Button();
            this.searchBox = new System.Windows.Forms.TextBox();
            this.openFileDialog1 = new System.Windows.Forms.OpenFileDialog();
            this.getTableButton = new System.Windows.Forms.Button();
            this.finalButton = new System.Windows.Forms.Button();
            this.dataGridView1 = new System.Windows.Forms.DataGridView();
            this.table_redact = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.table_add = new System.Windows.Forms.DataGridViewComboBoxColumn();
            this.groupCheckBox = new System.Windows.Forms.CheckBox();
            this.fillTypeCombo = new System.Windows.Forms.ComboBox();
            this.label3 = new System.Windows.Forms.Label();
            this.columnCheck = new System.Windows.Forms.CheckBox();
            this.columnNumeric = new System.Windows.Forms.NumericUpDown();
            this.columnText = new System.Windows.Forms.Label();
            this.dataGridView2 = new System.Windows.Forms.DataGridView();
            this.groupAmountNumeric = new System.Windows.Forms.NumericUpDown();
            this.groupText = new System.Windows.Forms.Label();
            this.currentGroupNumeric = new System.Windows.Forms.NumericUpDown();
            this.fillTableGroup = new System.Windows.Forms.GroupBox();
            this.toolTip1 = new System.Windows.Forms.ToolTip(this.components);
            this.label2 = new System.Windows.Forms.Label();
            this.sheetFindTypeBox = new System.Windows.Forms.ComboBox();
            this.sheetNameBox = new System.Windows.Forms.TextBox();
            ((System.ComponentModel.ISupportInitialize)(this.sheetNumBox)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.indentsNumeric)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.columnNumeric)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView2)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.groupAmountNumeric)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.currentGroupNumeric)).BeginInit();
            this.fillTableGroup.SuspendLayout();
            this.SuspendLayout();
            // 
            // sheetNumBox
            // 
            this.sheetNumBox.Location = new System.Drawing.Point(275, 87);
            this.sheetNumBox.Minimum = new decimal(new int[] {
            1,
            0,
            0,
            0});
            this.sheetNumBox.Name = "sheetNumBox";
            this.sheetNumBox.Size = new System.Drawing.Size(105, 20);
            this.sheetNumBox.TabIndex = 14;
            this.sheetNumBox.Value = new decimal(new int[] {
            1,
            0,
            0,
            0});
            this.sheetNumBox.Visible = false;
            // 
            // indentsNumeric
            // 
            this.indentsNumeric.Location = new System.Drawing.Point(275, 48);
            this.indentsNumeric.Name = "indentsNumeric";
            this.indentsNumeric.Size = new System.Drawing.Size(105, 20);
            this.indentsNumeric.TabIndex = 11;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F);
            this.label1.Location = new System.Drawing.Point(12, 48);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(236, 20);
            this.label1.TabIndex = 10;
            this.label1.Text = "Кол-во отступов у заголовков";
            this.toolTip1.SetToolTip(this.label1, "На какой строке основной заголовок (или с какой строки начинаются заголовки, если" +
        " у вас группированная таблица). \r\nЕсли начинаются с 1-ой строки, оставьте значен" +
        "ие 0.\r\n");
            // 
            // searchButton
            // 
            this.searchButton.Location = new System.Drawing.Point(275, 12);
            this.searchButton.Name = "searchButton";
            this.searchButton.Size = new System.Drawing.Size(105, 20);
            this.searchButton.TabIndex = 9;
            this.searchButton.Text = "Обзор";
            this.searchButton.UseVisualStyleBackColor = true;
            this.searchButton.Click += new System.EventHandler(this.searchButton_Click);
            // 
            // searchBox
            // 
            this.searchBox.Location = new System.Drawing.Point(12, 12);
            this.searchBox.Name = "searchBox";
            this.searchBox.Size = new System.Drawing.Size(257, 20);
            this.searchBox.TabIndex = 8;
            // 
            // openFileDialog1
            // 
            this.openFileDialog1.FileName = "openFileDialog1";
            // 
            // getTableButton
            // 
            this.getTableButton.Location = new System.Drawing.Point(152, 226);
            this.getTableButton.Name = "getTableButton";
            this.getTableButton.Size = new System.Drawing.Size(88, 23);
            this.getTableButton.TabIndex = 17;
            this.getTableButton.Text = "Подключить";
            this.getTableButton.UseVisualStyleBackColor = true;
            this.getTableButton.Click += new System.EventHandler(this.getTableButton_Click);
            // 
            // finalButton
            // 
            this.finalButton.Location = new System.Drawing.Point(143, 184);
            this.finalButton.Name = "finalButton";
            this.finalButton.Size = new System.Drawing.Size(88, 23);
            this.finalButton.TabIndex = 18;
            this.finalButton.Text = "Готово";
            this.finalButton.UseVisualStyleBackColor = true;
            this.finalButton.Click += new System.EventHandler(this.finalButton_Click);
            // 
            // dataGridView1
            // 
            this.dataGridView1.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dataGridView1.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.table_redact,
            this.table_add});
            this.dataGridView1.Location = new System.Drawing.Point(2, 29);
            this.dataGridView1.Name = "dataGridView1";
            this.dataGridView1.Size = new System.Drawing.Size(367, 150);
            this.dataGridView1.TabIndex = 19;
            this.dataGridView1.CellContentClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.dataGridView1_CellContentClick);
            // 
            // table_redact
            // 
            this.table_redact.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.Fill;
            this.table_redact.HeaderText = "Редактируемая таблица";
            this.table_redact.Name = "table_redact";
            this.table_redact.ReadOnly = true;
            // 
            // table_add
            // 
            this.table_add.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.Fill;
            this.table_add.HeaderText = "Используемая таблица";
            this.table_add.Name = "table_add";
            // 
            // groupCheckBox
            // 
            this.groupCheckBox.AutoSize = true;
            this.groupCheckBox.CheckAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.groupCheckBox.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F);
            this.groupCheckBox.Location = new System.Drawing.Point(12, 127);
            this.groupCheckBox.Name = "groupCheckBox";
            this.groupCheckBox.RightToLeft = System.Windows.Forms.RightToLeft.No;
            this.groupCheckBox.Size = new System.Drawing.Size(220, 24);
            this.groupCheckBox.TabIndex = 21;
            this.groupCheckBox.Text = "Групированная таблица?";
            this.toolTip1.SetToolTip(this.groupCheckBox, "Нажмите на галочку, если у вас группированная таблица.\r\nПосле выберите кол-во гру" +
        "пп (заголовков столбца) и требуюмую группу (заголовок столбца)");
            this.groupCheckBox.UseVisualStyleBackColor = true;
            this.groupCheckBox.CheckedChanged += new System.EventHandler(this.groupCheckBox_CheckedChanged);
            // 
            // fillTypeCombo
            // 
            this.fillTypeCombo.FormattingEnabled = true;
            this.fillTypeCombo.Items.AddRange(new object[] {
            "Вставить",
            "Заменить все",
            "Заполнить пустые"});
            this.fillTypeCombo.Location = new System.Drawing.Point(266, 2);
            this.fillTypeCombo.Name = "fillTypeCombo";
            this.fillTypeCombo.Size = new System.Drawing.Size(105, 21);
            this.fillTypeCombo.TabIndex = 23;
            this.fillTypeCombo.SelectedIndexChanged += new System.EventHandler(this.comboBox1_SelectedIndexChanged);
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F);
            this.label3.Location = new System.Drawing.Point(0, 0);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(228, 20);
            this.label3.TabIndex = 22;
            this.label3.Text = "Способ заполнения таблицы";
            this.toolTip1.SetToolTip(this.label3, "Сопоставьте столбец редакт. таблицы и таблицы данных, выбрав\r\nиз выпадающего спис" +
        "ка нужный столбец.");
            this.label3.Click += new System.EventHandler(this.label3_Click);
            // 
            // columnCheck
            // 
            this.columnCheck.AutoSize = true;
            this.columnCheck.CheckAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.columnCheck.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F);
            this.columnCheck.Location = new System.Drawing.Point(12, 164);
            this.columnCheck.Name = "columnCheck";
            this.columnCheck.RightToLeft = System.Windows.Forms.RightToLeft.No;
            this.columnCheck.Size = new System.Drawing.Size(200, 44);
            this.columnCheck.TabIndex = 26;
            this.columnCheck.Text = "Убрать пустые строки \r\nпо столбцу?";
            this.toolTip1.SetToolTip(this.columnCheck, "Нажмите на галочку и выберите столбец, по которому не будут учитываться\r\nпустые с" +
        "троки");
            this.columnCheck.UseVisualStyleBackColor = true;
            this.columnCheck.CheckedChanged += new System.EventHandler(this.columnCheck_CheckedChanged);
            // 
            // columnNumeric
            // 
            this.columnNumeric.Location = new System.Drawing.Point(275, 178);
            this.columnNumeric.Minimum = new decimal(new int[] {
            1,
            0,
            0,
            0});
            this.columnNumeric.Name = "columnNumeric";
            this.columnNumeric.Size = new System.Drawing.Size(108, 20);
            this.columnNumeric.TabIndex = 24;
            this.columnNumeric.Value = new decimal(new int[] {
            1,
            0,
            0,
            0});
            this.columnNumeric.Visible = false;
            // 
            // columnText
            // 
            this.columnText.AutoSize = true;
            this.columnText.Location = new System.Drawing.Point(285, 201);
            this.columnText.Name = "columnText";
            this.columnText.Size = new System.Drawing.Size(83, 13);
            this.columnText.TabIndex = 25;
            this.columnText.Text = "номер столбца";
            this.columnText.Visible = false;
            // 
            // dataGridView2
            // 
            this.dataGridView2.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dataGridView2.Location = new System.Drawing.Point(445, 12);
            this.dataGridView2.Name = "dataGridView2";
            this.dataGridView2.Size = new System.Drawing.Size(366, 444);
            this.dataGridView2.TabIndex = 27;
            // 
            // groupAmountNumeric
            // 
            this.groupAmountNumeric.Location = new System.Drawing.Point(287, 127);
            this.groupAmountNumeric.Minimum = new decimal(new int[] {
            1,
            0,
            0,
            0});
            this.groupAmountNumeric.Name = "groupAmountNumeric";
            this.groupAmountNumeric.Size = new System.Drawing.Size(41, 20);
            this.groupAmountNumeric.TabIndex = 28;
            this.groupAmountNumeric.Value = new decimal(new int[] {
            1,
            0,
            0,
            0});
            this.groupAmountNumeric.Visible = false;
            this.groupAmountNumeric.ValueChanged += new System.EventHandler(this.groupAmountNumeric_ValueChanged);
            // 
            // groupText
            // 
            this.groupText.AutoSize = true;
            this.groupText.Location = new System.Drawing.Point(229, 150);
            this.groupText.Name = "groupText";
            this.groupText.Size = new System.Drawing.Size(154, 13);
            this.groupText.TabIndex = 29;
            this.groupText.Text = "кол-во групп и номер группы";
            this.groupText.Visible = false;
            this.groupText.Click += new System.EventHandler(this.label4_Click);
            // 
            // currentGroupNumeric
            // 
            this.currentGroupNumeric.Location = new System.Drawing.Point(334, 127);
            this.currentGroupNumeric.Minimum = new decimal(new int[] {
            1,
            0,
            0,
            0});
            this.currentGroupNumeric.Name = "currentGroupNumeric";
            this.currentGroupNumeric.Size = new System.Drawing.Size(41, 20);
            this.currentGroupNumeric.TabIndex = 30;
            this.currentGroupNumeric.Value = new decimal(new int[] {
            1,
            0,
            0,
            0});
            this.currentGroupNumeric.Visible = false;
            // 
            // fillTableGroup
            // 
            this.fillTableGroup.BackColor = System.Drawing.SystemColors.Control;
            this.fillTableGroup.Controls.Add(this.label3);
            this.fillTableGroup.Controls.Add(this.fillTypeCombo);
            this.fillTableGroup.Controls.Add(this.dataGridView1);
            this.fillTableGroup.Controls.Add(this.finalButton);
            this.fillTableGroup.Enabled = false;
            this.fillTableGroup.Location = new System.Drawing.Point(12, 255);
            this.fillTableGroup.Name = "fillTableGroup";
            this.fillTableGroup.Size = new System.Drawing.Size(371, 219);
            this.fillTableGroup.TabIndex = 31;
            this.fillTableGroup.TabStop = false;
            this.fillTableGroup.Text = "groupBox1";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F);
            this.label2.Location = new System.Drawing.Point(12, 88);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(160, 20);
            this.label2.TabIndex = 12;
            this.label2.Text = "Используемый лист";
            this.toolTip1.SetToolTip(this.label2, "Выбор листа по его имени или номеру.");
            // 
            // sheetFindTypeBox
            // 
            this.sheetFindTypeBox.FormattingEnabled = true;
            this.sheetFindTypeBox.Items.AddRange(new object[] {
            "По имени",
            "По порядку"});
            this.sheetFindTypeBox.Location = new System.Drawing.Point(178, 87);
            this.sheetFindTypeBox.Name = "sheetFindTypeBox";
            this.sheetFindTypeBox.Size = new System.Drawing.Size(91, 21);
            this.sheetFindTypeBox.TabIndex = 13;
            this.sheetFindTypeBox.SelectedIndexChanged += new System.EventHandler(this.sheetFindTypeBox_SelectedIndexChanged);
            // 
            // sheetNameBox
            // 
            this.sheetNameBox.Location = new System.Drawing.Point(276, 87);
            this.sheetNameBox.Name = "sheetNameBox";
            this.sheetNameBox.Size = new System.Drawing.Size(105, 20);
            this.sheetNameBox.TabIndex = 15;
            // 
            // GetDataFromOtherTable
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(838, 491);
            this.Controls.Add(this.fillTableGroup);
            this.Controls.Add(this.currentGroupNumeric);
            this.Controls.Add(this.groupText);
            this.Controls.Add(this.groupAmountNumeric);
            this.Controls.Add(this.dataGridView2);
            this.Controls.Add(this.columnCheck);
            this.Controls.Add(this.columnText);
            this.Controls.Add(this.columnNumeric);
            this.Controls.Add(this.groupCheckBox);
            this.Controls.Add(this.getTableButton);
            this.Controls.Add(this.sheetNameBox);
            this.Controls.Add(this.sheetNumBox);
            this.Controls.Add(this.sheetFindTypeBox);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.indentsNumeric);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.searchButton);
            this.Controls.Add(this.searchBox);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog;
            this.MaximizeBox = false;
            this.Name = "GetDataFromOtherTable";
            this.Text = "Получение данных из другой таблицы";
            this.FormClosed += new System.Windows.Forms.FormClosedEventHandler(this.GetDataFromOtherTable_FormClosed);
            this.Load += new System.EventHandler(this.GetDataFromOtherTable_Load);
            ((System.ComponentModel.ISupportInitialize)(this.sheetNumBox)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.indentsNumeric)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.columnNumeric)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView2)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.groupAmountNumeric)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.currentGroupNumeric)).EndInit();
            this.fillTableGroup.ResumeLayout(false);
            this.fillTableGroup.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.NumericUpDown sheetNumBox;
        private System.Windows.Forms.NumericUpDown indentsNumeric;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Button searchButton;
        private System.Windows.Forms.TextBox searchBox;
        private System.Windows.Forms.OpenFileDialog openFileDialog1;
        private System.Windows.Forms.Button getTableButton;
        private System.Windows.Forms.Button finalButton;
        private System.Windows.Forms.DataGridView dataGridView1;
        private System.Windows.Forms.DataGridViewTextBoxColumn table_redact;
        private System.Windows.Forms.DataGridViewComboBoxColumn table_add;
        private System.Windows.Forms.CheckBox groupCheckBox;
        private System.Windows.Forms.ComboBox fillTypeCombo;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.CheckBox columnCheck;
        private System.Windows.Forms.NumericUpDown columnNumeric;
        private System.Windows.Forms.Label columnText;
        private System.Windows.Forms.DataGridView dataGridView2;
        private System.Windows.Forms.NumericUpDown groupAmountNumeric;
        private System.Windows.Forms.Label groupText;
        private System.Windows.Forms.NumericUpDown currentGroupNumeric;
        private System.Windows.Forms.GroupBox fillTableGroup;
        private System.Windows.Forms.ToolTip toolTip1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.ComboBox sheetFindTypeBox;
        private System.Windows.Forms.TextBox sheetNameBox;
    }
}