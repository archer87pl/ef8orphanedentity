using OrphanedEntities.Dal;

namespace OrphanedEntities.Services
{
    public interface ITestService
    {
        Task<CompanyEntity?> GetCompanyById(int id);
        Task Check();
    }
}
