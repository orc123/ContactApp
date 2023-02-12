using ContactApp.Blazor.Components;
using ContactApp.Blazor.Dto;
using ContactApp.Blazor.Dto.ContactPersons;
using Microsoft.AspNetCore.Components;
using MudBlazor;
using System;
using System.Reflection.Metadata;
using static System.Runtime.InteropServices.JavaScript.JSType;

namespace ContactApp.Blazor.Pages.Contact;

public partial class Index
{
    public List<PersonDto> Elements = new();

    [CascadingParameter]
    private Error Error { set; get; }

    public bool loading = false;
    int pageIndex = 1;
    int pageSize = 8;
    private PersonDto selectPerson = null;
    public MetaData MetaData { get; set; } = new MetaData();
    private GetMyContactsRequest getMyContactsRequest = new();

    protected override async Task OnInitializedAsync()
    {
        getMyContactsRequest.MaxResultCount = pageSize;
        getMyContactsRequest.SkipCount = pageIndex;
        await GetPersons();
    }

    private async Task GetPersons()
    {
        loading = true;
        try
        {
            var pagingResponse = await contactService.GetPersonsPagingAsync(getMyContactsRequest);
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
        await GetPersons();
        StateHasChanged();
    }

    private async Task SelectedPage(int page)
    {
        getMyContactsRequest.SkipCount = page;
        await GetPersons();
    }

    public async Task OpUpdateStatus(PersonDto person, bool status)
    {
        CreateOrUpdatePerson createOrUpdatePerson = new CreateOrUpdatePerson()
        {
            Address = person.Address,
            BestFriend = status,
            BirthDate = person.BirthDate,
            Email = person.Email,
            FirstName = person.FirstName,
            LastName = person.LastName,
            Job = person.Job,
            Phone = person.Phone
        };
        loading = true;
        bool success = await contactService.UpdateAsync(person.Id, createOrUpdatePerson);
        if (success)
        {
            Snackbar.Add("Cập nhật trạng thái thành công", Severity.Success);
            StateHasChanged();
        }
        else
        {
            Snackbar.Clear();
            Snackbar.Add("Cập nhật trạng thái thất bại", Severity.Error);
        }
        loading = false;
    }

    public async Task OnAddNewPerson()
    {
        selectPerson = new PersonDto();
        var parameters = new DialogParameters
        {
            { "Person", selectPerson },
            { "Title", "Thêm contact" }
        };
        var dialog = DialogService.Show<ContactPersonCreateOrUpdate>("", parameters);
        var result = await dialog.Result;
        if (!result.Cancelled)
        {
            await GetPersons();
        }
    }

    public async Task OnEditPersonAsync(PersonDto person)
    {
        selectPerson = person;
        var parameters = new DialogParameters
        {
            { "Person", selectPerson },
            { "Title", "Sửa contact" }
        };
        var dialog = DialogService.Show<ContactPersonCreateOrUpdate>("", parameters);
        var result = await dialog.Result;
        if (!result.Cancelled)
        {
            await GetPersons();
        }
    }
    public async Task OnDeletePersonAsync(PersonDto person)
    {
        Guid deleteId = person.Id;
        var parameters = new DialogParameters();
        parameters.Add("ContentText", "Bạn có muốn xóa bản ghi này không");
        parameters.Add("ButtonText", "Xóa");
        parameters.Add("Color", Color.Error);

        var options = new DialogOptions() { CloseButton = true, MaxWidth = MaxWidth.ExtraSmall };

        var dialog = DialogService.Show<ConfirmationDialog>("Xóa", parameters, options);
        var result = await dialog.Result;
        if (!result.Cancelled)
        {
            var success = await contactService.DeleteAsync(deleteId);
            if (success)
            {
                Snackbar.Add("Xóa bản ghi thành công", Severity.Success);
            }
            else
            {
                Snackbar.Add("Thất bại khi xóa", Severity.Error);
            }
            await GetPersons();
            StateHasChanged();
        }
    }
}
