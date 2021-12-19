using ShareModel;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace KhoaLuanTotNghiep_BackEnd.InterfaceService
{
    public interface INews
    {
        Task<ICollection<NewsModel>> GetListNewsAsync();

        Task<CreateNewsModel> CreateNewsAsync(CreateNewsModel newsModel, string userName);

        Task<NewsModel> UpdateNewsAsync(string id, NewsModel newsModel);
        Task<ICollection<NewsModel>> GetListNewsUserNameAsync(string userName);

        Task<bool> DeleteNewsAsync(string id);

        Task<NewsModel> GetNewsByIDAsync(string id);
    }
}
