using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using MySql.Data.MySqlClient;
using taswiq4u.Helpers;
using taswiq4u.Models;
using taswiq4u.Views;
using Xamarin.Forms;

namespace taswiq4u.ViewModels
{
    public class LoginViewModel : BaseViewModel
    {
     


   
     
        public const string LoginCommandPropertyName = "LoginCommand";
        Command loginCommand;
        public Command LoginCommand
        {
            get
            {
                return loginCommand ??
                    (loginCommand = new Command(async () => await ExecuteLoginCommand()));
            }
        }

        private async Task ExecuteLoginCommand()
        {

            bool isLoginSuccess = false;
            if (IsBusy)
                return;

            IsBusy = true;
            loginCommand.ChangeCanExecute();

            try
            {
                int count = 0;
                Database database = new Database();
                database.Openconnection();
                using (MySqlCommand cmd = new MySqlCommand
                    ("SELECT * FROM users", database.sqlconn))

                {

                    MySqlDataReader Reader = cmd.ExecuteReader();
                    //while (Reader.Read()) // this part is wrong somehow
                    //{
                    //    if (Reader.GetString(5) == username)
                    //    {
                    //        //abdo@gmail.com
                    //        string Red = Reader.GetString(6);
                    //        count++;
                    //    }
                    //}
                    Reader.Close();
                    if (count==0)
                        isLoginSuccess = true;
                    database.Closeconnection();
                }
            }
            catch (Exception ex)
            {
                isLoginSuccess = false;
            }

            finally
            {
                IsBusy = false;
                loginCommand.ChangeCanExecute();
            }

            if (isLoginSuccess)
            {

                //Application.Current.MainPage = new Main();
                Application.Current.MainPage = new NavigationPage(new Main()) {BarBackgroundColor = Color.Chartreuse, BarTextColor = Color.White};
            }
            else
            {
              
            }
        }


        string username = string.Empty;
        public const string UsernamePropertyName = "UserName";
        public string UserName
        {
            get { return username; }
            set { SetProperty(ref username, value, UsernamePropertyName); }
        }

        string password = string.Empty;
        public const string PasswordPropertyName = "Password";
        public string Password
        {
            get { return password; }
            set { SetProperty(ref password, value, PasswordPropertyName); }
        }
    }
}
