using ContactApp.Blazor.Dto;
using ContactApp.Blazor.Dto.ContactPersons;

namespace ContactApp.Blazor.Services.Interface;

public interface IContactService
{
    Task<PagedResultDto<PersonDto>> GetPersonsPagingAsync(GetMyContactsRequest request);

    Task<bool> CreateAsync(CreateOrUpdatePerson request);

    Task<bool> UpdateAsync(Guid id ,CreateOrUpdatePerson request);

    Task<bool> DeleteAsync(Guid id);
}
