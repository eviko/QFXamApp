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
    public class QualificationTypeListPageViewModel : ViewModelBase
    {
        public ObservableCollection<QualificationType> QualificationTypes { get; set; }
        public DelegateCommand<string> OnNavigateCommand { get; set; }
        public DelegateCommand<QualificationType> OnItemTappedCommand { get; set; }

        public DelegateCommand OnAddCommand { get; set; }

        private QualificationType _QualificationType;

        public QualificationTypeListPageViewModel(INavigationService navigationService) : base(navigationService)
        {
            QualificationTypes = new ObservableCollection<QualificationType>();
           // OnItemTappedCommand = new DelegateCommand<QualificationType>(NavigateQualificationTypeAsync);
        }

        public override async void OnNavigatedTo(NavigationParameters parameters)
        {
            Title = "Τύποι Προσόντων";
            //TODO: Get Language from parameters 
            //var language = parameters["language"];
            var language = "el";

            try
            {
                QualificationTypes.Clear();
                var qualificationTypes = QualificationTypeAppService.GetQualificationTypes(language);
                foreach (var qf in qualificationTypes)
                {
                    QualificationTypes.Add(qf);
                }

                base.OnNavigatedTo(parameters);
            }
            catch (Exception e)
            {
                //TODO: Find how to properly handle Exceptions
                await App.Current.MainPage.DisplayAlert("Error",
                    $"Application was not able to retrieve qualification Types: {e.Message}", "OK");
            }
        }

        //async void NavigateQualificationTypeAsync(QualificationType QualificationType)
        //{
        //    await NavigationService.NavigateAsync(new Uri($"EducationalLevelPage?EducationalLevelId={EducationalLevel.Id}", UriKind.Relative));
        //}
    }
}
