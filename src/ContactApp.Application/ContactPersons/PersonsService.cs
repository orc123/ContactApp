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
public class PersonsService : ContactAppAppService, IPersionsService
{
    private readonly ICurrentUser currentUser;
    private readonly IPersonRepository personRepository;
    public PersonsService(ICurrentUser currentUser, IPersonRepository personRepository)
    {
        this.currentUser = currentUser;
        this.personRepository = personRepository;
    }

    public async Task<bool> DeleteAsync(Guid id)
    {
        await personRepository.DeleteAsync(x => x.Id == id && x.CreatorId == currentUser.Id);

        return true;
    }

    public async Task<PagedResultDto<PersonDto>> GetMeAsync(GetMyContactsRequest request)
    {
        var (count, pagedItems) = await personRepository.GetPagedByUserId(
            currentUser.Id,
            request.SkipCount,
            request.MaxResultCount
        );

        return new PagedResultDto<PersonDto>(
        count,
            ObjectMapper.Map<List<ContactPersion>, List<PersonDto>>(
                pagedItems
            ));
    }

    public async Task<PersonDto> PostAsync(CreateOrUpdatePerson request)
    {
        var entity = ObjectMapper.Map<CreateOrUpdatePerson, ContactPersion> (request);

        var result = await personRepository.InsertAsync(entity);

        return ObjectMapper.Map<ContactPersion, PersonDto>(result);
    }

    public async Task<PersonDto> PutAsync(Guid id, CreateOrUpdatePerson request)
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

        entity.Address = request.Address;
        entity.BestFriend = request.BestFriend;
        entity.BirthDate = request.BirthDate;
        entity.Email = request.Email;
        entity.FirstName = request.FirstName;
        entity.LastName = request.LastName;
        entity.Job = request.Job;
        entity.Phone = request.Phone;
        


        var result = await personRepository.UpdateAsync(entity);

        return ObjectMapper.Map<ContactPersion, PersonDto>(result);
    }
}
