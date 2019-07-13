using Common.Exceptions;
using Entities;
using Microsoft.AspNetCore.Identity;
using System.Threading;
using System.Threading.Tasks;

namespace Services
{
    public class UserService : IUserService
    {
        private readonly IJwtService _jwtService;
        private readonly UserManager<User> _userManager;

        public UserService(IJwtService jwtService, UserManager<User> userManager)
        {
            _jwtService = jwtService;
            _userManager = userManager;
        }
        public async Task<AccessToken> TokenAsync(string username, string password, CancellationToken cancellationToken)
        {
            User existsUser = await _userManager.FindByNameAsync(username);
            if (existsUser == null)
            {
                throw new BadRequestException("نام کاربری یا رمز عبور اشتباه است");
            }

            bool isPasswordValid = await _userManager.CheckPasswordAsync(existsUser, password);
            if (!isPasswordValid)
            {
                throw new BadRequestException("نام کاربری یا رمز عبور اشتباه است");
            }



            AccessToken jwt = await _jwtService.GenerateAsync(existsUser);
            return jwt;

        }
    }
}
