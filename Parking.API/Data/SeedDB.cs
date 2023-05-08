using Parking.Shared.Entities;

namespace Parking.API.Data
{
    public class SeedDB
    {
        private readonly DataContext _context;

        public SeedDB(DataContext context)
        {
            _context = context;
        }

        public async Task SeedAsync()
        {
            await _context.Database.EnsureCreatedAsync();
            await CheckCategoriesAsync();
        }

        private async Task CheckCategoriesAsync()
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
