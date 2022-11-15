using System;

namespace LaboratoryL3N4
{
    struct participants
    {
        public string name;
        public double time;
        public participants(string name, double time)
        {
            this.name = name;
            this.time = time;
        }
    }
    class Program
    {
        static double time_input(string name)
        {
            Console.Write($"{name} time: ");
            string input_x = Console.ReadLine();
            if (!double.TryParse(input_x, out var n) || (n <= 0))
            {
                Console.WriteLine("Invalid input");
                System.Environment.Exit(1);
            }
            return n;
        }
        static string string_input(int i)
        {   
            Console.Write($"Participant №{i+1} name: ");
            string name = Console.ReadLine();
            if (string.IsNullOrEmpty(name))
            {
                Console.WriteLine("Name could not be nothing");
                System.Environment.Exit(1);
            }
            return name;
        }
        static void sort(participants[] group, int n)
        {
            for (int i = 0; i < n; i++)
            {
                double minim = group[i].time;
                for (int j = i + 1; j < n; j++)
                {
                    if (group[j].time < minim)
                    {
                        minim = group[j].time;
                        participants temp = group[i];
                        group[i] = group[j];
                        group[j] = temp;
                    }
                }
            }
        }
        static void Main(string[] args)
        {
            int number_1 = 3;
            int number_2 = 4;

            Console.WriteLine("Group 1:");
            participants[] group_1 = new participants[number_1+1];
            for (int i = 0; i < number_1; i++)
            {
                string name = string_input(i);
                double time = time_input(name);
                group_1[i] = new participants(name, time);
            }

            Console.WriteLine("-------------------Group 2:");
            participants[] group_2 = new participants[number_2+1];
            for (int i = 0; i < number_2; i++)
            {
                string name = string_input(i);
                double time = time_input(name);
                group_2[i] = new participants(name, time);
            }

            sort(group_1, number_1);
            sort(group_2, number_2);
            
            int k = 0, i2 = 0, j2 = 0;
            Console.WriteLine("Place: name, time");
            while(k != number_1 + number_2)
            {
                if (i2 < number_1 && j2 < number_2)
                {
                    if (group_1[i2].time < group_2[j2].time)
                    {
                        Console.WriteLine($"{k+1}: {group_1[i2].name}, {group_1[i2].time}");
                        k++;
                        i2++;
                    }
                    else
                    {
                        Console.WriteLine($"{k+1}: {group_2[j2].name}, {group_2[j2].time}");
                        j2++;
                        k++;
                    }
                }
                else if (i2 < number_1)
                {
                    Console.WriteLine($"{k+1}: {group_1[i2].name}, {group_1[i2].time}");
                    i2++;
                    k++;
                }
                else
                {
                    Console.WriteLine($"{k+1}: {group_2[j2].name}, {group_2[j2].time}");
                    j2++;
                    k++;
                }
            }
        }
    }
}