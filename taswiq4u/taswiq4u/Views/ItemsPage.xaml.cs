using System;
using taswiq4u.Helpers;
using taswiq4u.Models;
using taswiq4u.ViewModels;

using Xamarin.Forms;

namespace taswiq4u.Views
{
	public partial class ItemsPage : ContentPage
	{
	

		public ItemsPage()
		{
            BindingContext = new ItemsViewModel();
            InitializeComponent();
           
          
		}

	
	}
}
