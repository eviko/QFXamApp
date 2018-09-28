using Prism.Commands;
using Prism.Navigation;
using QFXamApp.Models;
using QFXamApp.Services;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Text;

namespace QFXamApp.ViewModels
{
    public class AwardingBodyListPageViewModel : ViewModelBase
    {
        public ObservableCollection<AwardingBody> AwardingBodies { get; set; }
        public DelegateCommand<string> OnNavigateCommand { get; set; }
        public DelegateCommand<AwardingBody> OnItemTappedCommand { get; set; }

        public DelegateCommand OnAddCommand { get; set; }

        private AwardingBody _AwardingBody;

        public AwardingBodyListPageViewModel(INavigationService navigationService) : base(navigationService)
        {
            AwardingBodies = new ObservableCollection<AwardingBody>();
            OnItemTappedCommand = new DelegateCommand<AwardingBody>(NavigateAwardingBodyAsync);
        }

        public override async void OnNavigatedTo(NavigationParameters parameters)
        {
            Title = "Φορείς Χορήγησης";
            //TODO: Get Language from parameters 
            //var language = parameters["language"];
            var language = "el";

            try
            {
                AwardingBodies.Clear();
                var awardingBodies = AwardingBodyAppService.GetAwardingBodies(language);
                foreach (var ed in awardingBodies)
                {
                    AwardingBodies.Add(ed);
                }

                base.OnNavigatedTo(parameters);
            }
            catch (Exception e)
            {
                //TODO: Find how to properly handle Exceptions
                await App.Current.MainPage.DisplayAlert("Error",
                    $"Application was not able to retrieve : {e.Message}", "OK");
            }
        }

        async void NavigateAwardingBodyAsync(AwardingBody AwardingBody)
        {
            await NavigationService.NavigateAsync(new Uri($"AwardingBodyPage?Id={AwardingBody.Id}", UriKind.Relative));
        }
    }
}