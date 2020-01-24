//using System;
//using System.Configuration;
//using System.Data.SqlClient;

//namespace AdoNetConsoleApplication
//{
//    class Program
//    {
//        string DBConnection = ConfigurationManager.ConnectionStrings["Demo"].ConnectionString;
//        static void Main(string[] args)
//        {
//            new Program().GetData();
//        }
//        public void GetData()
//        {
//            SqlConnection con = null;
//            try
//            {
//                // Creating Connection  
//                con = new SqlConnection(DBConnection);
//                // writing sql query  
//                SqlCommand cm = new SqlCommand("select * from Programmer; select * from Studies", con);
//                // Opening Connection  
//                con.Open();
//                // Executing the SQL query  
//                SqlDataReader sdr = cm.ExecuteReader();
//                while (sdr.Read())
//                {
//                    Console.WriteLine(sdr["Name"] + " " + sdr["DOB"]);

//                }
//                //bool bNextResult = true;
//                //while (bNextResult == true)
//                //{
//                //    while (sdr.Read())
//                //    {
//                //       Console.WriteLine(sdr.GetValue(1).ToString() + "\n");
//                //    }
//                //    bNextResult = sdr.NextResult();
//                //}
//            }
//            catch (Exception e)
//            {
//                Console.WriteLine("OOPs, something went wrong." + e.Message);
//            }
//            // Closing the connection  
//            finally
//            {
//                if(con != null)
//                {
//                    con.Close();
//                }
                
//            }
//        }
//    }
//}