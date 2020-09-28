using System;
using System.Collections.Generic;
using System.IO;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using OfficeOpenXml;

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
                var list = new List<UserInfo>()
                {
                    new UserInfo { UserName = "catcher", Age = 18 },
                    new UserInfo { UserName = "james", Age = 20 },
                };

                var stream = new MemoryStream();

                using (var package = new ExcelPackage(stream))
                {
                    var workSheet = package.Workbook.Worksheets.Add("Sheet1");
                    workSheet.Cells.LoadFromCollection(list, true);

                    package.Save();
                }

                stream.Position = 0;
                string excelName = $"UserList-{DateTime.Now:yyyyMMddHHmmssfff}.xlsx";

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