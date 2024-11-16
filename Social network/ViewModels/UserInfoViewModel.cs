using Social_network.Models;
using Social_network.Response;
using Social_network.ServicesImp;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Social_network.ViewModels
{
    class UserInfoViewModel : INotifyPropertyChanged
    {
        private readonly UserInfoService userInfoService;
        private UserInfoResponse _userinfo;

        // Change the type to List<MessageResponse>
        public UserInfoResponse UserMe
        {
            get => _userinfo;
            set
            {
                _userinfo = value;
                OnPropertyChanged(nameof(UserMe)); // Notify the UI of the update
            }
        }

        public UserInfoViewModel()
        {
            userInfoService = new UserInfoService();
        }

        public async Task GetMeAsync()
        {
            // Fetch the messages from the service
            var userme = await userInfoService.Getme();
            if (userme != null)
            {
                UserMe = userme; // Update the property with the fetched messages
            }
        }

        public event PropertyChangedEventHandler PropertyChanged;

        protected virtual void OnPropertyChanged(string propertyName)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }
    }
}
