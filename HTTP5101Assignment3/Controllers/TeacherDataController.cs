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
    public class TeacherDataController : ApiController
    {
        //Instantiates object with credentials to create a connection to the database
        private SchoolDbContext School = new SchoolDbContext();

        [HttpGet]
        public IEnumerable<Teacher> ListTeachers()
        {
            //Establishes a new connection to the database using the AccessDatabase method in the SchoolDbContext class
            MySqlConnection Conn = School.AccessDatabase();
            //Opens connection to the database
            Conn.Open();
            //Creates a new MySql command that displays all columns from the teachers table
            MySqlCommand cmd = Conn.CreateCommand();
            cmd.CommandText = "SELECT * FROM `teachers`";

            MySqlDataReader TeachersResults = cmd.ExecuteReader();
            List<Teacher> Teachers = new List<Teacher>{};
            
            while(TeachersResults.Read())
            {
                int TeacherId = (int)TeachersResults["teacherid"];
                string TeacherFName = (string)TeachersResults["teacherfname"];
                string TeacherLName = (string)TeachersResults["teacherlname"];
                string EmployeeNumber = (string)TeachersResults["employeenumber"];
                DateTime HireDate = (DateTime)TeachersResults["hiredate"];
                decimal Salary = (decimal)TeachersResults["salary"];

                Teacher NewTeacher = new Teacher();
                NewTeacher.Teacherid = TeacherId;
                NewTeacher.TeacherFname = TeacherFName;
                NewTeacher.TeacherLname = TeacherLName;
                NewTeacher.EmployeeNumber = EmployeeNumber;
                NewTeacher.HireDate = HireDate;
                NewTeacher.Salary = Salary;
                Teachers.Add(NewTeacher);
            }

            Conn.Close();

            return Teachers;
        }

        public Teacher FindTeacher(int id)
        {
            Teacher NewTeacher = new Teacher();
            //Establishes a new connection to the database using the AccessDatabase method in the SchoolDbContext class
            MySqlConnection Conn = School.AccessDatabase();
            //Opens connection to the database
            Conn.Open();
            //Creates a new MySql command that displays all columns from the teachers table
            MySqlCommand cmd = Conn.CreateCommand();
            cmd.CommandText = "SELECT * FROM `teachers` WHERE `teachers`.teacherid = " + id;

            MySqlDataReader TeacherResult = cmd.ExecuteReader();
            
            while(TeacherResult.Read())
            {
                int TeacherId = (int)TeacherResult["teacherid"];
                string TeacherFName = (string)TeacherResult["teacherfname"];
                string TeacherLName = (string)TeacherResult["teacherlname"];
                string EmployeeNumber = (string)TeacherResult["employeenumber"];
                DateTime HireDate = (DateTime)TeacherResult["hiredate"];
                decimal Salary = (decimal)TeacherResult["salary"];

                NewTeacher.Teacherid = TeacherId;
                NewTeacher.TeacherFname = TeacherFName;
                NewTeacher.TeacherLname = TeacherLName;
                NewTeacher.EmployeeNumber = EmployeeNumber;
                NewTeacher.HireDate = HireDate;
                NewTeacher.Salary = Salary;
            }

            Conn.Close();
            return NewTeacher;
        }
    }
}
