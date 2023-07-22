using Newtonsoft.Json.Linq;
using OfficeOpenXml;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static JSONXMLCSV_Data_Format.classes.ExcelExport;

namespace JSONXMLCSV_Data_Format.classes
{
    internal class JsonFile
    {
        public void CreateJsonBookstoreTable(string filePath)
        {

            string json = File.ReadAllText(filePath);

            JObject bookstoreData = JObject.Parse(json);
            JArray books = (JArray)bookstoreData["bookstore"]["book"];

            Dictionary<string, Dictionary<string, string>> bookstoreTable = new Dictionary<string, Dictionary<string, string>>();

            foreach (var book in books)
            {
                string title = book["title"]["__text"].ToString();
                string author = book["author"].Type == JTokenType.String ? book["author"].ToString() : string.Join(", ", book["author"]);
                string year = book["year"].ToString();
                string price = book["price"].ToString();
                string category = book["_category"].ToString();
                string cover = book["_cover"]?.ToString();

                Dictionary<string, string> bookData = new Dictionary<string, string>
                {
                    { "Title", title },
                    { "Author", author },
                    { "Year", year },
                    { "Price", price },
                    { "Category", category }
                };

                if (!string.IsNullOrEmpty(cover))
                {
                    bookData.Add("Cover", cover);
                }

                bookstoreTable.Add(title, bookData);
            }

            // Printing the table
            foreach (var bookEntry in bookstoreTable)
            {
                Console.WriteLine($"Title: {bookEntry.Key}");
                foreach (var dataEntry in bookEntry.Value)
                {
                    Console.WriteLine($"{dataEntry.Key}: {dataEntry.Value}");
                }
                Console.WriteLine();
            }


        }

        public void ExportToExcel(string jsonFilePath, string excelFilePath)
        {
          
                string json = File.ReadAllText(jsonFilePath);

                JObject bookstoreData = JObject.Parse(json);
                JArray books = (JArray)bookstoreData["bookstore"]["book"];

                using (var package = new ExcelPackage())
                {
                    ExcelWorksheet worksheet = package.Workbook.Worksheets.Add("Books");

                    int row = 1;
                    worksheet.Cells[row, 1].Value = "Title";
                    worksheet.Cells[row, 2].Value = "Author";
                    worksheet.Cells[row, 3].Value = "Year";
                    worksheet.Cells[row, 4].Value = "Price";
                    worksheet.Cells[row, 5].Value = "Category";
                    worksheet.Cells[row, 6].Value = "Cover";

                    row++;

                    foreach (var book in books)
                    {
                        string title = book["title"]["__text"].ToString();
                        string author = book["author"].Type == JTokenType.String ? book["author"].ToString() : string.Join(", ", book["author"]);
                        string year = book["year"].ToString();
                        string price = book["price"].ToString();
                        string category = book["_category"].ToString();
                        string cover = book["_cover"]?.ToString();

                        worksheet.Cells[row, 1].Value = title;
                        worksheet.Cells[row, 2].Value = author;
                        worksheet.Cells[row, 3].Value = year;
                        worksheet.Cells[row, 4].Value = price;
                        worksheet.Cells[row, 5].Value = category;
                        worksheet.Cells[row, 6].Value = cover;

                        row++;
                    }

                    // Save the Excel file
                    FileInfo excelFile = new FileInfo(excelFilePath);
                    package.SaveAs(excelFile);
                }

                Console.WriteLine($"Excel file '{excelFilePath}' created successfully.");
            
        }

    }
}
