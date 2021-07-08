using OfficeOpenXml;
using OfficeOpenXml.Style;
using System;
using System.Collections.Generic;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EPPlus
{
    class Program
    {
        private static string EXCEL_SHEET = "CHANOS";

        private static string[] EXCEL_COLUMN = new[] { "타입", "시간", "내용", "이미지" };

        private const string DEFAULT_CELL = "A1";

        private const string EXCEL_FONT = "굴림";

        private const double DEFAULT_HEIGHT = 0.746;
        private const double DEFAULT_WIDTH = 7.005;

        static void Main(string[] args)
        {

            using (var excel = CreateDefaultExcel(@"C:\test.xlsx"))
            using (var sheet = excel.Workbook.Worksheets[EXCEL_SHEET])
            {

                sheet.Cells["A2"].Value = "Hello!! Hello!! Hello!! Hello!!";

                using (var image = Image.FromFile(@"C:\test.jpg"))
                {
                    var excelImage = sheet.Drawings.AddPicture("test", image);
                    excelImage.SetSize(200, 200);
                    excelImage.SetPosition(1, 0, 1, 0);
                }

                sheet.Row(2).Height = 200 * DEFAULT_HEIGHT;

                SetExcelStyle(sheet);

                sheet.Column(2).Width = 200 / DEFAULT_WIDTH; 

                excel.Save();

            }

            Console.WriteLine("Created Excel!");
        }

        private static ExcelPackage CreateDefaultExcel(string filePath)
        {
            if (File.Exists(filePath))
                File.Delete(filePath);

            ExcelPackage.LicenseContext = LicenseContext.Commercial;
            var excel = new ExcelPackage(new FileInfo(filePath));
            var sheet = excel.Workbook.Worksheets.Add(EXCEL_SHEET);

            sheet.Cells[DEFAULT_CELL].LoadFromText(string.Join(",", EXCEL_COLUMN));

            // default save
            excel.Save();

            return excel;
        }

        private static void SetExcelStyle(ExcelWorksheet sheet)
        {
            sheet.Cells[sheet.Dimension.Address].Style.HorizontalAlignment = ExcelHorizontalAlignment.Center;
            sheet.Cells[sheet.Dimension.Address].Style.VerticalAlignment = ExcelVerticalAlignment.Center;
            sheet.Cells[sheet.Dimension.Address].Style.Font.Name = EXCEL_FONT;
            sheet.Cells[sheet.Dimension.Address].AutoFitColumns();
            sheet.Cells[sheet.Dimension.Address].AutoFilter = true;
        }
    }
}
