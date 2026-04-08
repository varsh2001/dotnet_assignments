using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace ArraysAndStrings
{
    class Program
    {
        /*
        Test your Knowledge:
        1. When to use String vs. StringBuilder in C#?
           String is for immutable text and few concatenations.
           StringBuilder is for many string manipulations (e.g., inside loops) to save memory and improve performance.

        2. What is the base class for all arrays in C#?
           System.Array

        3. How do you sort an array in C#?
           Using Array.Sort(yourArray)

        4. What property of an array object can be used to get the total number of elements?
           Length

        5. Can you store multiple data types in System.Array?
           Only if you declare it as object[] (array of objects), since all types inherit from System.Object. Regular arrays are normally strictly typed.

        6. What’s the difference between System.Array.CopyTo() and System.Array.Clone()?
           CopyTo(): Copies elements to an already existing, pre-sized array.
           Clone(): Creates and returns a new shallow copy of the array.
        */

        static void Main()
        {
            // You can test any method here
        }

        // Practice Arrays - 1. Copying an Array
        static void CopyArrayExample()
        {
            int[] arr1 = { 1, 2, 3, 4, 5, 6, 7, 8, 9, 10 };
            int[] arr2 = new int[arr1.Length];
            for (int i = 0; i < arr1.Length; i++) arr2[i] = arr1[i];

            Console.WriteLine("Original: " + string.Join(" ", arr1));
            Console.WriteLine("Copied: " + string.Join(" ", arr2));
        }

        // Practice Arrays - 2. List Manager
        static void ListManager()
        {
            var list = new List<string>();
            while (true)
            {
                Console.WriteLine("Enter command (+ item, - item, or -- to clear)):");
                string input = Console.ReadLine();
                if (string.IsNullOrWhiteSpace(input)) continue;

                if (input == "--") list.Clear();
                else if (input.StartsWith("+ ")) list.Add(input.Substring(2).Trim());
                else if (input.StartsWith("- ")) list.Remove(input.Substring(2).Trim());

                Console.WriteLine(list.Count == 0 ? "(empty)" : string.Join("\n", list.Select(x => $"- {x}")));
            }
        }

        // Practice Arrays - 3. Find primes
        static int[] FindPrimesInRange(int startNum, int endNum)
        {
            var primes = new List<int>();
            for (int i = Math.Max(2, startNum); i <= endNum; i++)
            {
                bool isPrime = true;
                for (int j = 2; j <= Math.Sqrt(i); j++)
                    if (i % j == 0) { isPrime = false; break; }
                if (isPrime) primes.Add(i);
            }
            return primes.ToArray();
        }

        // Practice Arrays - 4. Array Rotation and Sum
        static void RotateAndSum()
        {
            int[] arr = Console.ReadLine().Split(' ').Select(int.Parse).ToArray();
            int k = int.Parse(Console.ReadLine());
            int[] sum = new int[arr.Length];

            for (int r = 1; r <= k; r++)
            {
                for (int i = 0; i < arr.Length; i++)
                    sum[(i + r) % arr.Length] += arr[i];
            }
            Console.WriteLine(string.Join(" ", sum));
        }

        // Practice Arrays - 5. Longest sequence of equal elements
        static void LongestSequence()
        {
            int[] arr = Console.ReadLine().Split(' ').Select(int.Parse).ToArray();
            int maxVal = arr[0], maxCount = 1, currCount = 1;

            for (int i = 1; i < arr.Length; i++)
            {
                currCount = (arr[i] == arr[i - 1]) ? currCount + 1 : 1;
                if (currCount > maxCount)
                {
                    maxCount = currCount;
                    maxVal = arr[i];
                }
            }
            Console.WriteLine(string.Join(" ", Enumerable.Repeat(maxVal, maxCount)));
        }

        // Practice Arrays - 7. Most frequent number
        static void MostFrequent()
        {
            int[] arr = Console.ReadLine().Split(' ').Select(int.Parse).ToArray();
            var counts = arr.GroupBy(x => x).ToDictionary(g => g.Key, g => g.Count());
            int maxFreq = counts.Values.Max();
            int mostFrequent = arr.First(x => counts[x] == maxFreq); // Leftmost tie-breaker

            Console.WriteLine($"Number {mostFrequent} occurs {maxFreq} times");
        }

        // Practice Strings - 1. Reverse String
        static void ReverseString(string input)
        {
            // Method 1
            char[] arr = input.ToCharArray();
            Array.Reverse(arr);
            Console.WriteLine(new string(arr));

            // Method 2
            for (int i = input.Length - 1; i >= 0; i--) Console.Write(input[i]);
            Console.WriteLine();
        }

        // Practice Strings - 2. Reverse words
        static void ReverseWordsInSentence()
        {
            string s = "C# is not C++, and PHP is not Delphi!";
            char[] seps = { '.', ',', ':', ';', '=', '(', ')', '&', '[', ']', '"', '\'', '\\', '/', '!', '?', ' ' };
            
            var words = s.Split(seps, StringSplitOptions.RemoveEmptyEntries).Reverse().ToArray();
            var result = new StringBuilder();
            int wordIdx = 0;
            string currWord = "";

            for (int i = 0; i < s.Length; i++)
            {
                if (seps.Contains(s[i])) 
                {
                    if (currWord != "") { result.Append(words[wordIdx++]); currWord = ""; }
                    result.Append(s[i]);
                } 
                else 
                {
                    currWord += s[i];
                }
            }
            if (currWord != "") result.Append(words[wordIdx]);
            Console.WriteLine(result.ToString());
        }

        // Practice Strings - 3. Extract Palindromes
        static void ExtractPalindromes()
        {
            string text = "Hi,exe? ABBA! Hog fully a string: ExE. Bob";
            char[] seps = text.Where(c => char.IsPunctuation(c) || char.IsSeparator(c)).Distinct().ToArray();
            
            var palindromes = text.Split(seps, StringSplitOptions.RemoveEmptyEntries)
                .Where(w => w.SequenceEqual(w.Reverse()))
                .Distinct()
                .OrderBy(w => w)
                .ToList();
                
            Console.WriteLine(string.Join(", ", palindromes));
        }

        // Practice Strings - 4. Parse URL
        static void ParseUrl(string url)
        {
            string protocol = "", server = "", resource = "";
            
            int pIdx = url.IndexOf("://");
            if (pIdx != -1) { protocol = url.Substring(0, pIdx); url = url.Substring(pIdx + 3); }
            
            int rIdx = url.IndexOf("/");
            if (rIdx != -1) { server = url.Substring(0, rIdx); resource = url.Substring(rIdx + 1); }
            else { server = url; }

            Console.WriteLine($"[protocol] = \"{protocol}\"\n[server] = \"{server}\"\n[resource] = \"{resource}\"");
        }
    }
}
