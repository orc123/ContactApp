using System.Threading.Tasks;
using System;
using Volo.Abp.Application.Dtos;

namespace ContactApp;

public interface IPersionsService
{
    Task<PagedResultDto<PersionDto>> GetMeAsync(GetMyContactsRequest request);
    Task<PersionDto> PostAsync(CreateOrUpdatePersion request);
    Task<PersionDto> PutAsync(Guid id, CreateOrUpdatePersion request);
    Task<bool> DeleteAsync(Guid id);
}
