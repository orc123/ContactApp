using Microsoft.AspNetCore.Authorization;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Net;
using System.Threading.Tasks;
using Volo.Abp;
using Volo.Abp.Application.Dtos;
using Volo.Abp.Domain.Repositories;
using Volo.Abp.ObjectMapping;
using Volo.Abp.Users;

namespace ContactApp;

[Authorize]
public class PersionsService : ContactAppAppService, IPersionsService
{
    private readonly ICurrentUser currentUser;
    private readonly IPersonRepository personRepository;
    public PersionsService(ICurrentUser currentUser, IPersonRepository personRepository)
    {
        this.currentUser = currentUser;
        this.personRepository = personRepository;
    }

    public async Task<bool> DeleteAsync(Guid id)
    {
        await personRepository.DeleteAsync(x => x.Id == id && x.CreatorId == currentUser.Id);

        return true;
    }

    public async Task<PagedResultDto<PersionDto>> GetMeAsync(GetMyContactsRequest request)
    {
        var (count, pagedItems) = await personRepository.GetPagedByUserId(
            currentUser.Id,
            request.SkipCount,
            request.MaxResultCount
        );

        return new PagedResultDto<PersionDto>(
        count,
            ObjectMapper.Map<List<ContactPersion>, List<PersionDto>>(
                pagedItems
            ));
    }

    public async Task<PersionDto> PostAsync(CreateOrUpdatePersion request)
    {
        var entity = ObjectMapper.Map<CreateOrUpdatePersion, ContactPersion> (request);

        var result = await personRepository.InsertAsync(entity);

        return ObjectMapper.Map<ContactPersion, PersionDto>(result);
    }

    public async Task<PersionDto> PutAsync(Guid id, CreateOrUpdatePersion request)
    {
        var entity = await personRepository.FirstOrDefaultAsync(x => x.Id == id && x.CreatorId == currentUser.Id && !x.IsDeleted);
        if (entity == null)
        {
            throw new UserFriendlyException(
                "This person not found.",
                "ADD01",
                logLevel: LogLevel.Information
            );
        }



        var result = await personRepository.UpdateAsync(entity);

        return ObjectMapper.Map<ContactPersion, PersionDto>(result);
    }
}
