using KhoaLuanTotNghiep.Data;
using KhoaLuanTotNghiep_BackEnd.Interface;
using KhoaLuanTotNghiep_BackEnd.Models;
using Microsoft.EntityFrameworkCore;
using ShareModel;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Sockets;
using System.Threading.Tasks;

namespace KhoaLuanTotNghiep_BackEnd.Service
{
    public class ReportService : IReports
    {
        private readonly ApplicationDbContext _dbContext;

        public ReportService (ApplicationDbContext dbContext)
        {
            _dbContext = dbContext;
        }

        public async Task<ReportModel> CreateReportAsync(ReportModel reportModel)
        {
            var report = await _dbContext.realEstates.FirstOrDefaultAsync(x => x.RealEstateID == reportModel.RealEstatetID);
            if(report == null)
            {
                throw new Exception("Have not RealEstateID");
            }
            reportModel.ReportID = Guid.NewGuid().ToString();
            var model = new Report
            {
                RealEstatetID = reportModel.RealEstatetID,
                ReportID = reportModel.ReportID,
                Status = reportModel.Status,
                IPAddress = reportModel.IPAddress,
                CreateTime = reportModel.CreateTime,
                UpdateTime = reportModel.UpdateTime,
            };
            var create = _dbContext.Add(model);
            var result = _dbContext.SaveChanges();
            if (result > 0)
            {
                return reportModel;
            }
            throw new Exception("Create News Fail");
        }

        public async Task<bool> DeleteReportAsync(string id)
        {
            var report = await _dbContext.reports.FirstOrDefaultAsync(x => x.ReportID == id);
            if (report == null)
            {
                throw new Exception("Have not report");
            }
            var delete = _dbContext.reports.Remove(report);
            var result = _dbContext.SaveChanges();
            if (result > 0)
            {
                return true;
            }
            throw new Exception("Delete fail");

        }

        public async Task<IEnumerable<ReportModel>> GetAllReportAsync()
        {

            var reportModel = await _dbContext.reports.Include(x => x.realEstate).Select(x =>
                        new ReportModel
                        {
                            RealEstatetID = x.RealEstatetID,
                            ReportID = Guid.NewGuid().ToString(),
                            Status = x.Status,
                            IPAddress = x.IPAddress,
                            CreateTime = x.CreateTime,
                            UpdateTime = x.UpdateTime,

                        }).ToListAsync();
            return reportModel;
        }
    }
}
