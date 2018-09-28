using Prism.Commands;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Xamarin.Forms;

namespace QFXamApp.Views
{
    public partial class MainPage : ContentPage
    {
        public DelegateCommand NavigateToEducationalLevels { get; set; }
        public DelegateCommand NavigateToAwardingBodies { get; set; }
        public DelegateCommand NavigateToQualificationTypes { get; set; }
        public MainPage()
        {
            InitializeComponent();
        }
    }
}