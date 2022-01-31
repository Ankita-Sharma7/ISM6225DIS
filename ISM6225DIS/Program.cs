
//YOU ARE NOT ALLOWED TO MODIFY ANY FUNCTION DEFINATION's PROVIDED.
//WRITE YOUR CODE IN THE RESPECTIVE FUNCTION BLOCK

using System;
using System.Collections.Generic;
using System.Text.RegularExpressions;

namespace DIS_Assignmnet1_SPRING_2022
{
    class Program
    {
        static void Main(string[] args)
        {
            //Question 1
            Console.WriteLine("Q1: Enter the string:");
            string s = Console.ReadLine();
            string final_string = RemoveVowels(s);
            Console.WriteLine("Final string after removing the Vowels: {0}", final_string);
            Console.WriteLine();

            //Question 2:
            string[] bulls_string1 = new string[] { "Marshall", "Student", "Center" };
            string[] bulls_string2 = new string[] { "MarshallStudent", "Center" };
            bool flag = ArrayStringsAreEqual(bulls_string1, bulls_string2);
            Console.WriteLine("Q2");
            if (flag)
            {
                Console.WriteLine("Yes, Both the array’s represent the same string");
            }
            else
            {
                Console.WriteLine("No, Both the array’s don’t represent the same string ");
            }
            Console.WriteLine();

            //Question 3:
            int[] bull_bucks = new int[] { 1, 2, 3, 2 };
            int unique_sum = SumOfUnique(bull_bucks);
            Console.WriteLine("Q3:");
            Console.WriteLine("Sum of Unique Elements in the array are :{0}", unique_sum);
            Console.WriteLine();


            //Question 4:
            int[,] bulls_grid = new int[,] { { 1, 2, 3 }, { 4, 5, 6 }, { 7, 8, 9 } };
            Console.WriteLine("Q4:");
            int diagSum = DiagonalSum(bulls_grid);
            Console.WriteLine("The sum of diagonal elements in the bulls grid is {0}:", diagSum);
            Console.WriteLine();

            //Question 5:
            Console.WriteLine("Q5:");
            String bulls_string = "aiohn";
            int[] indices = { 3, 1, 4, 2, 0 };
            String rotated_string = RestoreString(bulls_string, indices);
            Console.WriteLine("The  Final string after rotation is {0} ", rotated_string);
            Console.WriteLine();

            //Quesiton 6:
            string bulls_string6 = "mumacollegeofbusiness";
            char ch = 'c';
            string reversed_string = ReversePrefix(bulls_string6, ch);
            Console.WriteLine("Q6:");
            Console.WriteLine("Resultant string are reversing the prefix:{0}", reversed_string);
            Console.WriteLine();

        }

        /* 
        <summary>
        Given a string s, remove the vowels 'a', 'e', 'i', 'o', and 'u' from it, and return the new string.

        Example 1:
        Input: s = "MumaCollegeofBusiness"
        Output: "MmCllgfBsnss"

        Example 2:
        Input: s = "aeiou"
        Output: ""

        Constraints:
        •	0 <= s.length <= 10000
        s consists of uppercase and lowercase letters
        </summary>
        */
        /**
         * This method takes a string as an input and looks vowels in the string and return string by removing all the vowels
         * 
         * 
         * */
        private static string RemoveVowels(string s)
        {
            {
                String outputstring = "";  //output string
                Char[] vowels = new Char[5] { 'A', 'E', 'I', 'O', 'U' }; //defining array of vowels
                int vowelflag; //define flag to capture vowel is present or not

                try
                {
                    // write your code here
                    // Iterating over the string letters and The flag validates if the letter is vowel or not, if it is vowel is present flag is set to 1 else 0, for vowelflag=0 the letter is returned
                    for (int i = 0; i < s.Length; i++)
                    {
                        vowelflag = 0;
                        //coverting the String to upper case
                        char stringletters = char.ToUpper(s[i]);
                        // comparing each letter of string with vowels array
                        for (int j = 0; j < vowels.Length; j++)
                        {
                            if (stringletters == vowels[j])
                            {
                                //if stringletter is a vowel vowelflag is set to 1
                                vowelflag = 1;
                            }
                        }

                        if (vowelflag == 0)
                        {
                            //If stringletter is not a vowel vowelflag is set to 0, If not a vowel the letter is returned
                            outputstring += stringletters;
                        }
                    }
                }
                catch (Exception e)
                {
                    Console.WriteLine(e.ToString());
                }

                return outputstring;  //output string
            }

        }

        /* 
        <summary>
       Given two string arrays word1 and word2, return true if the two arrays represent the same string, and false otherwise.
       A string is represented by an array if the array elements concatenated in order forms the string.
       Example 1:
       Input: : bulls_string1 = ["Marshall", "Student",”Center”], : bulls_string2 = ["MarshallStudent ", "Center"]
       Output: true
       Explanation:
       word1 represents string "marshall" + "student" + “center” -> "MarshallStudentCenter "
       word2 represents string "MarshallStudent" + "Center" -> "MarshallStudentCenter"
       The strings are the same, so return true.
       Example 2:
       Input: word1 = ["Zimmerman", "School", ”of Advertising”, ”and Mass Communications”], word2 = ["Muma", “College”,"of”, “Business"]
       Output: false

       Example 3:
       Input: word1  = ["University", "of", "SouthFlorida"], word2 = ["UniversityofSouthFlorida"]
       Output: true
       </summary>
       */

        private static bool ArrayStringsAreEqual(string[] bulls_string1, string[] bulls_string2)
        {

            bool sflag = false;
            string string1 = "";    //taking two input strings
            string string2 = "";

            try
            {
                // write your code here.
                //Combining all the array element as a string 
                string1 = String.Join("", bulls_string1).ToUpper();
                string2 = String.Join("", bulls_string2).ToUpper();

                Console.WriteLine(string1 + " : " + string2);
                //comparing both the string
                if (string1 == string2)
                {
                    sflag = true;                             //if the string matches then flag is set true else false
                }

                return sflag;
            }
            catch (Exception)
            {

                throw;
            }

        }
        /*
        <summary> 
       You are given an integer array bull_bucks. The unique elements of an array are the elements that appear exactly once in the array.
       Return the sum of all the unique elements of nums.
       Example 1:
       Input: bull_bucks = [1,2,3,2]
       Output: 4
       Explanation: The unique elements are [1,3], and the sum is 4.
       Example 2:
       Input: bull_bucks = [1,1,1,1,1]
       Output: 0
       Explanation: There are no unique elements, and the sum is 0.
       Example 3:
       Input: bull_bucks = [1,2,3,4,5]
       Output: 15
       Explanation: The unique elements are [1,2,3,4,5], and the sum is 15.
       </summary>
        */
        private static int SumOfUnique(int[] bull_bucks)

        {
            //checks if bull_bucks array is either null or has array element 0
            if (bull_bucks == null || bull_bucks.Length == 0)
                return 0;

            Dictionary<int, int> dict = new Dictionary<int, int>();   //defining a dictionary
            foreach (int number in bull_bucks)
            {
                if (dict.ContainsKey(number))
                    dict[number]++;
                else
                    dict.Add(number, 1);
            }

            //sum is initialized to 0
            int sum = 0;
            foreach (var k in dict)
            {
                //if number is unique with no multiple occurance its get added to the sum
                if (k.Value == 1)
                    sum += k.Key;
            }

            return sum;
        }


        /*

        <summary>
       Given a square matrix bulls_grid, return the sum of the matrix diagonals.
       Only include the sum of all the elements on the primary diagonal and all the elements on the secondary diagonal that are not part of the primary diagonal.

       Example 1:
       Input: bulls_grid = [[1,2,3],[4,5,6], [7,8,9]]
       Output: 25
       Explanation: Diagonals sum: 1 + 5 + 9 + 3 + 7 = 25
       Notice that element mat[1][1] = 5 is counted only once.
       Example 2:
       Input: bulls_grid = [[1,1,1,1], [1,1,1,1],[1,1,1,1], [1,1,1,1]]
       Output: 8
       Example 3:
       Input: bulls_grid = [[5]]
       Output: 5
       </summary>

        */

        private static int DiagonalSum(int[,] bulls_grid)
        {
            int sum = 0, common;
            try
            {
                // write your code here.
                //calculating the matrix length
                int length = Convert.ToInt32(Math.Sqrt(bulls_grid.Length));

                for (int i = 0; i < length; i++)
                {
                    //Calculating the first diagonal sum
                    sum = sum + bulls_grid[i, i];
                }

                for (int i = length - 1; i >= 0; i--)
                {
                    //Calculating the second diagonal sum
                    sum = sum + bulls_grid[Math.Abs(length - (i + 1)), i];
                }
                if (((length) % 2 != 0) && (length > 1))
                {
                    //Calculating the subtraction of the element repeating in the second diagonal.
                    common = (length - 1) / 2;
                    sum = sum - bulls_grid[common, common];
                }

                return sum;
            }
            catch (Exception e)
            {

                Console.WriteLine("Error Occured: " + e.Message);
                throw;
            }
        }



        /*

        <summary>
        Given a string bulls_string  and an integer array indices of the same length.
        The string bulls_string  will be shuffled such that the character at the ith position moves to indices[i] in the shuffled string.
        Return the shuffled string.

        Example 3:
        Input: bulls_string  = "aiohn", indices = [3,1,4,2,0]
        Output: "nihao"

        */

        private static string RestoreString(string bulls_string, int[] indices)
        {
            try
            {
                int str_length = bulls_string.Length;
                int ind_length = indices.Length;

                //Validating all the constraints defined in question
                if (str_length == ind_length && str_length >= 1 && str_length <= 100)
                {
                    //defining a regular expression to check that a string contained only lowercase characters
                    var regex_p = new Regex("^[a-z]+$");
                    if (regex_p.IsMatch(bulls_string) == true)
                    {
                        //suffling the characters in the bull_string based on the indices given 
                        string[] output = new string[str_length];
                        for (int i = 0; i < str_length; i++)
                        {
                            int value = indices[i];
                            if (value >= 0 && value < ind_length)
                            {
                                output[value] = char.ToString(bulls_string[i]);
                            }
                            else
                            {
                                return null;
                            }
                        }
                        //returning the suffled string
                        string st = string.Join("", output);
                        return st;
                    }
                    else
                    {
                        return null;
                    }
                }
                else
                {
                    return null;
                }
            }
            catch (Exception e)
            {
                Console.WriteLine(e.Message);
                throw;
            }

        }

        /*
         <summary>
        Given a 0-indexed string bulls_string   and a character ch, reverse the segment of word that starts at index 0 and ends at the index of the first occurrence of ch (inclusive). If the character ch does not exist in word, do nothing.
        For example, if word = "abcdefd" and ch = "d", then you should reverse the segment that starts at 0 and ends at 3 (inclusive). The resulting string will be "dcbaefd".
        Return the resulting string.

        Example 1:
        Input: bulls_string   = "mumacollegeofbusiness", ch = "c"
        Output: "camumollegeofbusiness"
        Explanation: The first occurrence of "c" is at index 4. 
        Reverse the part of word from 0 to 4 (inclusive), the resulting string is "camumollegeofbusiness".

        Example 2:
        Input: bulls_string   = "xyxzxe", ch = "z"
        Output: "zxyxxe"
        Explanation: The first and only occurrence of "z" is at index 3.
        Reverse the part of word from 0 to 3 (inclusive), the resulting string is "zxyxxe".

        Example 3:
        Input: bulls_string   = "zimmermanschoolofadvertising", ch = "x"
        Output: "zimmermanschoolofadvertising"
        Explanation: "x" does not exist in word.
        You should not do any reverse operation, the resulting string is "zimmermanschoolofadvertising".
        */

        private static string ReversePrefix(string bulls_string6, char ch)
        {
            try
            {
                String string_prefix = "";
                int index = bulls_string6.IndexOf(ch);
                //defining a regular expression to check that a string contained only lowercase characters
                var regex_p = new Regex("^[a-z]+$");
                //Validating all the constraints defined in question
                if (bulls_string6.Length >= 1 && bulls_string6.Length <= 250 && regex_p.IsMatch(char.ToString(ch)) == true)

                {
                    //reversing the string from the given character ch followed by left over characters
                    if (index >= 0)
                    {

                        string[] st = new string[bulls_string6.Length];
                        int j = 0;
                        for (int i = index; i >= 0; i--)
                        {
                            st[j] = char.ToString(bulls_string6[i]);
                            j++;
                        }
                        st[j] = bulls_string6.Substring(j, bulls_string6.Length - j);
                        string opposite = string.Join("", st);
                        return opposite;
                    }
                    else
                    {
                        return bulls_string6;
                    }
                }
                else
                {
                    return string_prefix;
                }

            }
            catch (Exception)
            {

                throw;

            }
        }
    }
}

//I spent around 10-12 hours to complete this assignment.
//During this assignment I leant how to implement logic, how can I optimized my code and also this helped me knowing how to code on platforms like leetcode, HakerRank.
//I believe this is great way to improve your coding skills and preparing for coding assesment for job applications and this will help my in tacking any future coding assesment. 

