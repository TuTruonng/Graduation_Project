using KhoaLuanTotNghiep_BackEnd.Models;
using ShareModel;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace KhoaLuanTotNghiep_BackEnd.Interface
{
    public interface IUser
    {
        Task<ICollection<User>> GetAllUserAsync();
        Task<UserModel> CreateAsync(CreateClientModel createUser);
        Task<ICollection<UserModel>> GetAdminAsync();
        Task<ICollection<UserModel>> GetUserAsync();
        Task<UserModel> AddAsync(CreateUserModel createUser);
        Task<UserModel> UpdateAsync(string id, EditUserModel editUserDto);
        Task<bool> DisableAsync(string id);
        Task<bool> ChangeUserPasswordAsync(ChangeUserPasswordDto changeUserPasswordDto);
        Task<UserModel> GetInfoSalaryAsync(string userName);
    }
}
