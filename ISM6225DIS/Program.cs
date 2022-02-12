/* 
 
YOU ARE NOT ALLOWED TO MODIFY ANY FUNCTION DEFINATION's PROVIDED.
WRITE YOUR CODE IN THE RESPECTIVE QUESTION FUNCTION BLOCK
*/

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text.RegularExpressions;

namespace ISM6225_Assignment_2_Spring_2022
{
    class Program
    {
        static void Main(string[] args)
        {

            //Question 1:
            Console.WriteLine("Question 1:");
            int[] nums1 = { 0, 1, 2, 3, 12 };
            Console.WriteLine("Enter the target number:");
            int target = Int32.Parse(Console.ReadLine());
            int pos = SearchInsert(nums1, target);
            Console.WriteLine("Insert Position of the target is : {0}", pos);
            Console.WriteLine("");

            //Question2:
            Console.WriteLine("Question 2");
            string paragraph = "Bob hit a ball, the hit BALL flew far after it was hit.";
            string[] banned = { "hit" };
            string commonWord = MostCommonWord(paragraph, banned);
            Console.WriteLine("Most frequent word is :{0}", commonWord);
            Console.WriteLine();

            //Question 3:
            Console.WriteLine("Question 3");
            int[] arr1 = { 2, 2, 3, 4 };
            int lucky_number = FindLucky(arr1);
            Console.WriteLine("The Lucky number in the given array is {0}", lucky_number);
            Console.WriteLine();

            //Question 4:
            Console.WriteLine("Question 4");
            string secret = "1807";
            string guess = "7810";
            string hint = GetHint(secret, guess);
            Console.WriteLine("Hint for the guess is :{0}", hint);
            Console.WriteLine();


            //Question 5:
            Console.WriteLine("Question 5");
            string s = "ababcbacadefegdehijhklij";
            List<int> part = PartitionLabels(s);
            Console.WriteLine("Partation lengths are:");
            for (int i = 0; i < part.Count; i++)
            {
                Console.Write(part[i] + "\t");
            }
            Console.WriteLine();

            //Question 6:
            Console.WriteLine("Question 6");
            int[] widths = new int[] { 10, 10, 10, 10, 10, 10, 10, 10, 10, 10, 10, 10, 10, 10, 10, 10, 10, 10, 10, 10, 10, 10, 10, 10, 10, 10 };
            string bulls_string9 = "abcdefghijklmnopqrstuvwxyz";
            List<int> lines = NumberOfLines(widths, bulls_string9);
            Console.WriteLine("Lines Required to print:");
            for (int i = 0; i < lines.Count; i++)
            {
                Console.Write(lines[i] + "\t");
            }
            Console.WriteLine();
            Console.WriteLine();

            //Question 7:
            Console.WriteLine("Question 7:");
            string bulls_string10 = "()[]{}";
            bool isvalid = IsValid(bulls_string10);
            if (isvalid)
                Console.WriteLine("Valid String");
            else
                Console.WriteLine("String is not Valid");

            Console.WriteLine();
            Console.WriteLine();


            //Question 8:
            Console.WriteLine("Question 8");
            string[] bulls_string13 = { "gin", "zen", "gig", "msg" };
            int diffwords = UniqueMorseRepresentations(bulls_string13);
            Console.WriteLine("Number of with unique code are: {0}", diffwords);
            Console.WriteLine();
            Console.WriteLine();

            //Question 9:
            //Console.WriteLine("Question 9");
            //int[,] grid = { { 0, 1, 2, 3, 4 }, { 24, 23, 22, 21, 5 }, { 12, 13, 14, 15, 16 }, { 11, 17, 18, 19, 20 }, { 10, 9, 8, 7, 6 } };
            //int time = SwimInWater(grid);
            //Console.WriteLine("Minimum time required is: {0}", time);
            //Console.WriteLine();

            //Question 10:
            Console.WriteLine("Question 10");
            string word1 = "horse";
            string word2 = "ros";
            int minLen = MinDistance(word1, word2);
            Console.WriteLine("Minimum number of operations required are {0}", minLen);
            Console.WriteLine();
        }


        /*
        
        Question 1:
        Given a sorted array of distinct integers and a target value, return the index if the target is found. If not, return the index where it would be if it were inserted in order.
        Note: The algorithm should have run time complexity of O (log n).
        Hint: Use binary search
        Example 1:
        Input: nums = [1,3,5,6], target = 5
        Output: 2
        Example 2:
        Input: nums = [1,3,5,6], target = 2
        Output: 1
        Example 3:
        Input: nums = [1,3,5,6], target = 7
        Output: 4
        */

        public static int SearchInsert(int[] nums, int target)
        {
            try
            {
                //Write your Code here.
                Array.Sort(nums);//sorting the array
                int min_index = 0, max_index = nums.Length - 1;
                while (min_index <= max_index)
                {
                    //calculating the index value of middle number from the sorted array
                    int mid_index = (min_index + max_index) / 2;
                    //returning middle index if target is found in middle index
                    if (target == nums[mid_index])
                    {
                        return mid_index;
                    }
                    //reducing the maximum index to mid_index - 1 if target is in left partition of array
                    else if (target < nums[mid_index])
                    {
                        max_index = mid_index - 1;
                    }
                    //update the minimum index to mid_index+1 if target is in right partition of array
                    else if (target > nums[mid_index])
                    {
                        min_index = mid_index + 1;
                    }
                }
                return min_index;
            }
            catch (Exception)
            {
                throw;
            }
        }

        /*
         
        Question 2
       
        Given a string paragraph and a string array of the banned words banned, return the most frequent word that is not banned. It is guaranteed there is at least one word that is not banned, and that the answer is unique.
        The words in paragraph are case-insensitive and the answer should be returned in lowercase.
        Example 1:
        Input: paragraph = "Bob hit a ball, the hit BALL flew far after it was hit.", banned = ["hit"]
        Output: "ball"
        Explanation: "hit" occurs 3 times, but it is a banned word. "ball" occurs twice (and no other word does), so it is the most frequent non-banned word in the paragraph. 
        Note that words in the paragraph are not case sensitive, that punctuation is ignored (even if adjacent to words, such as "ball,"), and that "hit" isn't the answer even though it occurs more because it is banned.
        Example 2:
        Input: paragraph = "a.", banned = []
        Output: "a"
        */

        public static string MostCommonWord(string paragraph, string[] banned)
        {
            char[] chars_delimiter = { ' ', '!', '?', '\'', ',', ';', '.' };
            IDictionary<string, int> Count_Words;   
            HashSet<string> Banned_words;
            try
            {
                string[] para_words = paragraph.Split(chars_delimiter);

                Banned_words = new HashSet<string>();
                foreach (var Words_banned in banned)
                {
                    Banned_words.Add(Words_banned.ToLower()); //converting the banned words to lower case
                }


                Count_Words = new Dictionary<string, int>();
                //for all the words in para_words, coverting to lower case and checking if word is a banned words or not. If not keeping a count of it

                foreach (var wd in para_words)
                {
                    string word = wd.ToLower();
                    if (Banned_words.Contains(word) || word.Length < 1) continue;
                    if (!Count_Words.TryAdd(word, 1))
                    {
                        Count_Words[word]++;
                    }
                }

                var wordList = Count_Words.ToList();
                wordList.Sort((a, b) => b.Value.CompareTo(a.Value));  // Sort the word list in Descending order

                return wordList.First().Key;  //Returning the word with highest count.

            }
            catch (Exception)
            {

                throw;
            }
        }

        /*
        Question 3:
        Given an array of integers arr, a lucky integer is an integer that has a frequency in the array equal to its value.
        Return the largest lucky integer in the array. If there is no lucky integer return -1.
 
        Example 1:
        Input: arr = [2,2,3,4]
        Output: 2
        Explanation: The only lucky number in the array is 2 because frequency[2] == 2.
        Example 2:
        Input: arr = [1,2,2,3,3,3]
        Output: 3
        Explanation: 1, 2 and 3 are all lucky numbers, return the largest of them.
        Example 3:
        Input: arr = [2,2,2,3,3]
        Output: -1
        Explanation: There are no lucky numbers in the array.
         */

        public static int FindLucky(int[] arr)
        {
            try
            {
                //write your code here.
                Dictionary<int, int> dict = new Dictionary<int, int>();
                int[] keys = new int[arr.Length];
                //Computing the count of each number in array
                for (int k = 0; k < arr.Length; k++)
                {
                    if (!dict.ContainsKey(arr[k])) dict.Add(arr[k], 1);
                    else dict[arr[k]] = dict[arr[k]] + 1;
                }
                int max = -1;
                var maxl = -1;
                // checking if key is equal to value if true then returns the lucky number
                foreach (var x in dict)
                {
                    if (x.Key == x.Value)
                    {
                        if (x.Value > max | x.Value == max & x.Key > maxl)
                        {
                            max = x.Value;
                            maxl = x.Key;
                        }
                        else continue;
                    }
                }
                return maxl;
            }
            catch (Exception)
            {

                throw;
            }

        }

        /*
        
        Question 4:
        You are playing the Bulls and Cows game with your friend.
        You write down a secret number and ask your friend to guess what the number is. When your friend makes a guess, you provide a hint with the following info:
        •	The number of "bulls", which are digits in the guess that are in the correct position.
        •	The number of "cows", which are digits in the guess that are in your secret number but are located in the wrong position. Specifically, the non-bull digits in the guess that could be rearranged such that they become bulls.
        Given the secret number secret and your friend's guess guess, return the hint for your friend's guess.
        The hint should be formatted as "xAyB", where x is the number of bulls and y is the number of cows. Note that both secret and guess may contain duplicate digits.
 
        Example 1:
        Input: secret = "1807", guess = "7810"
        Output: "1A3B"
        Explanation: Bulls relate to a '|' and cows are underlined:
        "1807"
          |
        "7810"
        */

        public static string GetHint(string secret, string guess)
        {
            try
            {
                //write your code here.
                char[] sec_char = secret.ToCharArray();
                char[] gus_char = guess.ToCharArray();
                //initializing A and B to zero
                int A = 0;
                int B = 0;
                var secret_isNumeric = int.TryParse(secret, out _);
                var guess_isNumeric = int.TryParse(guess, out _);
                if (sec_char.Length >= 1 && sec_char.Length <= 1000 && gus_char.Length >= 1 && gus_char.Length <= 1000  //verifying the constraints
                    && sec_char.Length == gus_char.Length
                    && secret_isNumeric && guess_isNumeric)
                {
                    //Comparing Guess Characters with Secret characters and keeping count of matched character in A and unmatched character in B 

                    for (int i = 0; i < sec_char.Length; i++)
                    {
                        
                        if (sec_char[i] == gus_char[i])
                        {
                            A += 1;
                        }
                        else
                        {
                            B += 1;
                        }
                    }
                    //returing the output in "xAyB" format by concatinating the count of mactched and unmatched charcters b/w secret and guess number and the Alphabets A nad B
                    string output = String.Concat(A, 'A', B, 'B');
                    return output;
                }
                return "";
            }
            catch (Exception)
            {

                throw;
            }
        }


        /*
        Question 5:
        You are given a string s. We want to partition the string into as many parts as possible so that each letter appears in at most one part.
        Return a list of integers representing the size of these parts.
        Example 1:
        Input: s = "ababcbacadefegdehijhklij"
        Output: [9,7,8]
        Explanation:
        The partition is "ababcbaca", "defegde", "hijhklij".
        This is a partition so that each letter appears in at most one part.
        A partition like "ababcbacadefegde", "hijhklij" is incorrect, because it splits s into less parts.
        */

        public static List<int> PartitionLabels(string s)
        {
            try
            {
                //write your code here
                int[] char_last_Index = new int[26];
                //Checking every characters last index
                for (int k = 0; k < s.Length; k++)
                {
                    char_last_Index[s[k] - 'a'] = k;
                }

                List<int> output = new List<int>();
                int move = 0;
                int last_currentIndex = 0;
                //checking if the character is spilling or not
                for (int k = 0; k < s.Length; k++)
                {
                    last_currentIndex = Math.Max(last_currentIndex, char_last_Index[s[k] - 'a']);

                    if (last_currentIndex == k)
                    {
                        output.Add(k + 1 - move);
                        move = k + 1;
                    }
                }

                return output;
                
            }
            catch (Exception)
            {
                throw;
            }
        }

        /*
        Question 6
        You are given a string s of lowercase English letters and an array widths denoting how many pixels wide each lowercase English letter is. Specifically, widths[0] is the width of 'a', widths[1] is the width of 'b', and so on.
        You are trying to write s across several lines, where each line is no longer than 100 pixels. Starting at the beginning of s, write as many letters on the first line such that the total width does not exceed 100 pixels. Then, from where you stopped in s, continue writing as many letters as you can on the second line. Continue this process until you have written all of s.
        Return an array result of length 2 where:
             •	result[0] is the total number of lines.
             •	result[1] is the width of the last line in pixels.
 
        Example 1:
        Input: widths = [10,10,10,10,10,10,10,10,10,10,10,10,10,10,10,10,10,10,10,10,10,10,10,10,10,10], s = "abcdefghijklmnopqrstuvwxyz"
        Output: [3,60]
        Explanation: You can write s as follows:
                     abcdefghij  	 // 100 pixels wide
                     klmnopqrst  	 // 100 pixels wide
                     uvwxyz      	 // 60 pixels wide
                     There are a total of 3 lines, and the last line is 60 pixels wide.
         Example 2:
         Input: widths = [4,10,10,10,10,10,10,10,10,10,10,10,10,10,10,10,10,10,10,10,10,10,10,10,10,10], 
         s = "bbbcccdddaaa" 
         Output: [2,4]
         Explanation: You can write s as follows:
                      bbbcccdddaa  	  // 98 pixels wide
                      a           	 // 4 pixels wide
                      There are a total of 2 lines, and the last line is 4 pixels wide.
         */

        public static List<int> NumberOfLines(int[] widths, string s)
        {
            try
            {
                //write your code here.
                
                char[] str = s.ToCharArray();
                int sum = 0;
                int row = 0;
                int pixReturn = 0;

                Dictionary<char, int> dictionary = new Dictionary<char, int>();
                //fetching the position of each alaphabet
                for (char c = 'a'; c <= 'z'; c++)
                {
                    int value = c - 'a';
                    dictionary.Add(c, value);
                }
                //dictionary.ToList().ForEach(x => Console.WriteLine(x.Key + " " + x.Value));

                // Checking pixel sum and if it exceeds 100 , breaking it into another line
                foreach (char e in str)
                {
                    sum += widths[dictionary[e]];
                    if (sum == 100)
                    {
                        row += 1;
                        sum = 0;
                    }
                    if (sum > 100)
                    {
                        row += 1;
                        sum = widths[dictionary[e]];
                    }

                    //Console.WriteLine(sum + " " + e + " " + widths[dictionary[e]]);
                }

                pixReturn = sum;
                row += 1;
                return new List<int>() { row, pixReturn };
            }
            catch (Exception)
            {
                throw;
            }

        }


        /*
        
        Question 7:
        Given a string bulls_string containing just the characters '(', ')', '{', '}', '[' and ']', determine if the input string is valid.
        An input string is valid if:
            1.	Open brackets must be closed by the same type of brackets.
            2.	Open brackets must be closed in the correct order.
 
        Example 1:
        Input: bulls_string = "()"
        Output: true
        Example 2:
        Input: bulls_string  = "()[]{}"
        Output: true
        Example 3:
        Input: bulls_string  = "(]"
        Output: false
        */

        public static bool IsValid(string bulls_string10)
        {
            
            string str_pattern = "[{}()\\[\\]]";

            try
            {
                if (bulls_string10.Length >= 1 && bulls_string10.Length <= 10000 && Regex.IsMatch(bulls_string10, str_pattern)) //handling all the constraints
                {
                    //Replacing each type of open and closed bracket pattern with empty string.
                    bulls_string10 = bulls_string10.Replace("()", "");
                    bulls_string10 = bulls_string10.Replace("{}", "");
                    bulls_string10 = bulls_string10.Replace("[]", "");
                }
                else
                    return false;
                //if the bulls_string10 length is zero then true else false
                if (bulls_string10.Length == 0)
                    return true;
                else
                    return false;
            }
            catch (Exception)
            {
                throw;
            }


        }



        /*
         Question 8
        International Morse Code defines a standard encoding where each letter is mapped to a series of dots and dashes, as follows:
        •	'a' maps to ".-",
        •	'b' maps to "-...",
        •	'c' maps to "-.-.", and so on.
        For convenience, the full table for the 26 letters of the English alphabet is given below:
        [".-","-...","-.-.","-..",".","..-.","--.","....","..",".---","-.-",".-..","--","-.","---",".--.","--.-",".-.","...","-","..-","...-",".--","-..-","-.--","--.."]
        Given an array of strings words where each word can be written as a concatenation of the Morse code of each letter.
            •	For example, "cab" can be written as "-.-..--...", which is the concatenation of "-.-.", ".-", and "-...". We will call such a concatenation the transformation of a word.
        Return the number of different transformations among all words we have.
 
        Example 1:
        Input: words = ["gin","zen","gig","msg"]
        Output: 2
        Explanation: The transformation of each word is:
        "gin" -> "--...-."
        "zen" -> "--...-."
        "gig" -> "--...--."
        "msg" -> "--...--."
        There are 2 different transformations: "--...-." and "--...--.".
        */

        public static int UniqueMorseRepresentations(string[] words)
        {
            Dictionary<string, int> newString = new Dictionary<string, int>();
            //creating an dictionary of alpabhets and associated series of dots and dashes
            Dictionary<char, string> morse_code = new Dictionary<char, string>()
            {

                { 'a' , ".-"},
        {'b' , "-..."},
        {'c' , "-.-."},
        {'d' , "-.."},
        {'e' , "."},
        {'f' , "..-."},
        {'g' , "--."},
        {'h' , "...."},
        {'i' , ".."},
        {'j' , ".---"},
        {'k' , "-.-"},
        {'l' , ".-.."},
        {'m' , "--"},
        {'n' , "-."},
        {'o' , "---"},
        {'p' , ".--."},
        {'q' , "--.-"},
        {'r' , ".-."},
        {'s' , "..."},
        {'t' , "-"},
        {'u' , "..-"},
        {'v' , "...-"},
        {'w' , ".--"},
        {'x' , "-..-"},
        {'y' , "-.--"},
        {'z' , "--.."}
    };
            string replcedString = "";

            try
            {
                if (words.Length >= 1 && words.Length <= 100) //checking the constraints
                {
                    //iterating array of words
                    foreach (string word in words)
                    {
                        replcedString = "";
                        //iterating to replace each letter of a word in the array with morse code
                        if (word.Length >= 1 && word.Length <= 12 && word.ToLower() == word)
                        {
                            foreach (char c in word)
                            {
                                replcedString += morse_code[c];
                            }
                        };
                        //checking if replaced string already avilable in list, then increasing count of new string that is unique
                        if (newString.ContainsKey(replcedString))
                            newString[replcedString] += 1;
                        else
                            newString[replcedString] = 1;
                    }
                };
            }
            catch (Exception)
            {
                throw;
            }
            return newString.Count;
               

        }



        /*
        
        Question 9:
        You are given an n x n integer matrix grid where each value grid[i][j] represents the elevation at that point (i, j).
        The rain starts to fall. At time t, the depth of the water everywhere is t. You can swim from a square to another 4-directionally adjacent square if and only if the elevation of both squares individually are at most t. You can swim infinite distances in zero time. Of course, you must stay within the boundaries of the grid during your swim.
        Return the least time until you can reach the bottom right square (n - 1, n - 1) if you start at the top left square (0, 0).
        Example 1:
        Input: grid = [[0,1,2,3,4],[24,23,22,21,5],[12,13,14,15,16],[11,17,18,19,20],[10,9,8,7,6]]
        Output: 16
        Explanation: The final route is shown.
        We need to wait until time 16 so that (0, 0) and (4, 4) are connected.
        */

        //public static int SwimInWater(int[,] grid)
        //{
        //    try
        //    {
        //        //write your code here.
        //        return 0;
        //    }
        //    catch (Exception)
        //    {

        //        throw;
        //    }
        //}





        /*

        Question 10:
        Given two strings word1 and word2, return the minimum number of operations required to convert word1 to word2.
        You have the following three operations permitted on a word:
        •	Insert a character
        •	Delete a character
        •	Replace a character
         Note: Try to come up with a solution that has polynomial runtime, then try to optimize it to quadratic runtime.
        Example 1:
        Input: word1 = "horse", word2 = "ros"
        Output: 3
        Explanation: 
        horse -> rorse (replace 'h' with 'r')
        rorse -> rose (remove 'r')
        rose -> ros (remove 'e')
        */

        public static int MinDistance(string word1, string word2)
        {
            try
            {
                int lengthX = word1.Length;
                int lengthY = word2.Length;

                //Craeting an array Prev which stores the output of last computation
                int[,] Prev = new int[2, lengthX + 1];

                //When second string is empty
                for (int i = 0; i <= lengthX; i++)
                    Prev[0, i] = i;

                for (int i = 1; i <= lengthY; i++)
                {
                    //Comparing each characters of 2nd string with 1st
                    for (int j = 0; j <= lengthX; j++)
                    {
                        //if first string is empty
                        if (j == 0)
                            Prev[i % 2, j] = i;
                        //comparing the characters of both the strings, if same or not
                        else if (word1[j - 1] == word2[i - 1])
                        {
                            Prev[i % 2, j] = Prev[(i - 1) % 2, j - 1];
                        }
                        
                        else
                        {
                            Prev[i % 2, j] = 1 + Math.Min(Prev[(i - 1) % 2, j],
                                                   Math.Min(Prev[i % 2, j - 1],
                                                       Prev[(i - 1) % 2, j - 1]));
                        }
                    }
                }

                return Prev[lengthY % 2, lengthX];

            
            }
            catch (Exception)
            {

                throw;
            }
        }
    }
}