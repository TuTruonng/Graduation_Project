using KhoaLuanTotNghiep_BackEnd.Interface;
using KhoaLuanTotNghiep_BackEnd.InterfaceService;
using KhoaLuanTotNghiep_BackEnd.Util;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using ShareModel;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Threading.Tasks;

namespace KhoaLuanTotNghiep_BackEnd.Controllers
{
    [Route("[controller]")]
    [ApiController]
    public class ReportController : ControllerBase
    {
        private readonly IReport _report;
        public ReportController(IReport reports)
        {
            _report = reports;
        }

        [HttpPost]
        [AllowAnonymous]
        public async Task<ActionResult<CreateReport>> CreateAsync(CreateReport reportModel)
        {
            reportModel.IPAddress = RequestHelpper.GetLocalIPAddress();
            if (!ModelState.IsValid) return BadRequest(reportModel);
            return Ok(await _report.CreateReportAsync(reportModel));
        }

        [HttpGet("export")]
        public async Task<FileContentResult> ExportAsync([FromQuery] ReportExcel reportRequestParams)
        {
            var report = await _report.ExportReportAsync(reportRequestParams);
            return ExportFileHelper.ExportExcel(report, "Report RealEstate", "Report");
        }

        [HttpGet]
        [Route("name={name}")]
        [AllowAnonymous]
        public async Task<ActionResult<ReportModel>> GetListAsync(string name)
        {
            if (!ModelState.IsValid) return BadRequest();
            return Ok(await _report.GetReportByUserNameAsync(name));
        }

        [HttpPut("disable/{id}")]
        [AllowAnonymous]
        public async Task<ActionResult<bool>> DeleteAsync([FromRoute] string id)
        {
            if (string.IsNullOrEmpty(id)) return BadRequest("Report is not valid");

            var result = await _report.DeleteReportAsync(id);
            return Ok(result);

        }
    }
}
