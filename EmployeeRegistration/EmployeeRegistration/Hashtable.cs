/**
 * HashTable
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
//    public class Employee1 : Signup
//    {
//        Hashtable database = new Hashtable();
//        private static string userId;
//        private static string userPassword;
//        public Employee1(int numberOfEmployees)
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
//                    database.Add(userId, signup);
//                    signup.GetDetails(userId, userPassword);
//                    Console.WriteLine("Profile completed successfully");
//                    Console.WriteLine();
//                }
//                catch (InvalidInput invalidInput)
//                {
//                    Console.WriteLine(invalidInput.Message);
//                    Console.WriteLine("Displaying existing User ID..");
//                    DisplayUserID();
//                    goto start;
//                }
//            }
//            Console.WriteLine("Logins created successfully");
//            Console.WriteLine("Number of logins: " + database.Count);
//            try
//            {
//                Console.WriteLine("To Delete login press D");
//                if (Console.ReadKey().Key == ConsoleKey.D)
//                {
//                    Console.WriteLine();
//                    DeleteAccount();
//                }
//            }
//            catch (UserAccountException userAccountException)
//            {
//                Console.WriteLine(userAccountException.Message);
//            }
//        }
//        static void Main()
//        {
//            try
//            {
//                Console.WriteLine("Enter the number of employee login you want to create");
//                int numberOfEmployees = 0;
//                numberOfEmployees = Input.GetInt();
//                Employee1 employee = new Employee1(numberOfEmployees);
//            }
//            catch (InvalidInput invalidInput)
//            {
//                Console.WriteLine(invalidInput.Message);
//            }
//            catch (Exception e)
//            {
//                Console.WriteLine(e.Message);
//                Console.WriteLine(e.StackTrace);
//            }
//        }
//        public static void CreateLogin()
//        {
//            Console.WriteLine("Enter User ID");
//            userId = Console.ReadLine();
//            Console.WriteLine("Enter Password");
//            userPassword = Console.ReadLine();
//        }
//        public bool ValidateAccount(string id)
//        {
//            Console.WriteLine("Checking for availability of account.....");
//            bool isContains = false;
//            foreach (DictionaryEntry account in database)
//            {
//                if (id.Equals(account.Key))
//                {
//                    isContains = true;
//                    break;
//                }
//            }
//            return isContains;
//        }
//        public bool VerifyPassword(string id, string password)
//        {
//            Console.WriteLine("Verifying Password..");
//            bool isMatched = false;
//            foreach (DictionaryEntry account in database)
//            {
//                if (id.Equals(account.Key))
//                {
//                    Signup signup = (Signup)account.Value;
//                    if (password.Equals(signup.userPassword))
//                    {
//                        isMatched = true;
//                    }
//                    break;
//                }
//            }
//            return isMatched;
//        }
//        void DisplayUserID()
//        {
//            foreach (DictionaryEntry id in database)
//            {
//                Console.WriteLine(id.Key);
//            }
//        }
//        void DeleteAccount()
//        {
//            Console.WriteLine("Enter the User Id to be deleted");
//            userId = Console.ReadLine();
//            if (!ValidateAccount(userId))
//            {
//                throw new UserAccountException("User not found");
//            }
//            Console.WriteLine("Enter the password");
//            userPassword = Console.ReadLine();
//            if (!VerifyPassword(userId, userPassword))
//            {
//                throw new UserAccountException("Incorrect password");
//            }
//            database.Remove(userId);
//            Console.WriteLine("Account deleted");
//        }
//    }
//}
