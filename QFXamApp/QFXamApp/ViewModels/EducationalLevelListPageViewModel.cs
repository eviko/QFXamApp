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
	public class EducationalLevelListPageViewModel : ViewModelBase
    {
        public ObservableCollection<EducationalLevel> EducationalLevels { get; set; }
        public DelegateCommand<string> OnNavigateCommand { get; set; }
        public DelegateCommand<EducationalLevel> OnItemTappedCommand { get; set; }

        public DelegateCommand OnAddCommand { get; set; }

        private EducationalLevel _EducationalLevel;

        public EducationalLevelListPageViewModel(INavigationService navigationService) : base(navigationService)
        {
            EducationalLevels = new ObservableCollection<EducationalLevel>();
            OnItemTappedCommand = new DelegateCommand<EducationalLevel>(NavigateEducationalLevelAsync);
        }

        public override async void OnNavigatedTo(NavigationParameters parameters)
        {
            Title = "Επίπεδα Πιστοποίησης";
            //TODO: Get Language from parameters 
            //var language = parameters["language"];
            var language = "el";

            try
            {
                EducationalLevels.Clear();
                var educationalLevels = EducationalLevelAppService.GetEducationalLevels(language);
                foreach(var ed in educationalLevels)
                {
                    EducationalLevels.Add(ed);
                }

                base.OnNavigatedTo(parameters);
            }
            catch (Exception e)
            {
                //TODO: Find how to properly handle Exceptions
                await App.Current.MainPage.DisplayAlert("Error",
                    $"Application was not able to retrieve Educational Levels: {e.Message}", "OK");
            }
        }

        async void NavigateEducationalLevelAsync(EducationalLevel EducationalLevel)
        {
            await NavigationService.NavigateAsync(new Uri($"EducationalLevelPage?Id={EducationalLevel.Id}", UriKind.Relative));
        }
    }
}
