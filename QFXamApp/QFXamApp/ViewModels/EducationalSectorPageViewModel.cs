using Prism.Commands;
using Prism.Navigation;
using QFXamApp.Models;
using QFXamApp.Services;
using System;
using System.Collections.Generic;
using System.Text;

namespace QFXamApp.ViewModels
{
   public class EducationalSectorPageViewModel : ViewModelBase
    {
        public DelegateCommand<string> OnNavigateCommand { get; set; }


        private EducationalSector _educationalSector = new EducationalSector();

        public EducationalSector EducationalSector
        {
            get => _educationalSector;
            set
            {
                _educationalSector = value;
                RaisePropertyChanged();
            }
        }
        public EducationalSectorPageViewModel(INavigationService navigationService)
                : base(navigationService)
        {
            Title = "Μαθησιακά Αποτελέσματα";
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
                EducationalSector = EducationalSectorAppService.GetEducationalSector(id,"el");               
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
