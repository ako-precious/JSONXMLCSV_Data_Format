using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace JSONXMLCSV_Data_Format.classes
{
    internal class CsvFileFormat
    {
       

        
           string Categories = "Category";
           string Titles = "Title";
           string Authors = "Author";
           string Prices = "Prices";
        

        public void CreateCsvTable(string csvPath)
        {
            string[] lines = File.ReadAllLines(csvPath);

            PrintTableHeader();

            for (int i = 1; i < lines.Length; i++)
            {
                string[] data = lines[i].Split(',');

                if (data.Length >= 5)
                {
                    string category = data[0].Trim();
                    string title = data[1].Trim();
                    string author = data[2].Trim();
                    string year = data[3].Trim();
                    string price = data[4].Trim();

                    PrintTableRow(category, title, author, price);
                }
            }

            Console.WriteLine("-----------------------------------------------------------");
        }

        private void PrintTableHeader()
        {
            if (Categories != null && Titles != null && Authors != null && Prices != null)
            {
                Console.WriteLine("-----------------------------------------------------------");
                Console.WriteLine($"| {Categories.PadRight(25)} | {Titles.PadRight(25)} | {Authors.PadRight(70)} |  {Prices} | ");
                Console.WriteLine("-----------------------------------------------------------");
            }
            else
            {
                Console.WriteLine("Error: Header column names are not set.");
            }
        }

        private void PrintTableRow(string category, string title, string author, string price)
        {
            Console.WriteLine($"| {category.PadRight(25)} | {title.PadRight(25)} | {author.PadRight(70)} |  {price} | ");
        }

       
    }
}
