using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using OfficeOpenXml;
using Newtonsoft.Json;
using Newtonsoft.Json.Linq;
using System.IO;
using System.Net;
using System.Web;

namespace PracticeCapital_ByNikitaRasputin
{
    public partial class Form1 : Form
    {
        private List<string> columns = new List<string>();
        public string testString;
        public DataTable dataTable = new DataTable();
        public Form1()
        {
            InitializeComponent();
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            string dir = $"C:/Users/{Environment.UserName}/Documents/ContragentDataGatherer";
            string path = Path.Combine(dir,"errorstack.txt");
            if (!Directory.Exists(dir)) Directory.CreateDirectory(dir);
            if(!File.Exists(path)) File.Create(path);
            dataGridView1.DataSource = dataTable;
            columnBox.Items.Add("нет");
            columnBox.SelectedIndex = 0;
        }
        public void GetColumns()
        {
            columnBox.Items.Clear();
            columnBox.Items.Add("нет");
            columnBox.SelectedIndex = 0;
            for (int i = 0; i < dataTable.Columns.Count; i++)
            {
                columnBox.Items.Add(dataTable.Columns[i].ColumnName);
            }
        }
        private void tableButton_Click(object sender, EventArgs e)
        {
            TableAdd tableAdd = new TableAdd();
            tableAdd.Show();
            tableAdd.form1 = this;
            this.Enabled = false;
        }

        private void secondaryTableButton_Click(object sender, EventArgs e)
        {
            GetDataFromOtherTable getDataFromOtherTable = new GetDataFromOtherTable();
            getDataFromOtherTable.form1 = this;
            getDataFromOtherTable.Show();
            this.Enabled = false;
        }

        private void button1_Click(object sender, EventArgs e)
        {
            GetDataFromNetDB getDataFromNetDB = new GetDataFromNetDB
            {
                form1 = this
            };
            getDataFromNetDB.Show();
            this.Enabled = false;
        }
        private void button1_Click_1(object sender, EventArgs e)
        {
            SaveExcel saveExcel = new SaveExcel() { form1 = this };
            saveExcel.Show();
            this.Enabled = false;
        }

        private void analysisButton_Click(object sender, EventArgs e)
        {
            DataAnalysis dataAnalysis = new DataAnalysis() {form1 = this };
            dataAnalysis.Show();
            foreach(Control control in this.Controls)
            {
                if(control != dataGridView1) control.Enabled = false;
            }
            this.dataGridView1.ReadOnly = true;
        }

        private void columnClearButton_Click(object sender, EventArgs e)
        {
            if (columnBox.SelectedIndex == 0) return;
            for (int i = 0; i < dataTable.Rows.Count; i++)
            {
                dataGridView1[columnBox.SelectedIndex - 1, i].Style.BackColor = Color.White;
            }
        }

        private void dataGridView1_ColumnAdded(object sender, DataGridViewColumnEventArgs e)
        {
            /*e.Column.SortMode = DataGridViewColumnSortMode.NotSortable;*/
        }

        private void addColumnsButton_Click(object sender, EventArgs e)
        {
            AddRemoveColumns addRemoveColumns = new AddRemoveColumns();
            addRemoveColumns.form1 = this;
            addRemoveColumns.Show();
            this.Enabled = false;
        }
    }
}
