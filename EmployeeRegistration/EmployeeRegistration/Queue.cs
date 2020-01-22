/**
 * Queue
*/

//using System;
//using System.Collections;

//namespace EmployeeManagement
//{
//    class InvalidInput : Exception
//    {
//        public InvalidInput(string error) : base(error)
//        {

//        }
//    }
//    class UserAccountException : Exception
//    {
//        public UserAccountException(string error) : base(error)
//        {

//        }
//    }
//    static class Input
//    {
//        public static int GetInt()
//        {
//            string input = Console.ReadLine();
//            bool canConvert;
//            canConvert = int.TryParse(input, out int value);
//            return canConvert ? value : throw new InvalidInput("Entered format is incorrect please enter a correct input");
//        }
//        public static long GetLong()
//        {
//            string input = Console.ReadLine();
//            bool canConvert;
//            canConvert = long.TryParse(input, out long value);
//            return canConvert ? value : throw new InvalidInput("Entered format is incorrect please enter a correct input");
//        }
//    }
//    public class Signup
//    {
//        public string userId { set; get; }
//        public string userPassword { set; get; }
//        public string employeeName { set; get; }

//        public int employeeAge;
//        public long employeeMobileNumber;
//        public int age
//        {
//            set
//            {
//                if (value < 1 || value > 50)
//                {
//                    throw new InvalidInput("Invalid age entered");
//                }
//                this.employeeAge = value;
//            }
//            get
//            {
//                return this.employeeAge;
//            }
//        }
//        public long mobileNumber
//        {
//            set
//            {
//                if (value < 6000000000 || value > 9999999999)
//                {
//                    throw new InvalidInput("Invalid mobile number entered");
//                }
//                this.employeeMobileNumber = value;
//            }
//            get
//            {
//                return this.employeeMobileNumber;
//            }
//        }
//        internal void GetDetails(string userId, string userPassword)
//        {
//            this.userId = userId;
//            this.userPassword = userPassword;
//            Console.WriteLine("Enter the Employee name");
//            employeeName = Console.ReadLine();
//            Console.WriteLine("Enter the Employee age");
//            age = Input.GetInt();
//            Console.WriteLine("Enter the Employee number");
//            mobileNumber = Input.GetLong();
//        }
//    }
//    public class Employee : Signup
//    {
//        Queue database = new Queue();
//        private string userId;
//        private string userPassword;
//        public Employee(int numberOfEmployees)
//        {
//            for (int index = 0; index < numberOfEmployees; index++)
//            {
//            start:
//                try
//                {
//                    Console.WriteLine("Enter the details to Create Account");
//                    CreateLogin();
//                    Console.WriteLine("Checking for availability of account.....");
//                    if (ValidateAccount(userId))
//                    {
//                        throw new InvalidInput("User name already exist");
//                    }
//                    Console.WriteLine("Account created!!! enter your details to complete the profile");
//                    Signup signup = new Signup();
//                    database.Enqueue(signup);
//                    signup.GetDetails(userId, userPassword);
//                    Console.WriteLine("Profile completed successfully");
//                    Console.WriteLine();
//                }
//                catch (InvalidInput invalidInput)
//                {
//                    Console.WriteLine(invalidInput.Message);
//                    goto start;
//                }
//            }
//            Console.WriteLine("Logins created successfully");
//            Console.WriteLine("Number of login: " + database.Count);
//            try
//            {
//                Console.WriteLine("To Delete press D To Clear press C");
//                ConsoleKey key = Console.ReadKey().Key;
//                if (key == ConsoleKey.D)
//                {
//                    Console.WriteLine();
//                    DeleteAccount();
//                }
//                if(key == ConsoleKey.C)
//                {
//                    Console.WriteLine();
//                    database.Clear();
//                    Console.WriteLine("Number of login after clearing: " + database.Count);
//                }
//            }
//            catch (UserAccountException userAccountException)
//            {
//                Console.WriteLine(userAccountException.Message);
//            }
//        }
//        void CreateLogin()
//        {
//            Console.WriteLine("Enter User ID");
//            userId = Console.ReadLine();
//            Console.WriteLine("Enter Password");
//            userPassword = Console.ReadLine();
//        }
//        public bool ValidateAccount(string id)
//        {
//            bool isContains = false;
//            foreach (var account in database)
//            {
//                Signup signup = (Signup)account;
//                if (id.Equals(signup.userId))
//                {
//                    isContains = true;
//                    break;
//                }
//            }
//            return isContains;
//        }
//        void DeleteAccount()
//        {
//            database.Dequeue();
//            Console.WriteLine("Account deleted");
//            Console.WriteLine("Number of logins after poping: " + database.Count);
//        }
//        static void Main()
//        {
//            try
//            {
//                Console.WriteLine("Enter the number of employee login you want to create");
//                int numberOfEmployees = 0;
//                numberOfEmployees = Input.GetInt();
//                Employee employee = new Employee(numberOfEmployees);
//            }
//            catch (Exception e)
//            {
//                Console.WriteLine(e);
//                Console.WriteLine(e.Message);
//                Console.WriteLine(e.StackTrace);
//            }
//        }
//    }
//}