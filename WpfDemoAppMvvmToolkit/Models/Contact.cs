using System.ComponentModel;
using System.Runtime.CompilerServices;
using CommunityToolkit.Mvvm.ComponentModel;

namespace WpfDemoAppMvvmToolkit.Models;

public partial class Contact : ObservableObject
{
    [ObservableProperty]
    private string _name = "";
    [ObservableProperty]
    private string _email = "";
    [ObservableProperty]
    private string _phone = "";

}