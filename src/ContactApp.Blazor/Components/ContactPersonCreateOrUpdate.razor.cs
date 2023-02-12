using ContactApp.Blazor.Dto.ContactPersons;
using Microsoft.AspNetCore.Components;
using Microsoft.AspNetCore.Components.Forms;
using MudBlazor;
using System.Reflection.Emit;

namespace ContactApp.Blazor.Components;

public partial class ContactPersonCreateOrUpdate
{
    [CascadingParameter]
    private MudDialogInstance MudDialog { get; set; }

    [Parameter]
    public PersonDto Person { get; set; }

    [Parameter]
    public string Title { get; set; }

    private bool success;
    private bool loading = false;

    private EditContext editContext;

    protected override void OnInitialized()
    {
        editContext = new EditContext(Person);
    }

    private void ClosePopup() => MudDialog.Cancel();

    private async Task HandleValidSubmitAsync()
    {
        if (string.IsNullOrWhiteSpace(Person.Email) || string.IsNullOrWhiteSpace(Person.FirstName)
             || (string.IsNullOrEmpty(Person.LastName)))
        {
            return;
        }
        if (editContext.Validate())
        {
            if (Person.Id == Guid.Empty)
            {
                CreateOrUpdatePerson createOrUpdatePerson = new CreateOrUpdatePerson()
                {
                    Address = Person.Address,
                    BestFriend = Person.BestFriend,
                    BirthDate = Person.BirthDate,
                    Email = Person.Email,
                    FirstName = Person.FirstName,
                    LastName = Person.LastName,
                    Job = Person.Job,
                    Phone = Person.Phone
                };
                loading = true;
                success = await contactService.CreateAsync(createOrUpdatePerson);
                if (success)
                {
                    Snackbar.Add("Tạo mới thành công", Severity.Success);
                    StateHasChanged();
                    MudDialog.Close(DialogResult.Ok(true));
                }
                else
                {
                    Snackbar.Clear();
                    Snackbar.Add("Tạo mới thất bại", Severity.Error);
                }
                loading = false;
            }
            else
            {
                CreateOrUpdatePerson createOrUpdatePerson = new CreateOrUpdatePerson()
                {
                    Address = Person.Address,
                    BestFriend = Person.BestFriend,
                    BirthDate = Person.BirthDate,
                    Email = Person.Email,
                    FirstName = Person.FirstName,
                    LastName = Person.LastName,
                    Job = Person.Job,
                    Phone = Person.Phone
                };
                loading = true;
                success = await contactService.UpdateAsync(Person.Id, createOrUpdatePerson);
                if (success)
                {
                    Snackbar.Add("Cập nhật thành công", Severity.Success);
                    StateHasChanged();
                    MudDialog.Close(DialogResult.Ok(true));
                }
                else
                {
                    Snackbar.Clear();
                    Snackbar.Add("Cập nhật thất bại", Severity.Error);
                }
                loading = false;
            }
        }
    }
}
