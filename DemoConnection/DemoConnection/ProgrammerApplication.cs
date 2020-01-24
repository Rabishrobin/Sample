using System;
using System.Data;
using System.Configuration;
using System.Data.SqlClient;

namespace DemoConnection
{
    class StudentApplication
    {
        string DBConnection = ConfigurationManager.ConnectionStrings["Demo"].ConnectionString;
        SqlConnection connection = null;
        static void Main()
        {
            new StudentApplication().EstablishConnection();
        }
        public void EstablishConnection()
        {
            try
            {
                connection = new SqlConnection(DBConnection);
                if (connection == null)
                {
                    Console.WriteLine("Database not found");
                    System.Environment.Exit(0);
                }
                else
                    Console.WriteLine("Database connected");
                while (true)
                {
                    Console.WriteLine("Enter your choice 1.Insert 2.Update 3.Delete 4.Display 5.Exit");
                    int choice = int.Parse(Console.ReadLine());
                    if (choice == 1)
                    {
                        InsertStudentDetails();
                    }
                    else if (choice == 2)
                    {
                        UpdateStudentDetails();
                    }
                    else if (choice == 3)
                    {
                        DeleteStudentDetails();
                    }
                    else if (choice == 4)
                    {
                        DisplayProgrammerDetails();
                    }
                    else if (choice == 5)
                    {
                        break;
                    }
                    else
                    {
                        Console.WriteLine("Invalid choice");
                    }
                }
            }
            catch (Exception e)
            {
                Console.WriteLine(e.Message);
            }
        }
        public void InsertStudentDetails()
        {
            connection.Open();
            string action = "INSERT";                       //Action of the stored procedure
            string sql = "SP_Student_Insert_Delete";        //Stored procedure of the database
            SqlCommand sqlCommand = new SqlCommand(sql, connection);
            sqlCommand.CommandType = CommandType.StoredProcedure;

            Console.WriteLine("Enter the student id");
            int id = int.Parse(Console.ReadLine());
            sqlCommand.Parameters.Add(new SqlParameter("@ID", id));     //Passing ID to the stored procedure

            Console.WriteLine("Enter the student name");
            string name = Console.ReadLine();
            sqlCommand.Parameters.Add(new SqlParameter("@Name", name));     //Passing Name to the stored procedure

            Console.WriteLine("Enter the student mail id");
            string mailId = Console.ReadLine();
            sqlCommand.Parameters.Add(new SqlParameter("@Mail_Id", mailId));     //Passing mail id to the stored procedure

            Console.WriteLine("Enter the student date of birth");
            DateTime dob = DateTime.Parse(Console.ReadLine());
            sqlCommand.Parameters.Add(new SqlParameter("@DOB", dob));     //Passing DOB to the stored procedure

            Console.WriteLine("Enter the student CGPA");
            string cgpa = Console.ReadLine();
            sqlCommand.Parameters.Add(new SqlParameter("@CGPA", cgpa));     //Passing CGPA to the stored procedure

            Console.WriteLine("Enter the language known by student");
            string languageKnown = Console.ReadLine();
            sqlCommand.Parameters.Add(new SqlParameter("@Language_Known", languageKnown));     //Passing language known to the stored procedure

            sqlCommand.Parameters.Add(new SqlParameter("@Action", action));             //Passing the action to the stored procedure
            int rows = sqlCommand.ExecuteNonQuery();
            if (rows >= 1)
            {
                Console.WriteLine("Programmer details added...");
            }
            else
            {
                Console.WriteLine("Unable to add programmer details");
            }
            sqlCommand.Dispose();
            connection.Close();
        }
        public void UpdateStudentDetails()
        {
            connection.Open();
            string action = "UPDATE";
            string sql = "PROGRAMMER_PROC_INSERT_UPDATE";
            SqlCommand sqlCommand = new SqlCommand(sql, connection);
            sqlCommand.CommandType = CommandType.StoredProcedure;

            Console.WriteLine("Enter the student id");
            int id = int.Parse(Console.ReadLine());
            sqlCommand.Parameters.Add(new SqlParameter("@ID", id));     //Passing ID to the stored procedure

            Console.WriteLine("Enter the student name");
            string name = Console.ReadLine();
            sqlCommand.Parameters.Add(new SqlParameter("@Name", name));     //Passing Name to the stored procedure

            Console.WriteLine("Enter the student mail id");
            string mailId = Console.ReadLine();
            sqlCommand.Parameters.Add(new SqlParameter("@Mail_Id", mailId));     //Passing mail id to the stored procedure

            Console.WriteLine("Enter the student date of birth");
            string dob = Console.ReadLine();
            sqlCommand.Parameters.Add(new SqlParameter("@DOB", dob));     //Passing DOB to the stored procedure

            Console.WriteLine("Enter the student CGPA");
            int cgpa = int.Parse(Console.ReadLine());
            sqlCommand.Parameters.Add(new SqlParameter("@CGPA", cgpa));     //Passing CGPA to the stored procedure

            Console.WriteLine("Enter the language known by student");
            string languageKnown = Console.ReadLine();
            sqlCommand.Parameters.Add(new SqlParameter("@Language_Known", languageKnown));     //Passing language known to the stored procedure

            sqlCommand.Parameters.Add(new SqlParameter("@Action", action));             //Passing the action to the stored procedure

            SqlDataAdapter sqlDataAdapter = new SqlDataAdapter();
            sqlDataAdapter.UpdateCommand = sqlCommand;
            DataSet ds = new DataSet();
            sqlDataAdapter.Fill(ds);
            Console.WriteLine("Programmer details updated...");
            sqlCommand.Dispose();
            connection.Close();
        }
        public void DeleteStudentDetails()
        {
            connection.Open();
            string action = "DELETE";
            string sql = "SP_Student_Insert_Delete";
            SqlCommand sqlCommand = new SqlCommand(sql, connection);
            sqlCommand.CommandType = CommandType.StoredProcedure;

            Console.WriteLine("Enter the student id");
            int id = int.Parse(Console.ReadLine());
            sqlCommand.Parameters.Add(new SqlParameter("@ID", id));     //Passing ID to the stored procedure

            sqlCommand.Parameters.Add(new SqlParameter("@Action", action));             //Passing the action to the stored procedure

            SqlDataAdapter sqlDataAdapter = new SqlDataAdapter();
            sqlDataAdapter.DeleteCommand.CommandText = sql;
            Console.WriteLine("Programmer details deleted...");
            sqlCommand.Dispose();
            connection.Close();
        }
        public void DisplayProgrammerDetails()
        {
            connection.Open();
            string sql = "SP_Student_View";
            SqlCommand sqlCommand = new SqlCommand(sql, connection);
            sqlCommand.CommandType = CommandType.StoredProcedure;

            Console.WriteLine("Enter the student id");
            int id = int.Parse(Console.ReadLine());
            sqlCommand.Parameters.AddWithValue("@ID", id);     //Passing ID to the stored procedure

            string name;


            sqlCommand.Parameters.Add("@Name", SqlDbType.VarChar, 15);
            sqlCommand.Parameters["@Name"].Direction = ParameterDirection.Output;
            sqlCommand.Parameters.Add("@Mail_Id", SqlDbType.VarChar, 25);
            sqlCommand.Parameters["@Mail_Id"].Direction = ParameterDirection.Output;
            sqlCommand.Parameters.Add("@DOB", SqlDbType.Date);
            sqlCommand.Parameters["@DOB"].Direction = ParameterDirection.Output;
            sqlCommand.Parameters.Add("@CGPA", SqlDbType.Int);
            sqlCommand.Parameters["@CGPA"].Direction = ParameterDirection.Output;
            sqlCommand.Parameters.Add("@Language_Known", SqlDbType.VarChar);
            sqlCommand.Parameters["@Language_Known"].Direction = ParameterDirection.Output;

            return new Tuple<string, string, DateTime>(clientGuid, clientName, dateCreated);
            connection.Close();
        }
    }
}