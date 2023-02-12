using System.Threading.Tasks;
using System;
using Volo.Abp.Application.Dtos;

namespace ContactApp;

public interface IPersionsService
{
    Task<PagedResultDto<PersonDto>> GetMeAsync(GetMyContactsRequest request);
    Task<PersonDto> PostAsync(CreateOrUpdatePerson request);
    Task<PersonDto> PutAsync(Guid id, CreateOrUpdatePerson request);
    Task<bool> DeleteAsync(Guid id);
}
