using Volo.Abp.Domain.Repositories;

namespace ContactApp;

public interface IPersonRepository : IRepository<ContactPersion>
{
    Task<(int, List<ContactPersion>)> GetPagedByUserId(
        Guid? userId,
        int skipCount,
        int maxResultCount
    );
}
