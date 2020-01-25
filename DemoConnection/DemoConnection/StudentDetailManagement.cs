using System;
using System.Data;
using System.Configuration;
using System.Data.SqlClient;

namespace DemoConnection
{
    class StudentDetailManagement
    {
        string DBConnection = ConfigurationManager.ConnectionStrings["Demo"].ConnectionString;
        SqlConnection connection = null;
        static void Main()
        {
            new StudentDetailManagement().EstablishConnection();
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
                    connection.Open();
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
                    connection.Close();
                }
            }
            catch (Exception e)
            {
                Console.WriteLine(e.Message);
                Console.WriteLine(e.StackTrace);
            }
        }
        public void InsertStudentDetails()
        {
            string sql = "SP_Student_Insert";        //Stored procedure of the database
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
            DateTime _dob = DateTime.Parse(Console.ReadLine());
            var dob = _dob.Date;
            sqlCommand.Parameters.Add(new SqlParameter("@DOB", dob));     //Passing DOB to the stored procedure

            Console.WriteLine("Enter the student CGPA");
            string cgpa = Console.ReadLine();
            sqlCommand.Parameters.Add(new SqlParameter("@CGPA", cgpa));     //Passing CGPA to the stored procedure

            Console.WriteLine("Enter the language known by student");
            string languageKnown = Console.ReadLine();
            sqlCommand.Parameters.Add(new SqlParameter("@Language_Known", languageKnown));     //Passing language known to the stored procedure

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
        }
        public void UpdateStudentDetails()
        {
            string action = null;
            string sql = "SP_Student_Update";
            SqlCommand sqlCommand = new SqlCommand(sql, connection);
            sqlCommand.CommandType = CommandType.StoredProcedure;

            Console.WriteLine("Enter the student id");
            int id = int.Parse(Console.ReadLine());
            sqlCommand.Parameters.Add(new SqlParameter("@ID", id));     //Passing ID to the stored procedure

            Console.WriteLine("Choose the field you want to update");
            Console.WriteLine("1.Name 2.Mail ID 3.DOB 4.CGPA 5.Language 6.Exit");
            int choice = int.Parse(Console.ReadLine());
            if(choice == 1)
            {
                action = "Name";
                Console.WriteLine("Enter the student name");
                string name = Console.ReadLine();
                sqlCommand.Parameters.Add(new SqlParameter("@Name", name));     //Passing Name to the stored procedure
            }
            else if(choice == 2)
            {
                action = "MailId";
                Console.WriteLine("Enter the student mail id");
                string mailId = Console.ReadLine();
                sqlCommand.Parameters.Add(new SqlParameter("@Mail_Id", mailId));     //Passing mail id to the stored procedure
            }
            else if (choice == 3)
            {
                action = "DOB";
                Console.WriteLine("Enter the student date of birth");
                string dob = Console.ReadLine();
                sqlCommand.Parameters.Add(new SqlParameter("@DOB", dob));     //Passing DOB to the stored procedure
            }
            else if (choice == 4)
            {
                action = "CGPA";
                Console.WriteLine("Enter the student CGPA");
                int cgpa = int.Parse(Console.ReadLine());
                sqlCommand.Parameters.Add(new SqlParameter("@CGPA", cgpa));     //Passing CGPA to the stored procedure
            }
            else if (choice == 5)
            {
                action = "LanguageKnown";
                Console.WriteLine("Enter the language known by student");
                string languageKnown = Console.ReadLine();
                sqlCommand.Parameters.Add(new SqlParameter("@Language_Known", languageKnown));     //Passing language known to the stored procedure
            }
            else if (choice == 6)
            {
                Console.WriteLine("Exiting..");
            }
            else
            {
                Console.WriteLine("Invalid choice");
            }
            sqlCommand.Parameters.Add(new SqlParameter("@Action", action));             //Passing the action to the stored procedure

            sqlCommand.ExecuteNonQuery();
            Console.WriteLine("Programmer details updated...");
            sqlCommand.Dispose();
        }
        public void DeleteStudentDetails()
        {
            string sql = "SP_Student_Delete";
            SqlCommand sqlCommand = new SqlCommand(sql, connection);
            sqlCommand.CommandType = CommandType.StoredProcedure;

            Console.WriteLine("Enter the student id");
            int id = int.Parse(Console.ReadLine());
            sqlCommand.Parameters.Add(new SqlParameter("@ID", id));     //Passing ID to the stored procedure

            SqlDataAdapter sqlDataAdapter = new SqlDataAdapter();
            sqlDataAdapter.DeleteCommand.CommandText = sql;
            Console.WriteLine("Programmer details deleted...");
            sqlCommand.Dispose();
        }
        public void DisplayProgrammerDetails()
        {
            string sql = "SP_Student_View";
            SqlCommand sqlCommand = new SqlCommand(sql, connection);
            sqlCommand.CommandType = CommandType.StoredProcedure;

            Console.WriteLine("Enter the student id");
            int id = int.Parse(Console.ReadLine());
            sqlCommand.Parameters.AddWithValue("@ID", id);     //Passing ID to the stored procedure

            string name;
            string mailId;
            DateTime dob;
            int cgpa;
            string languageKnown;

            sqlCommand.Parameters.Add("@Name", SqlDbType.VarChar, 15);
            sqlCommand.Parameters["@Name"].Direction = ParameterDirection.Output;
            sqlCommand.Parameters.Add("@Mail_Id", SqlDbType.VarChar, 25);
            sqlCommand.Parameters["@Mail_Id"].Direction = ParameterDirection.Output;
            sqlCommand.Parameters.Add("@DOB", SqlDbType.Date);
            sqlCommand.Parameters["@DOB"].Direction = ParameterDirection.Output;
            sqlCommand.Parameters.Add("@CGPA", SqlDbType.Int);
            sqlCommand.Parameters["@CGPA"].Direction = ParameterDirection.Output;
            sqlCommand.Parameters.Add("@Language_Known", SqlDbType.VarChar, 10);
            sqlCommand.Parameters["@Language_Known"].Direction = ParameterDirection.Output;

            sqlCommand.ExecuteNonQuery();
            name = Convert.ToString(sqlCommand.Parameters["@Name"].Value);
            mailId = Convert.ToString(sqlCommand.Parameters["@Mail_Id"].Value);
            dob = Convert.ToDateTime(sqlCommand.Parameters["@DOB"].Value);
            cgpa = Convert.ToInt32(sqlCommand.Parameters["@CGPA"].Value);
            languageKnown = Convert.ToString(sqlCommand.Parameters["@Language_Known"].Value);

            Console.WriteLine("Student details");
            Console.WriteLine("Name: {0}", name);
            Console.WriteLine("Mail ID: {0}", mailId);
            Console.WriteLine("DOB: {0}", dob);
            Console.WriteLine("CGPA: {0}", cgpa);
            Console.WriteLine("Language Known: {0}", languageKnown);

        }
    }
}