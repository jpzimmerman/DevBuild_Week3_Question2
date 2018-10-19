using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DevBuild.Utilities;

namespace DevBuild.Assessment2_Question2
{
    class Program
    {
        static uint maxRangeOfOddNumbers = 0;
        static string userResponse = "";

        static void Main(string[] args)
        {
            List<double> oddNumbers = new List<double>();

            while (true)
            {
                userResponse = "";
                oddNumbers.Clear();
                while (!uint.TryParse(userResponse, out maxRangeOfOddNumbers) || maxRangeOfOddNumbers < 1)
                {
                    UserInput.PromptUntilValidEntry("Please enter a number greater than zero: ", ref userResponse, InformationType.Numeric);
                }

                for (double i = 0; i <= maxRangeOfOddNumbers; i++)
                {
                    if (i % 2 == 1)
                    {
                        oddNumbers.Add(i);
                    }
                }
                Console.WriteLine($"The sum of all the odd numbers between 1 and {maxRangeOfOddNumbers} is {CalculateSum(oddNumbers)}");
                Console.WriteLine($"The average of all the odd numbers between 1 and {maxRangeOfOddNumbers} is {CalculateAverage(oddNumbers)}");

                maxRangeOfOddNumbers = 0;

                YesNoAnswer yesNoAnswer = UserInput.GetYesOrNoAnswer("Would you like to enter another maximum?");
                switch (yesNoAnswer)
                {
                    case YesNoAnswer.Yes: continue;
                    case YesNoAnswer.No: return;
                }
            }
        }

        static double CalculateSum(ICollection<double> numbers)
        {
            int sumOfNumbers = 0;

            foreach (int i in numbers)
            {
                sumOfNumbers += i;
            }
            return sumOfNumbers;
        }

        static double CalculateAverage(ICollection<double> numbers)
        {
            return CalculateSum(numbers) / numbers.Count;
        }

    }
}
