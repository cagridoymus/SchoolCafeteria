using System;
using System.Collections.Generic;

class Program
{
    static List<FoodItem> menu = new List<FoodItem>();
    static List<Student> students = new List<Student>();

    static void Main()
    {
        while (true)
        {
            Console.WriteLine("********** Cafeteria Management System **********");
            Console.WriteLine("1. Manage Menu");
            Console.WriteLine("2. Display Daily Cafeteria Menu");
            Console.WriteLine("3. Student Account Management");
            Console.WriteLine("4. Display Student Details");
            Console.WriteLine("0. Exit");

            int choice = GetIntInput("Enter your choice: ");

            switch (choice)
            {
                case 1:
                    ManageMenu();
                    break;
                case 2:
                    DisplayDailyMenu();
                    break;
                case 3:
                    StudentAccountManagement();
                    break;
                case 4:
                    DisplayStudentDetails();
                    break;
                case 0:
                    Environment.Exit(0);
                    break;
                default:
                    Console.WriteLine("Invalid choice. Please try again.");
                    break;
            }
        }
    }

    static void ManageMenu()
    {
        Console.WriteLine("\n********** Manage Menu **********");
        Console.WriteLine("1. Add Food to the Menu");
        Console.WriteLine("2. Delete Food from the Menu");

        int choice = GetIntInput("Enter your choice: ");

        switch (choice)
        {
            case 1:
                AddFoodToMenu();
                break;
            case 2:
                DeleteFoodFromMenu();
                break;
            default:
                Console.WriteLine("Invalid choice. Please try again.");
                break;
        }
    }

    static void AddFoodToMenu()
    {
        Console.WriteLine("\n********** Add Food to the Menu **********");
        Console.Write("Enter food name: ");
        string foodName = Console.ReadLine();
        double foodPrice = GetDoubleInput("Enter food price: ");

        menu.Add(new FoodItem(foodName, foodPrice));
        Console.WriteLine($"{foodName} added to the menu.");
    }

    static void DeleteFoodFromMenu()
    {
        DisplayCurrentMenu();
        int index = GetIntInput("Enter the index of the food to delete: ");

        if (index >= 0 && index < menu.Count)
        {
            string deletedFood = menu[index].Name;
            menu.RemoveAt(index);
            Console.WriteLine($"{deletedFood} deleted from the menu.");
        }
        else
        {
            Console.WriteLine("Invalid index. Please try again.");
        }
    }

    static void DisplayCurrentMenu()
    {
        Console.WriteLine("\n********** Current Menu **********");
        foreach (var foodItem in menu)
        {
            Console.WriteLine($"{foodItem.Name} - ${foodItem.Price:F2}");
        }
    }

    static void DisplayDailyMenu()
    {
        if (menu.Count == 0)
        {
            Console.WriteLine("\n********** Daily Cafeteria Menu **********");
            Console.WriteLine("The menu is currently empty. Add items to display the daily menu.");
        }
        else
        {
            Console.WriteLine("\n********** Daily Cafeteria Menu **********");
            foreach (var foodItem in menu)
            {
                Console.WriteLine($"{foodItem.Name} - ${foodItem.Price:F2}");
            }
        }
    }

    static void StudentAccountManagement()
    {
        Console.WriteLine("\n********** Student Account Management **********");
        Console.WriteLine("1. Add Student");
        Console.WriteLine("2. Delete Student");
        Console.WriteLine("3. Search Student Details");
        Console.WriteLine("4. Display Student Details");

        int choice = GetIntInput("Enter your choice: ");

        switch (choice)
        {
            case 1:
                AddStudent();
                break;
            case 2:
                DeleteStudent();
                break;
            case 3:
                SearchStudentDetails();
                break;
            case 4:
                DisplayStudentDetails();
                break;
            default:
                Console.WriteLine("Invalid choice. Please try again.");
                break;
        }
    }

    static void AddStudent()
    {
        Console.WriteLine("\n********** Add Student **********");
        Console.Write("Enter student name: ");
        string studentName = Console.ReadLine();
        int studentID = GenerateStudentID();
        double cafeteriaBalance = GetDoubleInput("Enter initial cafeteria balance: ");

        students.Add(new Student { StudentID = studentID, Name = studentName, CafeteriaBalance = cafeteriaBalance });
        Console.WriteLine($"{studentName} added to the student database with Student ID: {studentID}");
    }

    static void DeleteStudent()
    {
        DisplayStudents();
        int index = GetIntInput("Enter the index of the student to delete: ");

        if (index >= 0 && index < students.Count)
        {
            string deletedStudent = students[index].Name;
            students.RemoveAt(index);
            Console.WriteLine($"{deletedStudent} deleted from the student database.");
        }
        else
        {
            Console.WriteLine("Invalid index. Please try again.");
        }
    }

    static void DisplayStudents()
    {
        Console.WriteLine("\n********** Current Students **********");
        foreach (var student in students)
        {
            Console.WriteLine($"ID: {student.StudentID} - {student.Name} - Cafeteria Balance: ${student.CafeteriaBalance:F2}");
        }
    }

    static void SearchStudentDetails()
    {
        Console.WriteLine("\n********** Search Student Details **********");
        Console.Write("Enter student name to search: ");
        string searchName = Console.ReadLine();
        Student foundStudent = students.Find(student => student.Name.Equals(searchName, StringComparison.OrdinalIgnoreCase));

        if (foundStudent != null)
        {
            Console.WriteLine($"Student found: ID: {foundStudent.StudentID} - {foundStudent.Name} - Cafeteria Balance: ${foundStudent.CafeteriaBalance:F2}");
        }
        else
        {
            Console.WriteLine("Student not found.");
        }
    }

    static void DisplayStudentDetails()
    {
        Console.WriteLine("\n********** Display Student Details **********");
        DisplayStudents();
    }

    // Helper methods for input validation

    static double GetDoubleInput(string prompt)
    {
        double result;
        do
        {
            Console.Write(prompt);
        } while (!double.TryParse(Console.ReadLine(), out result));

        return result;
    }

    static int GetIntInput(string prompt)
    {
        int result;
        do
        {
            Console.Write(prompt);
        } while (!int.TryParse(Console.ReadLine(), out result));

        return result;
    }

    static int GenerateStudentID()
    {
        // Generate a random student ID for simplicity
        return new Random().Next(1000, 9999);
    }
}

class FoodItem
{
    public string Name { get; set; }
    public double Price { get; set; }

    public FoodItem(string name, double price)
    {
        Name = name;
        Price = price;
    }
}

class Student
{
    public int StudentID { get; set; }
    public string Name { get; set; }
    public double CafeteriaBalance { get; set; }
}
