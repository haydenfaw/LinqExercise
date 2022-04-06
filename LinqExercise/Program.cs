using System;
using System.Collections.Generic;
using System.Linq;

namespace LinqExercise
{
    class Program
    {
        //Static array of integers
        private static int[] numbers = { 1, 2, 3, 4, 5, 6, 7, 8, 9, 0 };

        static void Main(string[] args)
        {
            /*
             * 
             * Complete every task using Method OR Query syntax.
             *
             * HINT: Use the List of Methods defined in the Lecture Material Google Doc ***********
             *
             * You may find that Method syntax is easier to use since it is most like C#
             * Every one of these can be completed using Linq and then printing with a foreach loop.
             * Push to your github when completed!
             * 
             */

            //DONE -- Print the Sum and Average of numbers
            Console.WriteLine($"Sum of the numbers: {numbers.Sum()}");
            Console.WriteLine("--------------------------");
            Console.WriteLine($"Average of the numbers: {numbers.Average()}");
            Console.WriteLine("--------------------------");
            Console.WriteLine("Numbers in ascending order:");
            //DONE -- Order numbers in ascending order and decsending order. Print each to console.
            var ascendingNumbers = numbers.OrderBy(x => x);
            foreach (var number in ascendingNumbers)
            {
                Console.WriteLine(number);
            }
            Console.WriteLine("--------------------------");
            Console.WriteLine("Numbers in decending order:");
            var decendingNumbers = numbers.OrderByDescending(x => x);
            foreach (var number in decendingNumbers)
            {
                Console.WriteLine(number);
            }
            Console.WriteLine("--------------------------");
            Console.WriteLine("Numbers greater than 6:");
            var numbersGreaterThanSix = numbers.Where(x => x > 6);
            foreach (var number in numbersGreaterThanSix)
            {
                Console.WriteLine(number);
            }
            //DONE -- Order numbers in any order (acsending or desc) but only print 4 of them **foreach loop only!**
            Console.WriteLine("--------------------------");
            Console.WriteLine("Print 4 in whatever order (I chose ascending):");
            foreach (var number in ascendingNumbers.Take(4))
            {
                Console.WriteLine(number);
            }

            //DONE -- Change the value at index 4 to your age, then print the numbers in decsending order
            numbers[4] = 30;
            Console.WriteLine("--------------------------");
            Console.WriteLine("Numbers decending with age input:");
            foreach (var number in numbers.OrderByDescending(x => x))
            {
                Console.WriteLine(number);
            }
            // List of employees ***Do not remove this***
            var employees = CreateEmployees();

            Console.WriteLine("--------------------------");
            Console.WriteLine("--EMPLOYEES SECTION--");
            //DONE -- Print all the employees' FullName properties to the console only if their FirstName starts with a C OR an S.
            //DONE -- Order this in acesnding order by FirstName.
            Console.WriteLine("--------------------------");
            Console.WriteLine("Employees whos first name starts with a C or an S. Then filtered in ascending order by first name:");
            var filter = employees.Where(person => person.FirstName[0] == 'C' || person.FirstName.StartsWith('S')).OrderBy(person => person.FirstName);
            foreach (var employee in filter)
            {
                Console.WriteLine($"{employee.FullName}");
            }
            //DONE -- Print all the employees' FullName and Age who are over the age 26 to the console.
            //DONE -- Order this by Age first and then by FirstName in the same result.
            Console.WriteLine("--------------------------");
            Console.WriteLine("Employees over the age of 26:");
            foreach (var employee in employees.Where(employee => employee.Age > 26).OrderBy(employee => employee.Age).ThenBy(employee => employee.FirstName))
            {
                Console.WriteLine($"{employee.FullName} - Age: {employee.Age}");
            }


            //DONE -- Print the Sum and then the Average of the employees' YearsOfExperience
            //DONE -- if their YOE is less than or equal to 10 AND Age is greater than 35
            Console.WriteLine("--------------------------");
            var years = employees.Where(x => x.YearsOfExperience <= 10 && x.Age > 35);
            Console.WriteLine($"For employees that are older than 35 with 10 or more years of experience:");
            Console.WriteLine($"Sum of their years of expereince: {years.Sum(x => x.YearsOfExperience)}");
            Console.WriteLine($"Average of their years of expereince: {years.Average(x => x.YearsOfExperience)}");
            //DONE -- Add an employee to the end of the list without using employees.Add()
            //DONE -- public Employee(string firstName, string lastName, int age, int yearsOfExperience)
            employees = employees.Append(new Employee ("Hayden", "Faw", 30, 7)).ToList();
            Console.WriteLine("--------------------------");
            Console.WriteLine($"List of employees after new hire:");
            foreach (var employee in employees)
            {
                Console.WriteLine($"Employee: {employee.FullName}, age {employee.Age}, and {employee.YearsOfExperience} years of experience");
            }
            Console.WriteLine();

            Console.ReadLine();
        }

        #region CreateEmployeesMethod
        private static List<Employee> CreateEmployees()
        {
            List<Employee> employees = new List<Employee>();
            employees.Add(new Employee("Cruz", "Sanchez", 25, 10));
            employees.Add(new Employee("Steven", "Bustamento", 56, 5));
            employees.Add(new Employee("Micheal", "Doyle", 36, 8));
            employees.Add(new Employee("Daniel", "Walsh", 72, 22));
            employees.Add(new Employee("Jill", "Valentine", 32, 43));
            employees.Add(new Employee("Yusuke", "Urameshi", 14, 1));
            employees.Add(new Employee("Big", "Boss", 23, 14));
            employees.Add(new Employee("Solid", "Snake", 18, 3));
            employees.Add(new Employee("Chris", "Redfield", 44, 7));
            employees.Add(new Employee("Faye", "Valentine", 32, 10));

            return employees;
        }
        #endregion
    }
}
