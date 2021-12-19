
using ClosedXML.Excel;
using Microsoft.AspNetCore.Mvc;
using ShareModel;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.IO;
using System.Linq;
using System.Reflection;

namespace KhoaLuanTotNghiep_BackEnd.Util
{
    public class ExportFileHelper
    {
        public static FileContentResult ExportExcel(ICollection<ReportExcel> report, string workSheetName, string fileName)
        {
            if (report.Count > 0)
            {
                using (var workbook = new XLWorkbook())
                {
                    var worksheet = workbook.Worksheets.Add(workSheetName);
                    var currentRow = 1;
                    PropertyInfo[] properties = report.FirstOrDefault().GetType().GetProperties();//Lấy tên và giá trị các thuộc tính đầu tiên
                    for (int i = 0; i < properties.Length; i++)
                    {
                        var displayName = properties[i].GetCustomAttributes(typeof(DisplayNameAttribute), true).Cast<DisplayNameAttribute>().SingleOrDefault();// trả về 1 màn prop xác định và trả về 1 loại or mảng trống khi prop k xd
                        worksheet.Cell(currentRow, i + 1).Style.Font.SetBold();// in đậm hàng
                        worksheet.Cell(currentRow, i + 1).Value = displayName != null ? displayName.DisplayName.ToString() : properties[i].Name.ToString();
                    }
                    foreach (var reportmodel in report)
                    {
                        currentRow++;
                        PropertyInfo[] propertyInfos = reportmodel.GetType().GetProperties();
                        for (int i = 0; i < propertyInfos.Length; i++)
                        {
                            try
                            {
                                worksheet.Cell(currentRow, i + 1).Value = propertyInfos[i].GetValue(reportmodel).ToString();
                            }
                            catch (NullReferenceException ex)
                            {
                                throw new NullReferenceException();
                            }

                        }
                    }
                    using (var stream = new MemoryStream())
                    {
                        workbook.SaveAs(stream);
                        var content = stream.ToArray();
                        FileContentResult file = new FileContentResult(content, "application/vnd.openxmlformats-officedocument.spreadsheetml.sheet")
                        {
                            FileDownloadName = fileName + ".xlsx"
                        };
                        return file;
                    }
                }
            }
            return (FileContentResult)null;
        }
    }
}
