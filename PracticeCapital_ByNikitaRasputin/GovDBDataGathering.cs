using Newtonsoft.Json.Linq;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Net.Http;
using System.Threading.Tasks;
using System.Windows.Forms;
using CefSharp;
using CefSharp.WinForms;
using HtmlAgilityPack;
using System.Windows.Threading;
using HtmlDocument = HtmlAgilityPack.HtmlDocument;
using CheckBox = System.Windows.Forms.CheckBox;
using System.Threading;
using System.Windows.Markup;

namespace PracticeCapital_ByNikitaRasputin
{
    public class GovDBDataGathering
    {
        public static async void BFONalog(List<string> inns, DataTable dataTable, CheckBox elementsState, CancellationToken token)
        {
            token.Register(() => { return; });
            if (!dataTable.Columns.Contains("Адрес")) dataTable.Columns.Add("Адрес", typeof(string));
            if (!dataTable.Columns.Contains("ОКВЭД")) dataTable.Columns.Add("ОКВЭД", typeof(string));
            if (!dataTable.Columns.Contains("Дата регистрации")) dataTable.Columns.Add("Дата регистрации", typeof(string));
            if (!dataTable.Columns.Contains("Баланс 1600 за прошлый год")) dataTable.Columns.Add("Баланс 1600 за прошлый год", typeof(double));
            if (!dataTable.Columns.Contains("Баланс 1600 2 года ранее")) dataTable.Columns.Add("Баланс 1600 2 года ранее", typeof(double));
            if (!dataTable.Columns.Contains("Баланс 1600 3 года ранее")) dataTable.Columns.Add("Баланс 1600 3 года ранее", typeof(double));
            if (!dataTable.Columns.Contains("Выручка 2110 за прошлый год")) dataTable.Columns.Add("Выручка 2110 за прошлый год", typeof(double));
            if (!dataTable.Columns.Contains("Выручка 2110 2 года ранее")) dataTable.Columns.Add("Выручка 2110 2 года ранее", typeof(double));
            if (!dataTable.Columns.Contains("Выручка 2110 3 года ранее")) dataTable.Columns.Add("Выручка 2110 3 года ранее", typeof(double));
            if (!dataTable.Columns.Contains("Расходы 2120 за прошлый год")) dataTable.Columns.Add("Расходы 2120 за прошлый год", typeof(double));
            if (!dataTable.Columns.Contains("Расходы 2120 2 года ранее")) dataTable.Columns.Add("Расходы 2120 2 года ранее", typeof(double));
            if (!dataTable.Columns.Contains("Расходы 2120 3 года ранее")) dataTable.Columns.Add("Расходы 2120 3 года ранее", typeof(double));
            if (!dataTable.Columns.Contains("Прибыль 2300 за прошлый год")) dataTable.Columns.Add("Прибыль 2300 за прошлый год", typeof(double));
            if (!dataTable.Columns.Contains("Прибыль 2300 2 года ранее")) dataTable.Columns.Add("Прибыль 2300 2 года ранее", typeof(double));
            if (!dataTable.Columns.Contains("Прибыль 2300 3 года ранее")) dataTable.Columns.Add("Прибыль 2300 3 года ранее", typeof(double));
            if (!dataTable.Columns.Contains("Налог на прибыль за прошлый год")) dataTable.Columns.Add("Налог на прибыль за прошлый год", typeof(double));
            if (!dataTable.Columns.Contains("Налог на прибыль 2 года ранее")) dataTable.Columns.Add("Налог на прибыль 2 года ранее", typeof(double));
            if (!dataTable.Columns.Contains("Аудиторское заключение прошлого года")) dataTable.Columns.Add("Аудиторское заключение прошлого года", typeof(string));
            if (!dataTable.Columns.Contains("Аудиторское заключение 2 летней давности")) dataTable.Columns.Add("Аудиторское заключение 2 летней давности", typeof(string));
            if (!dataTable.Columns.Contains("Аудиторское заключение 3 летней давности")) dataTable.Columns.Add("Аудиторское заключение 3 летней давности", typeof(string));
            int time = 0;
            int Calculate2300(JArray data, int pos)
            {
                int calc = 0;
                calc = Convert.ToInt32(data[pos]["correction"]["financialResult"]["current2110"]) 
                    - Convert.ToInt32(data[pos]["correction"]["financialResult"]["current2120"])
                    + Convert.ToInt32(data[pos]["correction"]["financialResult"]["current2340"])
                    - Convert.ToInt32(data[pos]["correction"]["financialResult"]["current2350"]);
                return calc;
            }
            for (int i = 0; i < inns.Count; i++)
            {
                using (HttpClient httpClient = new HttpClient())
                {
                    if (token.IsCancellationRequested) return;
                    string json = await httpClient.GetStringAsync($"https://bo.nalog.ru/advanced-search/organizations/search?query={inns[i]}&page=0");
                    while (json == null)
                    {
                        time = Timer(time, elementsState);
                        if (time >= 1000 || token.IsCancellationRequested) return;
                        if (json != null) break;
                    }
                    JObject search = JObject.Parse(json);
                    if (search["content"].Count() == 0) continue;
                    string id = search["content"][0]["id"].ToString();

                    if (string.IsNullOrEmpty(dataTable.Rows[i]["Дата регистрации"].ToString())) dataTable.Rows[i]["Дата регистрации"] = search["content"][0]["statusDate"].ToString();

                    json = await httpClient.GetStringAsync($"https://bo.nalog.ru/nbo/organizations/{id}/bfo/");
                    while (json == null)
                    {
                        time = Timer(time, elementsState);
                        if (time >= 1000 || token.IsCancellationRequested) return;
                        if (json != null) break;
                    }
                    JArray data = JArray.Parse(json);

                    if (string.IsNullOrEmpty(dataTable.Rows[i]["Адрес"].ToString())) dataTable.Rows[i]["Адрес"] = data[0]["organizationInfo"]["address"].ToString();
                    if (string.IsNullOrEmpty(dataTable.Rows[i]["ОКВЭД"].ToString())) dataTable.Rows[i]["ОКВЭД"] = data[0]["organizationInfo"]["okved2"]["id"].ToString() + " " + data[0]["organizationInfo"]["okved2"]["name"].ToString();

                    List<string> checkedYears = new List<string>();
                    for (int j = 0; j < 3; j++)
                    {
                        if (token.IsCancellationRequested) return;
                        if (j == data.Count) break;
                        if (data[j]["period"].ToString() == (DateTime.Now.Year - 1).ToString())
                        {
                            dataTable.Rows[i]["Баланс 1600 за прошлый год"] = data[j]["correction"]["balance"]["current1600"] ?? 0;
                            dataTable.Rows[i]["Выручка 2110 за прошлый год"] = data[j]["correction"]["financialResult"]["current2110"] ?? 0;
                            dataTable.Rows[i]["Расходы 2120 за прошлый год"] = data[j]["correction"]["financialResult"]["current2120"] ?? 0;
                            dataTable.Rows[i]["Прибыль 2300 за прошлый год"] = data[j]["correction"]["financialResult"]["current2300"] ?? 0;
                            if (Convert.ToInt32(dataTable.Rows[i]["Прибыль 2300 за прошлый год"]) == 0) dataTable.Rows[i]["Прибыль 2300 за прошлый год"] = Calculate2300(data, j);
                            dataTable.Rows[i]["Налог на прибыль за прошлый год"] = data[j]["correction"]["financialResult"]["current2410"] ?? 0;
                            dataTable.Rows[i]["Аудиторское заключение прошлого года"] = data[j]["correction"]["auditReport"] != null ? "Есть" : "Нет";
                            checkedYears.Add(data[j]["period"].ToString());
                        }
                        else if (!checkedYears.Contains((DateTime.Now.Year - 1).ToString()))
                        {
                            dataTable.Rows[i]["Баланс 1600 за прошлый год"] = 0;
                            dataTable.Rows[i]["Выручка 2110 за прошлый год"] = 0;
                            dataTable.Rows[i]["Расходы 2120 за прошлый год"] = 0;
                            dataTable.Rows[i]["Прибыль 2300 за прошлый год"] = 0;
                            dataTable.Rows[i]["Налог на прибыль за прошлый год"] = 0;
                            dataTable.Rows[i]["Аудиторское заключение прошлого года"] = "Нет";
                        }

                        if (data[j]["period"].ToString() == (DateTime.Now.Year - 2).ToString())
                        {
                            dataTable.Rows[i]["Баланс 1600 2 года ранее"] = data[j]["correction"]["balance"]["current1600"] ?? 0;
                            dataTable.Rows[i]["Выручка 2110 2 года ранее"] = data[j]["correction"]["financialResult"]["current2110"] ?? 0;
                            dataTable.Rows[i]["Расходы 2120 2 года ранее"] = data[j]["correction"]["financialResult"]["current2120"] ?? 0;
                            dataTable.Rows[i]["Прибыль 2300 2 года ранее"] = data[j]["correction"]["financialResult"]["current2300"] ?? 0;
                            if (Convert.ToInt32(dataTable.Rows[i]["Прибыль 2300 2 года ранее"]) == 0) dataTable.Rows[i]["Прибыль 2300 2 года ранее"] = Calculate2300(data, j);
                            dataTable.Rows[i]["Налог на прибыль 2 года ранее"] = data[j]["correction"]["financialResult"]["current2410"] ?? 0;
                            dataTable.Rows[i]["Аудиторское заключение 2 летней давности"] = data[j]["correction"]["auditReport"] != null ? "Есть" : "Нет";
                            checkedYears.Add(data[j]["period"].ToString());
                        }
                        else if (!checkedYears.Contains((DateTime.Now.Year - 2).ToString()))
                        {
                            dataTable.Rows[i]["Баланс 1600 2 года ранее"] = 0;
                            dataTable.Rows[i]["Выручка 2110 2 года ранее"] = 0;
                            dataTable.Rows[i]["Расходы 2120 2 года ранее"] = 0;
                            dataTable.Rows[i]["Прибыль 2300 2 года ранее"] = 0;
                            dataTable.Rows[i]["Налог на прибыль 2 года ранее"] = 0;
                            dataTable.Rows[i]["Аудиторское заключение 2 летней давности"] = "Нет";
                        }

                        if (data[j]["period"].ToString() == (DateTime.Now.Year - 3).ToString())
                        {
                            dataTable.Rows[i]["Баланс 1600 3 года ранее"] = data[j]["correction"]["balance"]["current1600"] ?? 0;
                            dataTable.Rows[i]["Выручка 2110 3 года ранее"] = data[j]["correction"]["financialResult"]["current2110"] ?? 0;
                            dataTable.Rows[i]["Расходы 2120 3 года ранее"] = data[j]["correction"]["financialResult"]["current2120"] ?? 0;
                            dataTable.Rows[i]["Прибыль 2300 3 года ранее"] = data[j]["correction"]["financialResult"]["current2300"] ?? 0;
                            if (Convert.ToInt32(dataTable.Rows[i]["Прибыль 2300 3 года ранее"]) == 0) dataTable.Rows[i]["Прибыль 2300 3 года ранее"] = Calculate2300(data, j);
                            dataTable.Rows[i]["Аудиторское заключение 3 летней давности"] = data[j]["correction"]["auditReport"] != null ? "Есть" : "Нет";
                            checkedYears.Add(data[j]["period"].ToString());
                        }
                        else if (!checkedYears.Contains((DateTime.Now.Year - 3).ToString()))
                        {
                            dataTable.Rows[i]["Баланс 1600 3 года ранее"] = 0;
                            dataTable.Rows[i]["Выручка 2110 3 года ранее"] = 0;
                            dataTable.Rows[i]["Расходы 2120 3 года ранее"] = 0;
                            dataTable.Rows[i]["Прибыль 2300 3 года ранее"] = 0;
                            dataTable.Rows[i]["Аудиторское заключение 3 летней давности"] = "Нет";
                        }
                    }
                }
            }
            MessageBox.Show("Поиск завершен", "Конец операции", MessageBoxButtons.OK, MessageBoxIcon.Information);
            elementsState.Checked = true;
        }
        public static async void ClearBusiness(List<string> inns, DataTable dataTable, ChromiumWebBrowser browser, CheckBox elementsState, CancellationToken token)
        {
            token.Register(() => { return; });
            if (!dataTable.Columns.Contains("Адрес")) dataTable.Columns.Add("Адрес", typeof(string));
            if (!dataTable.Columns.Contains("ОКВЭД")) dataTable.Columns.Add("ОКВЭД", typeof(string));
            if (!dataTable.Columns.Contains("Дата регистрации")) dataTable.Columns.Add("Дата регистрации", typeof(string));
            if (!dataTable.Columns.Contains("Статус компании")) dataTable.Columns.Add("Статус компании", typeof(string));
            if (!dataTable.Columns.Contains("Дата ликвидации")) dataTable.Columns.Add("Дата ликвидации", typeof(string));
            if (!dataTable.Columns.Contains("Причина ликвидации")) dataTable.Columns.Add("Причина ликвидации", typeof(string));
            if (!dataTable.Columns.Contains("Численность сотрудников в прошлом году")) dataTable.Columns.Add("Численность сотрудников в прошлом году", typeof(double));
            if (!dataTable.Columns.Contains("Численность сотрудников 2 года ранее")) dataTable.Columns.Add("Численность сотрудников 2 года ранее", typeof(double));
            if (!dataTable.Columns.Contains("Численность сотрудников 3 года ранее")) dataTable.Columns.Add("Численность сотрудников 3 года ранее", typeof(double));
            if (!dataTable.Columns.Contains("Массовый руководитель")) dataTable.Columns.Add("Массовый руководитель", typeof(string));
            if (!dataTable.Columns.Contains("Массовый учредитель")) dataTable.Columns.Add("Массовый учредитель", typeof(string));
            /*            if (!dataTable.Columns.Contains("Массовый адрес")) dataTable.Columns.Add("Массовый адрес", typeof(string));*/
            if (!dataTable.Columns.Contains("Система налогообложения")) dataTable.Columns.Add("Система налогообложения", typeof(string));
            string html = "";
            int time = 0;
            HtmlDocument doc = new HtmlDocument();
            void CheckCaptcha(bool isChecked)
            {
                if (doc.DocumentNode.SelectSingleNode("//iframe[@class='iframe-content-outer']") != null)
                {
                    if (!browser.Enabled) MessageBox.Show("Пройдите каптчу", "Каптча", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                    browser.Enabled = true;
                    isChecked = true;
                }
                else isChecked = false;
            }
            for (int i = 0; i < inns.Count; i++)
            {
                if (token.IsCancellationRequested) return;
                time = 0;
                var script = "";
                bool isChecked = false;
                await browser.LoadUrlAsync($"https://pb.nalog.ru/search.html#queryAll={inns[i]}");
                while (true)
                {
                    html = await browser.GetSourceAsync();
                    doc.LoadHtml(html);
                    if (!isChecked) CheckCaptcha(isChecked);
                    HtmlNode node = doc.DocumentNode.SelectSingleNode("//div[@class='pb-card pb-card--clickable']");
                    if (node != null || (node == null && doc.DocumentNode.SelectSingleNode("//div[@data-group='no-data' and @class='pnl-search-result-group']") != null)) break;
                    time = Timer(time, elementsState);
                    if ((time >= 1000 && !isChecked) || token.IsCancellationRequested) 
                    {
                        return;
                    }
                    await Task.Delay(1);
                }
                time = 0;
                await Task.Delay(10000);
                if (token.IsCancellationRequested) return;
                if (doc.DocumentNode.SelectSingleNode("//div[@data-group='no-data' and @class='pnl-search-result-group']") != null) continue;
                browser.Enabled = false;
                script = $@"var elements = document.getElementsByClassName('pb-card pb-card--clickable');
                                elements[0].click();";
                browser.ExecuteScriptAsync(script);
                while (true)
                {
                    html = await browser.GetSourceAsync();
                    doc.LoadHtml(html);
                    if (!isChecked) CheckCaptcha(isChecked);
                    if (doc.DocumentNode.SelectSingleNode("//a[@data-appeal-kind=\"EGRUL_INN\"]") != null || doc.DocumentNode.SelectSingleNode("//a[@data-appeal-kind=\"EGRIP_INN\"]") != null) break;
                    time = Timer(time, elementsState);
                    if ((time >= 1000 && !isChecked) || token.IsCancellationRequested) return;
                    await Task.Delay(1);
                }
                time = 0;
                browser.Enabled = false;
                doc.LoadHtml(html);
                if (string.IsNullOrEmpty(dataTable.Rows[i]["Адрес"].ToString())) dataTable.Rows[i]["Адрес"] = doc.DocumentNode.SelectSingleNode("//a[@data-appeal-kind=\"EGRUL_ADRES\"]") != null
                        ? doc.DocumentNode.SelectSingleNode("//a[@data-appeal-kind=\"EGRUL_ADRES\"]").InnerText : "отсутствует";
                if (string.IsNullOrEmpty(dataTable.Rows[i]["ОКВЭД"].ToString())) dataTable.Rows[i]["ОКВЭД"] = doc.DocumentNode.SelectSingleNode("//a[@data-appeal-kind=\"EGRUL_OKVED\"]") != null
                        ? doc.DocumentNode.SelectSingleNode("//a[@data-appeal-kind=\"EGRUL_OKVED\"]").InnerText : doc.DocumentNode.SelectSingleNode("//a[@data-appeal-kind=\"EGRIP_OKVED\"]").InnerText;
                if (string.IsNullOrEmpty(dataTable.Rows[i]["Система налогообложения"].ToString()) && doc.DocumentNode.SelectSingleNode("//a[@data-appeal-kind=\"TAXMODE\"]") != null)
                {
                    if (doc.DocumentNode.SelectSingleNode("//a[@data-appeal-kind=\"TAXMODE\"]").ChildNodes.Count > 1)
                        dataTable.Rows[i]["Система налогообложения"] = doc.DocumentNode.SelectSingleNode("//a[@data-appeal-kind=\"TAXMODE\"]").ChildNodes[1].InnerText;
                    else dataTable.Rows[i]["Система налогообложения"] = doc.DocumentNode.SelectSingleNode("//a[@data-appeal-kind=\"TAXMODE\"]").InnerText;
                }
                else if (string.IsNullOrEmpty(dataTable.Rows[i]["Система налогообложения"].ToString()) && doc.DocumentNode.SelectSingleNode("//a[@data-appeal-kind=\"TAXMODE\"]") == null)
                {
                    dataTable.Rows[i]["Система налогообложения"] = "Неизвестно";
                }
                HtmlNode supervisor = doc.DocumentNode.SelectSingleNode("//div[@id='rupr']");
                if (string.IsNullOrEmpty(dataTable.Rows[i]["Массовый руководитель"].ToString()))
                {
                    bool found = false;
                    string super = "Есть. ";
                    if (supervisor != null)
                        for (int j = 2; j < supervisor.ChildNodes[1].ChildNodes.Count; j++)
                        {
                            if (supervisor.ChildNodes[1].ChildNodes[j].ChildNodes.Count == 0) continue;
                            else
                            {
                                if(supervisor.ChildNodes[1].ChildNodes[j].ChildNodes.Count > 7)
                                {
                                    if (Convert.ToInt32(supervisor.ChildNodes[1].ChildNodes[j].ChildNodes[7].ChildNodes[1].ChildNodes[3].InnerText) >= 10)
                                    {
                                        found = true;
                                        super += supervisor.ChildNodes[1].ChildNodes[j].ChildNodes[1].ChildNodes[1].ChildNodes[1].InnerText + ", " + supervisor.ChildNodes[1].ChildNodes[j].ChildNodes[7].ChildNodes[1].ChildNodes[3].InnerText + "; ";
                                    }
                                }
                                else
                                {
                                    if (Convert.ToInt32(supervisor.ChildNodes[1].ChildNodes[j].ChildNodes[5].ChildNodes[1].ChildNodes[3].InnerText) >= 10)
                                    {
                                        found = true;
                                        super += supervisor.ChildNodes[1].ChildNodes[j].ChildNodes[1].ChildNodes[1].ChildNodes[1].InnerText + ", " + supervisor.ChildNodes[1].ChildNodes[j].ChildNodes[5].ChildNodes[1].ChildNodes[3].InnerText + "; ";
                                    }
                                }
                            }
                        }
                    if (!found) super = "Нет";
                    dataTable.Rows[i]["Массовый руководитель"] = super;
                }
                HtmlNode founder = doc.DocumentNode.SelectSingleNode("//div[@id='ruchr']");
                if (string.IsNullOrEmpty(dataTable.Rows[i]["Массовый учредитель"].ToString()) || dataTable.Rows[i]["Массовый учредитель"].ToString() == "Есть")
                {
                    bool found = false;
                    string founders = "Есть. ";
                    if (founder != null)
                        for (int j = 2; j < founder.ChildNodes[1].ChildNodes.Count; j++)
                        {
                            if (founder.ChildNodes[1].ChildNodes[j].ChildNodes.Count == 0) continue;
                            else
                            {
                                if(founder.ChildNodes[1].ChildNodes[j].ChildNodes.Count > 5)
                                {
                                    if (Convert.ToInt32(founder.ChildNodes[1].ChildNodes[j].ChildNodes[5].ChildNodes[1].ChildNodes[3].InnerText) >= 10)
                                    {
                                        found = true;
                                        founders += founder.ChildNodes[1].ChildNodes[j].ChildNodes[1].ChildNodes[1].ChildNodes[1].InnerText + ", " + founder.ChildNodes[1].ChildNodes[j].ChildNodes[5].ChildNodes[1].ChildNodes[3].InnerText + "; ";
                                    }
                                }
                                else
                                {
                                    if (Convert.ToInt32(founder.ChildNodes[1].ChildNodes[j].ChildNodes[3].ChildNodes[1].ChildNodes[3].InnerText) >= 10)
                                    {
                                        found = true;
                                        founders += founder.ChildNodes[1].ChildNodes[j].ChildNodes[1].ChildNodes[1].ChildNodes[1].InnerText + ", " + founder.ChildNodes[1].ChildNodes[j].ChildNodes[3].ChildNodes[1].ChildNodes[3].InnerText + "; ";
                                    }
                                }
                            }
                        }
                    if (!found) founders = "Нет";
                    dataTable.Rows[i]["Массовый учредитель"] = founders;
                }
                if (string.IsNullOrEmpty(dataTable.Rows[i]["Дата регистрации"].ToString()))
                {
                    HtmlNode companyFields = doc.DocumentNode.SelectSingleNode("//div[@id=\"pnlCompanyLeftCol\"]") ?? doc.DocumentNode.SelectSingleNode("//div[@class='col-12 pb-company-multicolumn pt-3']");
                    foreach (HtmlNode node in companyFields.ChildNodes)
                    {
                        if(node.ChildNodes.Count == 0) continue;
                        else if (node.ChildNodes[1].ChildNodes.Count <= 1) continue;
                        if (node.ChildNodes[1].ChildNodes[1].InnerText == "Дата регистрации:" || node.ChildNodes[1].ChildNodes[1].InnerText == "Дата присвоения ОГРНИП:")
                        {
                            dataTable.Rows[i]["Дата регистрации"] = node.ChildNodes[1].ChildNodes[3].InnerText;
                        }
                    }
                }
                if (string.IsNullOrEmpty(dataTable.Rows[i]["Дата ликвидации"].ToString()) && string.IsNullOrEmpty(dataTable.Rows[i]["Причина ликвидации"].ToString()))
                {
                    if (doc.DocumentNode.SelectSingleNode("//span[@class='pb-subject-status pb-subject-status--active']") != null)
                    {
                        dataTable.Rows[i]["Статус компании"] = "Действующее";
                        dataTable.Rows[i]["Дата ликвидации"] = "Нет"; dataTable.Rows[i]["Причина ликвидации"] = "Нет";
                    }
                    else if (doc.DocumentNode.SelectSingleNode("//span[@class='pb-subject-status pb-subject-status--inprogress']") != null)
                    {
                        dataTable.Rows[i]["Статус компании"] = "В стадии реорганизации";
                        dataTable.Rows[i]["Дата ликвидации"] = "Нет"; dataTable.Rows[i]["Причина ликвидации"] = "Нет";
                    }
                    else if (doc.DocumentNode.SelectSingleNode("//span[@class='pb-subject-status pb-subject-status--closed']") != null)
                    {
                        dataTable.Rows[i]["Статус компании"] = "Ликвидирован";
                        foreach (HtmlNode node in doc.DocumentNode.SelectNodes("//div[@class='pb-company-block__row pb-company-multicolumn-item']"))
                        {
                            if (token.IsCancellationRequested) return;
                            if (node.ChildNodes[1].ChildNodes[1].InnerText == "Состояние согласно ЕГРЮЛ:" || node.ChildNodes[1].ChildNodes[1].InnerText == "Состояние согласно ЕГРИП:")
                            {
                                string reason = node.ChildNodes[1].ChildNodes[3].InnerText.Replace("\n", "");
                                reason = reason.Trim();
                                dataTable.Rows[i]["Причина ликвидации"] = reason;
                            }
                            else if (node.ChildNodes[1].ChildNodes[1].InnerText == "Дата состояния:")
                            {
                                dataTable.Rows[i]["Дата ликвидации"] = node.ChildNodes[1].ChildNodes[3].InnerText;
                            }
                        }
                    }
                }
                script = @"var q = document.querySelectorAll('[data-title=""Среднесписочная численность работников организации""]');
                               q[0].click();";
                browser.ExecuteScriptAsync(script);
                await Task.Delay(10);
                html = await browser.GetSourceAsync();
                doc.LoadHtml(html);
                HtmlNode staff = doc.DocumentNode.SelectSingleNode("//tbody[@id='modalCompanyTbody']");
                List<string> checkedYears = new List<string>();
                if (staff != null)
                    for (int j = 0; j < 3; j++)
                    {
                        if (token.IsCancellationRequested) return;
                        if (j >= staff.ChildNodes.Count) break;
                        if (staff.ChildNodes[j].LastChild.InnerText == "Сведения отсутствуют") continue;
                        if (staff.ChildNodes[j].FirstChild.InnerText == (DateTime.Now.Year - 1).ToString())
                        {
                            dataTable.Rows[i]["Численность сотрудников в прошлом году"] = Convert.ToDouble(staff.ChildNodes[j].LastChild.InnerText);
                            checkedYears.Add(staff.ChildNodes[j].FirstChild.InnerText);
                        }
                        else if (!checkedYears.Contains((DateTime.Now.Year - 1).ToString()))
                        {
                            dataTable.Rows[i]["Численность сотрудников в прошлом году"] = 0;
                        }

                        if (staff.ChildNodes[j].FirstChild.InnerText == (DateTime.Now.Year - 2).ToString())
                        {
                            dataTable.Rows[i]["Численность сотрудников 2 года ранее"] = Convert.ToDouble(staff.ChildNodes[j].LastChild.InnerText);
                            checkedYears.Add(staff.ChildNodes[j].FirstChild.InnerText);
                        }
                        else if (!checkedYears.Contains((DateTime.Now.Year - 2).ToString()))
                        {
                            dataTable.Rows[i]["Численность сотрудников 2 года ранее"] = 0;
                        }

                        if (staff.ChildNodes[j].FirstChild.InnerText == (DateTime.Now.Year - 3).ToString())
                        {
                            dataTable.Rows[i]["Численность сотрудников 3 года ранее"] = Convert.ToDouble(staff.ChildNodes[j].LastChild.InnerText);
                            checkedYears.Add(staff.ChildNodes[j].FirstChild.InnerText);
                        }
                        else if (!checkedYears.Contains((DateTime.Now.Year - 3).ToString()))
                        {
                            dataTable.Rows[i]["Численность сотрудников 3 года ранее"] = 0;
                        }
                    }
                else
                {
                    dataTable.Rows[i]["Численность сотрудников в прошлом году"] = 0;
                    dataTable.Rows[i]["Численность сотрудников 2 года ранее"] = 0;
                    dataTable.Rows[i]["Численность сотрудников 3 года ранее"] = 0;
                }
                try
                {
 
                }
                catch (Exception ex)
                {
                    MessageBox.Show($"Error: {ex.Message}");
                }
                if (i != inns.Count - 1) await Task.Delay(10000);
            }
            MessageBox.Show("Поиск завершен", "Конец операции", MessageBoxButtons.OK, MessageBoxIcon.Information);
            elementsState.Checked = true;
        }
        public static async void Terrorists(List<string> inns, DataTable dataTable, ChromiumWebBrowser browser, CheckBox elementsState, CancellationToken token)
        {
            token.Register(() => { return; });
            if (!dataTable.Columns.Contains("Причастность к терроризму")) dataTable.Columns.Add("Причастность к терроризму", typeof(string));
            await browser.LoadUrlAsync("https://www.fedsfm.ru/documents/terrorists-catalog-portal-act");
            int time = 0;
            while (browser.IsLoading)
            {
                time = Timer(time, elementsState);
                if (time >= 1000 || token.IsCancellationRequested) return;
                await Task.Delay(1);
            }
            string html = "";
            await Dispatcher.CurrentDispatcher.BeginInvoke((Action)(async () =>
            {
                html = await browser.GetSourceAsync();
            }));
            await Task.Delay(1000);
            if (token.IsCancellationRequested) return;
            HtmlDocument doc = new HtmlDocument();
            doc.LoadHtml(html);
            HtmlNode node = doc.DocumentNode.SelectSingleNode("//ol[@class='terrorist-list']");
            if (node == null) MessageBox.Show("Произошла ошибка при получении данных. Попробуйте еще раз или обратитесь к тех. специалисту.");
            List<string> terrorists = new List<string>();
            for (int i = 0; i < node.ChildNodes.Count; i++)
            {
                if (token.IsCancellationRequested) return;
                List<string> parsedString = node.ChildNodes[i].InnerText.Split(',').ToList();
                foreach (string s in parsedString)
                {
                    if (s.StartsWith(" ИНН: ")) terrorists.Add(s.Substring(6));
                }
            }
            for (int i = 0; i < inns.Count; i++)
            {
                if (token.IsCancellationRequested) return;
                if (terrorists.Contains(inns[i])) dataTable.Rows[i]["Причастность к терроризму"] = "Есть";
                else if(!terrorists.Contains(inns[i])) dataTable.Rows[i]["Причастность к терроризму"] = "Нет";
            }
            MessageBox.Show("Поиск завершен", "Конец операции", MessageBoxButtons.OK, MessageBoxIcon.Information);
            elementsState.Checked = true;
        }
        public static async void FindOrg(List<string> inns, DataTable dataTable, ChromiumWebBrowser browser, CheckBox elementsState, CancellationToken token)
        {
            token.Register(() => { return; });
            if (!dataTable.Columns.Contains("Адрес")) dataTable.Columns.Add("Адрес", typeof(string));
            if (!dataTable.Columns.Contains("ОКВЭД")) dataTable.Columns.Add("ОКВЭД", typeof(string));
            if (!dataTable.Columns.Contains("Дата регистрации")) dataTable.Columns.Add("Дата регистрации", typeof(string));
            if (!dataTable.Columns.Contains("Дата ликвидации")) dataTable.Columns.Add("Дата ликвидации", typeof(string));
            if (!dataTable.Columns.Contains("Причина ликвидации")) dataTable.Columns.Add("Причина ликвидации", typeof(string));
            if (!dataTable.Columns.Contains("Численность сотрудников")) dataTable.Columns.Add("Численность сотрудников", typeof(double));
            if (!dataTable.Columns.Contains("Статус компании")) dataTable.Columns.Add("Статус компании", typeof(string));
            string html = "";
            HtmlDocument doc = new HtmlDocument();
            async void CheckCaptcha()
            {
                if (doc.DocumentNode.SelectNodes("//h1")[0].InnerText == "Find-Org - Проверка, что Вы не робот")
                {
                    MessageBox.Show("Пройдите каптчу", "Каптча", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                    browser.Enabled = true;
                    while (doc.DocumentNode.SelectNodes("//h1")[0] != null)
                    {
                        if (token.IsCancellationRequested) return;
                        html = await browser.GetSourceAsync();
                        doc.LoadHtml(html);
                        if (doc.DocumentNode.SelectNodes("//h1")[0].InnerText != "Find-Org - Проверка, что Вы не робот") break;
                        await Task.Delay(1);
                    }
                    browser.Enabled = false;
                }
            }
            for (int i = 0; i < inns.Count; i++)
            {
                if(token.IsCancellationRequested)return;
                if (inns[i].Length > 10) continue;
                await browser.LoadUrlAsync($"https://www.find-org.com/search/all/?val={inns[i]}");
                html = await browser.GetSourceAsync();
                doc.LoadHtml(html);
                int time = 0;
                CheckCaptcha();
                while (doc.DocumentNode.SelectSingleNode("//div[@class='list']") == null)
                {
                    html = await browser.GetSourceAsync();
                    doc.LoadHtml(html);
                    time = Timer(time, elementsState);
                    if (time >= 1000 || token.IsCancellationRequested) return;
                    await Task.Delay(1);
                }
                await Task.Delay(10000);
                if (token.IsCancellationRequested) return;
                string script = @"var elements = document.querySelectorAll('a');
                           elements[elements.length - 1].click();";
                browser.ExecuteScriptAsync(script);
                CheckCaptcha();
                while (doc.DocumentNode.SelectSingleNode("//div[@class=\"content-main\"]") == null)
                {
                    html = await browser.GetSourceAsync();
                    doc.LoadHtml(html);
                    time = Timer(time, elementsState);
                    if (time >= 1000 || token.IsCancellationRequested) return;
                    await Task.Delay(1);
                }
                html = await browser.GetSourceAsync();
                doc.LoadHtml(html);
                HtmlNode node = doc.DocumentNode.SelectSingleNode("//div[@class='content-main']");
                foreach(HtmlNode childNode in node.ChildNodes)
                {
                    if (token.IsCancellationRequested) return;
                    await Task.Delay(1);
                    if(childNode.FirstChild == null) continue;
                    switch(childNode.FirstChild.InnerText)
                    {
                        case "Юридический адрес:":
                            if (string.IsNullOrEmpty(dataTable.Rows[i]["Адрес"].ToString())) dataTable.Rows[i]["Адрес"] = childNode.InnerText.Remove(0, childNode.FirstChild.InnerText.Length + 1);
                            break;
                        case "Численность персонала:":
                            if (string.IsNullOrEmpty(dataTable.Rows[i]["Численность сотрудников"].ToString())) dataTable.Rows[i]["Численность сотрудников"] = Convert.ToDouble(childNode.InnerText.Remove(0, childNode.FirstChild.InnerText.Length + 1));
                            break;
                        case "Дата присвоения:":
                            if (string.IsNullOrEmpty(dataTable.Rows[i]["Дата регистрации"].ToString())) dataTable.Rows[i]["Дата регистрации"] = childNode.InnerText.Remove(0, childNode.FirstChild.InnerText.Length + 1);
                            break;
                        case "Основной (по коду ОКВЭД 2):":
                            if (string.IsNullOrEmpty(dataTable.Rows[i]["ОКВЭД"].ToString())) dataTable.Rows[i]["ОКВЭД"] = childNode.InnerText.Remove(0, childNode.FirstChild.InnerText.Length + 1);
                            break;
                        case "Основной (по коду ОКВЭД):":
                            if (string.IsNullOrEmpty(dataTable.Rows[i]["ОКВЭД"].ToString())) dataTable.Rows[i]["ОКВЭД"] = childNode.InnerText.Remove(0, childNode.FirstChild.InnerText.Length + 1);
                            break;
                        case "Статус:":
                            if (string.IsNullOrEmpty(dataTable.Rows[i]["Статус компании"].ToString())) 
                            {
                                if (childNode.ChildNodes[2].InnerText == "Действующее") 
                                {
                                    if (string.IsNullOrEmpty(dataTable.Rows[i]["Статус компании"].ToString())) dataTable.Rows[i]["Статус компании"] = "Действующее";
                                    if (string.IsNullOrEmpty(dataTable.Rows[i]["Причина ликвидации"].ToString())) dataTable.Rows[i]["Причина ликвидации"] = "Нет";
                                    if (string.IsNullOrEmpty(dataTable.Rows[i]["Дата ликвидации"].ToString())) dataTable.Rows[i]["Дата ликвидации"] = "Нет";
                                }
                                else if (childNode.ChildNodes[2].InnerText == "Юридическое лицо находится в процессе реорганизации в форме выделения")
                                {
                                    if (string.IsNullOrEmpty(dataTable.Rows[i]["Статус компании"].ToString())) dataTable.Rows[i]["Статус компании"] = "В стадии реорганизации";
                                    if (string.IsNullOrEmpty(dataTable.Rows[i]["Причина ликвидации"].ToString())) dataTable.Rows[i]["Причина ликвидации"] = "Нет";
                                    if (string.IsNullOrEmpty(dataTable.Rows[i]["Дата ликвидации"].ToString())) dataTable.Rows[i]["Дата ликвидации"] = "Нет";
                                }
                                else
                                {
                                    if (string.IsNullOrEmpty(dataTable.Rows[i]["Статус компании"].ToString())) dataTable.Rows[i]["Статус компании"] = "Ликвидирован";
                                    if (string.IsNullOrEmpty(dataTable.Rows[i]["Причина ликвидации"].ToString())) dataTable.Rows[i]["Причина ликвидации"] = childNode.ChildNodes[2].InnerText;
                                    if (string.IsNullOrEmpty(dataTable.Rows[i]["Дата ликвидации"].ToString())) dataTable.Rows[i]["Дата ликвидации"] = node.SelectSingleNode("//ul").ChildNodes[2].ChildNodes[1].InnerText.Replace("\n", "");
                                }
                            } 
                            break;
                    }
                    if(childNode.Name == "ul")
                    {
                        foreach(HtmlNode ulChild in childNode.ChildNodes)
                        {
                            if (token.IsCancellationRequested) return;
                            if (ulChild.FirstChild == null) continue;
                            else if(ulChild.FirstChild.InnerText == " Дата изменения статуса:") 
                                if (string.IsNullOrEmpty(dataTable.Rows[i]["Дата ликвидации"].ToString())) 
                                    dataTable.Rows[i]["Дата ликвидации"] = ulChild.InnerText.Remove(0, ulChild.FirstChild.InnerText.Length + 1);
                        }
                    }
                }
                await Task.Delay(10000);
            }
            MessageBox.Show("Поиск завершен", "Конец операции", MessageBoxButtons.OK, MessageBoxIcon.Information);
            elementsState.Checked = true;
        }
        public static async void ListOrg(List<string> inns, DataTable dataTable, ChromiumWebBrowser browser, CheckBox elementsState, CancellationToken token)
        {
            token.Register(() => { return; });
            if (!dataTable.Columns.Contains("Адрес")) dataTable.Columns.Add("Адрес", typeof(string));
            if (!dataTable.Columns.Contains("ОКВЭД")) dataTable.Columns.Add("ОКВЭД", typeof(string));
            if (!dataTable.Columns.Contains("Дата регистрации")) dataTable.Columns.Add("Дата регистрации", typeof(string));
            if (!dataTable.Columns.Contains("Дата ликвидации")) dataTable.Columns.Add("Дата ликвидации", typeof(string));
            if (!dataTable.Columns.Contains("Причина ликвидации")) dataTable.Columns.Add("Причина ликвидации", typeof(string));
            if (!dataTable.Columns.Contains("Численность сотрудников")) dataTable.Columns.Add("Численность сотрудников", typeof(double));
            if (!dataTable.Columns.Contains("Статус компании")) dataTable.Columns.Add("Статус компании", typeof(string));
            if (!dataTable.Columns.Contains("Кол-во судебных дел")) dataTable.Columns.Add("Кол-во судебных дел", typeof(string));
            string html = "";
            HtmlDocument doc = new HtmlDocument();
            void CheckCaptcha()
            {
                if (token.IsCancellationRequested) return;
                if (browser.Address.StartsWith("https://www.list-org.com/bot"))
                {
                    if(!browser.Enabled)MessageBox.Show("Пройдите каптчу", "Каптча", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                    browser.Enabled = true;
                }
                else
                {
                    browser.Enabled = false;
                }
            }
            for (int i = 0; i < inns.Count; i++)
            {
                if (token.IsCancellationRequested) return;
                await browser.LoadUrlAsync($"https://www.list-org.com/search?val={inns[i]}");
                html = await browser.GetSourceAsync();
                doc.LoadHtml(html);
                int time = 0;
                while (doc.DocumentNode.SelectSingleNode("//div[@class='org_list']") == null)
                {
                    html = await browser.GetSourceAsync();
                    doc.LoadHtml(html);
                    CheckCaptcha();
                    if (!browser.Enabled)
                    {
                        time = Timer(time, elementsState);
                        if (time >= 1000 || token.IsCancellationRequested) return;
                    }
                    await Task.Delay(1);
                }
                await Task.Delay(10000);
                if (token.IsCancellationRequested) return;
                string script = @"var elements = document.querySelectorAll('p');
                           elements[elements.length - 1].children[0].children[1].click();";
                browser.ExecuteScriptAsync(script);
                html = await browser.GetSourceAsync();
                doc.LoadHtml(html);
                while (doc.DocumentNode.SelectSingleNode("//table[@class=\"table table-sm\"]") == null)
                {
                    html = await browser.GetSourceAsync();
                    doc.LoadHtml(html);
                    CheckCaptcha();
                    if (!browser.Enabled) 
                    {
                        time = Timer(time, elementsState);
                        if (time >= 1000 || token.IsCancellationRequested) return;
                    }
                    await Task.Delay(1);
                }
                html = await browser.GetSourceAsync();
                doc.LoadHtml(html);
                HtmlNodeCollection nodes = doc.DocumentNode.SelectNodes("//div[@class='card w-100 p-1 p-lg-3 mt-2']");
                bool isIE = false;
                foreach(HtmlNode node in nodes)
                {
                    if (token.IsCancellationRequested) return;
                    if (node.ChildNodes[0].InnerText == "Регистрации в качестве Индивидуального предпринимателя (ИП):")
                    {
                        if (string.IsNullOrEmpty(dataTable.Rows[i]["ОКВЭД"].ToString())) dataTable.Rows[i]["ОКВЭД"] = node.ChildNodes[1].ChildNodes[1].ChildNodes[19].InnerText;
                        if (doc.DocumentNode.SelectSingleNode("//span[@class='status_1']") != null)
                        {
                            if (string.IsNullOrEmpty(dataTable.Rows[i]["Статус компании"].ToString())) dataTable.Rows[i]["Статус компании"] = doc.DocumentNode.SelectSingleNode("//span[@class='status_1']").InnerText;
                            if (string.IsNullOrEmpty(dataTable.Rows[i]["Дата ликвидации"].ToString())) dataTable.Rows[i]["Дата ликвидации"] = "Нет";
                            if (string.IsNullOrEmpty(dataTable.Rows[i]["Причина ликвидации"].ToString())) dataTable.Rows[i]["Причина ликвидации"] = "Нет";
                        }
                        if (string.IsNullOrEmpty(dataTable.Rows[i]["Дата регистрации"].ToString())) dataTable.Rows[i]["Дата регистрации"] = node.ChildNodes[1].ChildNodes[1].ChildNodes[11].InnerText;
                        isIE = true;
                        break;
                    }
                    switch (node.ChildNodes[0].InnerText)
                    {
                        case "Контактная информация:":
                            foreach(HtmlNode node2 in node.ChildNodes[1].ChildNodes)
                            {
                                if (node2.ChildNodes.Count == 0) continue;
                                if (node2.ChildNodes[0].InnerText == "Юридический адрес:")
                                    if (string.IsNullOrEmpty(dataTable.Rows[i]["Адрес"].ToString())) dataTable.Rows[i]["Адрес"] = node2.ChildNodes[1].InnerText;
                            }
                            break;
                        case "Виды деятельности:":
                            if (string.IsNullOrEmpty(dataTable.Rows[i]["ОКВЭД"].ToString())) dataTable.Rows[i]["ОКВЭД"] = node.ChildNodes[1].ChildNodes[0].ChildNodes[2].InnerText + node.ChildNodes[1].ChildNodes[0].ChildNodes[3].InnerText;
                            break;
                    }
                    if (node.ChildNodes[0].InnerText.StartsWith("Арбитраж"))
                        if (string.IsNullOrEmpty(dataTable.Rows[i]["Кол-во судебных дел"].ToString()))
                        {
                            if (node.ChildNodes[0].InnerText.StartsWith("Арбитраж: не найдено")) dataTable.Rows[i]["Кол-во судебных дел"] = "Найдено 0 дел";
                            else
                            {
                                string[] dividedString = node.ChildNodes[0].InnerText.Split('(');
                                string result = "";
                                foreach(char c in dividedString[1])
                                {
                                    if(char.IsNumber(c)) result += c;
                                }
                                dataTable.Rows[i]["Кол-во судебных дел"] = "Найдено " + result + " дел";
                            }
                        }
                }
                if (isIE) continue;
                if (doc.DocumentNode.SelectSingleNode("//td[@class='status_5']") != null)
                {
                    if (string.IsNullOrEmpty(dataTable.Rows[i]["Статус компании"].ToString())) dataTable.Rows[i]["Статус компании"] 
                            = doc.DocumentNode.SelectSingleNode("//td[@class='status_5']").InnerText == "Действующее" ? "Действующее" : "В стадии реорганизации";
                    if (string.IsNullOrEmpty(dataTable.Rows[i]["Дата ликвидации"].ToString())) dataTable.Rows[i]["Дата ликвидации"] = "Нет";
                    if (string.IsNullOrEmpty(dataTable.Rows[i]["Причина ликвидации"].ToString())) dataTable.Rows[i]["Причина ликвидации"] = "Нет";
                }
                else if(doc.DocumentNode.SelectSingleNode("//td[@class='status_0']") != null)
                {
                    if (string.IsNullOrEmpty(dataTable.Rows[i]["Дата ликвидации"].ToString())) dataTable.Rows[i]["Дата ликвидации"] = doc.DocumentNode.SelectSingleNode("//div[@class='warn_red']").InnerText;
                    if (string.IsNullOrEmpty(dataTable.Rows[i]["Причина ликвидации"].ToString())) dataTable.Rows[i]["Причина ликвидации"] = doc.DocumentNode.SelectSingleNode("//td[@class='status_0']").InnerText;
                    if (string.IsNullOrEmpty(dataTable.Rows[i]["Статус компании"].ToString())) dataTable.Rows[i]["Статус компании"] = "Ликвидирован";
                }
                nodes = doc.DocumentNode.SelectNodes("//table[@class='table table-sm']")[0].ChildNodes[1].ChildNodes;
                foreach (HtmlNode node in nodes)
                {
                    if (token.IsCancellationRequested) return;
                    if (node.ChildNodes.Count == 0) continue;
                    string text = node.ChildNodes[0].InnerText;
                    switch(node.ChildNodes[0].InnerText)
                    {
                        case "Численность персонала:":
                            if (string.IsNullOrEmpty(dataTable.Rows[i]["Численность сотрудников"].ToString())) dataTable.Rows[i]["Численность сотрудников"] = Convert.ToDouble(node.ChildNodes[1].InnerText);
                            break;
                        case "Дата регистрации:":
                            if (string.IsNullOrEmpty(dataTable.Rows[i]["Дата регистрации"].ToString())) dataTable.Rows[i]["Дата регистрации"] = node.ChildNodes[1].InnerText;
                            break;
                    }
                }
                await Task.Delay(10000);
            }
            MessageBox.Show("Поиск завершен", "Конец операции", MessageBoxButtons.OK, MessageBoxIcon.Information);
            elementsState.Checked = true;
        }
        public static async void Arbitr(List<string> inns, DataTable dataTable, ChromiumWebBrowser browser, CheckBox elementsState, CancellationToken token)
        {
            token.Register(() => { return; });
            if (!dataTable.Columns.Contains("Кол-во судебных дел")) dataTable.Columns.Add("Кол-во судебных дел", typeof(string));
            string lastValueCheck = "";
            int time = 0;
            string prevValue = "";
            for(int i = 0; i < inns.Count; i++)
            {
                if (i > 0)
                    if (inns[i] == inns[i - 1])
                    {
                        dataTable.Rows[i]["Кол-во судебных дел"] = prevValue;
                        continue;
                    }
                prevValue = "";
                if (token.IsCancellationRequested) return;
                string script = $@"var elements = document.getElementsByTagName(""textarea"");
                                   elements[0].value = ""{inns[i]}"";
                                   elements[0].classList.remove(""g-ph"");
                                   elements[0].classList.add(""*"");
                                   var elements = document.querySelectorAll('button[type=submit]'); 
                                   elements[0].click();";
                browser.ExecuteScriptAsync(script);
                HtmlDocument doc = new HtmlDocument();
                string html = await browser.GetSourceAsync();
                doc.LoadHtml(html);
                await Task.Delay(1000);
                if(doc.DocumentNode.SelectSingleNode("//table[@id='b-cases']").ChildNodes.Count == 0)
                {
                    while (doc.DocumentNode.SelectSingleNode("//table[@id='b-cases']").ChildNodes.Count == 0)
                    {
                        html = await browser.GetSourceAsync();
                        doc.LoadHtml(html);
                        time = Timer(time, elementsState);
                        if (time >= 1000 || token.IsCancellationRequested) return;
                        await Task.Delay(1);
                    }
                    time = 0;
                }
                else
                {
                    html = await browser.GetSourceAsync();
                    doc.LoadHtml(html);
                    HtmlNode node = doc.DocumentNode.SelectSingleNode("//table[@id='b-cases']").ChildNodes[1];
                    if (node.ChildNodes.Count > 0)
                    {
                        while (true)
                        {
                            try
                            {
                                while (lastValueCheck == doc.DocumentNode.SelectSingleNode("//table[@id='b-cases']").ChildNodes[1].ChildNodes[0].InnerText)
                                {
                                    html = await browser.GetSourceAsync();
                                    doc.LoadHtml(html);
                                    time = Timer(time, elementsState);
                                    if (time >= 1000 || token.IsCancellationRequested) return;
                                    await Task.Delay(1);
                                }
                                break;
                            }
                            catch
                            {
                                continue;
                            }
                        }

                    }
                }
                time = 0;
                if (doc.DocumentNode.SelectSingleNode("//table[@id='b-cases']").ChildNodes[1].ChildNodes.Count == 0)
                {
                    if (string.IsNullOrEmpty(dataTable.Rows[i]["Кол-во судебных дел"].ToString())) dataTable.Rows[i]["Кол-во судебных дел"] = "Найдено 0 дел";
                }
                else
                {
                    if (string.IsNullOrEmpty(dataTable.Rows[i]["Кол-во судебных дел"].ToString())) dataTable.Rows[i]["Кол-во судебных дел"] = doc.DocumentNode.SelectSingleNode("//div[@class='b-found-total']").InnerText;
                    lastValueCheck = doc.DocumentNode.SelectSingleNode("//table[@id='b-cases']").ChildNodes[1].ChildNodes[0].InnerText;
                }
                prevValue = dataTable.Rows[i]["Кол-во судебных дел"].ToString();
            }
            MessageBox.Show("Поиск завершен", "Конец операции", MessageBoxButtons.OK, MessageBoxIcon.Information);
            elementsState.Checked = true;
        }
        public static async void ForFairBussiness(List<string> inns, DataTable dataTable, ChromiumWebBrowser browser, CheckBox elementsState, CancellationToken token)
        {
            if (!dataTable.Columns.Contains("Адрес")) dataTable.Columns.Add("Адрес", typeof(string));
            if (!dataTable.Columns.Contains("ОКВЭД")) dataTable.Columns.Add("ОКВЭД", typeof(string));
            if (!dataTable.Columns.Contains("Дата регистрации")) dataTable.Columns.Add("Дата регистрации", typeof(string));
            if (!dataTable.Columns.Contains("Статус компании")) dataTable.Columns.Add("Статус компании", typeof(string));
            if (!dataTable.Columns.Contains("Дата ликвидации")) dataTable.Columns.Add("Дата ликвидации", typeof(string));
            if (!dataTable.Columns.Contains("Причина ликвидации")) dataTable.Columns.Add("Причина ликвидации", typeof(string));
            if (!dataTable.Columns.Contains("Численность сотрудников в прошлом году")) dataTable.Columns.Add("Численность сотрудников в прошлом году", typeof(double));
            if (!dataTable.Columns.Contains("Численность сотрудников 2 года ранее")) dataTable.Columns.Add("Численность сотрудников 2 года ранее", typeof(double));
            if (!dataTable.Columns.Contains("Численность сотрудников 3 года ранее")) dataTable.Columns.Add("Численность сотрудников 3 года ранее", typeof(double));
            if (!dataTable.Columns.Contains("Массовый руководитель")) dataTable.Columns.Add("Массовый руководитель", typeof(string));
            if (!dataTable.Columns.Contains("Массовый учредитель")) dataTable.Columns.Add("Массовый учредитель", typeof(string));
/*            if (!dataTable.Columns.Contains("Массовый адрес")) dataTable.Columns.Add("Массовый адрес", typeof(string));*/
            if (!dataTable.Columns.Contains("Система налогообложения")) dataTable.Columns.Add("Система налогообложения", typeof(string));
            if (!dataTable.Columns.Contains("Рейтинг")) dataTable.Columns.Add("Рейтинг", typeof (string));
            HtmlDocument doc = new HtmlDocument();
            for (int i = 0; i < inns.Count; i++)
            {
                if (token.IsCancellationRequested) return;
                int time = 0;
                await browser.LoadUrlAsync($"https://zachestnyibiznes.ru/search?query={inns[i]}");
                string html;
                while (true)
                {
                    html = await browser.GetSourceAsync();
                    doc.LoadHtml(html);
                    HtmlNode node = doc.DocumentNode.SelectSingleNode("//div[@class='background-grey-blue-light p-15 b-radius-5 m-b-20']");
                    if (node != null) break;
                    time = Timer(time, elementsState);
                    if ((time >= 1000) || token.IsCancellationRequested) return;
                    await Task.Delay(1);
                }
                time = 0;
                await Task.Delay(10000);
                if (token.IsCancellationRequested) return;
                browser.Enabled = false;
                string script = @"var q = document.querySelector(""div[id='search_result']"");
                              q.childNodes[2].childNodes[0].childNodes[0].childNodes[0].childNodes[1].click();";
                browser.ExecuteScriptAsync(script);
                while (true)
                {
                    html = await browser.GetSourceAsync();
                    doc.LoadHtml(html);
                    if (doc.DocumentNode.SelectSingleNode("//h2[@class=\"h2-company\"]") != null) break;
                    time = Timer(time, elementsState);
                    if ((time >= 1000) || token.IsCancellationRequested) return;
                    await Task.Delay(1);
                }
                browser.Enabled = false;
                await Task.Delay(1000);
                doc.LoadHtml(html);
                if (string.IsNullOrEmpty(dataTable.Rows[i]["Дата регистрации"].ToString())) dataTable.Rows[i]["Дата регистрации"] = doc.DocumentNode.SelectSingleNode("//span[@itemprop='foundingDate']").InnerText;
                if (string.IsNullOrEmpty(dataTable.Rows[i]["Адрес"].ToString())) dataTable.Rows[i]["Адрес"] = doc.DocumentNode.SelectSingleNode("//span[@itemprop='address']").InnerText;
                if (string.IsNullOrEmpty(dataTable.Rows[i]["ОКВЭД"].ToString())) dataTable.Rows[i]["ОКВЭД"] = doc.DocumentNode.SelectSingleNode("//p[@class='no-indent m-b-0 sub-title-content']").FirstChild.InnerText;
                if (string.IsNullOrEmpty(dataTable.Rows[i]["Система налогообложения"].ToString())) dataTable.Rows[i]["Система налогообложения"] = doc.DocumentNode.SelectNodes("//p[@class='m-b-0 no-indent sub-title-content']")[0].FirstChild.InnerText;
                HtmlNode staff = doc.DocumentNode.SelectSingleNode("//div[@id='sshr-collapse']");
                List<string> checkedYears = new List<string>();
                if (staff != null)
                    for (int j = 0; j < 4; j++)
                    {
                        if (token.IsCancellationRequested) return;
                        if (j >= staff.ChildNodes.Count) break;
                        string[] parsedDate = staff.ChildNodes[j].ChildNodes[1].InnerText.Split('.');
                        if (parsedDate[2] == (DateTime.Now.Year - 1).ToString())
                        {
                            dataTable.Rows[i]["Численность сотрудников в прошлом году"] = Convert.ToDouble(staff.ChildNodes[j].ChildNodes[2].InnerText);
                            checkedYears.Add(parsedDate[2]);
                        }
                        else if (!checkedYears.Contains((DateTime.Now.Year - 1).ToString()))
                        {
                            dataTable.Rows[i]["Численность сотрудников в прошлом году"] = 0;
                        }

                        if (parsedDate[2] == (DateTime.Now.Year - 2).ToString())
                        {
                            dataTable.Rows[i]["Численность сотрудников 2 года ранее"] = Convert.ToDouble(staff.ChildNodes[j].ChildNodes[2].InnerText);
                            checkedYears.Add(parsedDate[2]);
                        }
                        else if (!checkedYears.Contains((DateTime.Now.Year - 2).ToString()))
                        {
                            dataTable.Rows[i]["Численность сотрудников 2 года ранее"] = 0;
                        }

                        if (parsedDate[2] == (DateTime.Now.Year - 3).ToString())
                        {
                            dataTable.Rows[i]["Численность сотрудников 3 года ранее"] = Convert.ToDouble(staff.ChildNodes[j].ChildNodes[2].InnerText);
                            checkedYears.Add(parsedDate[2]);
                        }
                        else if (!checkedYears.Contains((DateTime.Now.Year - 3).ToString()))
                        {
                            dataTable.Rows[i]["Численность сотрудников 3 года ранее"] = 0;
                        }
                    }
                else
                {
                    dataTable.Rows[i]["Численность сотрудников в прошлом году"] = 0;
                    dataTable.Rows[i]["Численность сотрудников 2 года ранее"] = 0;
                    dataTable.Rows[i]["Численность сотрудников 3 года ранее"] = 0;
                }
                bool canGetMass = true;
                while(doc.DocumentNode.SelectNodes("//div[@class='col-md-8 sub-title-content']") == null)
                {
                    html = await browser.GetSourceAsync();
                    doc.LoadHtml(html);
                    if (doc.DocumentNode.SelectNodes("//div[@class='col-md-8 sub-title-content']") != null) break;
                    time++;
                    if (time >= 2000)
                    {
                        canGetMass = false;
                        break;
                    }
                    await Task.Delay(1);
                }
                if(canGetMass) foreach(HtmlNode node in doc.DocumentNode.SelectNodes("//div[@class='col-md-8 sub-title-content']"))
                {
                    if(node.InnerText == "\nМассовый учредитель" && string.IsNullOrEmpty(dataTable.Rows[i]["Массовый учредитель"].ToString()))
                    {
                        if (node.ParentNode.ChildNodes[1].InnerText == "Не состоит") dataTable.Rows[i]["Массовый учредитель"] = "Нет";
                        else dataTable.Rows[i]["Массовый учредитель"] = "Есть";
                    }
                    else if(node.InnerText == "\nМассовый руководитель" && string.IsNullOrEmpty(dataTable.Rows[i]["Массовый руководитель"].ToString()))
                    {
                        if (node.ParentNode.ChildNodes[1].InnerText == "Не состоит") dataTable.Rows[i]["Массовый руководитель"] = "Нет";
                        else dataTable.Rows[i]["Массовый руководитель"] = "Есть";
                    }
                }
                string liquidationReason = "Нет";
                if (doc.DocumentNode.SelectSingleNode("//span[@class='badge bg-badge-soft-danger c-danger']") != null)
                {
                    dataTable.Rows[i]["Статус компании"] = "Ликвидирован";
                    liquidationReason = doc.DocumentNode.SelectSingleNode("//span[@class='badge bg-badge-soft-danger c-danger']").ParentNode.ChildNodes[5].InnerText;
                    dataTable.Rows[i]["Дата ликвидации"] = doc.DocumentNode.SelectNodes("//p[@class='m-b-0 no-indent sub-title-content']")[0].InnerText;
                }
                else if (doc.DocumentNode.SelectSingleNode("//span[@class='badge bg-badge-soft-warning c-warning']") != null) dataTable.Rows[i]["Статус компании"] = "В стадии реорганизации";
                else dataTable.Rows[i]["Статус компании"] = "Действующее";
                if (liquidationReason == "Нет")
                {
                    dataTable.Rows[i]["Дата ликвидации"] = "Нет";
                    int good = Convert.ToInt32(doc.DocumentNode.SelectSingleNode("//span[@class='success-risk icon-xs m-r-4']").ParentNode.ChildNodes[3].InnerText);
                    int mid = Convert.ToInt32(doc.DocumentNode.SelectSingleNode("//span[@class='warning-risk icon-xs m-r-4']").ParentNode.ChildNodes[3].InnerText);
                    int bad = Convert.ToInt32(doc.DocumentNode.SelectSingleNode("//span[@class='danger-risk icon-xs m-r-4']").ParentNode.ChildNodes[3].InnerText);
                    int sum = good + mid + bad, minMax = sum / 3, diff = good - bad;
                    if (diff >= minMax) dataTable.Rows[i]["Рейтинг"] = "Высокий";
                    else if (diff >= -minMax && diff < minMax) dataTable.Rows[i]["Рейтинг"] = "Средний";
                    else dataTable.Rows[i]["Рейтинг"] = "Низкий";
                }
                else
                {
                    dataTable.Rows[i]["Рейтинг"] = "Низкий";
                }
                dataTable.Rows[i]["Причина ликвидации"] = liquidationReason;
                if (i != inns.Count - 1) await Task.Delay(10000);
            }
            MessageBox.Show("Поиск завершен", "Конец операции", MessageBoxButtons.OK, MessageBoxIcon.Information);
            elementsState.Checked = true;
        }
        private static int Timer(int time, CheckBox elementsState)
        {
            time++;
            if (time >= 1000)
            {
                MessageBox.Show("Операция прервана по тех. причинам или проблемами с интернетом. Свяжитесь со специалистом");
                elementsState.Checked = true;
            }
            return time;
        }
    }
}
