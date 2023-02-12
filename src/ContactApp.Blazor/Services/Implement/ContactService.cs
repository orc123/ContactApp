using ContactApp.Blazor.Dto;
using ContactApp.Blazor.Dto.ContactPersions;
using ContactApp.Blazor.Services.Interface;
using Microsoft.AspNetCore.WebUtilities;
using System.Net.Http.Json;

namespace ContactApp.Blazor.Services.Implement;

public class ContactService : IContactService
{
    public HttpClient _httpClient;

    public ContactService(HttpClient httpClient)
    {
        _httpClient = httpClient;
    }
    public async Task<PersionDto> CreateAsync(CreateOrUpdatePersion request)
    {
        var result = await _httpClient.PostAsJsonAsync($"/api/app/persions", request);
        return new PersionDto();
    }

    public Task<bool> DeleteAsync(string id)
    {
        throw new NotImplementedException();
    }

    public async Task<PagedResultDto<PersionDto>> GetPersionsPagingAsync(GetMyContactsRequest request)
    {
        var queryStringParam = new Dictionary<string, string>
        {
            { "skipCount", request.SkipCount.ToString() },
            { "maxResultCount", request.MaxResultCount.ToString() }
        };

        string url = QueryHelpers.AddQueryString($"/api/app/persions/me", queryStringParam);

        var result = await _httpClient.GetFromJsonAsync<PagedResultDto<PersionDto>>(url);
        return result;
    }

    public async Task<PersionDto> UpdateAsync(string id, CreateOrUpdatePersion request)
    {
        var result = await _httpClient.PutAsJsonAsync($"/api/app/persions/{id}", request);
        return new PersionDto();
        //return result.Content;
    }
}
