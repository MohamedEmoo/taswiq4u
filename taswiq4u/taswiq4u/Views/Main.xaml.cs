using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using taswiq4u.Helpers;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace taswiq4u.Views
{
	[XamlCompilation(XamlCompilationOptions.Compile)]
	public partial class Main : MasterDetailPage
	{
		public Main ()
		{
			InitializeComponent ();
            Master=new MenuPage(this);
            Detail= new NavigationPage(new ItemsPage());
		}
	}
}