using SzafkiSzkolne.ViewModels;

namespace SzafkiSzkolne.Views;

public partial class ManageLocker : ContentPage
{
    public ManageLocker()
    {
        InitializeComponent();
        var lockerNumber = (int)Shell.Current.CurrentPage.Navigation.NavigationStack.Last().BindingContext;
        this.BindingContext = new ManageLockerViewModel(lockerNumber);
    }

}