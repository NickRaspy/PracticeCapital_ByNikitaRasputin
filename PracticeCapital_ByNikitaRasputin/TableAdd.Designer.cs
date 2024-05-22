namespace PracticeCapital_ByNikitaRasputin
{
    partial class TableAdd
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
            this.searchBox = new System.Windows.Forms.TextBox();
            this.searchButton = new System.Windows.Forms.Button();
            this.openFileDialog1 = new System.Windows.Forms.OpenFileDialog();
            this.toolTip1 = new System.Windows.Forms.ToolTip(this.components);
            this.columnCheck = new System.Windows.Forms.CheckBox();
            this.groupCheckBox = new System.Windows.Forms.CheckBox();
            this.label2 = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.getTableButton = new System.Windows.Forms.Button();
            this.currentGroupNumeric = new System.Windows.Forms.NumericUpDown();
            this.groupText = new System.Windows.Forms.Label();
            this.groupAmountNumeric = new System.Windows.Forms.NumericUpDown();
            this.columnText = new System.Windows.Forms.Label();
            this.columnNumeric = new System.Windows.Forms.NumericUpDown();
            this.sheetNameBox = new System.Windows.Forms.TextBox();
            this.sheetFindTypeBox = new System.Windows.Forms.ComboBox();
            this.indentsNumeric = new System.Windows.Forms.NumericUpDown();
            this.textBox1 = new System.Windows.Forms.TextBox();
            this.sheetNumBox = new System.Windows.Forms.NumericUpDown();
            ((System.ComponentModel.ISupportInitialize)(this.currentGroupNumeric)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.groupAmountNumeric)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.columnNumeric)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.indentsNumeric)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.sheetNumBox)).BeginInit();
            this.SuspendLayout();
            // 
            // searchBox
            // 
            this.searchBox.Location = new System.Drawing.Point(12, 12);
            this.searchBox.Name = "searchBox";
            this.searchBox.Size = new System.Drawing.Size(257, 20);
            this.searchBox.TabIndex = 0;
            // 
            // searchButton
            // 
            this.searchButton.Location = new System.Drawing.Point(275, 12);
            this.searchButton.Name = "searchButton";
            this.searchButton.Size = new System.Drawing.Size(105, 20);
            this.searchButton.TabIndex = 1;
            this.searchButton.Text = "Обзор";
            this.searchButton.UseVisualStyleBackColor = true;
            this.searchButton.Click += new System.EventHandler(this.searchButton_Click);
            // 
            // openFileDialog1
            // 
            this.openFileDialog1.FileName = "openFileDialog1";
            // 
            // columnCheck
            // 
            this.columnCheck.AutoSize = true;
            this.columnCheck.CheckAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.columnCheck.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F);
            this.columnCheck.Location = new System.Drawing.Point(12, 160);
            this.columnCheck.Name = "columnCheck";
            this.columnCheck.RightToLeft = System.Windows.Forms.RightToLeft.No;
            this.columnCheck.Size = new System.Drawing.Size(200, 44);
            this.columnCheck.TabIndex = 39;
            this.columnCheck.Text = "Убрать пустые строки \r\nпо столбцу?";
            this.toolTip1.SetToolTip(this.columnCheck, "Нажмите на галочку и выберите столбец, по которому не будут учитываться\r\nпустые с" +
        "троки");
            this.columnCheck.UseVisualStyleBackColor = true;
            this.columnCheck.CheckedChanged += new System.EventHandler(this.columnCheck_CheckedChanged);
            // 
            // groupCheckBox
            // 
            this.groupCheckBox.AutoSize = true;
            this.groupCheckBox.CheckAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.groupCheckBox.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F);
            this.groupCheckBox.Location = new System.Drawing.Point(12, 123);
            this.groupCheckBox.Name = "groupCheckBox";
            this.groupCheckBox.RightToLeft = System.Windows.Forms.RightToLeft.No;
            this.groupCheckBox.Size = new System.Drawing.Size(220, 24);
            this.groupCheckBox.TabIndex = 36;
            this.groupCheckBox.Text = "Групированная таблица?";
            this.toolTip1.SetToolTip(this.groupCheckBox, "Нажмите на галочку, если у вас группированная таблица.\r\nПосле выберите кол-во гру" +
        "пп (заголовков столбца) и требуюмую группу (заголовок столбца)");
            this.groupCheckBox.UseVisualStyleBackColor = true;
            this.groupCheckBox.CheckedChanged += new System.EventHandler(this.groupCheckBox_CheckedChanged);
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F);
            this.label2.Location = new System.Drawing.Point(12, 84);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(160, 20);
            this.label2.TabIndex = 33;
            this.label2.Text = "Используемый лист";
            this.toolTip1.SetToolTip(this.label2, "Выбор листа по его имени или номеру.");
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F);
            this.label1.Location = new System.Drawing.Point(12, 44);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(236, 20);
            this.label1.TabIndex = 31;
            this.label1.Text = "Кол-во отступов у заголовков";
            this.toolTip1.SetToolTip(this.label1, "На какой строке основной заголовок (или с какой строки начинаются заголовки, если" +
        " у вас группированная таблица). \r\nЕсли начинаются с 1-ой строки, оставьте значен" +
        "ие 0.\r\n");
            // 
            // getTableButton
            // 
            this.getTableButton.Location = new System.Drawing.Point(157, 224);
            this.getTableButton.Name = "getTableButton";
            this.getTableButton.Size = new System.Drawing.Size(75, 23);
            this.getTableButton.TabIndex = 8;
            this.getTableButton.Text = "Готово";
            this.getTableButton.UseVisualStyleBackColor = true;
            this.getTableButton.Click += new System.EventHandler(this.getTableButton_Click);
            // 
            // currentGroupNumeric
            // 
            this.currentGroupNumeric.Location = new System.Drawing.Point(334, 123);
            this.currentGroupNumeric.Minimum = new decimal(new int[] {
            1,
            0,
            0,
            0});
            this.currentGroupNumeric.Name = "currentGroupNumeric";
            this.currentGroupNumeric.Size = new System.Drawing.Size(41, 20);
            this.currentGroupNumeric.TabIndex = 42;
            this.currentGroupNumeric.Value = new decimal(new int[] {
            1,
            0,
            0,
            0});
            this.currentGroupNumeric.Visible = false;
            // 
            // groupText
            // 
            this.groupText.AutoSize = true;
            this.groupText.Location = new System.Drawing.Point(229, 146);
            this.groupText.Name = "groupText";
            this.groupText.Size = new System.Drawing.Size(154, 13);
            this.groupText.TabIndex = 41;
            this.groupText.Text = "кол-во групп и номер группы";
            this.groupText.Visible = false;
            // 
            // groupAmountNumeric
            // 
            this.groupAmountNumeric.Location = new System.Drawing.Point(287, 123);
            this.groupAmountNumeric.Minimum = new decimal(new int[] {
            1,
            0,
            0,
            0});
            this.groupAmountNumeric.Name = "groupAmountNumeric";
            this.groupAmountNumeric.Size = new System.Drawing.Size(41, 20);
            this.groupAmountNumeric.TabIndex = 40;
            this.groupAmountNumeric.Value = new decimal(new int[] {
            1,
            0,
            0,
            0});
            this.groupAmountNumeric.Visible = false;
            // 
            // columnText
            // 
            this.columnText.AutoSize = true;
            this.columnText.Location = new System.Drawing.Point(285, 197);
            this.columnText.Name = "columnText";
            this.columnText.Size = new System.Drawing.Size(83, 13);
            this.columnText.TabIndex = 38;
            this.columnText.Text = "номер столбца";
            this.columnText.Visible = false;
            // 
            // columnNumeric
            // 
            this.columnNumeric.Location = new System.Drawing.Point(275, 174);
            this.columnNumeric.Minimum = new decimal(new int[] {
            1,
            0,
            0,
            0});
            this.columnNumeric.Name = "columnNumeric";
            this.columnNumeric.Size = new System.Drawing.Size(108, 20);
            this.columnNumeric.TabIndex = 37;
            this.columnNumeric.Value = new decimal(new int[] {
            1,
            0,
            0,
            0});
            this.columnNumeric.Visible = false;
            // 
            // sheetNameBox
            // 
            this.sheetNameBox.Location = new System.Drawing.Point(275, 83);
            this.sheetNameBox.Name = "sheetNameBox";
            this.sheetNameBox.Size = new System.Drawing.Size(105, 20);
            this.sheetNameBox.TabIndex = 35;
            // 
            // sheetFindTypeBox
            // 
            this.sheetFindTypeBox.FormattingEnabled = true;
            this.sheetFindTypeBox.Items.AddRange(new object[] {
            "По имени",
            "По порядку"});
            this.sheetFindTypeBox.Location = new System.Drawing.Point(178, 83);
            this.sheetFindTypeBox.Name = "sheetFindTypeBox";
            this.sheetFindTypeBox.Size = new System.Drawing.Size(91, 21);
            this.sheetFindTypeBox.TabIndex = 34;
            // 
            // indentsNumeric
            // 
            this.indentsNumeric.Location = new System.Drawing.Point(275, 44);
            this.indentsNumeric.Name = "indentsNumeric";
            this.indentsNumeric.Size = new System.Drawing.Size(105, 20);
            this.indentsNumeric.TabIndex = 32;
            // 
            // textBox1
            // 
            this.textBox1.Location = new System.Drawing.Point(275, 83);
            this.textBox1.Name = "textBox1";
            this.textBox1.Size = new System.Drawing.Size(105, 20);
            this.textBox1.TabIndex = 43;
            // 
            // sheetNumBox
            // 
            this.sheetNumBox.Location = new System.Drawing.Point(275, 84);
            this.sheetNumBox.Minimum = new decimal(new int[] {
            1,
            0,
            0,
            0});
            this.sheetNumBox.Name = "sheetNumBox";
            this.sheetNumBox.Size = new System.Drawing.Size(105, 20);
            this.sheetNumBox.TabIndex = 44;
            this.sheetNumBox.Value = new decimal(new int[] {
            1,
            0,
            0,
            0});
            // 
            // TableAdd
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(392, 259);
            this.Controls.Add(this.sheetNumBox);
            this.Controls.Add(this.textBox1);
            this.Controls.Add(this.currentGroupNumeric);
            this.Controls.Add(this.groupText);
            this.Controls.Add(this.groupAmountNumeric);
            this.Controls.Add(this.columnCheck);
            this.Controls.Add(this.columnText);
            this.Controls.Add(this.columnNumeric);
            this.Controls.Add(this.groupCheckBox);
            this.Controls.Add(this.sheetNameBox);
            this.Controls.Add(this.sheetFindTypeBox);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.indentsNumeric);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.getTableButton);
            this.Controls.Add(this.searchButton);
            this.Controls.Add(this.searchBox);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog;
            this.MaximizeBox = false;
            this.Name = "TableAdd";
            this.Text = "Подключение редактируемой таблицы";
            this.FormClosed += new System.Windows.Forms.FormClosedEventHandler(this.TableAdd_FormClosed);
            ((System.ComponentModel.ISupportInitialize)(this.currentGroupNumeric)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.groupAmountNumeric)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.columnNumeric)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.indentsNumeric)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.sheetNumBox)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.TextBox searchBox;
        private System.Windows.Forms.Button searchButton;
        private System.Windows.Forms.OpenFileDialog openFileDialog1;
        private System.Windows.Forms.ToolTip toolTip1;
        private System.Windows.Forms.Button getTableButton;
        private System.Windows.Forms.NumericUpDown currentGroupNumeric;
        private System.Windows.Forms.Label groupText;
        private System.Windows.Forms.NumericUpDown groupAmountNumeric;
        private System.Windows.Forms.CheckBox columnCheck;
        private System.Windows.Forms.Label columnText;
        private System.Windows.Forms.NumericUpDown columnNumeric;
        private System.Windows.Forms.CheckBox groupCheckBox;
        private System.Windows.Forms.TextBox sheetNameBox;
        private System.Windows.Forms.ComboBox sheetFindTypeBox;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.NumericUpDown indentsNumeric;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.TextBox textBox1;
        private System.Windows.Forms.NumericUpDown sheetNumBox;
    }
}