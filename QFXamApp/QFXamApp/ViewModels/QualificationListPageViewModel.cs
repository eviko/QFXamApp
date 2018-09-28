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
    public class QualificationListPageViewModel : ViewModelBase
    {
        public ObservableCollection<Qualification> Qualifications { get; set; }
        public DelegateCommand<string> OnNavigateCommand { get; set; }
        public DelegateCommand<Qualification> OnItemTappedCommand { get; set; }

        public DelegateCommand OnAddCommand { get; set; }

        private QualificationType _QualificationType;

        public QualificationListPageViewModel(INavigationService navigationService) : base(navigationService)
        {
            Qualifications = new ObservableCollection<Qualification>();
            OnItemTappedCommand = new DelegateCommand<Qualification>(NavigateQualificationAsync);
        }

        public override async void OnNavigatedTo(NavigationParameters parameters)
        {
            Title = "Τύποι Προσόντων";
            //TODO: Get Language from parameters 
            //var language = parameters["language"];
            var language = "el";

            try
            {
                Qualifications.Clear();
                var qualifications = QualificationAppService.GetQualificationsByCriteria(language,SearchSettings.LevelId,SearchSettings.BodyId,SearchSettings.SectorId,SearchSettings.TypeId,SearchSettings.Text);               
                foreach (var qf in qualifications)
                {
                    Qualifications.Add(qf);
                }

                base.OnNavigatedTo(parameters);
            }
            catch (Exception e)
            {
                //TODO: Find how to properly handle Exceptions
                await App.Current.MainPage.DisplayAlert("Error",
                    $"Application was not able to retrieve qualifications: {e.Message}", "OK");
            }
        }

        async void NavigateQualificationAsync(Qualification Qualification)
        {
            await NavigationService.NavigateAsync(new Uri($"QualificationPage?QualificationId={Qualification.Id}", UriKind.Relative));
        }
    }
}
