using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Runtime.CompilerServices;
using System.Text;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace WpfDemoApps
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();
            ObservableCollection<Contact> contactsList = new()
            {
                new Contact { Name = "Joe", Email = "Joe@mail.com", Phone = "020123123" },
                new Contact { Name = "Jane", Email = "jane@email.com", Phone = "020234345" },
                new Contact { Name = "John", Email = "John@lol.se", Phone = "0201987876" },
            };
            Contacts.ItemsSource = contactsList;
        }

        

        

        private void Contacts_OnSelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            if (Contacts.SelectedItem is Contact contact)
            {
                NameField.Text = contact.Name;
                PhoneField.Text = contact.Phone;
                EmailField.Text = contact.Email;
            };
        }


        private void NameField_OnTextChanged(object sender, TextChangedEventArgs e)
        {
            if (Contacts.SelectedItem is Contact contact)
            {
                contact.Name = NameField.Text;
            };
        }

        private void EmailField_OnTextChanged(object sender, TextChangedEventArgs e)
        {
            if (Contacts.SelectedItem is Contact contact)
            {
                contact.Email = EmailField.Text;
            };
        }

        private void PhoneField_OnTextChanged(object sender, TextChangedEventArgs e)
        {
            if (Contacts.SelectedItem is Contact contact)
            {
                contact.Phone = PhoneField.Text;
            };
        }

        private void AddButton_OnClick(object sender, RoutedEventArgs e)
        {
            if(string.IsNullOrWhiteSpace(NameField.Text) || string.IsNullOrWhiteSpace(EmailField.Text) || string.IsNullOrWhiteSpace(PhoneField.Text))
                return;
            Contacts.ItemsSource = new ObservableCollection<Contact>(Contacts.Items.Cast<Contact>()
                .Append(new Contact { Name = NameField.Text, Email = EmailField.Text, Phone = PhoneField.Text }));
        }
    }

    public class Contact : INotifyPropertyChanged
    {
        private string _name;
        private string _email;
        private string _phone;

        public string Name
        {
            get => _name;
            set
            {
                if (_name != value)
                {
                    _name = value;
                    OnPropertyChanged(nameof(Name));
                }
            }
        }

        public string Email
        {
            get => _email;
            set
            {
                if (_email != value)
                {
                    _email = value;
                    OnPropertyChanged(nameof(Email));
                }
            }
        }

        public string Phone
        {
            get => _phone;
            set
            {
                if (_phone != value)
                {
                    _phone = value;
                    OnPropertyChanged(nameof(Phone));
                }
            }
        }
        public event PropertyChangedEventHandler? PropertyChanged;

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
}