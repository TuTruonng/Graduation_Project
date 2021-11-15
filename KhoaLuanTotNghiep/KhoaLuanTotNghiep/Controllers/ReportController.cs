using KhoaLuanTotNghiep_BackEnd.Interface;
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
    [Route("[Controller]")]
    [ApiController]
    public class ReportController : ControllerBase
    {
        private readonly IReports _report; 
        public ReportController(IReports reports)
        {
            _report = reports;
        }

        [HttpPost]
        [AllowAnonymous] 
        public async Task<ActionResult<ReportModel>> CreateAsync(ReportModel reportModel)
        {
            reportModel.IPAddress = RequestHelpper.GetLocalIPAddress();
            if (!ModelState.IsValid) return BadRequest(reportModel);
            return Ok(await _report.CreateReportAsync(reportModel));
        }

        [HttpGet]
        [AllowAnonymous]
        public async Task<ActionResult<ReportModel>> GetListAsync()
        {
            if (!ModelState.IsValid) return BadRequest();
            return Ok(await _report.GetAllReportAsync());
        }

        [HttpDelete("{id}")]
        [AllowAnonymous]
        public async Task<ActionResult<bool>> DeleteAsync(string id)
        {
            if (string.IsNullOrEmpty(id)) return BadRequest("Report is not valid");
            return Ok(await _report.DeleteReportAsync(id));

        }

    }
}
