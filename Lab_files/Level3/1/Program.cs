using System;
using System.Text.RegularExpressions;

namespace LaboratoryL3N1
{
    struct group_average
    {
        public string group;
        public double average;
        public group_average(double[] students_group, int students, string name)
        {
            group = name;
            double sum = 0;
            for (int i = 0; i < students; i++)
            {
                sum += students_group[i];
            }
            average = (sum / students);
        }
    }
    class Program
    {
        static int int_input(string name, int exams)
        {
            Console.Write($"{name}: ");
            string input_x = Console.ReadLine();
            if (!int.TryParse(input_x, out var n))
            {
                Console.WriteLine("Invalid input");
                System.Environment.Exit(1);
            }
            if (Regex.IsMatch(name, $@"Exam\s№[1-{exams}]"))
            {
                if (n < 2 || n > 5)
                {
                    Console.WriteLine("Invalid usage: Grade should be a number in range from 2 to 5");
                    System.Environment.Exit(1);
                }
            }
            return n;
        }
        static double ExamOfTheStudent(int ExamsNumber, int student)
        {
            double ans = 0;
            Console.WriteLine($"Student {student}");
            for (int i = 0; i < ExamsNumber; i++)
            {
                ans += int_input($"Exam №{i+1}", ExamsNumber);
            }
            return (ans / ExamsNumber);
        }
        static void sort(group_average[] group, int n)
        {
            for (int i = 0; i < n; i++)
            {
                double maxim = group[i].average;
                for (int j = i + 1; j < n; j++)
                {
                    if (group[j].average > maxim)
                    {
                        maxim = group[j].average;
                        group_average temp = group[i];
                        group[i] = group[j];
                        group[j] = temp;
                    }
                }
            }
        }
        static void Main(string[] args)
        {
            int ExamsNumber = 5;
            int GroupsNumber = 3;
            int StudentsInEachGroup = 4;
            group_average[] group = new group_average[GroupsNumber];
            
            for (int i = 0; i < GroupsNumber; i++)
            {
                double[] grades = new double[StudentsInEachGroup];
                string name = $"Group {i+1}";
                Console.WriteLine(name);
                for (int j = 0; j < StudentsInEachGroup; j++)
                {
                    grades[j] = ExamOfTheStudent(ExamsNumber, j+1);
                }
                group[i] = new group_average(grades, StudentsInEachGroup, name);
            }
            
            sort(group, GroupsNumber);
            
            Console.WriteLine("Group name, Group average");
            for (int i = 0; i < GroupsNumber; i++)
            {
                Console.WriteLine($"{group[i].group}, {group[i].average}");
            }
        }
    }
}