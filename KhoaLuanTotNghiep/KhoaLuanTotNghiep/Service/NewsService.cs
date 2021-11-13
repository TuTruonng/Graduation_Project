﻿using KhoaLuanTotNghiep.Data;
using KhoaLuanTotNghiep_BackEnd.InterfaceService;
using KhoaLuanTotNghiep_BackEnd.Models;
using ShareModel;
using System;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore;
using System.Linq;
using System.Threading.Tasks;

namespace KhoaLuanTotNghiep_BackEnd.Service
{
    public class NewsService : INews
    {
        private readonly ApplicationDbContext _dbContext;
        public NewsService(ApplicationDbContext dbContext)
        {
            _dbContext = dbContext;
        }
        public async Task<NewsModel> CreateNewsAsync(NewsModel newsModel)
        {
            var query = _dbContext.Users.Where(x => x.Id == newsModel.UserID);
            var userid = await query.FirstOrDefaultAsync();
            if (userid == null)
            {
                throw new Exception("have not userid");
            }
            newsModel.NewsID = Guid.NewGuid().ToString();

            var news = new News
            {
                NewsID = newsModel.NewsID,
                NewsName = newsModel.NewsName,
                UserName = newsModel.UserName,
                UserID = newsModel.UserID,
                Img = newsModel.Img,
                Description = newsModel.Description,
            };
            _dbContext.Add(news);
            var result = _dbContext.SaveChanges();
            if (result > 0)
            {
                return newsModel;
            }
            throw new Exception("Create News Fail");
        }

        public async Task<bool> DeleteCategoryAsync(string id)
        {
            var news = await _dbContext.news.FirstOrDefaultAsync(x => x.NewsID == id);
            if (news == null)
            {
                throw new Exception("Have not News");
            }
            var delete = _dbContext.news.Remove(news);
            var result = _dbContext.SaveChanges();
            if (result > 0)
            {
                return true;
            }
            throw new Exception("Delete fail");

        }

        public async Task<ICollection<NewsModel>> GetListNewsAsync()
        {
            var news = await _dbContext.news.Include(x => x.user).Select(x =>
                        new NewsModel
                        {
                            UserID = x.user.Id,
                            UserName = x.user.UserName,
                            NewsID = x.NewsID,
                            NewsName = x.NewsName,
                            Description = x.Description,
                            Img = x.Img,

                        }).ToListAsync();
            return news;
        }

        public async Task<NewsModel> UpdateNewsAsync(string id, NewsModel newsModel)
        {
            var news = await _dbContext.news.FirstOrDefaultAsync(x => x.NewsID == id);
            if (news == null)
            {
                throw new Exception("Have not NewsID");
            }
            newsModel.NewsID = Guid.NewGuid().ToString();
            news.NewsName = newsModel.NewsName;
            news.Description = newsModel.Description;
            news.Img = newsModel.Img;
            var result = await _dbContext.SaveChangesAsync();
            if (result > 0)
            {
                return newsModel;
            }
            throw new Exception("Update News fail");
        }
    }
}
