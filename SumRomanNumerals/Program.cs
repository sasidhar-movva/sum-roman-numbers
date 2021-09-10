using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SumRomanNumerals
{
    public static class Program
    {
        static char[] arrRoman = new char[] { 'I', 'V', 'X', 'L', 'C', 'D', 'M' };
        static void Main(string[] args)
        {
            Console.WriteLine("Enter first Roman numeral");
            string firstRoman = Console.ReadLine().Trim();
            if (ValidateInput(firstRoman))
            {
                Console.WriteLine("Enter second Roman numeral");
                string SecondRoman = Console.ReadLine().Trim();

                if (ValidateInput(SecondRoman))
                {
                    Console.WriteLine("Output: " + intToRoman(romanToInt(firstRoman) + romanToInt(SecondRoman)));
                    Console.ReadLine();
                }
                else
                {
                    Console.WriteLine("Please enter valid Roman numeral");
                    Console.ReadLine();
                }
            }
            else
            {
                Console.WriteLine("Please enter valid Roman numeral");
                Console.ReadLine();
            }
        }
        public static bool ValidateInput(string input)
        {
            for (int i = 0; i < input.Length; i++)
            {
                var result = arrRoman.Contains(input[i]);
                if (!result)
                    return false;
            }
            return true;
        }

        public static int romanToInt(string str)
        {
            int output = 0;
            for (int i = 0; i < str.Length; i++)
            {
                int value1 = romanToValue(str[i]);
                if (i + 1 < str.Length)
                {
                    int value2 = romanToValue(str[i + 1]);
                    if (value1 >= value2)
                    {
                        output = output + value1;
                    }
                    else
                    {
                        output = output + value2 - value1;
                        i++;
                    }
                }
                else
                {
                    output = output + value1;
                }
            }
            return output;
        }

        public static int romanToValue(char r)
        {
            if (r == 'I')
                return 1;
            if (r == 'V')
                return 5;
            if (r == 'X')
                return 10;
            if (r == 'L')
                return 50;
            if (r == 'C')
                return 100;
            if (r == 'D')
                return 500;
            if (r == 'M')
                return 1000;

            return -1;
        }

        public static string intToRoman(int number)
        {
            char[] romanArray = new char[100];
            int i = 0;
            while (number != 0)
            {
                if (number >= 1000)
                {
                    i = numeric('M', number / 1000, i, romanArray);
                    number = number % 1000;
                }

                else if (number >= 500)
                {
                    if (number < 900)
                    {

                        i = numeric('D', number / 500, i, romanArray);
                        number = number % 500;
                    }
                    else
                    {

                        i = nextnumeric('C', 'M', i, romanArray);
                        number = number % 100;
                    }
                }

                else if (number >= 100)
                {
                    if (number < 400)
                    {
                        i = numeric('C', number / 100, i, romanArray);
                        number = number % 100;
                    }

                    else
                    {
                        i = nextnumeric('C', 'D', i, romanArray);
                        number = number % 100;
                    }
                }
                else if (number >= 50)
                {
                    if (number < 90)
                    {
                        i = numeric('L', number / 50, i, romanArray);
                        number = number % 50;
                    }
                    else
                    {
                        i = nextnumeric('X', 'C', i, romanArray);
                        number = number % 10;
                    }
                }
                else if (number >= 10)
                {
                    if (number < 40)
                    {
                        i = numeric('X', number / 10, i, romanArray);
                        number = number % 10;
                    }
                    else
                    {
                        i = nextnumeric('X', 'L', i, romanArray);
                        number = number % 10;
                    }
                }
                else if (number >= 5)
                {
                    if (number < 9)
                    {
                        i = numeric('V', number / 5, i, romanArray);
                        number = number % 5;
                    }
                    else
                    {
                        i = nextnumeric('I', 'X', i, romanArray);
                        number = 0;
                    }
                }
                else if (number >= 1)
                {
                    if (number < 4)
                    {
                        i = numeric('I', number, i, romanArray);
                        number = 0;
                    }
                    else
                    {
                        i = nextnumeric('I', 'V', i, romanArray);
                        number = 0;
                    }
                }
            }
            string result = "";
            for (int j = 0; j < i; j++)
            {
                result += romanArray[j];
            }
            return result;
        }

        private static int nextnumeric(char char1, char char2,
                            int i, char[] romanArray)
        {
            romanArray[i++] = char1;
            romanArray[i++] = char2;
            return i;
        }
        private static int numeric(char char1, int num, int i, char[] romanArray)
        {
            for (int j = 0; j < num; j++)
            {
                romanArray[i++] = char1;
            }
            return i;
        }
    }
}
