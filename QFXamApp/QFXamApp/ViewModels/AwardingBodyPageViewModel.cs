using Prism.Commands;
using Prism.Navigation;
using QFXamApp.Models;
using QFXamApp.Services;
using System;
using System.Collections.Generic;
using System.Text;

namespace QFXamApp.ViewModels
{
   public class AwardingBodyPageViewModel : ViewModelBase
    {
        public DelegateCommand<string> OnNavigateCommand { get; set; }


        private AwardingBody _AwardingBody = new AwardingBody();

        public AwardingBody AwardingBody
        {
            get => _AwardingBody;
            set
            {
                _AwardingBody = value;
                RaisePropertyChanged();
            }
        }
        public AwardingBodyPageViewModel(INavigationService navigationService)
                : base(navigationService)
        {
            Title = "Φορέας Χορήγησης";
            OnNavigateCommand = new DelegateCommand<string>(NavigateAsync);

        }
        async void NavigateAsync(string page)
        {
            await NavigationService.NavigateAsync(new Uri(page, UriKind.Relative));
        }


      

        public override async void OnNavigatedTo(NavigationParameters parameters)
        {
            var id = Convert.ToInt32(parameters["Id"]);
            try
            {
                AwardingBody = AwardingBodyAppService.GetAwardingBody(id,"el");               
            }
            catch (Exception e)
            {
                //TODO: Find how to properly handle Exceptions
                await App.Current.MainPage.DisplayAlert("Error", $"Application was not able to retrieve Educational Sector with Id {id}:{e.Message}", "OK");
            }
            base.OnNavigatedTo(parameters);
        }
    }
}
