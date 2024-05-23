using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Diagnostics;
using System.Drawing;
using System.Linq;
using System.Net.Http;
using System.Security.Policy;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Windows.Media.Animation;
using System.Windows.Threading;
using CefSharp;
using CefSharp.DevTools.Debugger;
using CefSharp.DevTools.Runtime;
using CefSharp.WinForms;
using HtmlAgilityPack;
using Newtonsoft.Json.Linq;
using HtmlDocument = HtmlAgilityPack.HtmlDocument;

namespace PracticeCapital_ByNikitaRasputin
{
    public partial class GetDataFromNetDB : Form
    {
        private List<string> savedUrls = new List<string>();
        private int urlPosition = 0;
        private DataTable dataTable = new DataTable();
        private List<string> inns = new List<string>();
        private CancellationTokenSource cancelTokenSource = new CancellationTokenSource();
        private CancellationToken token;
        private Thread thread;
        public Form1 form1;
        string html;
        public GetDataFromNetDB()
        {
            InitializeComponent();
            dataGridView1.DataSource = dataTable;
            chromiumWebBrowser1.LifeSpanHandler = new OpenPageSelf();
            chromiumWebBrowser1.Load("yandex.ru");
            savedUrls.Add("yandex.ru");
        }

        private void button1_Click(object sender, EventArgs e)
        {

        }
        public IEnumerable<string> HtmlAgilityPackParse(string html)
        {
            HtmlDocument hap = new HtmlDocument();
            hap.LoadHtml(html);
            HtmlNodeCollection nodes = hap
                .DocumentNode
                .SelectNodes("//div[@class = 'itm-content']");

            List<string> hrefTags = new List<string>();

            if (nodes != null)
            {
                foreach (HtmlNode node in nodes)
                {
                    hrefTags.Add(node.InnerText);
                }
            }

            return hrefTags;
        }
        private void GetDataFromNetDB_FormClosed(object sender, FormClosedEventArgs e)
        {
            form1.Enabled = true;
            chromiumWebBrowser1.Dispose();
        }
        private async void button3_Click(object sender, EventArgs e)
        {
            var script = @"document.getElementById('queryAll').value = '7715672846';
                           var elements = document.querySelectorAll('button[type=submit]')
                           elements[0].click();";
            try
            {
                chromiumWebBrowser1.ExecuteScriptAsyncWhenPageLoaded(script);
                while(true)
                {
                    await Dispatcher.CurrentDispatcher.BeginInvoke((Action)(async () =>
                    {
                        html = await chromiumWebBrowser1.GetSourceAsync();
                    }));
                    HtmlDocument document = new HtmlDocument();
                    document.LoadHtml(html);
                    HtmlNodeCollection nodes = document.DocumentNode.SelectNodes("//dd");
                    bool found = false;
                    if(nodes !=  null) for(int i = 0; i < nodes.Count; i++)
                        {
                            if (nodes[i].InnerText == "7715672846")
                            {
                                found = true;
                            }
                        }
                    if (found) break;
                }
                script = @"var elements = document.getElementsByTagName('dd')
                           for(var i = 0; i < elements.length; i++)
                           {
                               if(elements[i].textContent == '7715672846') {elements[i].click(); break; }
                           }";
                chromiumWebBrowser1.ExecuteScriptAsyncWhenPageLoaded(script);
            }
            catch(Exception ex)
            {
                MessageBox.Show($"Error: {ex.Message}");
            }

        }
        private void GetDataFromNetDB_Load(object sender, EventArgs e)
        {
            if(form1.dataTable != null)
                for (int i = 0; i < form1.dataTable.Columns.Count; i++)
                {
                    INNBox.Items.Add(form1.dataTable.Columns[i].ColumnName);
                }
            for (int i = 0; i < form1.dataTable.Columns.Count; i++)
            {
                DataGridViewRow row = (DataGridViewRow)dataGridView2.Rows[0].Clone();
                row.Cells[0].Value = form1.dataTable.Columns[i].ColumnName;
                dataGridView2.Rows.Add(row);
            }
            fillTypeCombo.SelectedIndex = 0;
            var comboColumn = (DataGridViewComboBoxColumn)dataGridView2.Columns[1];
            comboColumn.Items.Insert(0, "нет");
            comboColumn.DefaultCellStyle.NullValue = "нет";
        }
        private void addButton_Click(object sender, EventArgs e)
        {
            dataTable.Columns.Add("ИНН", typeof(string));
            for (int i = 0; i < form1.dataTable.Rows.Count; i++)
            {
                inns.Add(form1.dataTable.Rows[i][INNBox.SelectedIndex].ToString());
                DataRow row = dataTable.NewRow();
                row[0] = form1.dataTable.Rows[i][INNBox.SelectedIndex].ToString();
                dataTable.Rows.Add(row);
            }
            MessageBox.Show(string.Join(", ", inns));
            addButton.Enabled = false;
            searchButton.Enabled = true;
            GovDBBox.Enabled = true;
        }

        private void searchButton_Click(object sender, EventArgs e)
        {
            token = cancelTokenSource.Token;
            try
            {
                switch (GovDBBox.SelectedIndex)
                {
                    case 0:
                        browserCheck.Checked = false;
                        GovDBDataGathering.BFONalog(inns, dataTable, browserCheck, token);
                        break;
                    case 1:
                        browserCheck.Checked = false;
                        GovDBDataGathering.FindOrg(inns, dataTable, chromiumWebBrowser1, browserCheck, token);
                        break;
                    case 2:
                        browserCheck.Checked = false;
                        GovDBDataGathering.ListOrg(inns, dataTable, chromiumWebBrowser1, browserCheck, token);
                        break;
                    case 3:
                        browserCheck.Checked = false;
                        GovDBDataGathering.Terrorists(inns, dataTable, chromiumWebBrowser1, browserCheck, token);
                        break;
                    case 4:
                        browserCheck.Checked = false;
                        MessageBox.Show("У данного сервиса ограниченное количество запросов у неавторизованных пользователей. Авторизуйтесь на сайте и после этого нажмите кнопку Начать");
                        try
                        {
                            chromiumWebBrowser1.LoadUrlAsync("https://kad.arbitr.ru");
                        }
                        catch
                        {
                            MessageBox.Show("Не удалось подключиться к сервису. Проверьте ваше интернет соединение или обратитесь к тех. специалисту.");
                        }
                        startButton.Enabled = true;
                        break;
                    case 5:
                        browserCheck.Checked = false;
                        GovDBDataGathering.ClearBusiness(inns, dataTable, chromiumWebBrowser1, browserCheck, token);
                        break;
                    case 6:
                        browserCheck.Checked = false;
                        GovDBDataGathering.ForFairBussiness(inns, dataTable, chromiumWebBrowser1, browserCheck, token);
                        break;
                }
            }
            catch
            {
                MessageBox.Show("Произошла ошибка, попробуйте еще раз");
            }
        }
        private void chromiumWebBrowser1_LoadingStateChanged(object sender, LoadingStateChangedEventArgs e)
        {
            if (!e.IsLoading)
            {
                Dispatcher.CurrentDispatcher.BeginInvoke((Action)(async () =>
                {
                    html = await chromiumWebBrowser1.GetSourceAsync();
                }));
            }
        }

        private void startButton_Click(object sender, EventArgs e)
        {
            switch (GovDBBox.SelectedIndex)
            {
                case 4:
                    GovDBDataGathering.Arbitr(inns, dataTable, chromiumWebBrowser1, browserCheck, token);
                    break;
            }
            startButton.Enabled = false;
        }

        private async void goButton_Click(object sender, EventArgs e)
        {
            try
            {
                chromiumWebBrowser1.Load(urlBox.Text);
                while (chromiumWebBrowser1.IsLoading)
                {
                    await Task.Delay(100);
                }
                HtmlDocument doc = new HtmlDocument(); doc.LoadHtml(await chromiumWebBrowser1.GetSourceAsync());
                if (doc.DocumentNode.SelectSingleNode("//body").ChildNodes.Count == 0) 
                {
                    urlBox.Text = "https://yandex.ru/search/?text=" + urlBox.Text;
                    chromiumWebBrowser1.Load(urlBox.Text);
                } 
            }
            catch
            {
                MessageBox.Show("Не удалось подключиться. Проверьте ваше интернет-соединение или обратитесь к тех. специалисту.");
            }
        }

        private void refreshButton_Click(object sender, EventArgs e)
        {
            chromiumWebBrowser1.Reload();
        }

        private void backPageButton_Click(object sender, EventArgs e)
        {
            if (chromiumWebBrowser1.CanGoBack) chromiumWebBrowser1.Back();
        }

        private void goPageButton_Click(object sender, EventArgs e)
        {
            if(chromiumWebBrowser1.CanGoForward) chromiumWebBrowser1.Forward();
        }
        private void TurnOnOffElements(bool turn)
        {
            stopButton.Enabled = !turn;
            chromiumWebBrowser1.Enabled = turn;
            backPageButton.Enabled= turn;
            goPageButton.Enabled = turn;
            refreshButton.Enabled = turn;
            urlBox.Enabled = turn;
            goButton.Enabled = turn;
            INNBox.Enabled = turn;
            GovDBBox.Enabled = turn;
            searchButton.Enabled = turn;
            dataGridView1.ReadOnly = !turn;
            fillTypeCombo.Enabled = turn;
            dataGridView2.Enabled = turn;
            finalButton.Enabled = turn;
            clearDataTableButton.Enabled = turn;
        }

        private void browserCheck_CheckedChanged(object sender, EventArgs e)
        {
            TurnOnOffElements(browserCheck.Checked);
        }

        private void GovDBBox_SelectedIndexChanged(object sender, EventArgs e)
        {
            startButton.Enabled = false;
            browserCheck.Checked = true;
        }

        private void chromiumWebBrowser1_AddressChanged(object sender, AddressChangedEventArgs e)
        {
            try
            {
                this.Invoke(new Action(() => urlBox.Text = e.Address));
            }
            catch
            {
                return;
            }
        }

        private void dataGridView1_ColumnAdded(object sender, DataGridViewColumnEventArgs e)
        {
            var comboColumn = (DataGridViewComboBoxColumn)dataGridView2.Columns[1];
            if(!comboColumn.Items.Contains(e.Column.Name) && e.Column.Name != "ИНН") comboColumn.Items.Add(e.Column.Name);
        }
        private void dataGridView1_ColumnRemoved(object sender, DataGridViewColumnEventArgs e)
        {
            var comboColumn = (DataGridViewComboBoxColumn)dataGridView2.Columns[1];
            if (comboColumn.Items.Contains(e.Column.Name) && e.Column.Name != "ИНН") comboColumn.Items.Remove(e.Column.Name);
        }
        private void finalButton_Click(object sender, EventArgs e)
        {
            for (int i = 0; i < dataTable.Rows.Count; i++)
            {
                DataRow newRow = form1.dataTable.Rows[i];
                for (int j = 0; j < dataGridView2.Rows.Count - 1; j++)
                {
                    if (!string.IsNullOrEmpty(newRow[j].ToString()) && fillTypeCombo.SelectedIndex == 1) continue;
                    if (dataGridView2[1, j].Value != null && (string)dataGridView2[1, j].Value != "нет")
                    {
                        var newData = dataGridView1[(string)dataGridView2[1, j].Value, i].Value;
                        if (string.IsNullOrEmpty(newData.ToString()))
                        {
                            newData = 0;
                        }
                        newRow[j] = newData;
                    }
                }
            }
            for(int i = 0; i < dataGridView2.Rows.Count; i++)
            {
                if(dataGridView2.Rows[i].Cells[1].Value != null)
                    switch (dataGridView2.Rows[i].Cells[1].Value.ToString())
                    {
                        case "Кол-во судебных дел":
                            AnalysisMethods.CheckYellowGreen(form1.dataGridView1, i, compareValue: "Найдено 0 дел");
                            break;
                        case "Причина ликвидации":
                        case "Массовый учредитель":
                        case "Массовый руководитель":
                        case "Массовый адрес":
                        case "Причастность к терроризму":
                            AnalysisMethods.CheckRedGreen(form1.dataGridView1, i);
                            break;
                    }
            }
            this.Close();
        }

        private void stopButton_Click(object sender, EventArgs e)
        {
            cancelTokenSource.Cancel();
            cancelTokenSource.Dispose();
            cancelTokenSource = new CancellationTokenSource();
            TurnOnOffElements(true);
        }

        private void clearDataTableButton_Click(object sender, EventArgs e)
        {
            if(dataTable.Rows.Count == 0) return;
            while(dataTable.Columns.Count != 1)
            {
                dataTable.Columns.RemoveAt(1);
            }
        }


    }
    internal class OpenPageSelf : ILifeSpanHandler
    {
        public bool DoClose(IWebBrowser browserControl, IBrowser browser)
        {
            return false;
        }

        public void OnAfterCreated(IWebBrowser browserControl, IBrowser browser)
        {

        }

        public void OnBeforeClose(IWebBrowser browserControl, IBrowser browser)
        {

        }

        public bool OnBeforePopup(IWebBrowser browserControl, IBrowser browser, IFrame frame, string targetUrl,
            string targetFrameName, WindowOpenDisposition targetDisposition, bool userGesture, IPopupFeatures popupFeatures,
            IWindowInfo windowInfo, IBrowserSettings browserSettings, ref bool noJavascriptAccess, out IWebBrowser newBrowser)
        {
            newBrowser = null;
            var chromiumWebBrowser = (ChromiumWebBrowser)browserControl;
            chromiumWebBrowser.Load(targetUrl);
            return true; //Return true to cancel the popup creation copyright by codebye.com.
        }
    }
}
