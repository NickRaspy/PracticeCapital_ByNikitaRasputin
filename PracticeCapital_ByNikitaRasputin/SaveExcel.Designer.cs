namespace PracticeCapital_ByNikitaRasputin
{
    partial class SaveExcel
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
            this.pathTextBox = new System.Windows.Forms.TextBox();
            this.searchButton = new System.Windows.Forms.Button();
            this.sheetNameBox = new System.Windows.Forms.TextBox();
            this.sheetFindTypeBox = new System.Windows.Forms.ComboBox();
            this.sheetLabel = new System.Windows.Forms.Label();
            this.saveButton = new System.Windows.Forms.Button();
            this.sheetNumBox = new System.Windows.Forms.NumericUpDown();
            this.newFileRadio = new System.Windows.Forms.RadioButton();
            this.newSheetRadio = new System.Windows.Forms.RadioButton();
            this.existingSheetRadio = new System.Windows.Forms.RadioButton();
            this.openFileDialog1 = new System.Windows.Forms.OpenFileDialog();
            this.saveFileDialog1 = new System.Windows.Forms.SaveFileDialog();
            ((System.ComponentModel.ISupportInitialize)(this.sheetNumBox)).BeginInit();
            this.SuspendLayout();
            // 
            // pathTextBox
            // 
            this.pathTextBox.Location = new System.Drawing.Point(12, 43);
            this.pathTextBox.Name = "pathTextBox";
            this.pathTextBox.Size = new System.Drawing.Size(384, 20);
            this.pathTextBox.TabIndex = 2;
            // 
            // searchButton
            // 
            this.searchButton.Location = new System.Drawing.Point(402, 43);
            this.searchButton.Name = "searchButton";
            this.searchButton.Size = new System.Drawing.Size(75, 20);
            this.searchButton.TabIndex = 3;
            this.searchButton.Text = "Обзор";
            this.searchButton.UseVisualStyleBackColor = true;
            this.searchButton.Click += new System.EventHandler(this.searchButton_Click);
            // 
            // sheetNameBox
            // 
            this.sheetNameBox.Location = new System.Drawing.Point(291, 79);
            this.sheetNameBox.Name = "sheetNameBox";
            this.sheetNameBox.Size = new System.Drawing.Size(105, 20);
            this.sheetNameBox.TabIndex = 18;
            // 
            // sheetFindTypeBox
            // 
            this.sheetFindTypeBox.FormattingEnabled = true;
            this.sheetFindTypeBox.Items.AddRange(new object[] {
            "По имени",
            "По порядку"});
            this.sheetFindTypeBox.Location = new System.Drawing.Point(194, 79);
            this.sheetFindTypeBox.Name = "sheetFindTypeBox";
            this.sheetFindTypeBox.Size = new System.Drawing.Size(91, 21);
            this.sheetFindTypeBox.TabIndex = 17;
            this.sheetFindTypeBox.SelectedIndexChanged += new System.EventHandler(this.sheetFindTypeBox_SelectedIndexChanged);
            // 
            // sheetLabel
            // 
            this.sheetLabel.AutoSize = true;
            this.sheetLabel.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F);
            this.sheetLabel.Location = new System.Drawing.Point(12, 79);
            this.sheetLabel.Name = "sheetLabel";
            this.sheetLabel.Size = new System.Drawing.Size(160, 20);
            this.sheetLabel.TabIndex = 16;
            this.sheetLabel.Text = "Используемый лист";
            // 
            // saveButton
            // 
            this.saveButton.Enabled = false;
            this.saveButton.Location = new System.Drawing.Point(194, 115);
            this.saveButton.Name = "saveButton";
            this.saveButton.Size = new System.Drawing.Size(91, 33);
            this.saveButton.TabIndex = 20;
            this.saveButton.Text = "Загрузить";
            this.saveButton.UseVisualStyleBackColor = true;
            this.saveButton.Click += new System.EventHandler(this.button2_Click);
            // 
            // sheetNumBox
            // 
            this.sheetNumBox.Location = new System.Drawing.Point(291, 79);
            this.sheetNumBox.Minimum = new decimal(new int[] {
            1,
            0,
            0,
            0});
            this.sheetNumBox.Name = "sheetNumBox";
            this.sheetNumBox.Size = new System.Drawing.Size(105, 20);
            this.sheetNumBox.TabIndex = 21;
            this.sheetNumBox.Value = new decimal(new int[] {
            1,
            0,
            0,
            0});
            this.sheetNumBox.Visible = false;
            // 
            // newFileRadio
            // 
            this.newFileRadio.AutoSize = true;
            this.newFileRadio.Font = new System.Drawing.Font("Microsoft Sans Serif", 14F);
            this.newFileRadio.Location = new System.Drawing.Point(13, 8);
            this.newFileRadio.Name = "newFileRadio";
            this.newFileRadio.Size = new System.Drawing.Size(137, 28);
            this.newFileRadio.TabIndex = 22;
            this.newFileRadio.TabStop = true;
            this.newFileRadio.Text = "Новый файл";
            this.newFileRadio.UseVisualStyleBackColor = true;
            this.newFileRadio.CheckedChanged += new System.EventHandler(this.newFileRadio_CheckedChanged);
            // 
            // newSheetRadio
            // 
            this.newSheetRadio.AutoSize = true;
            this.newSheetRadio.Font = new System.Drawing.Font("Microsoft Sans Serif", 14F);
            this.newSheetRadio.Location = new System.Drawing.Point(156, 8);
            this.newSheetRadio.Name = "newSheetRadio";
            this.newSheetRadio.Size = new System.Drawing.Size(133, 28);
            this.newSheetRadio.TabIndex = 23;
            this.newSheetRadio.TabStop = true;
            this.newSheetRadio.Text = "Новый лист";
            this.newSheetRadio.UseVisualStyleBackColor = true;
            this.newSheetRadio.CheckedChanged += new System.EventHandler(this.newSheetRadio_CheckedChanged);
            // 
            // existingSheetRadio
            // 
            this.existingSheetRadio.AutoSize = true;
            this.existingSheetRadio.Font = new System.Drawing.Font("Microsoft Sans Serif", 14F);
            this.existingSheetRadio.Location = new System.Drawing.Point(291, 9);
            this.existingSheetRadio.Name = "existingSheetRadio";
            this.existingSheetRadio.Size = new System.Drawing.Size(180, 28);
            this.existingSheetRadio.TabIndex = 24;
            this.existingSheetRadio.TabStop = true;
            this.existingSheetRadio.Text = "Имеющийся лист";
            this.existingSheetRadio.UseVisualStyleBackColor = true;
            this.existingSheetRadio.CheckedChanged += new System.EventHandler(this.existingSheetRadio_CheckedChanged);
            // 
            // openFileDialog1
            // 
            this.openFileDialog1.FileName = "openFileDialog1";
            // 
            // SaveExcel
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(483, 160);
            this.Controls.Add(this.existingSheetRadio);
            this.Controls.Add(this.newSheetRadio);
            this.Controls.Add(this.newFileRadio);
            this.Controls.Add(this.sheetNumBox);
            this.Controls.Add(this.saveButton);
            this.Controls.Add(this.sheetNameBox);
            this.Controls.Add(this.sheetFindTypeBox);
            this.Controls.Add(this.sheetLabel);
            this.Controls.Add(this.searchButton);
            this.Controls.Add(this.pathTextBox);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog;
            this.MaximizeBox = false;
            this.Name = "SaveExcel";
            this.Text = "Сохранение данных";
            this.FormClosed += new System.Windows.Forms.FormClosedEventHandler(this.SaveExcel_FormClosed);
            this.Load += new System.EventHandler(this.SaveExcel_Load);
            ((System.ComponentModel.ISupportInitialize)(this.sheetNumBox)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion
        private System.Windows.Forms.TextBox pathTextBox;
        private System.Windows.Forms.Button searchButton;
        private System.Windows.Forms.TextBox sheetNameBox;
        private System.Windows.Forms.ComboBox sheetFindTypeBox;
        private System.Windows.Forms.Label sheetLabel;
        private System.Windows.Forms.Button saveButton;
        private System.Windows.Forms.NumericUpDown sheetNumBox;
        private System.Windows.Forms.RadioButton newFileRadio;
        private System.Windows.Forms.RadioButton newSheetRadio;
        private System.Windows.Forms.RadioButton existingSheetRadio;
        private System.Windows.Forms.OpenFileDialog openFileDialog1;
        private System.Windows.Forms.SaveFileDialog saveFileDialog1;
    }
}