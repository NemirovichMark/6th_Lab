using System;
using System.Text.RegularExpressions;

namespace LaboratoryL2N1
{
    struct grades
    {
        public string name;
        public double average;
        public grades(double[] grades, string name)
        {
            this.name = name;
            double sum = 0;
            for (int i = 0; i < 4; i++)
            {
                sum += grades[i];
            }
            average = (sum / 4);
        }
    }
    class Program
    {
        static int int_input(string name)
        {
            Console.Write($"{name}: ");
            string input_x = Console.ReadLine();
            if (!int.TryParse(input_x, out var n))
            {
                Console.WriteLine("Invalid input");
                System.Environment.Exit(1);
            }
            if (Regex.IsMatch(name, @"Grade\s[1-4]"))
            {
                if (n < 2 || n > 5)
                {
                    Console.WriteLine("Invalid usage: Grade should be a number in range from 2 to 5");
                    System.Environment.Exit(1);
                }
                
            }
            return n;
        }
        static void sort(grades[] student, int n)
        {
            for (int i = 0; i < n; i++)
            {
                double maxim = student[i].average;
                for (int j = i + 1; j < n; j++)
                {
                    if (student[j].average > maxim)
                    {
                        maxim = student[j].average;
                        grades temp = student[i];
                        student[i] = student[j];
                        student[j] = temp;
                    }
                }
            }
        }
        static void Main(string[] args)
        {
            string number = "Number of students";
            int n = int_input(number);
            grades[] student = new grades[n];
            
            for (int i = 0; i < n; i++)
            {
                double[] grades = new double[4];
                Console.Write($"Name №{i+1}: ");
                string name = Console.ReadLine();
                for (int j = 0; j < 4; j++)
                {
                    grades[j] = int_input($"Grade {j+1}");
                }
                student[i] = new grades(grades, name);
            }
            
            sort(student, n);

            for (int i = 0; i < n; i++)
            {
                if (student[i].average >= 4)
                {
                    Console.WriteLine($"Name: {student[i].name}, Average Grade: {student[i].average}");
                }
            }
        }
    }
}