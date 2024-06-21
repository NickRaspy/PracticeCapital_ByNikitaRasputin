namespace PracticeCapital_ByNikitaRasputin
{
    partial class GetDataFromNetDB
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
            this.chromiumWebBrowser1 = new CefSharp.WinForms.ChromiumWebBrowser();
            this.dataGridView1 = new System.Windows.Forms.DataGridView();
            this.label1 = new System.Windows.Forms.Label();
            this.INNBox = new System.Windows.Forms.ComboBox();
            this.label2 = new System.Windows.Forms.Label();
            this.GovDBBox = new System.Windows.Forms.ComboBox();
            this.searchButton = new System.Windows.Forms.Button();
            this.addButton = new System.Windows.Forms.Button();
            this.startButton = new System.Windows.Forms.Button();
            this.backPageButton = new System.Windows.Forms.Button();
            this.goPageButton = new System.Windows.Forms.Button();
            this.refreshButton = new System.Windows.Forms.Button();
            this.goButton = new System.Windows.Forms.Button();
            this.urlBox = new System.Windows.Forms.TextBox();
            this.browserCheck = new System.Windows.Forms.CheckBox();
            this.label3 = new System.Windows.Forms.Label();
            this.fillTypeCombo = new System.Windows.Forms.ComboBox();
            this.dataGridView2 = new System.Windows.Forms.DataGridView();
            this.table_redact = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.table_add = new System.Windows.Forms.DataGridViewComboBoxColumn();
            this.finalButton = new System.Windows.Forms.Button();
            this.stopButton = new System.Windows.Forms.Button();
            this.clearDataTableButton = new System.Windows.Forms.Button();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView2)).BeginInit();
            this.SuspendLayout();
            // 
            // chromiumWebBrowser1
            // 
            this.chromiumWebBrowser1.ActivateBrowserOnCreation = false;
            this.chromiumWebBrowser1.Location = new System.Drawing.Point(660, 48);
            this.chromiumWebBrowser1.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.chromiumWebBrowser1.Name = "chromiumWebBrowser1";
            this.chromiumWebBrowser1.Size = new System.Drawing.Size(951, 658);
            this.chromiumWebBrowser1.TabIndex = 3;
            this.chromiumWebBrowser1.AddressChanged += new System.EventHandler<CefSharp.AddressChangedEventArgs>(this.chromiumWebBrowser1_AddressChanged);
            this.chromiumWebBrowser1.LoadingStateChanged += new System.EventHandler<CefSharp.LoadingStateChangedEventArgs>(this.chromiumWebBrowser1_LoadingStateChanged);
            // 
            // dataGridView1
            // 
            this.dataGridView1.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dataGridView1.Location = new System.Drawing.Point(16, 135);
            this.dataGridView1.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.dataGridView1.Name = "dataGridView1";
            this.dataGridView1.RowHeadersWidth = 51;
            this.dataGridView1.Size = new System.Drawing.Size(636, 313);
            this.dataGridView1.TabIndex = 6;
            this.dataGridView1.ColumnAdded += new System.Windows.Forms.DataGridViewColumnEventHandler(this.dataGridView1_ColumnAdded);
            this.dataGridView1.ColumnRemoved += new System.Windows.Forms.DataGridViewColumnEventHandler(this.dataGridView1_ColumnRemoved);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F);
            this.label1.Location = new System.Drawing.Point(16, 11);
            this.label1.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(265, 31);
            this.label1.TabIndex = 7;
            this.label1.Text = "Столбец с ИНН/ОГРН";
            // 
            // INNBox
            // 
            this.INNBox.FormattingEnabled = true;
            this.INNBox.Location = new System.Drawing.Point(383, 15);
            this.INNBox.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.INNBox.Name = "INNBox";
            this.INNBox.Size = new System.Drawing.Size(160, 24);
            this.INNBox.TabIndex = 8;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F);
            this.label2.Location = new System.Drawing.Point(16, 64);
            this.label2.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(186, 25);
            this.label2.TabIndex = 9;
            this.label2.Text = "Источники данных";
            // 
            // GovDBBox
            // 
            this.GovDBBox.Enabled = false;
            this.GovDBBox.FormattingEnabled = true;
            this.GovDBBox.Items.AddRange(new object[] {
            "БФО Налог",
            "Find-Org",
            "List-Org",
            "ПЕРЕЧЕНЬ ТЕРРОРИСТОВ И ЭКСТРЕМИСТОВ",
            "Арбитраж",
            "Прозрачный бизнес",
            "ЗАЧЕСТНЫЙБИЗНЕС"});
            this.GovDBBox.Location = new System.Drawing.Point(383, 66);
            this.GovDBBox.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.GovDBBox.Name = "GovDBBox";
            this.GovDBBox.Size = new System.Drawing.Size(160, 24);
            this.GovDBBox.TabIndex = 10;
            this.GovDBBox.SelectedIndexChanged += new System.EventHandler(this.GovDBBox_SelectedIndexChanged);
            // 
            // searchButton
            // 
            this.searchButton.Enabled = false;
            this.searchButton.Location = new System.Drawing.Point(552, 64);
            this.searchButton.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.searchButton.Name = "searchButton";
            this.searchButton.Size = new System.Drawing.Size(100, 28);
            this.searchButton.TabIndex = 11;
            this.searchButton.Text = "Поиск";
            this.searchButton.UseVisualStyleBackColor = true;
            this.searchButton.Click += new System.EventHandler(this.searchButton_Click);
            // 
            // addButton
            // 
            this.addButton.Location = new System.Drawing.Point(552, 12);
            this.addButton.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.addButton.Name = "addButton";
            this.addButton.Size = new System.Drawing.Size(100, 28);
            this.addButton.TabIndex = 12;
            this.addButton.Text = "Добавить";
            this.addButton.UseVisualStyleBackColor = true;
            this.addButton.Click += new System.EventHandler(this.addButton_Click);
            // 
            // startButton
            // 
            this.startButton.Enabled = false;
            this.startButton.Location = new System.Drawing.Point(383, 100);
            this.startButton.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.startButton.Name = "startButton";
            this.startButton.Size = new System.Drawing.Size(161, 28);
            this.startButton.TabIndex = 13;
            this.startButton.Text = "Начать";
            this.startButton.UseVisualStyleBackColor = true;
            this.startButton.Click += new System.EventHandler(this.startButton_Click);
            // 
            // backPageButton
            // 
            this.backPageButton.Location = new System.Drawing.Point(660, 7);
            this.backPageButton.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.backPageButton.Name = "backPageButton";
            this.backPageButton.Size = new System.Drawing.Size(43, 33);
            this.backPageButton.TabIndex = 14;
            this.backPageButton.Text = "<-";
            this.backPageButton.UseVisualStyleBackColor = true;
            this.backPageButton.Click += new System.EventHandler(this.backPageButton_Click);
            // 
            // goPageButton
            // 
            this.goPageButton.Location = new System.Drawing.Point(705, 7);
            this.goPageButton.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.goPageButton.Name = "goPageButton";
            this.goPageButton.Size = new System.Drawing.Size(43, 33);
            this.goPageButton.TabIndex = 15;
            this.goPageButton.Text = "->";
            this.goPageButton.UseVisualStyleBackColor = true;
            this.goPageButton.Click += new System.EventHandler(this.goPageButton_Click);
            // 
            // refreshButton
            // 
            this.refreshButton.Location = new System.Drawing.Point(752, 7);
            this.refreshButton.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.refreshButton.Name = "refreshButton";
            this.refreshButton.Size = new System.Drawing.Size(91, 33);
            this.refreshButton.TabIndex = 16;
            this.refreshButton.Text = "Обновить";
            this.refreshButton.UseVisualStyleBackColor = true;
            this.refreshButton.Click += new System.EventHandler(this.refreshButton_Click);
            // 
            // goButton
            // 
            this.goButton.Location = new System.Drawing.Point(1520, 10);
            this.goButton.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.goButton.Name = "goButton";
            this.goButton.Size = new System.Drawing.Size(91, 33);
            this.goButton.TabIndex = 17;
            this.goButton.Text = "Перейти";
            this.goButton.UseVisualStyleBackColor = true;
            this.goButton.Click += new System.EventHandler(this.goButton_Click);
            // 
            // urlBox
            // 
            this.urlBox.Location = new System.Drawing.Point(851, 12);
            this.urlBox.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.urlBox.Name = "urlBox";
            this.urlBox.Size = new System.Drawing.Size(660, 22);
            this.urlBox.TabIndex = 18;
            // 
            // browserCheck
            // 
            this.browserCheck.AutoSize = true;
            this.browserCheck.Checked = true;
            this.browserCheck.CheckState = System.Windows.Forms.CheckState.Checked;
            this.browserCheck.Location = new System.Drawing.Point(21, 39);
            this.browserCheck.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.browserCheck.Name = "browserCheck";
            this.browserCheck.Size = new System.Drawing.Size(18, 17);
            this.browserCheck.TabIndex = 19;
            this.browserCheck.UseVisualStyleBackColor = true;
            this.browserCheck.Visible = false;
            this.browserCheck.CheckedChanged += new System.EventHandler(this.browserCheck_CheckedChanged);
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F);
            this.label3.Location = new System.Drawing.Point(13, 462);
            this.label3.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(281, 25);
            this.label3.TabIndex = 26;
            this.label3.Text = "Способ заполнения таблицы";
            // 
            // fillTypeCombo
            // 
            this.fillTypeCombo.FormattingEnabled = true;
            this.fillTypeCombo.Items.AddRange(new object[] {
            "Заменить все",
            "Заполнить пустые"});
            this.fillTypeCombo.Location = new System.Drawing.Point(512, 464);
            this.fillTypeCombo.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.fillTypeCombo.Name = "fillTypeCombo";
            this.fillTypeCombo.Size = new System.Drawing.Size(139, 24);
            this.fillTypeCombo.TabIndex = 27;
            // 
            // dataGridView2
            // 
            this.dataGridView2.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dataGridView2.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.table_redact,
            this.table_add});
            this.dataGridView2.Location = new System.Drawing.Point(16, 497);
            this.dataGridView2.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.dataGridView2.Name = "dataGridView2";
            this.dataGridView2.RowHeadersWidth = 51;
            this.dataGridView2.Size = new System.Drawing.Size(636, 185);
            this.dataGridView2.TabIndex = 25;
            // 
            // table_redact
            // 
            this.table_redact.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.Fill;
            this.table_redact.HeaderText = "Редактируемая таблица";
            this.table_redact.MinimumWidth = 6;
            this.table_redact.Name = "table_redact";
            this.table_redact.ReadOnly = true;
            // 
            // table_add
            // 
            this.table_add.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.Fill;
            this.table_add.HeaderText = "Используемая таблица";
            this.table_add.MinimumWidth = 6;
            this.table_add.Name = "table_add";
            // 
            // finalButton
            // 
            this.finalButton.Location = new System.Drawing.Point(277, 689);
            this.finalButton.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.finalButton.Name = "finalButton";
            this.finalButton.Size = new System.Drawing.Size(117, 28);
            this.finalButton.TabIndex = 24;
            this.finalButton.Text = "Готово";
            this.finalButton.UseVisualStyleBackColor = true;
            this.finalButton.Click += new System.EventHandler(this.finalButton_Click);
            // 
            // stopButton
            // 
            this.stopButton.Enabled = false;
            this.stopButton.Location = new System.Drawing.Point(552, 100);
            this.stopButton.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.stopButton.Name = "stopButton";
            this.stopButton.Size = new System.Drawing.Size(100, 28);
            this.stopButton.TabIndex = 28;
            this.stopButton.Text = "Прервать";
            this.stopButton.UseVisualStyleBackColor = true;
            this.stopButton.Click += new System.EventHandler(this.stopButton_Click);
            // 
            // clearDataTableButton
            // 
            this.clearDataTableButton.Location = new System.Drawing.Point(16, 100);
            this.clearDataTableButton.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.clearDataTableButton.Name = "clearDataTableButton";
            this.clearDataTableButton.Size = new System.Drawing.Size(161, 28);
            this.clearDataTableButton.TabIndex = 29;
            this.clearDataTableButton.Text = "Очистить таблицу";
            this.clearDataTableButton.UseVisualStyleBackColor = true;
            this.clearDataTableButton.Click += new System.EventHandler(this.clearDataTableButton_Click);
            // 
            // GetDataFromNetDB
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1624, 721);
            this.Controls.Add(this.clearDataTableButton);
            this.Controls.Add(this.stopButton);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.fillTypeCombo);
            this.Controls.Add(this.dataGridView2);
            this.Controls.Add(this.finalButton);
            this.Controls.Add(this.browserCheck);
            this.Controls.Add(this.urlBox);
            this.Controls.Add(this.goButton);
            this.Controls.Add(this.refreshButton);
            this.Controls.Add(this.goPageButton);
            this.Controls.Add(this.backPageButton);
            this.Controls.Add(this.startButton);
            this.Controls.Add(this.addButton);
            this.Controls.Add(this.searchButton);
            this.Controls.Add(this.GovDBBox);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.INNBox);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.dataGridView1);
            this.Controls.Add(this.chromiumWebBrowser1);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog;
            this.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.MaximizeBox = false;
            this.Name = "GetDataFromNetDB";
            this.Text = "Получение данных из открытых источников";
            this.FormClosed += new System.Windows.Forms.FormClosedEventHandler(this.GetDataFromNetDB_FormClosed);
            this.Load += new System.EventHandler(this.GetDataFromNetDB_Load);
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView2)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion
        private CefSharp.WinForms.ChromiumWebBrowser chromiumWebBrowser1;
        private System.Windows.Forms.DataGridView dataGridView1;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.ComboBox INNBox;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.ComboBox GovDBBox;
        private System.Windows.Forms.Button searchButton;
        private System.Windows.Forms.Button addButton;
        private System.Windows.Forms.Button startButton;
        private System.Windows.Forms.Button backPageButton;
        private System.Windows.Forms.Button goPageButton;
        private System.Windows.Forms.Button refreshButton;
        private System.Windows.Forms.Button goButton;
        private System.Windows.Forms.TextBox urlBox;
        private System.Windows.Forms.CheckBox browserCheck;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.ComboBox fillTypeCombo;
        private System.Windows.Forms.DataGridView dataGridView2;
        private System.Windows.Forms.DataGridViewTextBoxColumn table_redact;
        private System.Windows.Forms.DataGridViewComboBoxColumn table_add;
        private System.Windows.Forms.Button finalButton;
        private System.Windows.Forms.Button stopButton;
        private System.Windows.Forms.Button clearDataTableButton;
    }
}