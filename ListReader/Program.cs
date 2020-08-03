using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ASP_MyBSNList.Models;

namespace ListReader
{
    class Program
    {
        public struct ListData
        {
            public string[] Accessors;
            public List<Dictionary<string,string>> Rows;

            public ListData(string[] accessors, List<Dictionary<string, string>> rows)
            {
                Accessors = new string[accessors.Length];

                for (int i = 0; i < accessors.Length; i++)
                    Accessors[i] = accessors[i];

                Rows = new List<Dictionary<string, string>>();

                foreach (Dictionary<string, string> row in rows)
                {
                    Rows.Add(row);
                }
            }
        }

        static void Main(string[] args)
        {
            ListData listData = LoadList("./list.csv");

            foreach (Dictionary<string, string> row in listData.Rows)
            {
                Console.WriteLine(string.Join(",",row.Values.ToArray()));
                //Console.WriteLine(row["List"]);
            }

            Console.WriteLine("Done!");
            Console.ReadKey();
        }

        public static ListData LoadList(string path)
        {
            string[] listData = File.ReadAllLines(path);
            string[] columnsRaw = listData.FirstOrDefault()?.Split(',').Select(s => s.Replace(" ", string.Empty)).ToArray();

            string[] accessors = columnsRaw?.Where(s =>
            {
                if (s == string.Empty)
                    return false;

                return true;
            }).ToArray();

            Console.WriteLine("Creating list data with accessors: " + string.Join(",", accessors));

            List<Dictionary<string, string>> rows = new List<Dictionary<string, string>>();

            for (int i = 1; i < listData.Length; i++)
            {
                string[] cells = listData[i].Split(',');
                Dictionary<string, string> row = new Dictionary<string, string>();

                if (cells.FirstOrDefault() == string.Empty)
                    continue;

                int cellIndexOffset = 0;

                for (int j = 0; j < accessors.Length; ++j)
                {
                    string cellValue = cells[j - cellIndexOffset];
                    string cellData = j < cells.Length ? (cellValue != "" ? cellValue : "UKN") : "UKN";

                    row.Add(accessors[j], cellData);
                }

                rows.Add(row);
            }

            Console.WriteLine(rows.Count + " rows created");

            return new ListData(accessors,rows);
        }

        /*static Person MakePerson(string[] data)
        {

        }*/
    }
}
