using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace QFXamApp.Views
{
	[XamlCompilation(XamlCompilationOptions.Compile)]
	public partial class SearchPage : ContentPage
	{
		public SearchPage ()
		{
			InitializeComponent ();
		}

        private void SearchBar_TextChanged(object sender, TextChangedEventArgs e)
        {
            //var vm = BindingContext as CategoryListPageViewModel;

            //CategoryList.ItemsSource = vm.Categories;
            //string kewyword = MainSearchBar.Text;
            //if (string.IsNullOrWhiteSpace(e.NewTextValue))
            //    CategoryList.ItemsSource = vm.Categories;
            //else
            //    CategoryList.ItemsSource = vm.Categories.Where(i => i.Name.ToLower().Contains(kewyword.ToLower()));
        }
    }
}