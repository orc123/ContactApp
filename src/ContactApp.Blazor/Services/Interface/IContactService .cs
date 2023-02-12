using ContactApp.Blazor.Dto;
using ContactApp.Blazor.Dto.ContactPersions;

namespace ContactApp.Blazor.Services.Interface;

public interface IContactService
{
    Task<PagedResultDto<PersionDto>> GetPersionsPagingAsync(GetMyContactsRequest request);

    Task<PersionDto> CreateAsync(CreateOrUpdatePersion request);

    Task<PersionDto> UpdateAsync(string id ,CreateOrUpdatePersion request);

    Task<bool> DeleteAsync(string id);
}
