using System;

namespace AdventOfCode2021_Day1._1
{
    class Program
    {
        static void Main(string[] args)
        { 
            depthIncreases(populateArrayFromFile(@"I:\Applied Computing HND\Software Development\AdventOfCode2021\AdventOfCode2021-Day1.1\AdventOfCode2021-Day1.1\input.txt"));
            slidingWindowIncreases(populateArrayFromFile(@"I:\Applied Computing HND\Software Development\AdventOfCode2021\AdventOfCode2021-Day1.1\AdventOfCode2021-Day1.1\input.txt"), 3);
        }

        //Based off sliding window technique, avoids repeating calculations by adjusting terminal elements appropriately.
        static int slidingWindowIncreases(int[] inputs, int windowSize)
        {
            //currentSum is the initial window, elements 0 through an zero-inclusive window adjustment.
            int currentSum = sumSeries(inputs, 0, windowSize - 1);
            int previousSum = currentSum;

            //Window increase count.
            int depthIncreases = 0;
            
            for (int i = 1; i <= inputs.Length - windowSize; i++)
            { 
                currentSum -= inputs[i - 1];
                currentSum += inputs[i + windowSize - 1];
                if (currentSum > previousSum)
                {
                    depthIncreases++;
                }
                previousSum = currentSum;
            }
            
            Console.WriteLine("Windowed depth increases : " + depthIncreases);
            return depthIncreases;
        }


        static int sumSeries(int[] series, int start, int end)
        {
            int sumOfSeries = 0;

            for (int i = start; i < end; i++)
            {
                sumOfSeries += series[i];
            }

            return sumOfSeries; 
        }

        //Check each depth value against the previous value. If the depth increases, increment the count and output total increments.
        static int depthIncreases(int[] arrayOfInputs)
        {
            int increments = 0;
            for (int i = 1; i < arrayOfInputs.Length; i++)
            {
                if(arrayOfInputs[i] > arrayOfInputs[i-1])
                {
                    increments++;
                }

            }
            Console.WriteLine("Positive changes in depth: " + increments);
            return increments;
        }

        //Get all inputs from input file, parse each as an integer to be placed in returning array.
        static int[] populateArrayFromFile(String filePath)
        {
            //output inputs to Console
            string text = System.IO.File.ReadAllText(filePath);
            System.Console.Write(text);
            String[] arrayOfInputs = System.IO.File.ReadAllLines(filePath);
            int[] arrayOfInputsInt = new int[arrayOfInputs.Length];

            for (int i = 0; i < arrayOfInputs.Length; i++)
            {
                arrayOfInputsInt[i] = int.Parse(arrayOfInputs[i]);
            }

            return arrayOfInputsInt;
        }

    }
}
