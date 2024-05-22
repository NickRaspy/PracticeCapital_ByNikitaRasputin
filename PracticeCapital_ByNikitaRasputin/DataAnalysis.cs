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
    public partial class DataAnalysis : Form
    {
        public Form1 form1;
        private List<string> columns = new List<string>();
        private List<int> redRows = new List<int>();
        private List<int> excludedColumns = new List<int>();
        private List<string> compareValues = new List<string>();
        public DataAnalysis()
        {
            InitializeComponent();
        }

        private void arbitrButton_Click(object sender, EventArgs e) 
        { 
            if (simpleDataBox.SelectedIndex != 0) 
                AnalysisMethods.CheckYellowGreen(form1.dataGridView1, form1.dataGridView1.Columns[simpleDataBox.SelectedItem.ToString()].Index, compareValues, "Найдено 0 дел"); 
        }

        private void DataAnalysis_Load(object sender, EventArgs e)
        {
            localRadio.Checked = true;
            columns.Add("Нет");
            foreach (DataColumn column in form1.dataTable.Columns) columns.Add(column.ColumnName);
            simpleDataBox.DataSource = columns;
            List<string> dtColumns = new List<string>(), forINNColumns = new List<string>(), 
                forRatingColumns = new List<string>(), forKzColumns = new List<string>(), forDzColumns = new List<string>();
            columns.ForEach(a => dtColumns.Add(a)); columns.ForEach(a => forINNColumns.Add(a)); 
            columns.ForEach(a => forRatingColumns.Add(a)); columns.ForEach(a => forKzColumns.Add(a));
            columns.ForEach(a => forDzColumns.Add(a));
            var expensesColumn = (DataGridViewComboBoxColumn)expRevDataTable.Columns[0]; expensesColumn.DataSource = dtColumns;
            var revenueColumn = (DataGridViewComboBoxColumn)expRevDataTable.Columns[1]; revenueColumn.DataSource = dtColumns;
            var profitColumn = (DataGridViewComboBoxColumn)profTaxDataTable.Columns[0]; profitColumn.DataSource = dtColumns;
            var taxColumn = (DataGridViewComboBoxColumn)profTaxDataTable.Columns[1]; taxColumn.DataSource = dtColumns;
            var balanceColumn = (DataGridViewComboBoxColumn)balanceDataTable.Columns[1]; balanceColumn.DataSource = dtColumns;
            var auditColumn = (DataGridViewComboBoxColumn)balanceDataTable.Columns[2]; auditColumn.DataSource = dtColumns;
            INNBox.DataSource = forINNColumns;
            ratingCombo.DataSource = forRatingColumns;
            balanceDataTable.Columns[0].ValueType = typeof(int);
            kzCombo.DataSource = forKzColumns;
            dzCombo.DataSource = forDzColumns;
            var yearColumn = (DataGridViewComboBoxColumn)balanceDataTable.Columns[0];
            for (int i = 0; i < 3; i++)
            {
                yearColumn.Items.Add(DateTime.Today.Year - i - 1);
            }
        }

        private void DataAnalysis_FormClosed(object sender, FormClosedEventArgs e)
        {
            foreach (Control control in form1.Controls)
            {
                control.Enabled = true;
            }
            form1.dataGridView1.ReadOnly = false;
        }

        private void compareExpProfButton_Click(object sender, EventArgs e)
        {
            int[] expensesColumns = new int[expRevDataTable.RowCount], revenueColumns = new int[expRevDataTable.RowCount];
            for(int i = 0; i < expRevDataTable.RowCount - 1; i++)
            {
                if (expRevDataTable[0, i].Value == null || expRevDataTable[1, i].Value == null)
                {
                    MessageBox.Show("Отсутствуют данные", "Ошибка", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    return;
                }
                expensesColumns[i] = form1.dataGridView1.Columns[expRevDataTable[0, i].Value.ToString()].Index;
                revenueColumns[i] = form1.dataGridView1.Columns[expRevDataTable[1, i].Value.ToString()].Index;
            }
            AnalysisMethods.CompareExpensesAndRevenue(form1.dataGridView1, expensesColumns, revenueColumns);
        }

        private void liquidationButton_Click(object sender, EventArgs e)
        {
            if (simpleDataBox.SelectedIndex == 0) return;
            AnalysisMethods.CheckRedGreen(form1.dataGridView1, form1.dataGridView1.Columns[simpleDataBox.SelectedItem.ToString()].Index, compareValues);
            for(int i = 0; i < form1.dataGridView1.RowCount - 1; i++)
            {
                if (form1.dataGridView1[form1.dataGridView1.Columns[simpleDataBox.SelectedItem.ToString()].Index, i].Style.BackColor == Color.FromArgb(255, 128, 128) && !redRows.Contains(i))
                    redRows.Add(i);
            }
            excludedColumns.Add(form1.dataGridView1.Columns[simpleDataBox.SelectedItem.ToString()].Index);
        }

        private void massDataButton_Click(object sender, EventArgs e)
        {
            if (simpleDataBox.SelectedIndex == 0) return;
            AnalysisMethods.CheckYellowGreen(form1.dataGridView1, form1.dataGridView1.Columns[simpleDataBox.SelectedItem.ToString()].Index, compareValues);
        }

        private void terrButton_Click(object sender, EventArgs e)
        {
            if (simpleDataBox.SelectedIndex == 0) return;
            AnalysisMethods.CheckRedGreen(form1.dataGridView1, form1.dataGridView1.Columns[simpleDataBox.SelectedItem.ToString()].Index, compareValues);
            for (int i = 0; i < form1.dataGridView1.RowCount - 1; i++)
            {
                if (form1.dataGridView1[form1.dataGridView1.Columns[simpleDataBox.SelectedItem.ToString()].Index, i].Style.BackColor == Color.FromArgb(255, 128, 128) && !redRows.Contains(i))
                    redRows.Add(i);
            }
            excludedColumns.Add(form1.dataGridView1.Columns[simpleDataBox.SelectedItem.ToString()].Index);
        }

        private void compareTaxButton_Click(object sender, EventArgs e)
        {
            int[] taxesColumns = new int[profTaxDataTable.RowCount], profitsColumns = new int[profTaxDataTable.RowCount];
            for (int i = 0; i < profTaxDataTable.RowCount - 1; i++)
            {
                if (profTaxDataTable[0, i].Value == null || profTaxDataTable[1, i].Value == null)
                {
                    MessageBox.Show("Отсутствуют данные", "Ошибка", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    return;
                }
                profitsColumns[i] = form1.dataGridView1.Columns[profTaxDataTable[0, i].Value.ToString()].Index;
                taxesColumns[i] = form1.dataGridView1.Columns[profTaxDataTable[1, i].Value.ToString()].Index;
            }
            AnalysisMethods.CompareTaxAndProfit(form1.dataGridView1, profitsColumns, taxesColumns);
        }

        private void localRadio_CheckedChanged(object sender, EventArgs e)
        {
            if (localRadio.Checked)
            {
                INNBox.Enabled = false;
                netRadio.Checked = false;
                balanceCompareBox.Enabled = true;
            }
        }

        private void netRadio_CheckedChanged(object sender, EventArgs e)
        {
            if (netRadio.Checked)
            {
                INNBox.Enabled = true;
                localRadio.Checked = false;
                balanceCompareBox.Enabled = false;
            }
        }

        private void balanceButton_Click(object sender, EventArgs e)
        {
            int[] balanceColumns = new int[balanceDataTable.RowCount], auditColumns = new int[balanceDataTable.RowCount];
            int divider = 1;
            switch (rubBox.SelectedIndex)
            {
                case 0:
                    divider = 1000000;
                    break;
                case 1:
                    divider = 1000;
                    break;
            }
            if (localRadio.Checked)
            {
                for (int i = 0; i < balanceDataTable.RowCount - 1; i++)
                {
                    if (balanceDataTable[0, i].Value == null || balanceDataTable[1, i].Value == null)
                    {
                        MessageBox.Show("Отсутствуют данные", "Ошибка", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                        return;
                    }
                    balanceColumns[i] = form1.dataGridView1.Columns[balanceDataTable[0, i].Value.ToString()].Index;
                    auditColumns[i] = form1.dataGridView1.Columns[balanceDataTable[1, i].Value.ToString()].Index;
                }
                AnalysisMethods.CompareBalanceWithAudit(form1.dataGridView1, balanceColumns, divider, auditColumns, !string.IsNullOrEmpty(balanceCompareBox.Text) ? balanceCompareBox.Text : "Нет");
            }
            else if (netRadio.Checked)
            {
                if (INNBox.SelectedIndex == 0) return;
                string[] inns = new string[form1.dataGridView1.RowCount - 1];
                for (int i = 0; i < balanceDataTable.RowCount - 1; i++) 
                {
                    if (balanceDataTable[0, i] == null)
                    {
                        MessageBox.Show("Отсутствуют данные", "Ошибка", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                        return;
                    }
                    balanceColumns[i] = form1.dataGridView1.Columns[balanceDataTable[1, i].Value.ToString()].Index;
                } 
                for (int i = 0; i < form1.dataGridView1.RowCount - 1; i++) inns[i] = form1.dataGridView1.Rows[i].Cells[(string)INNBox.SelectedValue].Value.ToString();
                int[] years = new int[balanceDataTable.RowCount - 1];
                for (int i = 0; i < balanceDataTable.RowCount - 1; i++) years[i] = (int)balanceDataTable[0, i].Value;
                this.Enabled = false;
                AnalysisMethods.CompareBalanceWithAudit(this,form1.dataGridView1, balanceColumns, divider, inns, years);
            }
        }

        private void ratingCalculateRadio_CheckedChanged(object sender, EventArgs e)
        {
            if (ratingCalculateRadio.Checked)
            {
                dataRadio.Checked = false;
                ratingGreenBox.Enabled = false;
                ratingRedBox.Enabled = false;
                ratingYellowBox.Enabled = false;
            }
        }

        private void dataRadio_CheckedChanged(object sender, EventArgs e)
        {
            if(dataRadio.Checked)
            {
                ratingCalculateRadio.Checked = false;
                ratingGreenBox.Enabled = true;
                ratingRedBox.Enabled=true;
                ratingYellowBox.Enabled=true;
            }
        }

        private void ratingButton_Click(object sender, EventArgs e)
        {
            if (ratingCombo.SelectedIndex == 0) return;
            int index = form1.dataGridView1.Columns[ratingCombo.SelectedItem.ToString()].Index;
            if (ratingCalculateRadio.Checked)
            {
                for (int i = 0; i < form1.dataGridView1.Rows.Count - 1; i++)
                {
                    if (redRows.Contains(i))
                    {
                        form1.dataGridView1[index, i].Style.BackColor = Color.FromArgb(255, 128, 128);
                        form1.dataGridView1[index, i].Value = "Ненадёжный";
                        continue;
                    }
                    int redCount = 0, yellowCount = 0, greenCount = 0;
                    for (int j = 0; j < form1.dataGridView1.ColumnCount; j++)
                    {
                        if (j == index || excludedColumns.Contains(j)) continue;
                        if (form1.dataGridView1[j, i].Style.BackColor == Color.FromArgb(128, 255, 128))greenCount++;
                        else if(form1.dataGridView1[j, i].Style.BackColor == Color.FromArgb(255, 128, 128))redCount++;
                        else if(form1.dataGridView1[j, i].Style.BackColor == Color.FromArgb(243, 255, 74))yellowCount++;
                    }
                    int sum = redCount + yellowCount + greenCount;
                    int minMax = sum / 6; int diff = greenCount - redCount;
                    if(diff < -minMax)
                    {
                        form1.dataGridView1[index, i].Style.BackColor = Color.FromArgb(255, 128, 128);
                        form1.dataGridView1[index, i].Value = "Ненадёжный";
                    }
                    else if(diff >= -minMax && diff <= minMax)
                    {
                        form1.dataGridView1[index, i].Style.BackColor = Color.FromArgb(243, 255, 74);
                        form1.dataGridView1[index, i].Value = "Сомнительный";
                    }
                    else
                    {
                        form1.dataGridView1[index, i].Style.BackColor = Color.FromArgb(128, 255, 128);
                        form1.dataGridView1[index, i].Value = "Надёжный";
                    }
                }
            }
            else if (dataRadio.Checked)
            {
                for (int i = 0; i < form1.dataGridView1.Rows.Count - 1; i++)
                {
                    if ((form1.dataGridView1[index, i].Value.ToString() == ratingGreenBox.Text && string.IsNullOrEmpty(ratingGreenBox.Text))
                || form1.dataGridView1[index, i].Value.ToString() == "Надёжный"
                || form1.dataGridView1[index, i].Value.ToString() == "надёжный"
                || form1.dataGridView1[index, i].Value.ToString() == "Высокий"
                || form1.dataGridView1[index, i].Value.ToString() == "высокий")
                    {
                        form1.dataGridView1[index, i].Style.BackColor = Color.FromArgb(128, 255, 128);
                        continue;
                    }
                    else if ((form1.dataGridView1[index, i].Value.ToString() == ratingYellowBox.Text && string.IsNullOrEmpty(ratingYellowBox.Text))
                        || form1.dataGridView1[index, i].Value.ToString() == "Сомнительный"
                        || form1.dataGridView1[index, i].Value.ToString() == "сомнительный"
                        || form1.dataGridView1[index, i].Value.ToString() == "Средний"
                        || form1.dataGridView1[index, i].Value.ToString() == "средний")
                    {
                        form1.dataGridView1[index, i].Style.BackColor = Color.FromArgb(243, 255, 74);
                        continue;
                    }
                    else if ((form1.dataGridView1[index, i].Value.ToString() == ratingRedBox.Text && string.IsNullOrEmpty(ratingRedBox.Text))
                        || form1.dataGridView1[index, i].Value.ToString() == "Ненадёжный"
                        || form1.dataGridView1[index, i].Value.ToString() == "ненадёжный"
                        || form1.dataGridView1[index, i].Value.ToString() == "Низкий"
                        || form1.dataGridView1[index, i].Value.ToString() == "низкий")
                    {
                        form1.dataGridView1[index, i].Style.BackColor = Color.FromArgb(255, 128, 128);
                        continue;
                    }
                    else
                    {
                        form1.dataGridView1[index, i].Style.BackColor = Color.FromArgb(128, 128, 255);
                        continue;
                    }
                }
            }
            MessageBox.Show("Готово", "Конец операции", MessageBoxButtons.OK, MessageBoxIcon.Information);
        }

        private void staffsButton_Click(object sender, EventArgs e)
        {
            if (simpleDataBox.SelectedIndex == 0) return;
            AnalysisMethods.CheckStaffCount(form1.dataGridView1, form1.dataGridView1.Columns[simpleDataBox.SelectedItem.ToString()].Index);
        }

        private void dzkzButton_Click(object sender, EventArgs e)
        {
            if(dzCombo.SelectedIndex == 0 || kzCombo.SelectedIndex == 0) return;
            AnalysisMethods.CompareDzKz(form1.dataGridView1, form1.dataGridView1.Columns[dzCombo.SelectedItem.ToString()].Index, form1.dataGridView1.Columns[kzCombo.SelectedItem.ToString()].Index);
        }

        private void compareValueTable_KeyDown(object sender, KeyEventArgs e)
        {
            if(compareValueTable.Rows.Count == 1) return;
            if (e.KeyCode == Keys.Delete && compareValueTable.SelectedCells != null)
            {
                foreach(DataGridViewRow row in compareValueTable.Rows)
                {
                    if (compareValueTable.SelectedCells.Contains(row.Cells[0]) && row.Cells[0].Value != null)
                    {
                        compareValueTable.Rows.Remove(row);
                        compareValues.RemoveAt(row.Index + 1);
                    }
                }
            }
        }
        private void compareValueTable_CellEndEdit(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex >= compareValues.Count) compareValues.Add(compareValueTable[0, e.RowIndex].EditedFormattedValue.ToString());
            else compareValues[e.RowIndex] = compareValueTable[0, e.RowIndex].EditedFormattedValue.ToString();
        }
    }
}
