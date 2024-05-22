using OfficeOpenXml;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace PracticeCapital_ByNikitaRasputin
{
    public partial class TableAdd : Form
    {
        public Form1 form1;
        public TableAdd()
        {
            InitializeComponent();
            sheetFindTypeBox.SelectedIndex = 1;
        }

        private void searchButton_Click(object sender, EventArgs e)
        {
            if (openFileDialog1.ShowDialog() == DialogResult.Cancel) return;
            searchBox.Text = (openFileDialog1.InitialDirectory + "\\" + openFileDialog1.FileName).TrimStart('\\');
        }

        private void sheetFindTypeBox_SelectedIndexChanged(object sender, EventArgs e)
        {
            switch(sheetFindTypeBox.SelectedIndex)
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
            DataTable dataTable = new DataTable();
            try
            {
                if (dataObjects.Count > 0)
                {
                    for (int i = 0; i < dataObjects.Count; i++)
                    {
                        DataColumn dataColumn = new DataColumn
                        {
                            ColumnName = dataObjects[i].name
                        };
                        dataTable.Columns.Add(dataColumn);
                    }
                    for (int i = 0; i < dataObjects[0].data.Count; i++)
                    {
                        DataRow dataRow = dataTable.NewRow();
                        for (int j = 0; j < dataTable.Columns.Count; j++)
                        {
                            dataRow[j] = dataObjects[j].data[i];
                        }
                        dataTable.Rows.Add(dataRow);
                    }
                }
                else dataTable = sheet.Cells[$"A{indents}:{sheet.Dimension.End.Address}"].ToDataTable();
                form1.dataTable = dataTable;
            }
            catch 
            {
                MessageBox.Show("Не удалось загрузить таблицу. Попробуйте поменять значение отступов и/или группированной таблицы", "Ошибка", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }
            try
            {
                form1.dataGridView1.DataSource = form1.dataTable;
            }
            catch(Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
            form1.GetColumns();
            form1.secondaryTableButton.Enabled = true;
            form1.webDataButton.Enabled = true;
            form1.dataSaveButton.Enabled = true;
            form1.analysisButton.Enabled = true;
            form1.columnClearButton.Enabled = true;
            this.Close();
        }

        private void TableAdd_FormClosed(object sender, FormClosedEventArgs e)
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
    }
}
