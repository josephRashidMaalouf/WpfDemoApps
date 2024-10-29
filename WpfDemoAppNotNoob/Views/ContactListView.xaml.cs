using System.Windows.Controls;
using WpfDemoAppNotNoob.ViewModels;

namespace WpfDemoAppNotNoob.Views
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
