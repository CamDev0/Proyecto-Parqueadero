using Parking.API.Helpers;
using Parking.API.Services;
using Parking.Shared.Entities;
using Parking.Shared.Enums;

namespace Parking.API.Data
{
    public class SeedDB
    {
        private readonly DataContext _context;
        private readonly IApiService _apiService;
        private readonly IUserHelper _userHelper;

        public SeedDB(DataContext context,IApiService apiService, IUserHelper userHelper)
        {
            _context = context;
            _apiService = apiService;
            _userHelper = userHelper;

        }

        public async Task SeedAsync()
        {
            await _context.Database.EnsureCreatedAsync();
            await CheckBrandsAsync();
            await CheckRolesAsync();
            await CheckUserAsync("1", "OAP", "OAP", "oap@yopmail.com", "300445555", "CR 78 9687", UserType.Admin);

        }

        private async Task<User> CheckUserAsync(string document, string firstName, string lastName, string email, string phone, string address, UserType userType)
        {
            var user = await _userHelper.GetUserAsync(email);
            if (user == null)
            {
                user = new User
                {
                    FirstName = firstName,
                    LastName = lastName,
                    Email = email,
                    UserName = email,
                    PhoneNumber = phone,
                    Address = address,
                    Document = document,
                    UserType = userType,
                };

                await _userHelper.AddUserAsync(user, "123456");
                await _userHelper.AddUserToRoleAsync(user, userType.ToString());
            }

            return user;
        }

        private async Task CheckRolesAsync()
        {
            await _userHelper.CheckRoleAsync(UserType.Admin.ToString());
            await _userHelper.CheckRoleAsync(UserType.User.ToString());
        }


        private async Task CheckBrandsAsync()
        {
            if (!_context.Brands.Any())
            {
                _context.Brands.Add(new Brand { Name = "BMW" });
                _context.Brands.Add(new Brand { Name = "Nissan" });
                _context.Brands.Add(new Brand { Name = "Toyota" });

            }

            await _context.SaveChangesAsync();
        }

    }
}
