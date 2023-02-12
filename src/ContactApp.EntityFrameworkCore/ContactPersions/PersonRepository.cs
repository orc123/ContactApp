using ContactApp.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Volo.Abp.DependencyInjection;
using Volo.Abp.Domain.Repositories.EntityFrameworkCore;
using Volo.Abp.EntityFrameworkCore;

namespace ContactApp;

public class PersonRepository :
    EfCoreRepository<ContactAppDbContext, ContactPersion, Guid>,
    IPersonRepository,
    ITransientDependency
{
    public PersonRepository(IDbContextProvider<ContactAppDbContext> dbContextProvider) : base(dbContextProvider)
    {
    }

    public async Task<(int, List<ContactPersion>)> GetPagedByUserId(Guid? userId, int skipCount, int maxResultCount)
    {
        var dbSet = await GetDbSetAsync();
        var query = dbSet
            .WhereIf(userId.HasValue, x => x.CreatorId == userId.Value)
            .Where(x => !x.IsDeleted);

        return (
                await query.CountAsync(),
                await query
                .Skip(skipCount)
                .Take(maxResultCount)
                .ToListAsync()
            );

    }
}
