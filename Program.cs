using JSON_XML_CSV_Data_Format.models;
using JSONXMLCSV_Data_Format.classes;
using Newtonsoft.Json.Linq;

string url = "https://jsonplaceholder.typicode.com/users";
JsonFileFormat UrlJsonData = new();
string jsonData = UrlJsonData.GetJsonFromUrl(url);

Console.WriteLine("\n ============ Get Json Data From URL ============== \n");
Console.WriteLine(jsonData);
Console.WriteLine();

JArray jsonObj = JArray.Parse(jsonData);
DisplayUserInfo userInfo = new();
Console.WriteLine("\nUsers Name \n");
userInfo.DisplayName(jsonObj);
Console.WriteLine();

Console.WriteLine("\nUsers Phone Number \n");
userInfo.DisplayPhoneNumber(jsonObj);
Console.WriteLine();

Console.WriteLine("\nUsers Email \n");
userInfo.DisplayEmail(jsonObj);
Console.WriteLine();

Console.WriteLine("\nUser Address \n");
userInfo.DisplayAddress(jsonObj);
Console.WriteLine();

Console.WriteLine("\nUsers Table \n");
userInfo.DisplayUserInfoTable(jsonObj);
Console.WriteLine();

Console.WriteLine("\n ============ Save User Information Into Excel ============== \n");
ExcelExport jsonToExcel = new();
jsonToExcel.SaveJsonToExcel(jsonObj);
Console.WriteLine();



string csvFilePath = @"C:\Users\akopr\OneDrive\Documents\Books\books.csv";
string xmlFilePath = @"C:\Users\akopr\OneDrive\Documents\Books\books.xml";
string jsonFilePath = @"C:\Users\akopr\OneDrive\Documents\Books\books.json";

Console.WriteLine("\n ============ Table for XMl file ============== \n");
XmlFileFormat xmlFormat = new();
xmlFormat.CreateXmlTable(xmlFilePath);
Console.WriteLine();

Console.WriteLine("\n ============ Table for CSV file ============== \n");
CsvFileFormat csvFormat = new();
csvFormat.CreateCsvTable(csvFilePath);
Console.WriteLine();

Console.WriteLine("\n ============ Table for JSON file ============== \n");
JsonFile jsonformat = new();
jsonformat.CreateJsonBookstoreTable(jsonFilePath);
Console.WriteLine();


Console.WriteLine("\n ============ Excel file for JSON file ============== \n");
string excelFilePath = "Bookstore.xlsx";
jsonformat.ExportToExcel(jsonFilePath, excelFilePath);
Console.WriteLine($"Excel file created: {excelFilePath}");
Console.WriteLine();
