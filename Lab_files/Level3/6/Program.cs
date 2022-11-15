using System;

namespace LaboratoryL3N4
{
    class Program
    {
        static string string_input()
        {   
            string name = Console.ReadLine();
            return name;
        }
        static void sort(List<string> questions, List<int> results)
        {
            for (int i = 0; i < questions.Count(); i++)
            {
                int maxim = results[i];
                for (int j = i+1; j < questions.Count(); j++)
                {
                    if (maxim < results[j])
                    {
                        maxim = results[j];
                        string temp = questions[j];
                        results[j] = results[i];
                        questions[j] = questions[i];
                        results[i] = maxim;
                        questions[i] = temp;
                    }
                }
            }
        }
        static void Main(string[] args)
        {
            Dictionary<string, int> question_1 = new Dictionary<string, int>();
            Dictionary<string, int> question_2 = new Dictionary<string, int>(); //Probably I could have done some array of dictionaries
            Dictionary<string, int> question_3 = new Dictionary<string, int>(); //But I'm not that good with dict's so yea, some very bad looking code right here
            int questions = 3;
            int respondents = 5;
            int[] valid_answers = new int[]{0,0,0};
            
            Console.WriteLine($"Question №1");
            for (int j = 0; j < respondents; j++)
            {
                Console.Write($"Respondent №{j+1} answer: ");
                string answer = string_input();
                //I hope i can assume that void answer will not participate in calculating final results
                if (string.IsNullOrEmpty(answer))
                {
                   continue;
                }
                valid_answers[0] += 1;
                if (!question_1.ContainsKey(answer))
                {
                    question_1.Add(answer, 1);
                }
                else
                {
                    question_1[answer] += 1;
                }
            }
            Console.WriteLine($"Question №2");
            for (int j = 0; j < respondents; j++)
            {
                Console.Write($"Respondent №{j+1} answer: ");
                string answer = string_input();
                if (string.IsNullOrEmpty(answer))
                {
                   continue;
                }
                valid_answers[1] += 1;
                if (!question_2.ContainsKey(answer))
                {
                    question_2.Add(answer, 1);
                }
                else
                {
                    question_2[answer] += 1;
                }
            }
            Console.WriteLine($"Question №3");
            for (int j = 0; j < respondents; j++)
            {
                Console.Write($"Respondent №{j+1} answer: ");
                string answer = string_input();
                if (string.IsNullOrEmpty(answer))
                {
                   continue;
                }
                valid_answers[2] += 1;
                if (!question_3.ContainsKey(answer))
                {
                    question_3.Add(answer, 1);
                }
                else
                {
                    question_3[answer] += 1;
                }
            }
            //
            List<string> Final_answers1 = question_1.Keys.ToList();
            List<int> Final_Results1 = question_1.Values.ToList();
            sort(Final_answers1, Final_Results1);

            List<string> Final_answers2 = question_2.Keys.ToList();
            List<int> Final_Results2 = question_2.Values.ToList();
            sort(Final_answers2, Final_Results2);

            List<string> Final_answers3 = question_3.Keys.ToList();
            List<int> Final_Results3 = question_3.Values.ToList();
            sort(Final_answers3, Final_Results3);

            Console.WriteLine("Question 1 most popular answers (Answer, votes)");
            for (int i = 0; i < Final_answers1.Count(); i++)
            {
                Console.WriteLine($"{Final_answers1[i]}, {Final_Results1[i]}");
            }
            Console.WriteLine();

            Console.WriteLine("Question 2 most popular answers (Answer, votes)");
            for (int i = 0; i < Final_answers2.Count(); i++)
            {
                Console.WriteLine($"{Final_answers2[i]}, {Final_Results2[i]}");
            }
            Console.WriteLine();

            Console.WriteLine("Question 3 most popular answers (Answer, votes)");
            for (int i = 0; i < Final_answers3.Count(); i++)
            {
                Console.WriteLine($"{Final_answers3[i]}, {Final_Results3[i]}");
            }
            Console.WriteLine();
        } 
    }
}