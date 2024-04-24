using Microsoft.EntityFrameworkCore;
using OrphanedEntities.Dal;
using OrphanedEntities.Entity;

namespace OrphanedEntities.Services
{
    public class TestService : ITestService
    {
        private readonly TestDbContext _db;
        public TestService(TestDbContext db)
        {
            _db = db;
        }

        public async Task<CompanyEntity?> GetCompanyById(int id)
        {
            return await _db.Companies.Include(x=>x.CompanyProperties).FirstOrDefaultAsync(company => company.Id == id);
        }

        public async Task Check()
        {
            var DefaultCompanyId = 1;
            var company = await GetCompanyById(DefaultCompanyId);

            var companyToUpdate = new CompanyEntity()
            {
                Id = DefaultCompanyId,
                Name = "Updated name",
                CompanyProperties = new List<CompanyPropertyEntity>()
                {
                    new CompanyPropertyEntity()
                    {
                        Id = 1,
                        Name = "Prop 1"
                    },
                    new CompanyPropertyEntity()
                    {
                        Id = 2,
                        Name = "Prop 2"
                    },
                }
            };

            company.CompanyProperties = companyToUpdate.CompanyProperties;

            await _db.SaveChangesAsync();  
        }
    }
}
