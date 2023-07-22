using Newtonsoft.Json.Linq;
using OfficeOpenXml;

namespace JSONXMLCSV_Data_Format.classes
{
    internal class ExcelExport
    {
        public void SaveJsonToExcel(JArray jsonArray)
        {
            string excelFileName = "UsersInfo.xlsx";

            // Create an ExcelPackage object
            ExcelPackage excelPackage = new ExcelPackage();

            // Create a excelworksheet
            ExcelWorksheet excelworksheet = excelPackage.Workbook.Worksheets.Add("Users");

            // Set the header row
            excelworksheet.Cells[1, 1].Value = "Name";
            excelworksheet.Cells[1, 2].Value = "Email";
            excelworksheet.Cells[1, 3].Value = "Phone";
            excelworksheet.Cells[1, 4].Value = "Address";

            // Iterate through the JSON array and add the user data to the excelworksheet
            int row = 2;
            foreach (JObject user in jsonArray)
            {
                string name = user["name"].ToString();
                string email = user["email"].ToString();
                string phone = user["phone"].ToString();
                string address = $"{user["address"]["suite"]}-{user["address"]["street"].ToString()}, {user["address"]["city"].ToString()}";

                excelworksheet.Cells[row, 1].Value = name;
                excelworksheet.Cells[row, 2].Value = email;
                excelworksheet.Cells[row, 3].Value = phone;
                excelworksheet.Cells[row, 4].Value = address;

                row++;
            }

            // Save the Excel file
            FileInfo excelFile = new FileInfo(excelFileName);
            excelPackage.SaveAs(excelFile);

        }
        public class Book
        {
            public string Title { get; set; }
            public string[] Authors { get; set; }
            public int Year { get; set; }
            public decimal Price { get; set; }
            public string Category { get; set; }
            public string Cover { get; set; }
        }

        public class Bookstore
        {
            public Book[] Books { get; set; }
        }
       
    }
}
