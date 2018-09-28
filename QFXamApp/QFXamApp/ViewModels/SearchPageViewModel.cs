using Prism.Commands;
using Prism.Navigation;
using QFXamApp.Models;
using QFXamApp.Services;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Runtime.CompilerServices;
using System.Text;

namespace QFXamApp.ViewModels
{
    public class SearchPageViewModel : ViewModelBase, INotifyPropertyChanged
    {

        public DelegateCommand<string> OnNavigateCommand { get; set; }

        public ObservableCollection<EducationalLevel> EducationalLevels { get; set; }
        public ObservableCollection<EducationalSector> EducationalSectors { get; set; }
        public ObservableCollection<QualificationType> QualificationTypes { get; set; }
        public ObservableCollection<AwardingBody> AwardingBodies { get; set; }

        private string _searchText;

        public string SearchText
        {
            get { return _searchText; }
            set
            {
                _searchText = value;
                SearchSettings.Text = _searchText;
            }
        }

        int picker = 0;
        //educationallevel

        int _educationallevelSelectedIndex;
        public int EducationalLevelSelectedIndex
        {
            get
            {
                return _educationallevelSelectedIndex;
            }
            set
            {
                if (_educationallevelSelectedIndex != value)
                {
                    _educationallevelSelectedIndex = value;

                    // trigger some action to take such as updating other labels or fields
                    OnPropertyChanged(nameof(EducationalLevelSelectedIndex));
                    SelectedEducationalLevel = EducationalLevels[_educationallevelSelectedIndex];
                }
            }
        }
        private EducationalLevel _selectedEducationalLevel;

        public EducationalLevel SelectedEducationalLevel
        {
            get { return _selectedEducationalLevel; }
            set
            {
                _selectedEducationalLevel = value;
                SearchSettings.LevelId = _selectedEducationalLevel.Id;
            }
        }

        //EducationalSector

        int _educationalsectorSelectedIndex;
        public int EducationalSectorSelectedIndex
        {
            get
            {
                return _educationalsectorSelectedIndex;
            }
            set
            {
                if (_educationalsectorSelectedIndex != value)
                {
                    _educationalsectorSelectedIndex = value;

                    // trigger some action to take such as updating other labels or fields
                    OnPropertyChanged(nameof(EducationalSectorSelectedIndex));
                    SelectedEducationalSector = EducationalSectors[_educationalsectorSelectedIndex];
                }
            }
        }
        private EducationalSector _selectedEducationalSector;

        public EducationalSector SelectedEducationalSector
        {
            get { return _selectedEducationalSector; }
            set
            {
                _selectedEducationalSector = value;
                SearchSettings.SectorId = _selectedEducationalSector.Id;
            }
        }
        //QualificationType
        int _qualificationtypeSelectedIndex;
        public int QualificationTypeSelectedIndex
        {
            get
            {
                return _qualificationtypeSelectedIndex;
            }
            set
            {
                if (_qualificationtypeSelectedIndex != value)
                {
                    _qualificationtypeSelectedIndex = value;

                    // trigger some action to take such as updating other labels or fields
                    OnPropertyChanged(nameof(QualificationTypeSelectedIndex));
                    SelectedQualificationType = QualificationTypes[_qualificationtypeSelectedIndex];
                }
            }
        }
        private QualificationType _selectedqualificationtype;

        public QualificationType SelectedQualificationType
        {
            get { return _selectedqualificationtype; }
            set
            {
                _selectedqualificationtype = value;
                SearchSettings.TypeId = _selectedqualificationtype.Id;
            }
        }

        //AwardingBody

        int _awardingbodySelectedIndex;
        public int AwardingBodySelectedIndex
        {
            get
            {
                return _awardingbodySelectedIndex;
            }
            set
            {
                if (_awardingbodySelectedIndex != value)
                {
                    _awardingbodySelectedIndex = value;

                    // trigger some action to take such as updating other labels or fields
                    OnPropertyChanged(nameof(AwardingBodySelectedIndex));
                    SelectedAwardingBody = AwardingBodies[_awardingbodySelectedIndex];
                }
            }
        }
        private AwardingBody _selectedawardingbody;

        public AwardingBody SelectedAwardingBody
        {
            get { return _selectedawardingbody; }
            set
            {
                _selectedawardingbody = value;
                SearchSettings.BodyId = _selectedawardingbody.Id;
            }
        }
        //

        public event PropertyChangedEventHandler PropertyChanged;

        protected virtual void OnPropertyChanged([CallerMemberName] string propertyName = null)
        {
            PropertyChangedEventHandler handler = PropertyChanged;
            if (handler != null)
            {
                handler(this, new PropertyChangedEventArgs(propertyName));
            }
        }

        public SearchPageViewModel(INavigationService navigationService)
                : base(navigationService)
        {
            Title = "Αναζήτηση Προσόντος";
            SearchSettings.TypeId = -1;
            SearchSettings.LevelId = -1;
            SearchSettings.BodyId = -1;
            SearchSettings.SectorId = -1;
            // OnNavigateCommand = new DelegateCommand<string>(NavigateAsync);
            EducationalLevels = new ObservableCollection<EducationalLevel>();
            EducationalSectors = new ObservableCollection<EducationalSector>();
            QualificationTypes = new ObservableCollection<QualificationType>();
            AwardingBodies = new ObservableCollection<AwardingBody>();

            OnNavigateCommand = new DelegateCommand<string>(NavigateAync);
        }

        async void NavigateAync(string page)
        {
            await NavigationService.NavigateAsync(new Uri(page, UriKind.RelativeOrAbsolute));
        }

        public override async void OnNavigatedTo(NavigationParameters parameters)
        {
            var language = "el";

            try
            {
                if (EducationalLevels == null)
                    EducationalLevels = new ObservableCollection<EducationalLevel>();
                if (EducationalSectors == null)
                    EducationalSectors = new ObservableCollection<EducationalSector>();
                if (QualificationTypes == null)
                    QualificationTypes = new ObservableCollection<QualificationType>();
                if (AwardingBodies == null)
                    AwardingBodies = new ObservableCollection<AwardingBody>();


                //EducationalLevels
                if (EducationalLevels != null && EducationalLevels.Count == 0)
                {
                    EducationalLevels.Clear();
                    var educationalLevels = EducationalLevelAppService.GetEducationalLevels(language);
                    foreach (var ed in educationalLevels)
                    {
                        EducationalLevels.Add(ed);
                    }
                }

                //EducationalSectors
                if (EducationalSectors != null && EducationalSectors.Count == 0)
                {
                    EducationalSectors.Clear();
                    var educationalSectors = EducationalSectorAppService.GetEducationalSectors(language);
                    foreach (var es in educationalSectors)
                    {
                        EducationalSectors.Add(es);
                    }
                }

                //QualificationTypes
                if (QualificationTypes != null && QualificationTypes.Count == 0)
                {
                    QualificationTypes.Clear();
                    var qualificationTypes = QualificationTypeAppService.GetQualificationTypes(language);
                    foreach (var qt in qualificationTypes)
                    {
                        QualificationTypes.Add(qt);
                    }
                }

                //AwardingBodies
                if (AwardingBodies != null && AwardingBodies.Count == 0)
                {
                    AwardingBodies.Clear();
                    var awardingBodies = AwardingBodyAppService.GetAwardingBodies(language);
                    foreach (var ab in awardingBodies)
                    {
                        AwardingBodies.Add(ab);
                    }
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
        //}
    }

}
