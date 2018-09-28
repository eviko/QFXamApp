using Prism.Commands;
using Prism.Mvvm;
using Prism.Navigation;
using QFXamApp.Models;
using QFXamApp.Services;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;

namespace QFXamApp.ViewModels
{
	public class EducationalSectorListPageViewModel : ViewModelBase
    {
        public ObservableCollection<EducationalSector> EducationalSectors { get; set; }
        public DelegateCommand<string> OnNavigateCommand { get; set; }
        public DelegateCommand<EducationalSector> OnItemTappedCommand { get; set; }

        public DelegateCommand OnAddCommand { get; set; }

        private EducationalSector _EducationalSector;

        public EducationalSectorListPageViewModel(INavigationService navigationService) : base(navigationService)
        {
            EducationalSectors = new ObservableCollection<EducationalSector>();
            OnItemTappedCommand = new DelegateCommand<EducationalSector>(NavigateEducationalSectorAsync);
        }

        public override async void OnNavigatedTo(NavigationParameters parameters)
        {
            Title = "Τομείς Εκπαίδευσης";
            //TODO: Get Language from parameters 
            //var language = parameters["language"];
            var language = "el";

            try
            {
                EducationalSectors.Clear();
                var educationalSectors = EducationalSectorAppService.GetEducationalSectors(language);
                foreach(var ed in educationalSectors)
                {
                    EducationalSectors.Add(ed);
                }

                base.OnNavigatedTo(parameters);
            }
            catch (Exception e)
            {
                //TODO: Find how to properly handle Exceptions
                await App.Current.MainPage.DisplayAlert("Error",
                    $"Application was not able to retrieve Educational Sectors: {e.Message}", "OK");
            }
        }

        async void NavigateEducationalSectorAsync(EducationalSector EducationalSector)
        {
            await NavigationService.NavigateAsync(new Uri($"EducationalSectorPage?Id={EducationalSector.Id}", UriKind.Relative));
        }
    }
}
