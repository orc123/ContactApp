using ContactApp.Blazor.Dto;
using ContactApp.Blazor.Dto.ContactPersions;
using Microsoft.AspNetCore.Components;
using static System.Runtime.InteropServices.JavaScript.JSType;

namespace ContactApp.Blazor.Pages.Contact;

public partial class Index
{
    public List<PersionDto> Elements = new();

    [CascadingParameter]
    private Error Error { set; get; }

    public bool loading = false;
    int pageIndex = 1;
    int pageSize = 8;
    public MetaData MetaData { get; set; } = new MetaData();
    private GetMyContactsRequest getMyContactsRequest = new();

    protected override async Task OnInitializedAsync()
    {
        getMyContactsRequest.MaxResultCount = pageSize;
        getMyContactsRequest.SkipCount = pageIndex;
        await GetPersions();
    }

    private async Task GetPersions()
    {
        loading = true;
        try
        {
            var pagingResponse = await contactService.GetPersionsPagingAsync(getMyContactsRequest);
            Elements = pagingResponse.Items;
            MetaData.TotalCount = pagingResponse.TotalCount;
            MetaData.CurrentPage = pageIndex;
            MetaData.PageSize = pageSize;
            MetaData.TotalPages = (int)Math.Ceiling(pagingResponse.TotalCount / (double)pageSize);
            loading = false;
        }
        catch (Exception ex)
        {
            loading = false;
        }
    }

    public async Task HandleIntervalElapsed(string search)
    {
        await GetPersions();
        StateHasChanged();
    }

    private async Task SelectedPage(int page)
    {
        getMyContactsRequest.SkipCount = page;
        await GetPersions();
    }
}
