using System;

/*
======================================================
01 Introduction to C# and Data Types
======================================================

Understanding Data Types - Test your Knowledge
1. Best type for:
   - Telephone number: string
   - Height: float
   - Age: byte
   - Gender: enum or string
   - Salary: decimal
   - ISBN: string
   - Price: decimal
   - Shipping weight: float
   - Country's population: int or long
   - Stars in the universe: ulong or BigInteger
   - UK business employees (up to 50k): ushort

2. Value vs Reference Types; Boxing vs Unboxing
   - Value type: Stores data directly (e.g., int, bool).
   - Reference type: Stores a reference/pointer to data on the heap (e.g., string, class).
   - Boxing: Converting a value type to a reference type (object).
   - Unboxing: Converting a boxed object back to a value type.

3. Managed vs Unmanaged Resources
   - Managed: Memory cleaned up automatically by the .NET Garbage Collector.
   - Unmanaged: External resources (Files, DB connections) you must clean up manually.

4. Garbage Collector Purpose
   - Automatically frees up memory used by objects that are no longer needed.

======================================================
Controlling Flow and Converting Types
======================================================

Test your Knowledge
1. int divided by 0? Throws DivideByZeroException.
2. double divided by 0? Returns Infinity or NaN. Doesn't throw error.
3. Overflowing an int? Wraps around to opposite range by default. Throws OverflowException if in 'checked' block.
4. x = y++; vs x = ++y;? 
   - y++ (post-increment): Assigns first, then increments.
   - ++y (pre-increment): Increments first, then assigns.
5. break, continue, return in loops:
   - break: Exits the loop completely.
   - continue: Skips to the next iteration.
   - return: Exits the entire method.
6. Three parts of 'for' statement: Initializer, Condition, Iterator. None are required.
7. '=' vs '==':
   - '=': Assigns a value.
   - '==': Compares if two values are equal.
8. Does `for ( ; true; ) ;` compile? Yes, it's an infinite loop.
9. Underscore '_' in switch expression? It denotes the default case (matches anything else).
10. Interface for 'foreach'? IEnumerable.

======================================================
What happens if this code executes?
int max = 500;
for (byte i = 0; i < max; i++) { Console.WriteLine(i); }
======================================================
Answer: Infinite loop. A byte maxes out at 255. When it hits 255, i++ wraps it back to 0. 
To warn us, wrap the loop in a `checked { }` block to throw an OverflowException.
*/

namespace DotNetAssignments
{
    class Program
    {
        static void Main()
        {
            Console.WriteLine("Uncomment the method you want to run:");
            // HackerName();
            // NumberSizes();
            // CenturiesConverter();
            // FizzBuzz();
            // GuessNumber();
            // PrintPyramid();
            // AgeInDays();
            // Greetings();
            // CountingIncrements();
        }

        static void HackerName()
        {
            Console.Write("Favorite color? ");
            string color = Console.ReadLine();
            Console.Write("Astrology sign? ");
            string sign = Console.ReadLine();
            Console.Write("Street address number? ");
            string addr = Console.ReadLine();
            
            Console.WriteLine($"Your hacker name is {color}{sign}{addr}");
        }

        static void NumberSizes()
        {
            Console.WriteLine($"sbyte: {sizeof(sbyte)} bytes, Min: {sbyte.MinValue}, Max: {sbyte.MaxValue}");
            Console.WriteLine($"byte: {sizeof(byte)} bytes, Min: {byte.MinValue}, Max: {byte.MaxValue}");
            Console.WriteLine($"short: {sizeof(short)} bytes, Min: {short.MinValue}, Max: {short.MaxValue}");
            Console.WriteLine($"ushort: {sizeof(ushort)} bytes, Min: {ushort.MinValue}, Max: {ushort.MaxValue}");
            Console.WriteLine($"int: {sizeof(int)} bytes, Min: {int.MinValue}, Max: {int.MaxValue}");
            Console.WriteLine($"uint: {sizeof(uint)} bytes, Min: {uint.MinValue}, Max: {uint.MaxValue}");
            Console.WriteLine($"long: {sizeof(long)} bytes, Min: {long.MinValue}, Max: {long.MaxValue}");
            Console.WriteLine($"ulong: {sizeof(ulong)} bytes, Min: {ulong.MinValue}, Max: {ulong.MaxValue}");
            Console.WriteLine($"float: {sizeof(float)} bytes, Min: {float.MinValue}, Max: {float.MaxValue}");
            Console.WriteLine($"double: {sizeof(double)} bytes, Min: {double.MinValue}, Max: {double.MaxValue}");
            Console.WriteLine($"decimal: {sizeof(decimal)} bytes, Min: {decimal.MinValue}, Max: {decimal.MaxValue}");
        }

        static void CenturiesConverter()
        {
            Console.Write("Input centuries: ");
            int centuries = int.Parse(Console.ReadLine());

            long years = centuries * 100L;
            long days = (long)(years * 365.2422);
            long hours = days * 24;
            long minutes = hours * 60;
            long seconds = minutes * 60;
            long ms = seconds * 1000;
            long us = ms * 1000;
            decimal ns = us * 1000m;

            Console.WriteLine($"{centuries} centuries = {years} years = {days} days = {hours} hours = {minutes} minutes = {seconds} seconds = {ms} milliseconds = {us} microseconds = {ns} nanoseconds");
        }

        static void FizzBuzz()
        {
            for (int i = 1; i <= 100; i++)
            {
                if (i % 15 == 0) Console.WriteLine("FizzBuzz");
                else if (i % 3 == 0) Console.WriteLine("Fizz");
                else if (i % 5 == 0) Console.WriteLine("Buzz");
                else Console.WriteLine(i);
            }
        }

        static void GuessNumber()
        {
            int correctNumber = new Random().Next(3) + 1;
            Console.Write("Guess a number between 1 and 3: ");
            int guess = int.Parse(Console.ReadLine());

            if (guess < 1 || guess > 3) Console.WriteLine("Outside valid range!");
            else if (guess < correctNumber) Console.WriteLine("You guessed low!");
            else if (guess > correctNumber) Console.WriteLine("You guessed high!");
            else Console.WriteLine("Correct!");
        }

        static void PrintPyramid()
        {
            int levels = 5;
            for (int i = 1; i <= levels; i++)
            {
                for (int s = 1; s <= levels - i; s++) Console.Write(" ");
                for (int star = 1; star <= (2 * i - 1); star++) Console.Write("*");
                Console.WriteLine();
            }
        }

        static void AgeInDays()
        {
            Console.Write("Enter your birth date (YYYY-MM-DD): ");
            DateTime birth = DateTime.Parse(Console.ReadLine());
            
            int days = (int)(DateTime.Today - birth).TotalDays;
            Console.WriteLine($"You are {days} days old.");
            
            int diff = 10000 - (days % 10000);
            Console.WriteLine($"Next 10,000-day anniversary: {DateTime.Today.AddDays(diff).ToShortDateString()}");
        }

        static void Greetings()
        {
            int hour = DateTime.Now.Hour;
            if (hour >= 5 && hour < 12) Console.WriteLine("Good Morning");
            if (hour >= 12 && hour < 17) Console.WriteLine("Good Afternoon");
            if (hour >= 17 && hour < 21) Console.WriteLine("Good Evening");
            if (hour >= 21 || hour < 5) Console.WriteLine("Good Night");
        }

        static void CountingIncrements()
        {
            for (int inc = 1; inc <= 4; inc++)
            {
                for (int i = 0; i <= 24; i += inc)
                {
                    Console.Write(i);
                    if (i + inc <= 24) Console.Write(",");
                }
                Console.WriteLine();
            }
        }
    }
}
