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

        //This controller is used to retrieve classes taught by a single teacher
        /// <summary>
        /// Returns a list of courses taught by a teacher
        /// </summary>
        /// <param name="id"></param>
        /// <returns>A list of classes taught by a teacher</returns>
        public IEnumerable<Class> FindTeacherClass(int id)
        {
            
            //Establishes a new connection to the database using the AccessDatabase method in the SchoolDbContext class
            MySqlConnection Conn = School.AccessDatabase();
            //Opens connection to the database
            Conn.Open();
            //Creates a new MySql command that displays all columns from the class table
            MySqlCommand cmd = Conn.CreateCommand();
            //Query only requests classname from classes object since that is the only info needed in the teacher table for now
            cmd.CommandText = "SELECT classname FROM `classes` WHERE `classes`.teacherid = " + id;
            //Collects query result and stores them in an object we can access
            MySqlDataReader ResultSet = cmd.ExecuteReader();
            List<Class> Classes = new List<Class> { };

            //Loop to extract results and assign them to a class object
            while (ResultSet.Read())
            {
                //Instantiate new Class object to assign classname to
                Class NewClass = new Class();
                //Extract classname from result set
                string ClassName = (string)ResultSet["classname"];
                //Assign result to classname property in a class object
                NewClass.ClassName = ClassName;
                //Add the new class object to a running list of objects
                Classes.Add(NewClass);
            }
            Conn.Close();
            return Classes;
        }
        /// <summary>
        /// List all classes in database
        /// </summary>
        /// <example></example>
        /// <returns>A list of class objects</returns>
        [HttpGet]
        public IEnumerable<Class> ListClasses()
        {
            //Establishes a new connection to the database using the AccessDatabase method in the SchoolDbContext class
            MySqlConnection Conn = School.AccessDatabase();
            //Opens connection to the database
            Conn.Open();
            //Creates a new MySql command that displays all columns from the class table
            MySqlCommand cmd = Conn.CreateCommand();
            cmd.CommandText = "SELECT * FROM `classes`";
            //Collects query result and stores them in an object we can access
            MySqlDataReader ResultSet = cmd.ExecuteReader();
            List<Class> Classes = new List<Class> { };
            //Loop to extract results and assign them to a class object
            while (ResultSet.Read())
            {
                //Instantiate new class object to assign results to
                Class NewClass = new Class();
                //Assign results to variables
                int ClassId = (int)ResultSet["classid"];
                string ClassCode = (string)ResultSet["classcode"];
                long TeacherId = (long)ResultSet["teacherid"];
                DateTime StartDate = (DateTime)ResultSet["startdate"];
                DateTime FinishDate = (DateTime)ResultSet["finishdate"];
                string ClassName = (string)ResultSet["classname"];
                //Assign results to the new class object properties
                NewClass.ClassId = ClassId;
                NewClass.ClassCode = ClassCode;
                NewClass.TeacherId = TeacherId;
                NewClass.StartDate = StartDate;
                NewClass.FinishDate = FinishDate;
                NewClass.ClassName = ClassName;
                //Add the new class object to a running list of objects
                Classes.Add(NewClass);
            }
            Conn.Close();
            return Classes;
        }
        /// <summary>
        /// Show class properties from Class with matching id
        /// </summary>
        /// <param name="id"></param>
        /// <returns>One class object with all its properties</returns>
        [HttpGet]
        public Class FindClass(int id)
        {
            //Establishes a new connection to the database using the AccessDatabase method in the SchoolDbContext class
            MySqlConnection Conn = School.AccessDatabase();
            //Opens connection to the database
            Conn.Open();
            //Creates a new MySql command that displays all columns from the class table
            MySqlCommand cmd = Conn.CreateCommand();
            cmd.CommandText = "SELECT * FROM `classes` WHERE classid = " + id;
            //Collects query result and stores them in an object we can access
            MySqlDataReader ResultSet = cmd.ExecuteReader();
            //Instantiate new class object to assign results to
            Class NewClass = new Class();

            while (ResultSet.Read())
            {
                //Assign results to variables
                int ClassId = (int)ResultSet["classid"];
                string ClassCode = (string)ResultSet["classcode"];
                long TeacherId = (long)ResultSet["teacherid"];
                DateTime StartDate = (DateTime)ResultSet["startdate"];
                DateTime FinishDate = (DateTime)ResultSet["finishdate"];
                string ClassName = (string)ResultSet["classname"];
                //Assign results to the new class object properties
                NewClass.ClassId = ClassId;
                NewClass.ClassCode = ClassCode;
                NewClass.TeacherId = TeacherId;
                NewClass.StartDate = StartDate;
                NewClass.FinishDate = FinishDate;
                NewClass.ClassName = ClassName;
            }
            Conn.Close();
            return NewClass;
        }
    }
}
