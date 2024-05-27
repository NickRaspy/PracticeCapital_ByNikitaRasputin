using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.Common;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace PracticeCapital_ByNikitaRasputin
{
    public partial class AddRemoveColumns : Form
    {
        public Form1 form1;
        public AddRemoveColumns()
        {
            InitializeComponent();
        }

        private void deleteButton_Click(object sender, EventArgs e)
        {
            if (columnNamesTable.SelectedCells.Count == 0 || columnNamesTable.Rows.Count == 1) { MessageBox.Show("Выберите заголовки в списке.", "Ошибка", MessageBoxButtons.OK, MessageBoxIcon.Warning); return; }
            foreach(DataGridViewCell cell in columnNamesTable.SelectedCells)
            {
                columnNamesTable.Rows.RemoveAt(cell.RowIndex);
            }
        }

        private void columnNamesTable_KeyDown(object sender, KeyEventArgs e)
        {
            if (columnNamesTable.Rows.Count == 1) return;
            if (e.KeyCode == Keys.Delete && columnNamesTable.SelectedCells.Count > 0)
            {
                foreach (DataGridViewCell cell in columnNamesTable.SelectedCells)
                {
                    columnNamesTable.Rows.RemoveAt(cell.RowIndex);
                }
            }
        }

        private void AddRemoveColumns_FormClosed(object sender, FormClosedEventArgs e)
        {
            form1.Enabled = true;
        }

        private void AddRemoveColumns_Load(object sender, EventArgs e)
        {
            columnNamesTable.Rows[0].Cells[1].Value = "Текстовый";
            if (form1.dataTable.Columns.Count > 0)
            {
                for (int i = 0; i < form1.dataTable.Columns.Count; i++)
                {
                    DataGridViewRow row = (DataGridViewRow)columnNamesTable.Rows[0].Clone();
                    row.Cells[0].Value = form1.dataTable.Columns[i].ColumnName;
                    if (form1.dataTable.Columns[i].DataType == typeof(double)) row.Cells[1].Value = "Числовой";
                    else row.Cells[1].Value = "Текстовый";
                    columnNamesTable.Rows.Add(row);
                }
            }
        }

        private void completeButton_Click(object sender, EventArgs e)
        {
            if(form1.dataTable.Columns.Count > 0)
            {
                List<string> names = new List<string>();
                for (int i = 0; i < columnNamesTable.Rows.Count - 1; i++) names.Add(columnNamesTable[0, i].Value.ToString());
                DataTable temp = form1.dataTable.Copy();
                foreach (DataColumn column in temp.Columns)
                {
                    if (!names.Contains(column.ColumnName)) form1.dataTable.Columns.RemoveAt(form1.dataTable.Columns.IndexOf(column.ColumnName));
                }
            }
            try
            {
                for (int i = 0; i < columnNamesTable.Rows.Count - 1; i++)
                {
                    if(columnNamesTable.Rows[i].Cells[0].Value == null) continue;
                    if (form1.dataTable.Columns.IndexOf(columnNamesTable.Rows[i].Cells[0].Value.ToString()) == -1)
                    {
                        form1.dataTable.Columns.Add(columnNamesTable.Rows[i].Cells[0].Value.ToString(), columnNamesTable.Rows[i].Cells[1].Value.ToString() == "Текстовый" ? typeof(string) : typeof(double));
                    }
                }
            }
            catch
            {
                MessageBox.Show("Столбцы не должны быть одинаковыми!");
            }
            if(form1.dataTable.Columns.Count > 0)
            {
                form1.GetColumns();
                form1.secondaryTableButton.Enabled = true;
                form1.webDataButton.Enabled = true;
                form1.dataSaveButton.Enabled = true;
                form1.analysisButton.Enabled = true;
                form1.columnClearButton.Enabled = true;
            }
            this.Close();
        }

        private void columnNamesTable_RowsAdded(object sender, DataGridViewRowsAddedEventArgs e)
        {
            if(columnNamesTable.Rows[e.RowIndex].Cells[1].Value == null) columnNamesTable.Rows[e.RowIndex].Cells[1].Value = "Текстовый";
        }
    }
}
