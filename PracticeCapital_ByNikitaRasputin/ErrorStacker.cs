using PracticeCapital_ByNikitaRasputin.Properties;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PracticeCapital_ByNikitaRasputin
{
    public class ErrorStacker
    {
        public string errorStack = "";
        public void AddError(string inn, string resource, Exception ex)
        {
            errorStack += $"INN: {inn}, Resource: {resource}\n{ex}\n\n";
        }
        public void AddError(string analysis, Exception ex)
        {
            errorStack += $"Analysis: {analysis}\n{ex}\n\n";
        }
        public void Save()
        {
            Random r = new Random(); int rn = r.Next(1000000, 99999999);
            if (!File.Exists($"C:/Users/{Environment.UserName}/Documents/ContragentDataGatherer/errorstack{rn}.txt"))
            {
                File.Create($"C:/Users/{Environment.UserName}/Documents/ContragentDataGatherer/errorstack{rn}.txt").Close();
            }
            File.WriteAllText($"C:/Users/{Environment.UserName}/Documents/ContragentDataGatherer/errorstack{rn}.txt", errorStack);
        }
        
    }
}
