using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Diagnostics;
using System.Runtime.CompilerServices;
using System.Threading.Tasks;
using MySql.Data.MySqlClient;
using taswiq4u.Droid.Annotations;
using taswiq4u.Helpers;
using taswiq4u.Models;
using taswiq4u.Views;

using Xamarin.Forms;

namespace taswiq4u.ViewModels
{
    public class ItemsViewModel : INotifyPropertyChanged
    {
        public IList<Item> Items { get; set; }

        public ItemsViewModel()
        {
            Database database = new Database();
            database.Openconnection();
            Items=new List<Item>();
            using (MySqlCommand cmd = new MySqlCommand
                ("SELECT * FROM users", database.sqlconn))
            {

                MySqlDataReader Reader = cmd.ExecuteReader();
                while (Reader.Read()) // this part is wrong somehow
                {
                    Items.Add(new Item {Text = Reader.GetString(4),Description = Reader.GetString(5)});
                }
                Reader.Close();

                database.Closeconnection();
            }


        }

        public event PropertyChangedEventHandler PropertyChanged;

        [NotifyPropertyChangedInvocator]
        protected virtual void OnPropertyChanged([CallerMemberName] string propertyName = null)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }
    }
}