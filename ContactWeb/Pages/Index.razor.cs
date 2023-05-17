using ContactData.Interfaces;
using ContactData.Models;
using Microsoft.AspNetCore.Components;

namespace ContactWeb.Pages
{
    public partial class Index
    {
        [Inject]
        public IContactService ContactService { get; set; }
        private List<Contact> contacts;
        private Contact editcontact;
        private string searchTerm = "";
        public bool deleteConfirm { get; set; }
        public bool showAddDialog { get; set; }
        public bool showEditDialog { get; set; }

        protected override async Task OnInitializedAsync()
        {
            await loadlist();
            base.OnInitialized();
        }


        private async void Search(string value)
        {


            if (string.IsNullOrWhiteSpace(value))
            {

                await loadlist();

            }
            else
            {

                contacts = contacts.Where(c =>
         c.FirstName.Contains(value, StringComparison.OrdinalIgnoreCase) ||
         c.LastName.Contains(value, StringComparison.OrdinalIgnoreCase) ||
         c.Address.Street.Contains(value, StringComparison.OrdinalIgnoreCase) ||
         c.Address.City.Contains(value, StringComparison.OrdinalIgnoreCase) ||
         c.Address.State.Contains(value, StringComparison.OrdinalIgnoreCase) ||
         c.Address.PostalCode.Contains(value, StringComparison.OrdinalIgnoreCase))
         .ToList();
            }

            StateHasChanged();

        }


        private void OpenEditDialog(Contact contact)
        {
            editcontact = contact;
            showEditDialog = true;

        }

        private async Task OnEditDialogClose(bool isOk)
        {
            showEditDialog = false;

        }


        private void OpenDeleteDialog(Contact contact)
        {
            editcontact = contact;
            deleteConfirm = true;
        }

        private async Task OnDeleteDialogClose(bool isOk)
        {
            deleteConfirm = false;
            await loadlist();
        }

        private async Task OnAddDialogClose(bool isOk)
        {
            showAddDialog = false;
            await loadlist();
        }

        private void AddNewContact()
        {
            showAddDialog = true;

        }


        private async Task loadlist()
        {
            contacts = await ContactService.GetAllContactsAsync();
        }



    }
}

