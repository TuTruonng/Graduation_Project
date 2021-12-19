using KhoaLuanTotNghiep.Data;
using KhoaLuanTotNghiep_BackEnd.InterfaceService;
using KhoaLuanTotNghiep_BackEnd.Models;
using ShareModel;
using System;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Identity;

namespace KhoaLuanTotNghiep_BackEnd.Service
{
    public class NewsService : INews
    {
        private readonly ApplicationDbContext _dbContext;
        private readonly UserManager<User> _userManager;
        public NewsService(ApplicationDbContext dbContext, UserManager<User> userManager)
        {
            _dbContext = dbContext;
            _userManager = userManager;
        }
        public async Task<CreateNewsModel> CreateNewsAsync(CreateNewsModel newsModel, string userName)
        {
            var user = await _userManager.FindByNameAsync(userName);
            var query = _dbContext.Users.Where(x => x.Id == user.Id);
            var userid = await query.FirstOrDefaultAsync();
            if (userid == null)
            {
                throw new Exception("have not userid");
            }

            var news = new News
            {
                NewsID = Guid.NewGuid().ToString(),
                NewsName = newsModel.NewsName,
                //UserName = userName,
                UserID = user.Id,
                Img = newsModel.Img,
                Status = true,
                Description = newsModel.Description,
            };
            _dbContext.Add(news);
            var result = _dbContext.SaveChanges();
            return newsModel;
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

        public async Task<ICollection<NewsModel>> GetListNewsUserNameAsync(string userName)
        {
            var user = await _userManager.FindByNameAsync(userName);
            var queryable = _dbContext.news.AsQueryable();
            queryable = queryable.Where(n => n.UserID == user.Id && n.Status == true);
            var news = await queryable.Select(x =>
                        new NewsModel
                        {
                            //UserID = x.UserID,
                            UserName = x.user.UserName,
                            NewsID = x.NewsID,
                            NewsName = x.NewsName,
                            Description = x.Description,
                            Img = x.Img,

                        }).ToListAsync();
            return news;
        }


        /// <summary>
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        public async Task<bool> DeleteNewsAsync(string id)
        {
            var news = await _dbContext.news.FirstOrDefaultAsync(x => x.NewsID == id);
            if (news == null)
            {
                throw new Exception("Have not News");
            }
            news.Status = false;
            await _dbContext.SaveChangesAsync();
            return true;
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

        public async Task<NewsModel> GetNewsByIDAsync(string id)
        {
            var news = await _dbContext.news.Include(x => x.user).FirstOrDefaultAsync(x => x.NewsID == id);
            if (news == null)
            {
                throw new Exception("Have not News ID");
            }

            var newsModel = new NewsModel
            {
                NewsID = news.NewsID,
                UserID = news.UserID,
                UserName = news.user.UserName,
                NewsName = news.NewsName,
                Description = news.Description,
                Img = news.Img,
            };
            return newsModel;
        }


    }
}
