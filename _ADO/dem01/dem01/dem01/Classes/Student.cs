using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.Data.SqlClient;

namespace dem01.Classes
{
    public class Student
    {
        private int ID { get; set; }
        public string firstName { get; set; }
        public string lastName { get; set; }
        public int classNumber { get; set; }
        public DateTime Date { get; set; }


        public Student( string firstname, string lastname, int classnumber, DateTime date)
        {
 
            firstName = firstname;
            lastName = lastname;
            classNumber = classnumber;
            Date = date;
        }
        public Student(int id ,string firstname, string lastname, int classnumber, DateTime date)
        {
            ID = id;
            firstName = firstname;
            lastName = lastname;
            classNumber = classnumber;
            Date = date;
        }

        public override string ToString()
        {
            return $"ID: {ID}, Name: {firstName} {lastName}, Class Number: {classNumber}, Date: {Date:yyyy-MM-dd}";
        }
        static public bool Save(SqlConnection connection)
        {
            try
            {
                Console.WriteLine("First Name : ");
                string firstName = Console.ReadLine();
                Console.WriteLine("Last name : ");
                string lastName = Console.ReadLine();
                Console.WriteLine("Class Number : ");
                int classNumber = Convert.ToInt32(Console.ReadLine());
                Console.WriteLine("Date of obtention (YYYY-MM-DD) : ");
                DateTime licenseDate = DateTime.Parse(Console.ReadLine());

                string query = "INSERT INTO Student (firstName, lastName, classNumber, licenseDate) VALUES (@firstName, @lastName,@classNumber, @licenseDate)";
                var command = new SqlCommand(query, connection);

                command.Parameters.AddWithValue("@firstName", firstName);
                command.Parameters.AddWithValue("@lastName", lastName);
                command.Parameters.AddWithValue("@classNumber", classNumber);
                command.Parameters.AddWithValue("@licenseDate", licenseDate);

                command.ExecuteNonQuery();
            }
            catch (Exception ex)
            {
                return false;
                throw new Exception("Command bugged");
            }
            Console.WriteLine("Command worked");
            return true;
    
        }
        static public bool Delete(SqlConnection connection)
        {
            try
            {
                int id = Convert.ToInt32(Console.ReadLine());
                string query = "DELETE FROM student WHERE id = @id";
                var command = new SqlCommand(query, connection);
                command.Parameters.AddWithValue("@id", id);
                command.ExecuteNonQuery();
            }
            catch (Exception ex)
            {
                return false;
                throw new Exception("Command bugged");
            }
            return true;
        }

        public static Student GetbyId(int id, SqlConnection connection)
        {
            Student student = null;
            string request = "SELECT * FROM student WHERE  id = @id";

            using (SqlCommand sqlCommand = new SqlCommand(request, connection))
            {
                sqlCommand.Parameters.AddWithValue("@id", id);
                SqlDataReader reader = sqlCommand.ExecuteReader();
                while (reader.Read())
                {

                    student = new Student(reader.GetInt32(0), reader.GetString(1), reader.GetString(2), reader.GetInt32(3), reader.GetDateTime(4));
                    Console.WriteLine($"Student : {student.firstName} {student.lastName}");
                    return student;
                }
            }
                return student;
        }

        public static List<Student> GetStudents( SqlConnection connection, int? classNumber = null)
        {
            List<Student> students = new();
            string request = "SELECT * FROM Student WHERE classNumber = @classnumber";

            using (SqlCommand sqlCommand = new SqlCommand(request, connection))
            {
                sqlCommand.Parameters.AddWithValue("@classNumber", classNumber);

                SqlDataReader reader = sqlCommand.ExecuteReader();

                while (reader.Read())
                {   
                    students.Add(new Student(reader.GetInt32(0), reader.GetString(1), reader.GetString(2), reader.GetInt32(3), reader.GetDateTime(4)));
                }
            }
            return students;
        }
        //static public void GetStudents(SqlConnection connection)
        //{
        //    string request = "SELECT * FROM Student;";

        //    using (SqlCommand sqlCommand = new SqlCommand(request, connection))
        //    {
        //        SqlDataReader reader = sqlCommand.ExecuteReader();

        //        while (reader.Read())
        //        {
        //            Console.WriteLine($"id: {reader.GetInt32(0)} firstname: {reader.GetString(1)} lastname: {reader.GetString(2)}, classNumber: {reader.GetInt32(3)},  date : {reader.GetDateTime(4)}");
        //        }
        //    }
        //}
    }
}
