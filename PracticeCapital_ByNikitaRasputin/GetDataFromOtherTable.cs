using OfficeOpenXml;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace PracticeCapital_ByNikitaRasputin
{
    public partial class GetDataFromOtherTable : Form
    {
        public Form1 form1;
        private DataTable dataTable = new DataTable();
        public GetDataFromOtherTable()
        {
            InitializeComponent();
        }

        private void GetDataFromOtherTable_Load(object sender, EventArgs e)
        {
            sheetFindTypeBox.SelectedIndex = 1;
            currentGroupNumeric.Maximum = groupAmountNumeric.Value;
            for(int i = 0; i < form1.dataTable.Columns.Count; i++)
            {
                DataGridViewRow row = (DataGridViewRow)dataGridView1.Rows[0].Clone();
                row.Cells[0].Value = form1.dataTable.Columns[i].ColumnName;
                dataGridView1.Rows.Add(row);
            }
            fillTypeCombo.SelectedIndex = 0;
        }

        private void searchButton_Click(object sender, EventArgs e)
        {
            if (openFileDialog1.ShowDialog() == DialogResult.Cancel) return;
            searchBox.Text = (openFileDialog1.InitialDirectory + "\\" + openFileDialog1.FileName).TrimStart('\\');
        }

        private void sheetFindTypeBox_SelectedIndexChanged(object sender, EventArgs e)
        {
            switch (sheetFindTypeBox.SelectedIndex)
            {
                case 0:
                    sheetNameBox.Visible = true;
                    sheetNumBox.Visible = false;
                    break;
                case 1:
                    sheetNameBox.Visible = false;
                    sheetNumBox.Visible = true;
                    break;
            }
        }

        private void getTableButton_Click(object sender, EventArgs e)
        {
            if (string.IsNullOrEmpty(searchBox.Text))
            {
                MessageBox.Show("Отсутствует путь к таблице. Укажите путь через кнопку Обзор или введите его самостоятельно в верхнее текстовое поле.");
                return;
            }
            ExcelPackage excel = new ExcelPackage();
            try
            {
                excel = new ExcelPackage(searchBox.Text);
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.InnerException.ToString());
                return;
            }
            ExcelWorksheet sheet = null;
            switch (sheetFindTypeBox.SelectedIndex)
            {
                case 0:
                    if (excel.Workbook.Worksheets.Any(x => x.Name == sheetNameBox.Text))
                    {
                        sheet = excel.Workbook.Worksheets[sheetNameBox.Text];
                    }
                    else
                    {
                        MessageBox.Show("Данного листа не существует");
                        return;
                    }
                    break;
                case 1:
                    if (excel.Workbook.Worksheets.Any(x => x.Index == Convert.ToInt32(sheetNumBox.Text) - 1))
                    {
                        sheet = excel.Workbook.Worksheets[Convert.ToInt32(sheetNumBox.Text) - 1];
                    }
                    else
                    {
                        MessageBox.Show("Данного листа не существует");
                        return;
                    }
                    break;
            }
            List<DataObject> dataObjects = new List<DataObject>();
            int indents = (int)indentsNumeric.Value + 1;
            if (groupCheckBox.Checked) 
            {
                GetTableMethods.GroupMethod(sheet, (int)indentsNumeric.Value, (int)groupAmountNumeric.Value, (int)currentGroupNumeric.Value, dataObjects, columnCheck.Checked ? (int)columnNumeric.Value : 0);
                indents = (int)indentsNumeric.Value + (int)groupAmountNumeric.Value;
            } 
            else GetTableMethods.StandartMethod(sheet, (int)indentsNumeric.Value);
            if(dataObjects.Count > 0)
            {
                for(int i = 0; i < dataObjects.Count; i++)
                {
                    DataColumn dataColumn = new DataColumn();
                    dataColumn.ColumnName = dataObjects[i].name;
                    dataTable.Columns.Add(dataColumn);
                }
                for(int i = 0; i < dataObjects[0].data.Count; i++)
                {
                    DataRow dataRow = dataTable.NewRow();
                    for(int j = 0; j < dataTable.Columns.Count; j++)
                    {
                        dataRow[j] = dataObjects[j].data[i];
                    }
                    dataTable.Rows.Add(dataRow);
                }
            }
            else dataTable = sheet.Cells[$"A{indents}:{sheet.Dimension.End.Address}"].ToDataTable();
            dataGridView2.DataSource = dataTable;
            fillTableGroup.Enabled = true;
            List<string> columns = new List<string>();
            for(int i = 0; i < dataTable.Columns.Count; i++) columns.Add(dataTable.Columns[i].ColumnName);
            var comboColumn = (DataGridViewComboBoxColumn)dataGridView1.Columns[1];
            columns.ForEach(a => comboColumn.Items.Add(a));
            comboColumn.Items.Insert(0, "нет");
            comboColumn.DefaultCellStyle.NullValue = "нет";
        }
        
        private void GetDataFromOtherTable_FormClosed(object sender, FormClosedEventArgs e)
        {
            form1.Enabled = true;
        }

        private void groupCheckBox_CheckedChanged(object sender, EventArgs e)
        {
            if (groupCheckBox.Checked)
            {
                groupAmountNumeric.Visible = true;
                currentGroupNumeric.Visible = true;
                groupText.Visible = true;
            }
            else
            {
                groupAmountNumeric.Visible = false;
                currentGroupNumeric.Visible = false;
                groupText.Visible = false;
            }
        }

        private void columnCheck_CheckedChanged(object sender, EventArgs e)
        {
            if (columnCheck.Checked)
            {
                columnNumeric.Visible = true;
                columnText.Visible = true;
            }
            else
            {
                columnNumeric.Visible = false;
                columnText.Visible = false;
            }
        }

        private void dataGridView1_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }

        private void comboBox1_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        private void label3_Click(object sender, EventArgs e)
        {

        }

        private void label4_Click(object sender, EventArgs e)
        {

        }

        private void groupAmountNumeric_ValueChanged(object sender, EventArgs e)
        {
            currentGroupNumeric.Maximum = groupAmountNumeric.Value;
        }

        private void finalButton_Click(object sender, EventArgs e)
        {
            for (int i = 0; i < dataTable.Rows.Count; i++)
            {
                DataRow newRow = null;
                switch (fillTypeCombo.SelectedIndex)
                {
                    case 0:
                        newRow = form1.dataTable.NewRow();
                        form1.dataTable.Rows.Add(newRow);
                        break;
                    case 1: case 2:
                        if (i < form1.dataTable.Rows.Count) newRow = form1.dataTable.Rows[i];
                        else
                        {
                            newRow = form1.dataTable.NewRow();
                            form1.dataTable.Rows.Add(newRow);
                        }
                        break;
                }
                for (int j = 0; j < dataGridView1.Rows.Count - 1; j++)
                {
                    if (!string.IsNullOrEmpty(newRow[j].ToString()) && fillTypeCombo.SelectedIndex == 2) continue;
                    if (dataGridView1[1, j].Value != null && (string)dataGridView1[1, j].Value != "нет")
                    {
                        var newData = dataGridView2[(string)dataGridView1[1, j].Value, i].Value;
                        if (string.IsNullOrEmpty(newData.ToString())) 
                        {
                            if (form1.dataTable.Columns[j].DataType == typeof(double))
                            {
                                Convert.ToDouble(newData = 0);
                            }
                        }
                        else if(form1.dataTable.Columns[j].DataType == typeof(double))
                        {
                            Convert.ToDouble(newData);
                        }
                        newRow[j] = newData;
                    }
                }
            }
            this.Close();
        }
    }
}
