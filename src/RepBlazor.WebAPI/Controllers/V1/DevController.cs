using System;
using System.IO;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using OfficeOpenXml;
using OfficeOpenXml.Style;

namespace RepBlazor.WebAPI.Controllers.V1
{
    public class DevController : BaseController
    {
        [AllowAnonymous]
        [HttpGet("index")]
        public ActionResult Index()
        {
            try
            {
                return Ok("Hello Dev");
            }
            catch (Exception exception)
            {
                return BadRequest($"Exception: {exception.Message}");
            }
        }

        [AllowAnonymous]
        [HttpGet("export")]
        public ActionResult Export()
        {
            try
            {
                const bool defaultFontBold = true;
                const int defaultFontSize = 12;
                const string defaultFontName = "Calibri";

                string headerName = "LAPORAN  KINERJA  HARIAN  / PIKET";
                string footerName = "Petugas";

                const bool headerFontBold = true;
                const int headerFontSize = 16;
                const string headerFontName = "Calibri";

                const double A_ColumnWidth = 5.5;
                const double B_ColumnWidth = 10;
                const double C_ColumnWidth = 5;
                const double D_ColumnWidth = 60;
                const double E_ColumnWidth = 15;
                const double F_ColumnWidth = 15;

                const string A_TableHeader = "NO";
                const string B_TableHeader = "WAKTU";
                const string C_TableHeader = "KEGIATAN";
                const string F_TableHeader = "KETERANGAN";

                const string subjectName = "Nama";
                const string subjectDateTime = "Tanggal";
                const string subjectDay = "Hari";

                string userName = "Sri Dayani";
                string userNip = "PPTS. 0122017";
                string activityDateTime = "01 Maret 2020";
                string activityDay = "Minggu";

                string holidayMessage = "LIBUR MINGGUAN";

                // tableBorders
                string tableBorders = "A7:F41";
                // total-merge-table-column-kegiatan
                int totalMergeKegiatanColumns = 41;
                // scale
                int pageScale = 80;
                // page-layout
                ePaperSize pageLayout = ePaperSize.Legal;

                // isHoliday
                bool IsHoliday = false;
                // IsAfterPiket
                bool _ = false;

                // max-character-per-row -> 43

                var stream = new MemoryStream();

                using (var package = new ExcelPackage(stream))
                {
                    string workSheetName = "Day, Date";
                    var workSheet = package.Workbook.Worksheets.Add(workSheetName);

                    #region DefaultWorksheetSettings
                    // page-size
                    workSheet.PrinterSettings.PaperSize = pageLayout;
                    // page-scale
                    workSheet.PrinterSettings.Scale = pageScale;

                    // defaultFontSize
                    workSheet.Cells["A1:F252"].Style.Font.Size = defaultFontSize;
                    // defaultFontName
                    workSheet.Cells["A1:F252"].Style.Font.Name = defaultFontName;
                    // defaultverticalAlignment All Columns
                    workSheet.Cells[workSheet.Dimension.Address].Style.VerticalAlignment = ExcelVerticalAlignment.Center;
                    // defaultRowHeight
                    workSheet.DefaultRowHeight = 23;

                    // defaultTableBorder-Top
                    workSheet.Cells[tableBorders].Style.Border.Top.Style = ExcelBorderStyle.Thin;
                    // defaultTableBorder-Bottom
                    workSheet.Cells[tableBorders].Style.Border.Bottom.Style = ExcelBorderStyle.Thin;
                    // defaultTableBorder-Left
                    workSheet.Cells[tableBorders].Style.Border.Left.Style = ExcelBorderStyle.Thin;
                    // defaultTableBorder-Right
                    workSheet.Cells[tableBorders].Style.Border.Right.Style = ExcelBorderStyle.Thin;

                    // default "horizontalAlignment" table columns "NO"
                    workSheet.Cells["A8:A41"].Style.HorizontalAlignment = ExcelHorizontalAlignment.Center;
                    // default "horizontalAlignment" table columns "WAKTU"
                    workSheet.Cells["B8:B41"].Style.HorizontalAlignment = ExcelHorizontalAlignment.Center;
                    // default "horizontalAlignment" table columns "KEGIATAN"
                    workSheet.Cells["D8:D41"].Style.HorizontalAlignment = ExcelHorizontalAlignment.Left;
                    // default "horizontalAlignment" table columns "KETERANGAN"
                    workSheet.Cells["F8:F41"].Style.HorizontalAlignment = ExcelHorizontalAlignment.Left;
                    #endregion

                    #region Header
                    // headerName
                    workSheet.Cells[1, 1].Value = headerName;
                    // font.bold
                    workSheet.Cells[1, 1].Style.Font.Bold = headerFontBold;
                    // font.size
                    workSheet.Cells[1, 1].Style.Font.Size = headerFontSize;
                    // font.name
                    workSheet.Cells[1, 1].Style.Font.Name = headerFontName;
                    // horizontalAlignment
                    workSheet.Cells["A1:F1"].Style.HorizontalAlignment = ExcelHorizontalAlignment.Center;
                    // verticalAlignment
                    workSheet.Cells["A1:F1"].Style.VerticalAlignment = ExcelVerticalAlignment.Center;
                    // horizontalAlignment Column C
                    workSheet.Column(3).Style.HorizontalAlignment = ExcelHorizontalAlignment.Center;

                    // merge
                    workSheet.Cells["A1:F1"].Merge = true;
                    // merge
                    workSheet.Cells["A6:F6"].Merge = true;
                    #endregion

                    #region Subject Name
                    // subject Name
                    workSheet.Cells[3, 1].Value = subjectName;
                    // font.bold
                    workSheet.Cells[3, 1].Style.Font.Bold = defaultFontBold;
                    // separator
                    workSheet.Cells[3, 3].Value = ":";
                    // userName
                    workSheet.Cells[3, 4].Value = userName;
                    // merge
                    workSheet.Cells["A3:B3"].Merge = true;
                    #endregion

                    #region Subject DateTime
                    // subject DateTime
                    workSheet.Cells[4, 1].Value = subjectDateTime;
                    // font.bold
                    workSheet.Cells[4, 1].Style.Font.Bold = defaultFontBold;
                    // separator
                    workSheet.Cells[4, 3].Value = ":";
                    // dateTime
                    workSheet.Cells[4, 4].Value = activityDateTime;
                    // merge
                    workSheet.Cells["A4:B4"].Merge = true;
                    #endregion

                    #region Subject Day
                    // subject Day
                    workSheet.Cells[5, 1].Value = subjectDay;
                    // font.bold
                    workSheet.Cells[5, 1].Style.Font.Bold = defaultFontBold;
                    // separator
                    workSheet.Cells[5, 3].Value = ":";
                    // day
                    workSheet.Cells[5, 4].Value = activityDay;
                    // merge
                    workSheet.Cells["A5:B5"].Merge = true;
                    #endregion

                    #region primary table header
                    // A_TableHeader
                    workSheet.Cells[7, 1].Value = A_TableHeader;
                    // B_TableHeader
                    workSheet.Cells[7, 2].Value = B_TableHeader;
                    // C_TableHeader
                    workSheet.Cells[7, 3].Value = C_TableHeader;
                    // E_TableHeader
                    workSheet.Cells[7, 6].Value = F_TableHeader;

                    // font.bold
                    workSheet.Cells["A7:F7"].Style.Font.Bold = defaultFontBold;
                    // horizontalAlignment
                    workSheet.Cells["A7:F7"].Style.HorizontalAlignment = ExcelHorizontalAlignment.Center;
                    // merge
                    workSheet.Cells["C7:E7"].Merge = true;
                    #endregion

                    // merge all kegiatan columns
                    for (int i = 8; i <= totalMergeKegiatanColumns; i++)
                    {
                        workSheet.Cells[$"D{i}:E{i}"].Merge = true;
                    }

                    // check if isHoliday
                    if (IsHoliday)
                    {
                        // holidayMessage
                        workSheet.Cells[25, 4].Value = holidayMessage;
                        // font.bold
                        workSheet.Cells[25, 4].Style.Font.Bold = defaultFontBold;
                        // horizontalAlignment
                        workSheet.Cells[25, 4].Style.HorizontalAlignment = ExcelHorizontalAlignment.Center;
                    }

                    #region footer
                    workSheet.Cells[44, 5].Value = footerName;
                    workSheet.Cells[48, 5].Value = userName;
                    workSheet.Cells[49, 5].Value = userNip;

                    // horizontalAlignment
                    workSheet.Cells["E44:E49"].Style.HorizontalAlignment = ExcelHorizontalAlignment.Center;
                    // font.bold
                    workSheet.Cells["E44:E49"].Style.Font.Bold = defaultFontBold;
                    #endregion

                    #region default column width
                    // A_ColumnWidth
                    workSheet.Column(1).Width = A_ColumnWidth;
                    // B_ColumnWidth
                    workSheet.Column(2).Width = B_ColumnWidth;
                    // C_ColumnWidth
                    workSheet.Column(3).Width = C_ColumnWidth;
                    // D_ColumnWidth
                    workSheet.Column(4).Width = D_ColumnWidth;
                    // E_ColumnWidth
                    workSheet.Column(5).Width = E_ColumnWidth;
                    // F_ColumnWidth
                    workSheet.Column(6).Width = F_ColumnWidth;
                    #endregion

                    //workSheet.Cells.LoadFromCollection(list, true);

                    package.Save();
                }

                stream.Position = 0;
                string excelName = $"Laporan Kinerja Harian Pegawai - {userName} - {DateTime.Now:MMMM-yyyy}.xlsx";

                //return File(stream, "application/octet-stream", excelName);
                return File(stream, "application/vnd.openxmlformats-officedocument.spreadsheetml.sheet", excelName);
            }
            catch (Exception exception)
            {
                return BadRequest($"Exception: {exception.Message}");
            }
        }

        public class UserInfo
        {
            public string UserName { get; set; }
            public int Age { get; set; }
        }
    }
}