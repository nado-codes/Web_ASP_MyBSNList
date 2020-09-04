using System.Collections.Generic;
using System.IO;
using ASP_MyBSNList.Controllers.Api;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Newtonsoft.Json;
using Newtonsoft.Json.Linq;

namespace ASP_MyBSNList_Tests
{
    [TestClass]
    public class ListUploadControllerIntegrationTests
    {
        [TestMethod]
        public void UploadCSV()
        {
            string json = ConvertCsvFileToJsonObject(@"D:\Storage\Projects\Web\ASP\_MyBSNList\ListReader\bin\Debug\list.csv");
            JArray jsonArray = JArray.Parse(json);

            ListUploadController listUpload = new ListUploadController();
            listUpload.PostDefault(jsonArray);
        }

        //..This method can't handle commas properly i.e. all commas will be treated as a new field, regardless of
        //whether they are part of a "string" within a field
        private string ConvertCsvFileToJsonObject(string path)
        {
            var csv = new List<string[]>();
            var lines = File.ReadAllLines(path);

            foreach (string line in lines)
                csv.Add(line.Split(','));

            var properties = lines[0].Split(',');

            var listObjResult = new List<Dictionary<string, string>>();

            for (int i = 1; i < lines.Length; i++)
            {
                var objResult = new Dictionary<string, string>();
                for (int j = 0; j < properties.Length; j++)
                    objResult.Add(properties[j], csv[i][j]);

                listObjResult.Add(objResult);
            }

            return JsonConvert.SerializeObject(listObjResult);
        }
    }
}
