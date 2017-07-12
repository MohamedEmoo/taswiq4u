using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using taswiq4u.Models;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace taswiq4u.Views
{
	[XamlCompilation(XamlCompilationOptions.Compile)]
	public partial class Profile : ContentPage
	{
		public Profile (MyProfile myProfile = null)
		{
			InitializeComponent ();
		}
	}
}