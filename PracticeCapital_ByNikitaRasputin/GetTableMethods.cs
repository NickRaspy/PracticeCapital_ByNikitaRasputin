using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using OfficeOpenXml;

namespace PracticeCapital_ByNikitaRasputin
{
    public static class GetTableMethods
    {
        public static void StandartMethod(ExcelWorksheet sheet, int indents)
        {
            int count = 0;
            if(indents != 0)
            {
                string[] columns = new string[sheet.Dimension.End.Column];
                for (int i = 0; i < sheet.Dimension.End.Column; i++)
                {
                    columns[i] = sheet.Cells[indents + 1, i + 1].Text;
                }
                for (int i = 1; i < sheet.Dimension.End.Column + 1; i++)
                {
                    if (string.IsNullOrEmpty(sheet.Cells[indents + 1, i].Text))
                    {
                        if (!string.IsNullOrEmpty(sheet.Cells[indents, i].Text)) sheet.Cells[indents + 1, i].Value = sheet.Cells[indents, i].Value;
                        else sheet.Cells[indents + 1, i].Value = "Столбец " + count; 
                    }
                    else
                    {
                        if (sheet.GetMergeCellId(indents, i) != 0 && columns.Count(x => x == sheet.Cells[indents + 1, i].Text) > 1)
                        {
                            sheet.Cells[indents + 1, i].Value += " " + sheet.Cells[sheet.MergedCells[sheet.GetMergeCellId(indents, i) - 1]].First().Value;
                        }
                    }
                    count++;
                }
            }
            for (int i = indents + 1; i < sheet.Dimension.End.Row + 1; i++)
            {
                for (int j = 1; j < sheet.Dimension.End.Column + 1; j++)
                {
                    if (sheet.Cells[i, j].Value == null) sheet.Cells[i, j].Value = "";
                }
            }
        }
        public static void GroupMethod(ExcelWorksheet sheet, int indents, int groupAmount, int currentGroup, List<DataObject> dataObject, int excludedColumn = 0)
        {
            int newIndent = indents + groupAmount;
            sheet.Cells[newIndent, 1].Value = sheet.Cells[indents + currentGroup, 1].Value;
            List<string[]> columns = new List<string[]>();
            for (int i = 0; i < groupAmount; i++)
            {
                string[] column = new string[sheet.Dimension.End.Column];
                for (int j = 0; j < sheet.Dimension.End.Column; j++)
                {
                    column[j] = sheet.Cells[indents + i + 1, j + 1].Text;
                }
                columns.Add(column);
            }
            for (int i = 1; i < sheet.Dimension.End.Column + 1; i++)
            {
                if (String.IsNullOrEmpty(sheet.Cells[newIndent, i].Text)) 
                {
                    for(int j = indents + groupAmount - 1; j > indents; j--)
                    {
                        if (sheet.Cells[j, i].Value != null)
                        {
                            if (columns[Math.Abs(groupAmount - j + 1)].Count(x => x == sheet.Cells[j, i].Text) > 1)
                            {
                                if (sheet.Cells[j - 1, i].Value != null) sheet.Cells[j, i].Value += " " + sheet.Cells[j - 1, i].Value;
                                else
                                {
                                    for(int k = i; k > 0; k--)
                                    {
                                        if (sheet.Cells[j - 1, k].Value != null) 
                                        {
                                            sheet.Cells[j, i].Value += " " + sheet.Cells[j - 1, k].Value;
                                            break;
                                        }
                                    }
                                }
                            }
                            sheet.Cells[newIndent, i].Value = sheet.Cells[j, i].Value;
                            break;
                        }
                    }
                } 
                else
                {
                    if (columns[columns.Count - 1].Count(x => x == sheet.Cells[newIndent, i].Text) > 1)
                    {
                        if (sheet.Cells[newIndent - 1, i].Value != null) sheet.Cells[newIndent, i].Value += " " + sheet.Cells[newIndent - 1, i].Value;
                        else
                        {
                            for (int k = i; k > 0; k--)
                            {
                                if (sheet.Cells[newIndent - 1, k].Value != null) sheet.Cells[newIndent, i].Value += " " + sheet.Cells[newIndent - 1, k].Value;
                                break;
                            }
                        }
                    }
                }
            }
            for(int i = 1; i < sheet.Dimension.End.Column + 1; i++)
            {
                dataObject.Add(new DataObject());
                for (int j = newIndent + 1; j < sheet.Dimension.End.Row + 1; j++)
                {
                    if (excludedColumn > 0 && sheet.Cells[j, excludedColumn].Value == null) continue;
                    if (sheet.Cells[j, 1].EntireRow.Collapsed) 
                    {
                        if (sheet.Cells[j, i].Value == null) sheet.Cells[j, i].Value = "";
                        dataObject[i - 1].data.Add(sheet.Cells[j, i].Text);
                        
                    }
                }
                dataObject[i-1].name = sheet.Cells[newIndent, i].Text;
            }
        }
    }
    public static class OtherTableMethods
    {
        public static List<int> ExcludedRows(ExcelWorksheet sheet, int column, int indents)
        {
            List<int> rows = new List<int>();
            for (int i = indents + 1; i < sheet.Dimension.End.Row; i++)
            {
                if (sheet.Cells[i, column].Value == null) rows.Add(i);
            }
            return rows;
        }
        public static List<int> ExcludedRows(List<DataObject> dataObjects, int column)
        {
            List<int> rows = new List<int>();
            for(int i = 0; i < dataObjects[0].data.Count; i++)
            {
                if (string.IsNullOrEmpty(dataObjects[column - 1].data[i])) 
                {
                    rows.Add(i);
                }
            }
            return rows;
        }
    }
    public class DataObject
    {
        public string name;
        public List<string> data = new List<string>();
    }
}
