using Newtonsoft.Json.Linq;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Common;
using System.Drawing;
using System.Linq;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace PracticeCapital_ByNikitaRasputin
{
    public class AnalysisMethods
    {
        public static void CompareExpensesAndRevenue(DataGridView dataGrid, int[] expensesColumns, int[] revenueColumns)
        {
            for(int i = 0; i < dataGrid.Rows.Count - 1; i++) 
            {
                for(int j = 0; j < expensesColumns.Length - 1; j++)
                {
                    double exp = Math.Abs(Convert.ToDouble(dataGrid[expensesColumns[j], i].Value)), rev = Convert.ToDouble(dataGrid[revenueColumns[j], i].Value);
                    if (exp == 0 && rev == 0)
                    {
                        dataGrid[revenueColumns[j], i].Style.BackColor = Color.FromArgb(128, 128, 255);
                        continue;
                    }
                    if (exp >= rev) dataGrid[revenueColumns[j], i].Style.BackColor = Color.FromArgb(255, 128, 128);
                    else dataGrid[revenueColumns[j], i].Style.BackColor = Color.FromArgb(128, 255, 128);
                }
            }
            MessageBox.Show("Готово", "Конец операции", MessageBoxButtons.OK, MessageBoxIcon.Information);
        }
        public static void CompareTaxAndProfit(DataGridView dataGrid, int[] profitsColumns, int[] taxesColumns)
        {
            for (int i = 0; i < dataGrid.Rows.Count - 1; i++)
            {
                for (int j = 0; j < taxesColumns.Length - 1; j++)
                {
                    double prof = Convert.ToDouble(dataGrid[profitsColumns[j], i].Value), tax = Convert.ToDouble(dataGrid[taxesColumns[j], i].Value);
                    if (tax >= prof * 0.2) dataGrid[taxesColumns[j], i].Style.BackColor = Color.FromArgb(128, 255, 128);
                    else if(tax == 0 && prof == 0) dataGrid[taxesColumns[j], i].Style.BackColor = Color.FromArgb(128, 128, 255);
                    else dataGrid[taxesColumns[j], i].Style.BackColor = Color.FromArgb(255, 128, 128);
                }
            }
            MessageBox.Show("Готово", "Конец операции", MessageBoxButtons.OK, MessageBoxIcon.Information);
        }
        public static void CheckRedGreen(DataGridView dataGrid, int columnIndex, List<string> compareValues = null, string compareValue = "Нет")
        {
            if (compareValues == null) compareValues = new List<string>();
            for (int i = 0; i < dataGrid.Rows.Count - 1; i++)
            {
                if (dataGrid.Rows[i].Cells[columnIndex].Value.ToString() == compareValue || compareValues.Contains(dataGrid.Rows[i].Cells[columnIndex].Value.ToString())) 
                    dataGrid.Rows[i].Cells[columnIndex].Style.BackColor = Color.FromArgb(128, 255, 128);
                else dataGrid.Rows[i].Cells[columnIndex].Style.BackColor = Color.FromArgb(255, 128, 128);
            }
            MessageBox.Show("Готово", "Конец операции", MessageBoxButtons.OK, MessageBoxIcon.Information);
        }
        public static void CheckYellowGreen(DataGridView dataGrid, int columnIndex, List<string> compareValues = null, string compareValue = "Нет")
        {
            if(compareValues == null) compareValues = new List<string>();
            for (int i = 0; i < dataGrid.Rows.Count - 1; i++)
            {
                if (dataGrid.Rows[i].Cells[columnIndex].Value.ToString() == compareValue || compareValues.Contains(dataGrid.Rows[i].Cells[columnIndex].Value.ToString())) dataGrid.Rows[i].Cells[columnIndex].Style.BackColor = Color.FromArgb(128, 255, 128);
                else dataGrid.Rows[i].Cells[columnIndex].Style.BackColor = Color.FromArgb(243, 255, 74);
            }
            MessageBox.Show("Готово", "Конец операции", MessageBoxButtons.OK, MessageBoxIcon.Information);
        }
        public static void CheckRedYellowGreen(DataGridView dataGrid, int columnIndex, List<string> greenCompareValues = null, List<string> yellowCompareValues = null, string greenCompareValue = "Нет", string yellowCompareValue = "")
        {
            if (greenCompareValues == null) greenCompareValues = new List<string>();
            if(yellowCompareValues == null) yellowCompareValues = new List<string>();
            for (int i = 0; i < dataGrid.Rows.Count - 1; i++)
            {
                if (dataGrid.Rows[i].Cells[columnIndex].Value.ToString() == greenCompareValue || greenCompareValues.Contains(dataGrid.Rows[i].Cells[columnIndex].Value.ToString())) dataGrid.Rows[i].Cells[columnIndex].Style.BackColor = Color.FromArgb(128, 255, 128);
                else if(dataGrid.Rows[i].Cells[columnIndex].Value.ToString() == yellowCompareValue || yellowCompareValues.Contains(dataGrid.Rows[i].Cells[columnIndex].Value.ToString())) dataGrid.Rows[i].Cells[columnIndex].Style.BackColor = Color.FromArgb(243, 255, 74);
                else dataGrid.Rows[i].Cells[columnIndex].Style.BackColor = Color.FromArgb(255, 128, 128);
            }
            MessageBox.Show("Готово", "Конец операции", MessageBoxButtons.OK, MessageBoxIcon.Information);
        }
        public static void CheckStaffCount(DataGridView dataGrid, int columnIndex)
        {
            for (int i = 0; i < dataGrid.Rows.Count - 1; i++)
            {
                if ((double)dataGrid.Rows[i].Cells[columnIndex].Value == 1) dataGrid.Rows[i].Cells[columnIndex].Style.BackColor = Color.FromArgb(255, 128, 128);
                else if((double)dataGrid.Rows[i].Cells[columnIndex].Value == 0) dataGrid.Rows[i].Cells[columnIndex].Style.BackColor = Color.FromArgb(128, 128, 255);
                else if((double)dataGrid.Rows[i].Cells[columnIndex].Value > 1 && (double)dataGrid.Rows[i].Cells[columnIndex].Value < 11) dataGrid.Rows[i].Cells[columnIndex].Style.BackColor = Color.FromArgb(243, 255, 74);
                else dataGrid.Rows[i].Cells[columnIndex].Style.BackColor = Color.FromArgb(128, 255, 128);
            }
            MessageBox.Show("Готово", "Конец операции", MessageBoxButtons.OK, MessageBoxIcon.Information);
        }
        public static void CompareBalanceWithAudit(DataGridView dataGrid, int[] balanceColumns, int rubDivider, int[] auditColumns, string checkValue = "Нет")
        {
            for(int i = 0; i < dataGrid.Rows.Count - 1; i++)
            {
                for(int j = 0; j < auditColumns.Length - 1; j++)
                {
                    double balance = Convert.ToDouble(dataGrid[balanceColumns[j], i].Value); string audit = (string)dataGrid[auditColumns[j], i].Value;
                    if(balance/rubDivider < 400 || (balance/rubDivider >= 400 && audit != checkValue)) dataGrid[balanceColumns[j], i].Style.BackColor = Color.FromArgb(128, 255, 128);
                    else dataGrid[balanceColumns[j], i].Style.BackColor = Color.FromArgb(255, 128, 128);
                }
            }
            MessageBox.Show("Готово", "Конец операции", MessageBoxButtons.OK, MessageBoxIcon.Information);
        }
        public async static void CompareBalanceWithAudit(DataAnalysis form,DataGridView dataGrid, int[] balanceColumns, int rubDivider, string[] inns, int[] years, string checkValue = "Нет")
        {
            string[,] auditChecks = new string[inns.Length, 3];
            using (HttpClient httpClient = new HttpClient())
            {
                try
                {
                    for (int i = 0; i < inns.Length; i++)
                    {
                        string json = await httpClient.GetStringAsync($"https://bo.nalog.ru/advanced-search/organizations/search?query={inns[i]}&page=0");
                        JObject search = JObject.Parse(json);
                        if (search["content"].Count() == 0) continue;
                        string id = search["content"][0]["id"].ToString();
                        json = await httpClient.GetStringAsync($"https://bo.nalog.ru/nbo/organizations/{id}/bfo/");
                        JArray data = JArray.Parse(json);
                        List<string> checkedYears = new List<string>();
                        for (int j = 0; j < balanceColumns.Length - 1; j++)
                        {
                            if (j == data.Count) break;
                            if (data[j]["period"].ToString() == (DateTime.Now.Year - 1).ToString())
                            {
                                auditChecks[i, 0] = data[j]["correction"]["auditReport"] != null ? "Есть" : "Нет";
                                checkedYears.Add((DateTime.Now.Year - 1).ToString());
                            }
                            else if (!checkedYears.Contains((DateTime.Now.Year - 1).ToString()))
                            {
                                auditChecks[i, 0] = "Нет";
                            }

                            if (data[j]["period"].ToString() == (DateTime.Now.Year - 2).ToString())
                            {
                                auditChecks[i, 1] = data[j]["correction"]["auditReport"] != null ? "Есть" : "Нет";
                                checkedYears.Add((DateTime.Now.Year - 2).ToString());
                            }
                            else if (!checkedYears.Contains((DateTime.Now.Year - 2).ToString()))
                            {
                                auditChecks[i, 1] = "Нет";
                            }

                            if (data[j]["period"].ToString() == (DateTime.Now.Year - 3).ToString())
                            {
                                auditChecks[i, 2] = data[j]["correction"]["auditReport"] != null ? "Есть" : "Нет";
                                checkedYears.Add((DateTime.Now.Year - 3).ToString());
                            }
                            else if (!checkedYears.Contains((DateTime.Now.Year - 3).ToString()))
                            {
                                auditChecks[i, 2] = "Нет";
                            }
                        }
                    }
                }
                catch
                {
                    MessageBox.Show("Произошла ошибка. Попробуйте еще раз или позовите тех. специалиста", "Ошибка", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    form.Enabled = true;
                    return;
                }
            }
            for (int i = 0; i < dataGrid.Rows.Count - 1; i++)
            {
                for (int j = 0; j < balanceColumns.Length - 1; j++)
                {
                    double balance = 0;
                    string audit = "";
                    if (years[j] == DateTime.Now.Year - 1)
                    {
                        balance = Convert.ToDouble(dataGrid[balanceColumns[j], i].Value); audit = auditChecks[i, 0];
                    }
                    else if (years[j] == DateTime.Now.Year - 2)
                    {
                        balance = Convert.ToDouble(dataGrid[balanceColumns[j], i].Value); audit = auditChecks[i, 1];
                    }
                    else if (years[j] == DateTime.Now.Year - 3)
                    {
                        balance = Convert.ToDouble(dataGrid[balanceColumns[j], i].Value); audit = auditChecks[i, 2];
                    }
                    if ((balance / rubDivider < 400 && balance != 0) || (balance / rubDivider >= 400 && audit != "Нет")) dataGrid[balanceColumns[j], i].Style.BackColor = Color.FromArgb(128, 255, 128);
                    else if (balance == 0) dataGrid[balanceColumns[j], i].Style.BackColor = Color.FromArgb(128, 128, 255);
                    else dataGrid[balanceColumns[j], i].Style.BackColor = Color.FromArgb(255, 128, 128);
                }
            }
            form.Enabled = true;
            MessageBox.Show("Готово", "Конец операции", MessageBoxButtons.OK, MessageBoxIcon.Information);
        }
        public static void CompareDzKz(DataGridView dataGrid, int dzColumn, int kzColumn)
        {
            int kz, dz;
            for(int i = 0; i < dataGrid.Rows.Count - 1; i++)
            {
                if (string.IsNullOrEmpty(dataGrid[kzColumn, i].Value.ToString())) kz = 0;
                else kz = Convert.ToInt32(dataGrid[kzColumn, i].Value);
                if (string.IsNullOrEmpty(dataGrid[dzColumn, i].Value.ToString())) dz = 0;
                else dz = Convert.ToInt32(dataGrid[dzColumn, i].Value);
                if(kz == dz && kz != 0 & dz != 0) dataGrid[dzColumn, i].Style.BackColor = Color.FromArgb(255, 128, 128);
                else if(kz == 0 && dz == 0) dataGrid[dzColumn, i].Style.BackColor = Color.FromArgb(128, 128, 255);
                else dataGrid[dzColumn, i].Style.BackColor = Color.FromArgb(128, 255, 128);
            }
            MessageBox.Show("Готово", "Конец операции", MessageBoxButtons.OK, MessageBoxIcon.Information);
        }
    }
}
