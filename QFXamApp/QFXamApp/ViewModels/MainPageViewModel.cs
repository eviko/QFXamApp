using Prism.Commands;
using Prism.Mvvm;
using Prism.Navigation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace QFXamApp.ViewModels
{
    public class MainPageViewModel : ViewModelBase
    {
        public DelegateCommand<string> OnNavigateCommand { get; set; }
        public DelegateCommand NavigateCommand { get; private set; }

        public MainPageViewModel(INavigationService navigationService)
            : base(navigationService)
        {
            Title = "Qualification Framework";
            OnNavigateCommand = new DelegateCommand<string>(NavigateAync);
            NavigateCommand = new DelegateCommand(Navigate);
        }

        async void NavigateAync(string page)
        {
            //            if (page.Equals("GetSubscriptions"))
            //            {
            //                await NavigationService.NavigateAsync(new Uri(page, UriKind.RelativeOrAbsolute));
            //            }
            await NavigationService.NavigateAsync(new Uri(page, UriKind.RelativeOrAbsolute));
        }

        //        public override void OnNavigatedTo(NavigationParameters parameters)
        //        {
        ////            var element = parameters["Page"];
        //        }

        async void Navigate()
        {
          //  await NavigationService.NavigateAsync(nameof(NavigationPage) + "/" + "FacilitiesPage");
        }
    }
}
