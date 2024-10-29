using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Runtime.CompilerServices;
using System.Windows.Input;
using WpfDemoAppNotNoob.Commands;
using WpfDemoAppNotNoob.Models;

namespace WpfDemoAppNotNoob.ViewModels;

public class ContactsListViewModel : INotifyPropertyChanged
{
    public event PropertyChangedEventHandler? PropertyChanged;

    private Contact _selectedContact = new Contact();

    public ICommand AddCommand { get; } 

    public ObservableCollection<Contact> ContactsList { get; set; } = new()
    {
        new Contact { Name = "Joe", Email = "Joe@mail.com", Phone = "020123123" },
        new Contact { Name = "Jane", Email = "jane@email.com", Phone = "020234345" },
        new Contact { Name = "John", Email = "John@lol.se", Phone = "0201987876" },
    };

    public Contact SelectedContact
    {
        get => _selectedContact;
        set
        {
            _selectedContact = value;
            OnPropertyChanged(nameof(SelectedContact));
        }
    }

    public ContactsListViewModel()
    {
        AddCommand = new RelayCommand(AddContact, CanAdd);
    }


    private void AddContact(object obj)
    {
        ContactsList.Add(new Contact()
        {
            Name = SelectedContact.Name,
            Email = SelectedContact.Email,
            Phone = SelectedContact.Phone
        });
    }

    private bool CanAdd(object obj)
    {
        return !string.IsNullOrEmpty(SelectedContact.Name) &&
               !string.IsNullOrEmpty(SelectedContact.Email) &&
               !string.IsNullOrEmpty(SelectedContact.Phone);
    }
    protected virtual void OnPropertyChanged([CallerMemberName] string? propertyName = null)
    {
        PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
    }

    protected bool SetField<T>(ref T field, T value, [CallerMemberName] string? propertyName = null)
    {
        if (EqualityComparer<T>.Default.Equals(field, value)) return false;
        field = value;
        OnPropertyChanged(propertyName);
        return true;
    }
}