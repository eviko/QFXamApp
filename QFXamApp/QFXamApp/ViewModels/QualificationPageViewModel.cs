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
    public class QualificationPageViewModel : ViewModelBase
    {
        public DelegateCommand<string> OnNavigateCommand { get; set; }


        private Qualification _qualification = new Qualification();

        public Qualification Qualification
        {
            get => _qualification;
            set
            {
                _qualification = value;
                RaisePropertyChanged();
            }
        }
        public QualificationPageViewModel(INavigationService navigationService)
                : base(navigationService)
        {
            Title = "Προσόν";
            OnNavigateCommand = new DelegateCommand<string>(NavigateAsync);

        }
        async void NavigateAsync(string page)
        {
            await NavigationService.NavigateAsync(new Uri(page, UriKind.Relative));
        }




        public override async void OnNavigatedTo(NavigationParameters parameters)
        {
            var id = Convert.ToInt32(parameters["QualificationId"]);
            try
            {
                //EducationalLevel = EducationalLevelAppService.GetEducationalLevel(id,"el");
                Qualification = QualificationAppService.GetQualification(id, "el");

            }
            catch (Exception e)
            {
                //TODO: Find how to properly handle Exceptions
                await App.Current.MainPage.DisplayAlert("Error", $"Application was not able to retrieve Qualification with Id {id}:{e.Message}", "OK");
            }
            base.OnNavigatedTo(parameters);
        }
    }
}
