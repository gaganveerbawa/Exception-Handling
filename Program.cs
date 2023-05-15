using System;
using System.Collections.Generic;

namespace ExceptionHandling
{

    class Account
    {
        public string FirstName { get; private set; }
        public string LastName { get; private set; }
        public int Balance { get; private set; }

        public Account(string firstName, string lastName, int balance)
        {
            FirstName = firstName;
            LastName = lastName;
            Balance = balance;
        }

        public void Withdraw(int amount)
        {
            if (amount > Balance)
            {
                throw new InvalidOperationException("Insufficient fund");
            }
            Balance = Balance - amount;
        }
    }

    class Student
    {
        public string Name { get; set; }
    }

    class Program
    {
        // StackOverflowError
        static void RecursiveMethod(int i)
        {
            i++;
            RecursiveMethod(i);
        }
        public static void Main()
        {
            //NullRference Example
            try
            {
                /* NullRference occurs here as array of Student objects
                 * are created but not intialised. trying to access its Name 
                 * property results in NullReference expection.
                 */
                Student[] students = new Student[3];
                Console.WriteLine(students[0].Name);
            }
            catch (NullReferenceException exception)
            {
                Console.WriteLine("The following error detected: " + 
                    exception.GetType().ToString() + " with message \"" +
                    exception.Message + "\"");
            }

            //indexOutOfrange Example
            try
            {
                int[] myArray =  {0, 1, 2, 3, 4};

                /* Here the loop is trying acces the element at the 
                 * index greater than the size of array.
                 */
                for(int i = 0; i <= myArray.Length; i++)
                {
                    Console.Write(myArray[i] + "\t");
                }
                Console.WriteLine();
            }
            catch (IndexOutOfRangeException exception)
            {
                Console.WriteLine("The following error detected: " +
                    exception.GetType().ToString() + " with message \"" +
                    exception.Message + "\"");
            }

            // OutOfMemoryException Example
            try 
            {
                List<string[]> myList = new List<string[]>();
                while(true)
                {
                    string[] names = new string[int.MaxValue];
                    myList.Add(names);
                }
            }
            catch(OutOfMemoryException exception)
            {
                Console.WriteLine("The following error detected: " +
                       exception.GetType().ToString() + " with message \"" +
                       exception.Message + "\"");
            }

            //InvalidCastException example
            object myObject = "Police";
            try
            {
                /* trying to cast a string object to an integer 
                 * using the (int) cast operator. Since the string cannot be 
                 * converted to an integer, an InvalidCastException is thrown.
                 */
                int cast = (int)myObject;
            }
            catch (InvalidCastException exception)
            {
                Console.WriteLine("The following error detected: " +
                       exception.GetType().ToString() + " with message \"" +
                       exception.Message + "\"");
            }

            // DivideByZeroException Example
            try
            {
                int a = 6;
                int b = 0;

                Console.WriteLine(a / b);
            }
            catch (DivideByZeroException exception)
            {
                Console.WriteLine("The following error detected: " +
                       exception.GetType().ToString() + " with message \"" +
                       exception.Message + "\"");
            }

            //ArgumentException Exampel
            void MethodArgument(int number)
            {
                if (number <= 0)
                    throw new ArgumentException();
            }
            try
            {
                /* as -10 i not the valid argument for the function
                 * it will throw error
                 */
                MethodArgument(-10);
            }
            catch ( ArgumentException exception)
            {
                Console.WriteLine("The following error detected: " +
                       exception.GetType().ToString() + " with message \"" +
                       exception.Message + "\"");
            }

            //ArgumentOutOfRange Example
            void methodRange(int number)
            {
                if (number <= 0 || number > 13)
                    throw new ArgumentOutOfRangeException();
            }
            try
            {
                /* As 21 is not in the range of the method defined 
                   it will throw error
                 */
                methodRange(21);
            }
            catch(ArgumentOutOfRangeException exception)
            {
                Console.WriteLine("The following error detected: " +
                       exception.GetType().ToString() + " with message \"" +
                       exception.Message + "\"");
            }

            // SystemException Example
            try
            {
                string myName = null;
                Console.WriteLine(myName);
            }
            catch ( SystemException exception)
            {
                Console.WriteLine("The following error detected: " +
                       exception.GetType().ToString() + " with message \"" +
                       exception.Message + "\"");
            }

            try
            {
                Account account = new Account("Sergey", "P", 100);
                account.Withdraw(1000);
            }
            catch (InvalidOperationException exception)
            {
                Console.WriteLine("The following error detected: " 
                    + exception.GetType().ToString() + " with message \"" + 
                    exception.Message + "\"");
            }


            // StackOverflow example
            try
            {
                /* Since we never exit the recursion,
                 * the call stack continues to grow until 
                 * it reaches its maximum size,                
                 */
                RecursiveMethod(0);
            }
            catch (StackOverflowException exception)
            {
                // never excutes as program terminates due to stackoverflow
                Console.WriteLine("The following error detected: " +
                    exception.GetType().ToString() + " with message \"" +
                    exception.Message + "\"");
            }
            Console.ReadKey();
        }
    }
}
