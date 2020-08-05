using OfficeOpenXml;
using System;
using System.IO;
using System.Linq;
using EntityDataContext;
using ExcelWorker;
using Microsoft.Extensions.Hosting;

namespace ExcelWorkerMain
{
    public class ExcelWorker
    {
        public ExcelWorker()
        {
            ExcelPackage.LicenseContext = LicenseContext.NonCommercial;
        }

        public void ReadExcel(string excelPath)
        {
            var fileInfo = new FileInfo(excelPath);
            using var excelPackage = new ExcelPackage(fileInfo);

            var firstWorksheet = excelPackage.Workbook.Worksheets[0];

            //Get a WorkSheet by name. If the worksheet doesn't exist, throw an exeption
            var namedWorksheet = excelPackage.Workbook.Worksheets["SomeWorksheet"];

            //If you don't know if a worksheet exists, you could use LINQ,
            //So it doesn't throw an exception, but return null in case it doesn't find it
            var anotherWorksheet =
                excelPackage.Workbook.Worksheets.FirstOrDefault(x => x.Name == "SomeWorksheet");

            //Get the content from cells A1 and B1 as string, in two different notations
            string valA1 = firstWorksheet.Cells["A1"].Value.ToString();
            string valB1 = firstWorksheet.Cells[1, 2].Value.ToString();

            //Save your file
            excelPackage.Save();
        }

        public void TestDatabaseConnection(EntityDatabaseContext databaseContext)
        {

        }
    }
}
