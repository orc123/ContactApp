using ContactApp.Blazor.Dto;
using ContactApp.Blazor.Dto.ContactPersons;
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
    public async Task<bool> CreateAsync(CreateOrUpdatePerson request)
    {
        var result = await _httpClient.PostAsJsonAsync($"/api/app/persons", request);
        return result.IsSuccessStatusCode;
    }

    public async Task<bool> DeleteAsync(Guid id)
    {
        var result = await _httpClient.DeleteAsync($"/api/app/persons/{id}");
        return result.IsSuccessStatusCode;
    }

    public async Task<PagedResultDto<PersonDto>> GetPersonsPagingAsync(GetMyContactsRequest request)
    {
        var queryStringParam = new Dictionary<string, string>
        {
            { "skipCount", request.SkipCount.ToString() },
            { "maxResultCount", request.MaxResultCount.ToString() }
        };

        string url = QueryHelpers.AddQueryString($"/api/app/persons/me", queryStringParam);

        var result = await _httpClient.GetFromJsonAsync<PagedResultDto<PersonDto>>(url);
        return result;
    }

    public async Task<bool> UpdateAsync(Guid id, CreateOrUpdatePerson request)
    {
        var result = await _httpClient.PutAsJsonAsync($"/api/app/persons/{id}", request);
        return result.IsSuccessStatusCode;
    }
}
