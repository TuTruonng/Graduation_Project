using KhoaLuanTotNghiep.Data;
using KhoaLuanTotNghiep_BackEnd.InterfaceService;
using KhoaLuanTotNghiep_BackEnd.Models;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using ShareModel;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace KhoaLuanTotNghiep_BackEnd.Service
{
    public class ReportService : IReport
    {
        private readonly ApplicationDbContext _dbContext;
        private readonly UserManager<User> _userManager;

        public ReportService(ApplicationDbContext dbContext, UserManager<User> userManager)
        {
            _dbContext = dbContext;
            _userManager = userManager;
        }

        public async Task<CreateReport> CreateReportAsync(CreateReport reportModel)
        {
            var report = await _dbContext.realEstates.FirstOrDefaultAsync(x => x.RealEstateID == reportModel.RealEstateID);
            if (report == null)
            {
                throw new Exception("Have not RealEstateID");
            }
            reportModel.ReportID = Guid.NewGuid().ToString();
            var model = new Report
            {
                RealEstateID = reportModel.RealEstateID,
                ReportID = reportModel.ReportID,
                Status = reportModel.Status,
                IPAddress = reportModel.IPAddress,
                CreaeTime = reportModel.CreateTime,
                UpadateTime = reportModel.UpdateTime,
                State = false,
            };
            var create = _dbContext.Add(model);
            var result = _dbContext.SaveChanges();
            if (result > 0)
            {
                return reportModel;
            }
            throw new Exception("Create News Fail");
        }

        public async Task<ICollection<ReportExcel>> ExportReportAsync(ReportExcel reportRequest)
        {
            var reportModel = await _dbContext.reports.Include(x => x.realEstates).Select(x =>
                       new ReportExcel
                       {
                           RealEstateID = x.realEstates.RealEstateID,
                           ReportID = Guid.NewGuid().ToString(),
                           Status = x.Status,
                           IPAddress = x.IPAddress,
                           CreateTime = x.CreaeTime,
                           UpdateTime = x.UpadateTime,

                       }).ToListAsync();
            return reportModel;
        }

        public async Task<ICollection<ReportModel>> GetReportByUserNameAsync(string userName)
        {
            var user = await _userManager.FindByNameAsync(userName);
            var queryable = _dbContext.reports.Include(r => r.realEstates).AsQueryable();
            queryable = queryable.Where(r => r.realEstates.AdminID == user.Id && r.State == false);
            var reportModel = await queryable.Select(r => new ReportModel
            {
                ReportID = Guid.NewGuid().ToString(),
                RealEstateID = r.realEstates.RealEstateID,
                Title = r.realEstates.Title,
                Status = r.Status,
                IPAddress = r.IPAddress,
                CreateTime = r.CreaeTime,
                UpdateTime = r.UpadateTime,

            }).ToListAsync();
            return reportModel;
        }

        public async Task<bool> DeleteReportAsync(string id)
        {
            var report = await _dbContext.reports.FirstOrDefaultAsync(x => x.ReportID == id);
            if (report == null)
            {
                throw new Exception("Have not report");
            }
            report.State = true;
            var result = _dbContext.SaveChanges();
            return true;

        }
    }
}

