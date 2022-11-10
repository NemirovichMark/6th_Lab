using System;
using System.Text.RegularExpressions;

namespace LaboratoryL2N2
{
    struct grades
    {
        public string name;
        public double average;
        public grades(double[] grades, string name)
        {
            this.name = name;
            double sum = 0;
            for (int i = 0; i < 3; i++)
            {
                sum += grades[i];
            }
            average = (sum / 3);
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
            if (Regex.IsMatch(name, @"Exam\s[1-3]"))
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
            int success = 0;
            
            for (int i = 0; i < n; i++)
            {
                double[] grades = new double[3];
                Console.Write($"Name №{i+1}: ");
                string name = Console.ReadLine();
                
                double[] temp = new double[3];
                bool flag = true;

                for (int j = 0; j < 3; j++)
                {
                    temp[j] = int_input($"Exam {j+1}");
                    if (temp[j] == 2)
                    {
                        Console.WriteLine("Student failed");
                        flag = false;
                        break;
                    }
                }

                if (flag == true)
                {
                    for (int j = 0; j < 3; j++)
                    {
                        grades[j] = temp[j];
                    }
                    student[success] = new grades(grades, name);
                    success++;
                }
            }
            
            sort(student, success);

            for (int i = 0; i < success; i++)
            {
                Console.WriteLine($"Name: {student[i].name}, Average Grade: {student[i].average}");
            }
        }
    }
}