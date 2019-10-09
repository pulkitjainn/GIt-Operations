using System;

namespace Assignment_1
{
    class Program
    {
        static void Main(string[] args)
        {
            QuestionOneWrapperFunction(); // Function that takes the size input and intialize the object of the class
        }
        static void QuestionOneWrapperFunction()
        {
            Console.Write("Enter the value of N : ");
            int n;
            try
            {
                n = int.Parse(Console.ReadLine());
            }
            catch (Exception)
            {
                Console.WriteLine("Invalid Entry");
                Console.ReadLine();
                return;
            }
            if (n < 1)
            {
                Console.WriteLine("Invalid Entry");
                Console.ReadLine();
                return;
            }
            QuestionOne questionOne = new QuestionOne(n); //Object declearation and initialization
            questionOne.FillArray(); //Function fills the array with A and P randomly
            questionOne.PrintArray(); //Function print the array 
            int countOfPlusCross = questionOne.CountPlusCross(); // Function counts plus and cross made by A and prints all the cells that are forming them
            Console.WriteLine("Total count of Plus and Cross is : " + countOfPlusCross);
            Console.ReadKey();
        }
    }


    class QuestionOne
    {
        String[,] arr;
        static int rowColumnLength;

        public QuestionOne(int n)
        {
            arr = new String[n, n];
            rowColumnLength = n;
        }
        
        public void FillArray()
        {
            Random random = new Random();
            for (int i = 0; i < rowColumnLength; ++i)
            {
                for (int j = 0; j < rowColumnLength; ++j)
                {
                    int num = random.Next(2);
                    arr[i, j] = num == 1 ? "A" : "P";
                }
            }
        }

        public void PrintArray()
        {
            for (int i = 0; i < rowColumnLength; i++)
            {
                for (int j = 0; j < rowColumnLength; j++)
                {
                    Console.Write("{0} ({1})  ", arr[i, j], i * rowColumnLength + j + 1);
                }
                Console.WriteLine();
            }
            Console.WriteLine();
        }

        public int CountPlusCross()
        {
            int cross = 0, plus = 0, totalCount = 0;
            for (int i = 1; i < rowColumnLength - 1; i++)
            {
                for (int j = 1; j < rowColumnLength - 1; j++)
                {
                    if (arr[i, j - 1] == "A" && arr[i - 1, j] == "A" && arr[i, j] == "A"
                        && arr[i + 1, j] == "A" && arr[i, j + 1] == "A")
                    {
                        plus += 1;
                        Console.WriteLine("PLUS Cell numbers : {0} {1} {2} {3} {4}", (i * rowColumnLength) + j, ((i - 1) * rowColumnLength) + j + 1, (i * rowColumnLength) + j + 1, ((i + 1) * rowColumnLength) + j + 1, (i * rowColumnLength) + j + 2);
                    }

                    if (arr[i - 1, j - 1] == "A" && arr[i + 1, j - 1] == "A" && arr[i, j] == "A"
                        && arr[i - 1, j + 1] == "A" && arr[i + 1, j + 1] == "A")
                    {
                        cross += 1;
                        Console.WriteLine("CROSS Cell numbers : {0} {1} {2} {3} {4}", ((i - 1) * rowColumnLength) + j, ((i + 1) * rowColumnLength) + j, (i * rowColumnLength) + j + 1, ((i - 1) * rowColumnLength) + j + 2, ((i + 1) * rowColumnLength) + j + 2);
                    }
                }
            }
            totalCount = plus + cross;
            Console.WriteLine("Plus Count : " + plus);
            Console.WriteLine("Cross Count : " + cross);
            return totalCount;
        }
    }
}
