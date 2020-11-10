using MySql.Data.MySqlClient;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace HTTP5101Assignment3.Models
{
    //Code based off blogdbContext shown in Christina Bittle's video (Learning C# for web development Pt11)
    public class SchoolDbContext
    {
        //Credentials for accessing database
        private static string User { get { return "root"; } }
        private static string Password { get { return "root"; } }
        private static string Database { get { return "schooldb"; } }
        private static string Server { get { return "localhost"; } }
        private static string Port { get { return "3306"; } }
        //Puts credentials in a protected string to pass unto MySqlConnection object below
        protected static string ConnectionString
        {
            get
            {
                return "server=" + Server + ";"
                    + "user=" + User + ";"
                    + "database=" + Database + ";"
                    + "port=" + Port + ";"
                    + "password=" + Password;
            }
        }
        //Passes connection string to a new MySqlConnection object to create a connection to the database
        public MySqlConnection AccessDatabase()
        {
            return new MySqlConnection(ConnectionString);
        }
    }
}