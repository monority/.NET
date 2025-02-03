using Microsoft.Data.SqlClient;
using System.Data;
using dem01.Classes;
string connectionString = "Data Source=(localdb)\\demoADO; Database=ContactDB;";
var connection = new SqlConnection(connectionString);

connection.Open();

//Student.Save(connection);
//Student.GetStudents(connection);
//Student.GetbyId(2,connection);
Student.GetStudents(connection);
connection.Dispose();
connection.Close();


//string classNumber = Console.ReadLine();
//string request = "SELECT firstName, lastName FROM student WHERE  classNumber = @classNumber";

//using (SqlCommand sqlCommand = new SqlCommand(request, connection))
//{
//    sqlCommand.Parameters.AddWithValue("@classNumber", classNumber);

//    SqlDataReader reader = sqlCommand.ExecuteReader();

//    while (reader.Read())
//    {
//        string firstName = reader.GetString(0);
//        string lastName = reader.GetString(1);

//        Console.WriteLine($"{firstName}, {lastName}");
//    }
//}

//connection.Dispose();
//connection.Close();

//int id = Convert.ToInt32(Console.ReadLine());
//string query = "DELETE FROM student WHERE id = @id";

//var command = new SqlCommand(query, connection);

//command.Parameters.AddWithValue("@id", id);
//command.ExecuteNonQuery();
//connection.Dispose();
//connection.Close();

//int id = Convert.ToInt32(Console.ReadLine());
//Student student01 = new Student("Da", "CS", "14", DateTime.Now);

//string request = "UPDATE student set   firstName = @firstName, lastname = @lastName, classNumber = @classNumber, licenseDate = @licenseDate WHERE id = @id";

//var command = new SqlCommand(request, connection);

//command.Parameters.AddWithValue("@id", id);
//command.Parameters.AddWithValue("@firstName", student01.firstName);
//command.Parameters.AddWithValue("@lastName", student01.lastName);
//command.Parameters.AddWithValue("@classNumber", student01.classNumber);
//command.Parameters.AddWithValue("@licenseDate", student01.Date);
//command.ExecuteNonQuery();
//connection.Dispose();
//connection.Close();
