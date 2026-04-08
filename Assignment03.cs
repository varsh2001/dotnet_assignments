using System;
using System.Collections.Generic;

/*
======================================================
03 Object-Oriented Programming
======================================================

Test your knowledge
1. What are the six combinations of access modifier keywords and what do they do?
   - public: Accessible from anywhere.
   - private: Accessible only within the same class/struct.
   - protected: Accessible within the same class or derived classes.
   - internal: Accessible within the same assembly.
   - protected internal: Accessible within the same assembly OR from derived classes.
   - private protected: Accessible within the same class or derived classes WITHIN the same assembly.

2. Difference between static, const, and readonly?
   - static: Member belongs to the type itself, not an instance.
   - const: Value is hardcoded at compile time and cannot change.
   - readonly: Value is set at runtime (in declaration or constructor) and cannot change afterwards.

3. What does a constructor do?
   - Initializes an object's state when an instance of a class/struct is created.

4. Why is the partial keyword useful?
   - It allows a class, struct, or interface to be split across multiple files (useful for auto-generated code + user code).

5. What is a tuple?
   - A lightweight data structure to group multiple values together without creating a custom type.

6. What does the C# record keyword do?
   - Defines a reference type with built-in value-based equality, ideal for immutable data models.

7. What does overloading and overriding mean?
   - Overloading: Multiple methods with the same name but different parameters in the same class.
   - Overriding: A derived class provides its own implementation for a inherited virtual or abstract method.

8. Difference between a field and a property?
   - Field: A variable declared directly in a class (data storage).
   - Property: A member that provides a flexible mechanism (get/set accessors) to read, write, or compute the value of a private field.

9. How do you make a method parameter optional?
   - Provide a default value in the method signature (e.g., void MyMethod(int x = 5)).

10. What is an interface and how is it different from abstract class?
    - Interface: A contract defining members without state. A class can implement multiple interfaces.
    - Abstract class: Can contain state (fields), constructors, and partial implementations. A class can inherit only one abstract class.

11. What accessibility level are members of an interface?
    - Historically public by default (C# 8.0 introduced explicit access modifiers for default interface methods, but typically public).

12. True/False. Polymorphism allows derived classes to provide different implementations of the same method. (True)
13. True/False. The override keyword is used to indicate that a method in a derived class is providing its own implementation of a method. (True)
14. True/False. The new keyword is used to indicate that a method in a derived class is providing its own implementation of a method. (True - though it hides the base method rather than overriding it for polymorphism).
15. True/False. Abstract methods can be used in a normal (non-abstract) class. (False)
16. True/False. Normal (non-abstract) methods can be used in an abstract class. (True)
17. True/False. Derived classes can override methods that were virtual in the base class. (True)
18. True/False. Derived classes can override methods that were abstract in the base class. (True - they MUST override).
19. True/False. In a derived class, you can override a method that was neither virtual nor abstract in the base class. (False).
20. True/False. A class that implements an interface does not have to provide an implementation for all of the members of the interface. (False - unless the class is abstract).
21. True/False. A class that implements an interface is allowed to have other members that aren't defined in the interface. (True)
22. True/False. A class can have more than one base class. (False)
23. True/False. A class can implement more than one interface. (True)
*/

namespace DotNetAssignments
{
    class Assignment03
    {
        static void Main()
        {
            Console.WriteLine("Uncomment the method you want to run:");
            // ReverseArraySequence();
            // FibonacciSequence();
            // TestSchoolSystem();
            // TestBallsAndColors();
        }

        // ======================================================
        // Working with methods
        // ======================================================

        static void ReverseArraySequence()
        {
            int[] numbers = GenerateNumbers(10);
            Reverse(numbers);
            PrintNumbers(numbers);
        }

        static int[] GenerateNumbers(int length = 10)
        {
            int[] arr = new int[length];
            for (int i = 0; i < length; i++)
            {
                arr[i] = i + 1;
            }
            return arr;
        }

        static void Reverse(int[] arr)
        {
            int len = arr.Length;
            for (int i = 0; i < len / 2; i++)
            {
                int temp = arr[i];
                arr[i] = arr[len - i - 1];
                arr[len - i - 1] = temp;
            }
        }

        static void PrintNumbers(int[] arr)
        {
            foreach (int num in arr)
            {
                Console.Write(num + " ");
            }
            Console.WriteLine();
        }

        static void FibonacciSequence()
        {
            for (int i = 1; i <= 10; i++)
            {
                Console.Write(Fibonacci(i) + " ");
            }
            Console.WriteLine();
        }

        static int Fibonacci(int n)
        {
            if (n <= 2) return 1;
            return Fibonacci(n - 1) + Fibonacci(n - 2);
        }

        // ======================================================
        // Designing and Building Classes using OOP
        // ======================================================
        static void TestSchoolSystem()
        {
            var student = new Student("Alice", new DateTime(2000, 1, 1));
            student.CalculateSalary();
            Console.WriteLine($"Student Age: {student.CalculateAge()}");

            var instructor = new Instructor("Bob", new DateTime(1980, 5, 20), new DateTime(2010, 8, 1));
            Console.WriteLine($"Instructor Age: {instructor.CalculateAge()}");
            Console.WriteLine($"Instructor Salary: {instructor.CalculateSalary()}");
        }

        static void TestBallsAndColors()
        {
            var redColor = new Color(255, 0, 0);
            var greenColor = new Color(0, 255, 0, 128);

            var ball1 = new Ball(10, redColor);
            var ball2 = new Ball(20, greenColor);

            ball1.Throw();
            ball1.Throw();
            ball2.Throw();

            ball1.Pop();
            ball1.Throw(); // Shouldn't increment

            Console.WriteLine($"Ball 1 thrown {ball1.GetThrows()} times.");
            Console.WriteLine($"Ball 2 thrown {ball2.GetThrows()} times.");
        }
    }

    #region School System

    public interface IPersonService
    {
        int CalculateAge();
        decimal CalculateSalary();
        List<string> GetAddresses();
    }

    public interface IStudentService : IPersonService
    {
        double CalculateGPA();
    }

    public interface IInstructorService : IPersonService
    {
        int CalculateExperience();
    }

    public interface IDepartmentService { }
    public interface ICourseService { }

    public abstract class Person : IPersonService
    {
        public string Name { get; private set; }
        public DateTime DateOfBirth { get; private set; }
        private List<string> Addresses { get; set; } = new List<string>();
        protected decimal BaseSalary { get; set; }

        public Person(string name, DateTime dateOfBirth)
        {
            Name = name;
            DateOfBirth = dateOfBirth;
        }

        public int CalculateAge()
        {
            int age = DateTime.Today.Year - DateOfBirth.Year;
            if (DateOfBirth.Date > DateTime.Today.AddYears(-age)) age--;
            return age;
        }

        public virtual decimal CalculateSalary()
        {
            return BaseSalary < 0 ? 0 : BaseSalary;
        }

        public List<string> GetAddresses()
        {
            return Addresses;
        }

        public void AddAddress(string address)
        {
            Addresses.Add(address);
        }
    }

    public class Student : Person, IStudentService
    {
        public Dictionary<Course, char> CourseGrades { get; private set; } = new Dictionary<Course, char>();

        public Student(string name, DateTime dateOfBirth) : base(name, dateOfBirth) { }

        public override decimal CalculateSalary()
        {
            return 0; // Students don't have salary
        }

        public double CalculateGPA()
        {
            if (CourseGrades.Count == 0) return 0.0;
            double totalPoints = 0;
            foreach (var grade in CourseGrades.Values)
            {
                switch (grade)
                {
                    case 'A': totalPoints += 4.0; break;
                    case 'B': totalPoints += 3.0; break;
                    case 'C': totalPoints += 2.0; break;
                    case 'D': totalPoints += 1.0; break;
                    case 'F': totalPoints += 0.0; break;
                }
            }
            return totalPoints / CourseGrades.Count;
        }
    }

    public class Instructor : Person, IInstructorService
    {
        public DateTime JoinDate { get; private set; }
        public Department Department { get; set; }
        public bool IsHeadOfDepartment { get; set; }

        public Instructor(string name, DateTime dateOfBirth, DateTime joinDate) : base(name, dateOfBirth)
        {
            JoinDate = joinDate;
            BaseSalary = 50000m; // Example base salary
        }

        public int CalculateExperience()
        {
            int exp = DateTime.Today.Year - JoinDate.Year;
            if (JoinDate.Date > DateTime.Today.AddYears(-exp)) exp--;
            return exp;
        }

        public override decimal CalculateSalary()
        {
            decimal expBonus = CalculateExperience() * 1000m;
            decimal salary = BaseSalary + expBonus;
            return salary < 0 ? 0 : salary;
        }
    }

    public class Course : ICourseService
    {
        public string Title { get; set; }
        public List<Student> EnrolledStudents { get; set; } = new List<Student>();
    }

    public class Department : IDepartmentService
    {
        public Instructor Head { get; set; }
        public decimal Budget { get; set; }
        public DateTime StartDate { get; set; }
        public DateTime EndDate { get; set; }
        public List<Course> OfferedCourses { get; set; } = new List<Course>();
    }

    #endregion

    #region Color and Ball

    public class Color
    {
        public byte Red { get; set; }
        public byte Green { get; set; }
        public byte Blue { get; set; }
        public byte Alpha { get; set; }

        public Color(byte red, byte green, byte blue, byte alpha)
        {
            Red = red;
            Green = green;
            Blue = blue;
            Alpha = alpha;
        }

        public Color(byte red, byte green, byte blue) : this(red, green, blue, 255) { }

        public int GetGrayscale()
        {
            return (Red + Green + Blue) / 3;
        }
    }

    public class Ball
    {
        public int Size { get; private set; }
        public Color Color { get; private set; }
        private int ThrowCount { get; set; }

        public Ball(int size, Color color)
        {
            Size = size;
            Color = color;
            ThrowCount = 0;
        }

        public void Pop()
        {
            Size = 0;
        }

        public void Throw()
        {
            if (Size > 0)
            {
                ThrowCount++;
            }
        }

        public int GetThrows()
        {
            return ThrowCount;
        }
    }

    #endregion
}
