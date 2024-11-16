using Social_network.Models;
using Social_network.ViewModels;

namespace Social_network.Views;

public partial class ProfilePage : ContentPage
{

	private UserInfoViewModel _viewmodel;
	public ProfilePage()
	{
		InitializeComponent();
        _viewmodel = new UserInfoViewModel();
        BindingContext = _viewmodel;
        LoadUserData();
    }

    private async void LoadUserData()
    {
        await _viewmodel.GetMeAsync();
    }
    private async void OnFriendsButtonClicked(object sender, EventArgs e)
    {
        await Navigation.PushAsync(new FriendsPage());
    }
}
