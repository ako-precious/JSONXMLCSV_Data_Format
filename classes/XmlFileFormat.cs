using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml;
using System.Xml.Linq;

namespace JSONXMLCSV_Data_Format.classes
{
    internal class XmlFileFormat
    {
        public void CreateXmlTable(string xmlPath)
        {
            XDocument xmlDoc = XDocument.Load(xmlPath);

            var books = xmlDoc.Descendants("book")
                .Select(book => new
                {
                    Category = (string)book.Attribute("category"),
                    Title = (string)book.Element("title"),
                    Authors = string.Join(", ", book.Elements("author").Select(author => (string)author)),
                    Price = (string)book.Element("price"),
                    Cover = (string)book.Attribute("cover") ?? ""
                })
                .ToList();

            // Create a table
            Console.WriteLine("-----------------------------------------------------------------------");
            Console.WriteLine($"| {Categories.PadRight(25)} | {Titles.PadRight(25)} | {Authors.PadRight(70)} |  {Prices} | ");
            Console.WriteLine("-----------------------------------------------------------------------");

            foreach (var book in books)
            {
                Console.WriteLine($"| {book.Category.PadRight(25)} | {book.Title.PadRight(25)} | {book.Authors.PadRight(70)} |  {book.Price} | ");
            }

            Console.WriteLine("-----------------------------------------------------------------------");
        }

        // Constants for formatting table headers
        private const string Categories = "Category";
        private const string Titles = "Title";
        private const string Authors = "Authors";
        private const string Prices = "Price";
    }
}
