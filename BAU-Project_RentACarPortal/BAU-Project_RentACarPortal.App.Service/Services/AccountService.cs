using AutoMapper;
using BAU_Project_RentACarPortal.App.DataAccess.Identity.Model;
using BAU_Project_RentACarPortal.App.Entity.Services;
using BAU_Project_RentACarPortal.App.Entity.ViewModels;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BAU_Project_RentACarPortal.App.Service.Services
{
    public class AccountService : IAccountService
    {
        private readonly UserManager<AppUser> _userManager;
        private readonly RoleManager<AppRole> _roleManager;
        private readonly SignInManager<AppUser> _signInManager;
        private readonly IMapper _mapper;

        public AccountService(UserManager<AppUser> userManager, RoleManager<AppRole> roleManager, SignInManager<AppUser> signInManager, IMapper mapper)
        {
            _userManager = userManager;
            _roleManager = roleManager;
            _signInManager = signInManager;
            _mapper = mapper;
        }

        public async Task<string> CreateUserAsync(RegisterViewModel model)
        {
            string message = string.Empty;
            var user = new AppUser()
            {
                Name = model.FirstName,
                Surname = model.LastName,
                Email = model.Email,
                PhoneNumber = model.PhoneNumber,
                UserName = model.Username,
                Cinsiyet = model.Cinsiyet,
                DogumYili = model.DogumYili,
                TCKNo = model.TcNo,
                Adres = model.Adres,
            };

            var identityResult = await _userManager.CreateAsync(user, model.ConfirmPassword);

            if (identityResult.Succeeded)
            {
                message = "OK";
            }
            else
            {
                foreach (var error in identityResult.Errors)
                {
                    message = error.Description;
                }
            }
            return message;
        }

        public async Task<string> DeleteUserByIdAsync(string userId)
        {
            var user = await _userManager.FindByIdAsync(userId);
            if (user == null)
            {
                return "Kullanıcı bulunamadı";
            }

            var result = await _userManager.DeleteAsync(user);
            if (result.Succeeded)
            {
                return "OK";
            }
            else
            {
                return $"Kullanıcı silinemedi : {string.Join(", ", result.Errors.Select(e => e.Description))}";
            }
        }

        public async Task<UserViewModel> FindAsync(string name)
        {
            var user = await _userManager.FindByNameAsync(name);
            return _mapper.Map<UserViewModel>(user);
        }

        public async Task<string> FindByNameAsync(LoginViewModel model)
        {
            string message = string.Empty;
            var user = await _userManager.FindByNameAsync(model.Username);
            if (user == null)
            {
                message = "user not found";
                return message;
            }
            var signInResult = await _signInManager.PasswordSignInAsync(user, model.Password, model.RememberMe, false);
            if (signInResult.Succeeded)
            {
                message = "OK";
            }
            return message;
        }
        public async Task<List<UserViewModel>> GetAllUsersAsync()
        {
            var list = await _userManager.Users.ToListAsync();
            return _mapper.Map<List<UserViewModel>>(list);
        }

        public async Task LogoutAsync()
        {
            await _signInManager.SignOutAsync();
        }
        public async Task<PasswordResetViewModel> FindUser(PasswordResetViewModel model) //model üzerinden email ve kullanıcıadı çekiliyor.
        {
            PasswordResetViewModel passwordReset = new PasswordResetViewModel();
            if (model.Email != null && model.Username != null)
            {
                var user = await _userManager.FindByEmailAsync(model.Email);
                if (user != null && user.UserName == model.Username)
                {
                    passwordReset.Token = await _userManager.GeneratePasswordResetTokenAsync(user);
                    passwordReset.Id = user.Id;
                    return passwordReset;
                }
            }
            return passwordReset;
        }

        public async Task UpdatePassword(PasswordResetViewModel model)
        {
            var user = await _userManager.FindByIdAsync(model.Id.ToString());
            if (user != null)
            {
                await _userManager.ResetPasswordAsync(user, model.Token, model.Password);
            }
        }

        public async Task<UserViewModel> UpdateUserInformation(UserViewModel model, string SuankiSifre)
        {
            var kullanici = await _userManager.FindByIdAsync(model.Id.ToString());

            if(kullanici != null)
            {
                kullanici.PhoneNumber = model.PhoneNumber;
                kullanici.Adres=model.Adres;
                kullanici.Email = model.Email;
                await _userManager.ChangePasswordAsync(kullanici, SuankiSifre, model.YeniSifre);
            }
            await _userManager.UpdateAsync(kullanici);
            model.YeniSifre = null;
            model.YeniSifreTekrar = null;
            return model;
        }

        public async Task<string> CreateRoleAsync(RoleViewModel model)
        {
            string message = string.Empty;
            var role = new AppRole()
            {
                Name = model.Name,
                Description = model.Description
            };

            var result = await _roleManager.CreateAsync(role);
            if (result.Succeeded)
            {
                message = "OK";
            }
            else
            {
                foreach (var error in result.Errors)
                {
                    message = error.Description;
                }
            }
            return message;
        }

        public async Task<List<RoleViewModel>> GetRoles()
        {
            var roles = await _roleManager.Roles.ToListAsync();
            return _mapper.Map<List<RoleViewModel>>(roles);
        }

        public async Task<RoleViewModel> FindByIdAsync(string id)
        {
            var role = await _roleManager.FindByIdAsync(id);
            return _mapper.Map<RoleViewModel>(role);
        }

        public async Task<UsersInOrOutViewModel> GetAllUsersByRole(string id)
        {
            var role = await this.FindByIdAsync(id);

            var usersInRole = new List<AppUser>();
            var usersOutRole = new List<AppUser>();

            var users = await _userManager.Users.ToListAsync();

            foreach (var user in users)
            {
                if (await _userManager.IsInRoleAsync(user, role.Name))
                {
                    usersInRole.Add(user);           //Bu rolde bulunan kullanıcıların listesi

                }
                else
                {
                    usersOutRole.Add(user);         //Bu rolde bulunmayan kullanıcıların listesi

                }
            }


            UsersInOrOutViewModel model = new UsersInOrOutViewModel()
            {
                Role = _mapper.Map<RoleViewModel>(role),
                UsersInRole = _mapper.Map<List<UserViewModel>>(usersInRole),
                UsersOutRole = _mapper.Map<List<UserViewModel>>(usersOutRole)
            };
            return model;
        }

        public async Task<string> EditRoleListAsync(EditRoleViewModel model)
        {
            string message = "OK";
            foreach (var userId in model.UsersIdsToAdd ?? new string[] { })
            {
                var user = await _userManager.FindByIdAsync(userId);
                if (user != null)
                {
                    var result = await _userManager.AddToRoleAsync(user, model.RoleName);
                    if (!result.Succeeded)
                    {
                        message = $"{user.UserName} role eklenemedi.";
                    }
                }

            }
            foreach (var userId in model.UsersIdsToDelete ?? new string[] { })
            {
                var user = await _userManager.FindByIdAsync(userId);
                if (user != null)
                {
                    var result = await _userManager.RemoveFromRoleAsync(user, model.RoleName);
                    if (!result.Succeeded)
                    {
                        message = $"{user.UserName} rolden çıkarılamadı.";
                    }
                }
            }
            return message;
        }
    }
}
