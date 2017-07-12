using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Android.Provider;
using taswiq4u.Style;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace taswiq4u.Views
{
	[XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class MenuPage : ContentPage
    {
        public ListView Menu { get; set; }
        Main rootPage;
        TableView tableView;
        public class MenuTableView : TableView
        {

        }
        public MenuPage(Main rootPage)
        {
            Icon = "menu.png";
            Title = "menu"; // The Title property must be set.

            this.rootPage = rootPage;

            var logoutButton = new Button { Text = "Logout", TextColor = Color.White , BackgroundColor = Color.FromHex("#8BC34A") };
            logoutButton.Clicked += (sender, e) =>
            {


                Navigation.PushModalAsync(new LoginPage());

                //Special Handel for Android Back button
                if (Device.OS == TargetPlatform.Android)
                    Application.Current.MainPage = new LoginPage();
            };
            var layout = new StackLayout
            {
           
            };
            var section = new TableSection()
            {
                new MenuCell {Text = "Home",Host= this,ImageSrc="home_black.png"},
                new MenuCell {Text = "Favorites",Host= this,ImageSrc="star_black.png"},
                new MenuCell {Text = "About",Host= this,ImageSrc="about_black.png"},
            };

            var root = new TableRoot() { section };

            tableView = new MenuTableView()
            {
                Root = root,
                Intent = TableIntent.Data,
                //BackgroundColor = Color.FromHex("2C3E50"),
                BackgroundColor = Color.White,

            };

            var settingView = new SettingsUserView();

            //settingView.tapped += (object sender, TapViewEventHandler e) =>
            //{

            //    Navigation.PushAsync(new Profile());
            //    // var home = new NavigationPage(new Profile());
            //    // rootPage.Detail = home;
            //};

            //layout.Children.Add(settingView);
            //layout.Children.Add(new BoxView()
            //{
            //    HeightRequest = 1,
            //    BackgroundColor = AppStyle.DarkLabelColor,
            //});
            layout.Children.Add(tableView);
            layout.Children.Add(logoutButton);

            Content = layout;

            var tapGestureRecognizer = new TapGestureRecognizer();
            tapGestureRecognizer.Tapped +=
                (sender, e) =>
                {
               //     NavigationPage profile = new NavigationPage(new Profile(settingView.profileViewModel.myProfile)) { BarBackgroundColor = App.BrandColor, BarTextColor = Color.White };
                    rootPage.Detail = new AboutPage();
                    rootPage.IsPresented = false;
                };
            settingView.GestureRecognizers.Add(tapGestureRecognizer);

        }

        ContentPage home, About, favorites;
        public void Selected(string item)
        {

            switch (item)
            {
                case "Home":
                    if (home == null)
                        home = new ItemsPage();
                    rootPage.Detail = home;
                    break;
                case "Favorites":
                    favorites = new ItemsPage();
                    rootPage.Detail = favorites;
                    break;
                case "About":
                    About = new AboutPage();
                    rootPage.Detail = About;
                    break;
            };
            rootPage.IsPresented = false;  // close the slide-out
        }

    }
}