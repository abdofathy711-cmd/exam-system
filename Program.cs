using System;
using System.Collections.Generic;
namespace task01
{
    #region pro10.4
    class Employee
    {
        public int salary { get; set; }
        public string name { get; set; }
        public override string ToString()
        {
            return $" name : {name} , salary : {salary}";
        }
    } 
    #endregion
    static class method
    {
        #region pro6.3
        public static bool IsPalindrome(this string s)
        {
            for (int i = 0; i < s.Length / 2; i++)
            {
                if (s[i] != s[s.Length - 1 - i])
                {
                    return false;
                }
              
            }
            return true;
        }
        #endregion
        #region pro7.4
        public static bool IsPrime(this int number)
        {
            if (number <= 1) return false;
            for (int i = 2; i <= Math.Sqrt(number); i++)
            {
                if (number % i == 0) return false;
            }
            return true;
        }
        #endregion
        #region pro8.4
        public static int Sumarr(this int[] arr)
        {
            int sum = 0;
            foreach (int n in arr)
            {
                sum += n;
            }
            return sum;
        }
        #endregion
    }
    internal class Program
    {  
        static void Main(string[] args)
        {
            #region pro1.1
            Console.WriteLine("Question 1 part 1");
            Console.WriteLine();
            var a = 5;
            var b = "abdo";
            var c = 3.14;
            var d = true;
            var e = new int[] { 1, 2, 3, 4, 5 };
            Console.WriteLine(a.GetType());
            Console.WriteLine(b.GetType());
            Console.WriteLine(c.GetType());
            Console.WriteLine(d.GetType());
            Console.WriteLine(e.GetType());
            Console.WriteLine();
            #endregion
            #region pro2.1
            Console.WriteLine("Question 2 part 1");
            int age = 25;
            string name = "John";
            var age2 = 30;
            var name2 = "Jane";
            /*
             * compiler will infer the type of age2 and name2 based on the assigned values, 
             * so age2 will be of type int and name2 will be of type string before runing.
             */
            #endregion
            #region pro3.2
            Console.WriteLine("Question 3 part 2");
            Console.WriteLine();
            var product = new { Name = "Laptop", Price = 1000.0, Quantity = 5 };
            Console.WriteLine(product);
            Console.WriteLine();
            #endregion
            #region pro4.2
            Console.WriteLine("Question 4 part 2");
            Console.WriteLine();
            var student = new []{ new { name = "abdo", grade = 78 },
                new { name = "ahmed", grade = 90 },
                new { name = "ali", grade = 85 }
            };
            foreach (var s in student)
            {
                Console.WriteLine($"Name: {s.name}, Grade: {s.grade}");
            }
            Console.WriteLine();
            #endregion
            #region pro5.2 bouns
            Console.WriteLine("question 5 part 2 bouns");
            Console.WriteLine();
            var order = new { OrderId = 123, Customer = new
            {
                Name = "John",
                city="New York"
            }
            };
            foreach (var o in order.GetType().GetProperties())
            {
                Console.WriteLine($"{o.Name}: {o.GetValue(order)}");
            }
            Console.WriteLine();
            #endregion
            #region pro6.3
            Console.WriteLine("question 6 part 3");
            Console.WriteLine();
            string str = "madam";
              Console.WriteLine(method.IsPalindrome(str));
            Console.WriteLine();
            #endregion
            #region pro7.3
            Console.WriteLine("question 7 part 3");
            Console.WriteLine();
            int number = 7;
              Console.WriteLine(method.IsPrime(number));
            Console.WriteLine();
            #endregion
            #region pro8.3
            Console.WriteLine("question 8 part 3");
            Console.WriteLine();
            int[] numb = { 1,2,3,5,6,9 };
            Console.WriteLine($"Sum of Array = {numb.Sumarr()}");
            Console.WriteLine();
            #endregion
            #region pro9.4
            Console.WriteLine("Question 9 paet 4");
            Console.WriteLine();
            List<String> employee_names = new List<String>();
            for (int i = 0; i < 5; i++)
            {
                Console.WriteLine($"Enter employee name {i + 1}:");
                string name_input = Console.ReadLine();
                employee_names.Add(name_input);
            }
            employee_names.Remove(employee_names[0]);
            Console.WriteLine();

            Console.WriteLine("list after remove first name");
            foreach (string s in employee_names)
            {
                Console.WriteLine(s);
            }
            Console.WriteLine($"search for abdo : {employee_names.Contains("abdo")}");
            Console.WriteLine();
            #endregion
            #region pro10.4
            Console.WriteLine("Question 10 part 4");
            Console.WriteLine();
            List<Employee> emplist = new List<Employee>();
            emplist.Add(new Employee { name = "Abdelrhman", salary = 10000 });
            emplist.Add(new Employee { name = "ali", salary = 8000 });
            emplist.Add(new Employee { name = "same", salary = 12000 });
            emplist.Add(new Employee { name = "mohamed", salary = 7000 });
           foreach(Employee e1 in emplist)
            {
                if (e1.salary >= 10000)
                {
                    Console.WriteLine(e1.ToString());
                }
            }
            #endregion
        }
    }
}
