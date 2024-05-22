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
    public partial class SaveExcel : Form
    {
        public Form1 form1;
        private ExcelWorksheet sheet;
        public SaveExcel()
        {
            InitializeComponent();
            saveFileDialog1.Filter = "Excel files(*.xlsx)|*.xlsx";
            openFileDialog1.Filter = "Excel files(*.xlsx)|*.xlsx";
        }

        private void SaveExcel_Load(object sender, EventArgs e)
        {
            sheetFindTypeBox.SelectedIndex = 1;
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

        private void SaveExcel_FormClosed(object sender, FormClosedEventArgs e)
        {
            form1.Enabled = true;
        }

        private void newFileRadio_CheckedChanged(object sender, EventArgs e)
        {
            if (newFileRadio.Checked)
            {
                newSheetRadio.Checked = false;
                existingSheetRadio.Checked = false;
                sheetFindTypeBox.Enabled = false;
                sheetLabel.Enabled = false;
                sheetNameBox.Enabled = false;
                sheetNumBox.Enabled = false;
                pathTextBox.Enabled = false;
                searchButton.Enabled = false;
                saveButton.Enabled = true;
            }
        }

        private void newSheetRadio_CheckedChanged(object sender, EventArgs e)
        {
            if (newSheetRadio.Checked)
            {
                newFileRadio.Checked = false;
                existingSheetRadio.Checked = false;
                sheetFindTypeBox.Enabled = false;
                sheetLabel.Enabled = false;
                sheetNameBox.Enabled = false;
                sheetNumBox.Enabled = false;
                pathTextBox.Enabled = true;
                searchButton.Enabled = true;
                saveButton.Enabled = true;
            }
        }

        private void existingSheetRadio_CheckedChanged(object sender, EventArgs e)
        {
            if (existingSheetRadio.Checked)
            {
                newFileRadio.Checked = false;
                newSheetRadio.Checked = false;
                sheetFindTypeBox.Enabled = true;
                sheetLabel.Enabled = true;
                sheetNameBox.Enabled = true;
                sheetNumBox.Enabled = true;
                pathTextBox.Enabled = true;
                searchButton.Enabled = true;
                saveButton.Enabled = true;
            }
        }

        private void button2_Click(object sender, EventArgs e)
        {
            using(ExcelPackage package = new ExcelPackage())
            {
                string path = "";
                if (newFileRadio.Checked)
                {
                    if (saveFileDialog1.ShowDialog() == DialogResult.Cancel) return;
                    try { sheet = package.Workbook.Worksheets.Add("Новый лист"); }
                    catch
                    {
                        int count = 1;
                        while (true)
                        {
                            if (!package.Workbook.Worksheets.Any(x => x.Name == $"Новый лист({count})"))
                            {
                                sheet = package.Workbook.Worksheets.Add($"Новый лист({count})");
                                break;
                            }
                            count++;
                        }
                    }
                    path = saveFileDialog1.FileName;
                }
                else if (newSheetRadio.Checked || existingSheetRadio.Checked)
                {
                    if (string.IsNullOrEmpty(pathTextBox.Text))
                    {
                        MessageBox.Show("Отсутствует путь к таблице. Укажите путь через кнопку Обзор или введите его самостоятельно в верхнее текстовое поле.");
                        return;
                    }
                    try
                    {
                        using (var openFile = File.Open(pathTextBox.Text, FileMode.Open))
                        {
                            package.Load(openFile);
                        }
                    }
                    catch
                    {
                        MessageBox.Show("Файл таблицы открыт. Закройте его для сохранения.", "Не удалось сохранить", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                        return;
                    }
                    if (existingSheetRadio.Checked)
                    {
                        switch (sheetFindTypeBox.SelectedIndex)
                        {
                            case 0:
                                if(package.Workbook.Worksheets.Any(x => x.Name == sheetNameBox.Text)) sheet = package.Workbook.Worksheets[sheetNameBox.Text];
                                else{MessageBox.Show("Данного листа не существует"); return;}
                                break;
                            case 1:
                                if (package.Workbook.Worksheets.Any(x => x.Index == (int)sheetNumBox.Value - 1)) sheet = package.Workbook.Worksheets[(int)sheetNumBox.Value - 1];
                                else { MessageBox.Show("Данного листа не существует"); return; }
                                break;
                        }
                    }
                    else
                    {
                        try { sheet = package.Workbook.Worksheets.Add("Новый лист"); }
                        catch
                        {
                            int count = 1;
                            while (true)
                            {
                                if (!package.Workbook.Worksheets.Any(x => x.Name == $"Новый лист({count})"))
                                {
                                    sheet = package.Workbook.Worksheets.Add($"Новый лист({count})");
                                    break;
                                }
                                count++;
                            }
                        }
                    }
                    path = pathTextBox.Text;

                }
                for (int i = 0; i < form1.dataTable.Columns.Count; i++)
                {
                    sheet.Cells[1, i + 1].Value = form1.dataTable.Columns[i].ColumnName;
                    for(int j = 0; j < form1.dataTable.Rows.Count; j++)
                    {
                        sheet.Cells[j + 2, i + 1].Style.Fill.PatternType = OfficeOpenXml.Style.ExcelFillStyle.Solid;
                        if(form1.dataGridView1[i, j].Style.BackColor.Name == "0" || form1.dataGridView1[i, j].Style.BackColor == Color.White) sheet.Cells[j + 2, i + 1].Style.Fill.BackgroundColor.SetColor(Color.White);
                        else sheet.Cells[j + 2, i + 1].Style.Fill.BackgroundColor.SetColor(form1.dataGridView1[i, j].Style.BackColor);
                    }
                }
                sheet.Cells["A2"].LoadFromDataTable(form1.dataTable);
                try
                {
                    package.SaveAs(path);
                }
                catch
                {
                    MessageBox.Show("Файл таблицы открыт. Закройте его для сохранения.", "Не удалось сохранить", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    return;
                }
            }
            MessageBox.Show("Сохранено.", "Процесс завершен", MessageBoxButtons.OK, MessageBoxIcon.Information);
        }

        private void searchButton_Click(object sender, EventArgs e)
        {
            if (openFileDialog1.ShowDialog() == DialogResult.Cancel) return;
            pathTextBox.Text = (openFileDialog1.InitialDirectory + "\\" + openFileDialog1.FileName).TrimStart('\\');
        }
    }
}
