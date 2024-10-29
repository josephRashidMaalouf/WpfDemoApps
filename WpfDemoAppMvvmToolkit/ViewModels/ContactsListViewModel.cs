using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Runtime.CompilerServices;
using CommunityToolkit.Mvvm.ComponentModel;
using CommunityToolkit.Mvvm.Input;
using WpfDemoAppMvvmToolkit.Models;

namespace WpfDemoAppMvvmToolkit.ViewModels;

public partial class ContactsListViewModel : ObservableObject
{
    [ObservableProperty]
    private Contact _selectedContact = new();
    public ObservableCollection<Contact> ContactsList { get; set; } = new()
    {
        new Contact { Name = "Joe", Email = "Joe@mail.com", Phone = "020123123" },
        new Contact { Name = "Jane", Email = "jane@email.com", Phone = "020234345" },
        new Contact { Name = "John", Email = "John@lol.se", Phone = "0201987876" },
    };

    
    [RelayCommand(CanExecute = nameof(CanAdd))]
    public void Add()
    {
        ContactsList.Add(new Contact()
        {
            Name = SelectedContact.Name,
            Email = SelectedContact.Email,
            Phone = SelectedContact.Phone
        });
    }
    private bool CanAdd()
    {
        return true;
    }
}