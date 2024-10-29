using System.Windows.Controls;
using WpfDemoAppMvvmToolkit.ViewModels;

namespace WpfDemoAppMvvmToolkit.Views
{
    /// <summary>
    /// Interaction logic for ContactListView.xaml
    /// </summary>
    public partial class ContactListView : UserControl
    {
        public ContactListView()
        {
            InitializeComponent();
            DataContext = new ContactsListViewModel();
        }
    }
}
