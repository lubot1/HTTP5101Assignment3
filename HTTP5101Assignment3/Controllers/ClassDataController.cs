using HTTP5101Assignment3.Models;
using MySql.Data.MySqlClient;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;

namespace HTTP5101Assignment3.Controllers
{
    public class ClassDataController : ApiController
    {
        private SchoolDbContext School = new SchoolDbContext();

        public IEnumerable<Class> FindTeacherClass(int id)
        {
            
            //Establishes a new connection to the database using the AccessDatabase method in the SchoolDbContext class
            MySqlConnection Conn = School.AccessDatabase();
            //Opens connection to the database
            Conn.Open();
            //Creates a new MySql command that displays all columns from the class table
            MySqlCommand cmd = Conn.CreateCommand();
            cmd.CommandText = "SELECT classname FROM `classes` WHERE `classes`.teacherid = " + id;

            MySqlDataReader ResultSet = cmd.ExecuteReader();
            List<Class> Classes = new List<Class> { };

            while (ResultSet.Read())
            {
                string ClassName = (string)ResultSet["classname"];
                Class NewClass = new Class();
                NewClass.ClassName = ClassName;
                Classes.Add(NewClass);
            }
            Conn.Close();
            return Classes;
        }
    }
}
