using taswiq4u.Views;

using Xamarin.Forms;
using Xamarin.Forms.Xaml;

[assembly: XamlCompilation(XamlCompilationOptions.Compile)]
namespace taswiq4u
{
	public partial class App : Application
	{
        public App()
		{
			InitializeComponent();

			SetMainPage();
		}

		public static void SetMainPage()
		{
            Current.MainPage = new LoginPage();
            
        }
	}
}
