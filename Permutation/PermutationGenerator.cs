﻿
using System.Collections.Generic;
using System.Linq;

namespace Permutation
{
    public static class PermutationGenerator
    {
        private static int _factors = 0;

        public static IEnumerable<string> GetUsingOldAlgorithm(string word)
        {
            int wordLength = word.Length;
            char[] inputCharArray = word.ToCharArray();
            string subString;
            string[] subStrings = new string[100 * 100 * 100 * 10];
            int subIndex = 0;
            int first = wordLength - 2;
            int second = first + 1;

            for (int count = 0; count < 2; count++)
            {
                inputCharArray = Swap(first, second, ref inputCharArray);
                subString = new string(inputCharArray).Substring(wordLength - 2, 2);
                subStrings[subIndex] = subString;
                subIndex++;
            }

            for (int prevLetter = wordLength - 3; prevLetter >= 0; prevLetter--)
            {
                string tempLetter = inputCharArray[prevLetter].ToString();
                Factorial(wordLength - (prevLetter + 1));
                int tempIndex = subIndex;

                for (int subs = subIndex - _factors; subs < tempIndex; subs++)
                {
                    subString = tempLetter.Insert(1, subStrings[subs]);
                    subStrings[subIndex] = subString;
                    subIndex++;
                }

                char[] savedArray = new char[subStrings[subIndex - 1].Length];
                char[] tempArray = new char[subStrings[subIndex - 1].Length];
                int anotherTempIndex = subIndex;

                for (int subs = subIndex - _factors; subs < anotherTempIndex; subs++)
                {
                    savedArray = subStrings[subs].ToCharArray();
                    tempArray = subStrings[subs].ToCharArray();
                    string savedString = new string(savedArray);
                    string tempString;

                    for (int swaps = 1; swaps <= tempArray.Length - 1; swaps++)
                    {
                        Swap(0, swaps, ref tempArray);
                        tempString = new string(tempArray);
                        subStrings[subIndex] = tempString;
                        subIndex++;
                        tempArray = savedString.ToCharArray();
                    }
                }
            }

            Factorial(wordLength);
            int startOfFinalStrings = (subStrings.Count(s => s != null) - _factors);
            int finalCount = (subStrings.Count(s => s != null) - startOfFinalStrings);
            string[] outputStrings = new string[finalCount];
            int outputCounter = 0;

            for (int swapOver = startOfFinalStrings; swapOver < subIndex; swapOver++)
            {
                outputStrings[outputCounter] = subStrings[swapOver];
                outputCounter++;
            }

            return outputStrings;
        }

        private static void Factorial(int input)
        {
            if (input == 1 || input == 0)
                _factors = 1;
            else
            {
                Factorial(input - 1);
                _factors = _factors * (input);
            }
        }

        private static char[] Swap(int one, int two, ref char[] charArray)
        {
            char temp = charArray[one];
            charArray[one] = charArray[two];
            charArray[two] = temp;
            return charArray;
        }

        private static bool HasDuplicates(string[] permArray)
        {
            for (int outer = 0; outer <= permArray.Length - 1; outer++)
            {
                for (int inner = outer + 1; inner <= permArray.Length - 1; inner++)
                {
                    if (permArray[outer].Equals(permArray[inner]))
                        return true;
                }
            }
            return false;
        }
    }
}
