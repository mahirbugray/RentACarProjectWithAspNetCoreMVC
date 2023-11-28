using BAU_Project_RentACarPortal.App.Entity.ViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BAU_Project_RentACarPortal.App.Entity.Services
{
    public interface IAccountService
    {
        Task<string> CreateUserAsync(RegisterViewModel model);
        Task<string> FindByNameAsync(LoginViewModel model);
        Task<UserViewModel> FindAsync(string name);

        Task<List<UserViewModel>> GetAllUsersAsync();
        Task<string> DeleteUserByIdAsync(string userId);
        Task LogoutAsync();
        Task UpdatePassword(PasswordResetViewModel model);
        Task<PasswordResetViewModel> FindUser(PasswordResetViewModel model);
        Task<UserViewModel> UpdateUserInformation(UserViewModel model, string SuankiSifre);
        Task<string> CreateRoleAsync(RoleViewModel model);
        Task<List<RoleViewModel>> GetRoles();
        Task<RoleViewModel> FindByIdAsync(string id);
        Task<UsersInOrOutViewModel> GetAllUsersByRole(string id);
        Task<string> EditRoleListAsync(EditRoleViewModel model);
        Task DeleteRoleAsync(int id);

    }
}
