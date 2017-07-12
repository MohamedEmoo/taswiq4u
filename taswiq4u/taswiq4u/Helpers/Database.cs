using System;
using System.Collections.Generic;
using System.Text;
using MySql.Data.MySqlClient;
using System.Data;
namespace taswiq4u.Helpers
{
    public class Database
    {
        private string connsqlstring = "Server=volkswagen.websitewelcome.com;Port=3306;database=mercatog_tasweq;UId=mercatog_tasweq;Pwd=z(r+O1r1q@*W";
        public MySqlConnection sqlconn;

        public bool Openconnection()
        {
            try
            { 
             sqlconn = new MySqlConnection(connsqlstring);
             sqlconn.Open();
                return true;
            }
            catch(Exception e)
            {
                return false;
            } 
        }

        public void Closeconnection()
        {
            sqlconn.Close();
        }

        public void insert(string tablename, List<object> values)
        {

        }
    }
}
