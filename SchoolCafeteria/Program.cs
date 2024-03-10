using System;
using System.Collections.Generic;

class Program
{
    static List<FoodItem> menu = new List<FoodItem>();
    static List<Student> students = new List<Student>();
    static List<Feedback> feedbackList = new List<Feedback>();
    static List<MealRating> mealRatings = new List<MealRating>(); // New list for storing meal ratings

    static void Main()
    {
        while (true)
        {
            Console.WriteLine("********** Cafeteria Management System **********");
            Console.WriteLine("1. Manage Menu");
            Console.WriteLine("2. Display Daily Cafeteria Menu");
            Console.WriteLine("3. Student Account Management");
            Console.WriteLine("4. Feedback");
            Console.WriteLine("5. Rate Cafeteria Meals"); // New option
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
                    FeedbackMenu();
                    break;
                case 5:
                    RateCafeteriaMeals(); 
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
        Console.WriteLine("3. Update Food Details");
        Console.WriteLine("4. Search for Food Details"); // New option

        int choice = GetIntInput("Enter your choice: ");

        switch (choice)
        {
            case 1:
                AddFoodToMenu();
                break;
            case 2:
                DeleteFoodFromMenu();
                break;
            case 3:
                UpdateFoodDetails();
                break;
            case 4:
                SearchFoodDetails(); // New case
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
        int foodCalories = GetIntInput("Enter food calories: "); // New input for calories

        menu.Add(new FoodItem(foodName, foodPrice, foodCalories));
        Console.WriteLine($"{foodName} added to the menu.");
    }

    static void SearchFoodDetails()
    {
        Console.WriteLine("\n********** Search for Food Details **********");
        Console.Write("Enter food name to search: ");
        string searchName = Console.ReadLine();
        FoodItem foundFood = menu.Find(food => food.Name.Equals(searchName, StringComparison.OrdinalIgnoreCase));

        if (foundFood != null)
        {
            Console.WriteLine($"Food found: {foundFood.Name} - Price: ${foundFood.Price:F2} - Calories: {foundFood.Calories}");
        }
        else
        {
            Console.WriteLine("Food not found.");
        }
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

    static void UpdateFoodDetails()
    {
        DisplayCurrentMenu();
        int index = GetIntInput("Enter the index of the food to update: ");

        if (index >= 0 && index < menu.Count)
        {
            Console.WriteLine($"\n********** Update Food Details **********");
            Console.WriteLine($"Current details of {menu[index].Name}:");
            Console.WriteLine($"1. Name: {menu[index].Name}");
            Console.WriteLine($"2. Price: ${menu[index].Price:F2}");

            int updateChoice = GetIntInput("Enter the number of the detail to update (0 to cancel): ");

            switch (updateChoice)
            {
                case 1:
                    Console.Write("Enter new food name: ");
                    menu[index].Name = Console.ReadLine();
                    Console.WriteLine("Food name updated successfully.");
                    break;
                case 2:
                    menu[index].Price = GetDoubleInput("Enter new food price: ");
                    Console.WriteLine("Food price updated successfully.");
                    break;
                case 0:
                    Console.WriteLine("Update canceled.");
                    break;
                default:
                    Console.WriteLine("Invalid choice. Update canceled.");
                    break;
            }
        }
        else
        {
            Console.WriteLine("Invalid index. Please try again.");
        }
    }

    static void DisplayCurrentMenu()
    {
        Console.WriteLine("\n********** Current Menu **********");
        for (int i = 0; i < menu.Count; i++)
        {
            Console.WriteLine($"{i}. {menu[i].Name} - ${menu[i].Price:F2} - Average Rating: {menu[i].AverageRating.ToString("F2")}");
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
            for (int i = 0; i < menu.Count; i++)
            {
                Console.WriteLine($"{i}. {menu[i].Name} - ${menu[i].Price:F2} - Average Rating: {menu[i].AverageRating.ToString("F2")}");
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
        Console.WriteLine("5. Update Student Information"); // New option

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
            case 5:
                UpdateStudentInformation(); // New case
                break;
            default:
                Console.WriteLine("Invalid choice. Please try again.");
                break;
        }
    }

    static void UpdateStudentInformation()
    {
        DisplayStudents();

        if (students.Count == 0)
        {
            Console.WriteLine("No students available to update.");
            return;
        }

        int index = GetIntInput("Enter the index of the student to update information: ");

        if (index >= 0 && index < students.Count)
        {
            Console.WriteLine($"\n********** Update Student Information **********");
            Console.WriteLine($"Current information of {students[index].Name}:");
            Console.WriteLine($"ID: {students[index].StudentID} - Name: {students[index].Name} - Cafeteria Balance: ${students[index].CafeteriaBalance:F2}");

            int updateChoice = GetIntInput("Enter the number of the detail to update (0 to cancel): ");

            switch (updateChoice)
            {
                case 1:
                    Console.Write("Enter new student name: ");
                    students[index].Name = Console.ReadLine();
                    Console.WriteLine("Student name updated successfully.");
                    break;
                case 2:
                    students[index].CafeteriaBalance = GetDoubleInput("Enter new cafeteria balance: ");
                    Console.WriteLine("Cafeteria balance updated successfully.");
                    break;
                case 0:
                    Console.WriteLine("Update canceled.");
                    break;
                default:
                    Console.WriteLine("Invalid choice. Update canceled.");
                    break;
            }
        }
        else
        {
            Console.WriteLine("Invalid index. Please try again.");
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
        for (int i = 0; i < students.Count; i++)
        {
            Console.WriteLine($"Index: {i} - ID: {students[i].StudentID} - {students[i].Name} - Cafeteria Balance: ${students[i].CafeteriaBalance:F2}");
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

    static void FeedbackMenu()
    {
        Console.WriteLine("\n********** Feedback Menu **********");
        Console.WriteLine("1. Submit Feedback");
        Console.WriteLine("2. View Feedback");

        int choice = GetIntInput("Enter your choice: ");

        switch (choice)
        {
            case 1:
                SubmitFeedback();
                break;
            case 2:
                ViewFeedback();
                break;
            default:
                Console.WriteLine("Invalid choice. Returning to main menu.");
                break;
        }
    }

    static void SubmitFeedback()
    {
        Console.WriteLine("\n********** Submit Feedback **********");
        DisplayStudents();

        int studentIndex = GetIntInput("Enter the index of the student submitting feedback: ");

        if (studentIndex >= 0 && studentIndex < students.Count)
        {
            Console.Write("Enter feedback: ");
            string studentFeedback = Console.ReadLine();

            feedbackList.Add(new Feedback
            {
                StudentID = students[studentIndex].StudentID,
                FeedbackText = studentFeedback,
                SubmissionDate = DateTime.Now
            });

            Console.WriteLine("Feedback submitted successfully.");
        }
        else
        {
            Console.WriteLine("Invalid student index. Feedback submission canceled.");
        }
    }

    static void ViewFeedback()
    {
        Console.WriteLine("\n********** View Feedback **********");

        if (feedbackList.Count > 0)
        {
            foreach (var feedback in feedbackList)
            {
                Console.WriteLine($"Student ID: {feedback.StudentID} - Feedback: {feedback.FeedbackText} - Submission Date: {feedback.SubmissionDate}");
            }
        }
        else
        {
            Console.WriteLine("No feedback available.");
        }
    }

    static void RateCafeteriaMeals()
    {
        Console.WriteLine("\n********** Rate Cafeteria Meals **********");
        DisplayStudents();

        int studentIndex = GetIntInput("Enter the index of the student rating meals: ");

        if (studentIndex >= 0 && studentIndex < students.Count)
        {
            DisplayCurrentMenu();

            int mealIndex = GetIntInput("Enter the index of the meal to rate: ");

            if (mealIndex >= 0 && mealIndex < menu.Count)
            {
                int rating = GetIntInput("Enter the rating (1 to 5, where 1 is the lowest and 5 is the highest): ");

                if (rating >= 1 && rating <= 5)
                {
                    menu[mealIndex].Ratings.Add(rating); // Add the rating to the FoodItem's Ratings list

                    mealRatings.Add(new MealRating
                    {
                        StudentID = students[studentIndex].StudentID,
                        MealIndex = mealIndex,
                        Rating = rating,
                        RatingDate = DateTime.Now
                    });

                    Console.WriteLine("Meal rated successfully.");
                }
                else
                {
                    Console.WriteLine("Invalid rating. Please enter a value between 1 and 5.");
                }
            }
            else
            {
                Console.WriteLine("Invalid meal index. Rating canceled.");
            }
        }
        else
        {
            Console.WriteLine("Invalid student index. Rating canceled.");
        }
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
    public int Calories { get; set; }
    public List<int> Ratings { get; set; } = new List<int>();

    public double AverageRating
    {
        get
        {
            if (Ratings.Count == 0)
            {
                return double.NaN; // Return NaN if there are no ratings
            }

            return Ratings.Average();
        }
    }

    public FoodItem(string name, double price, int calories)
    {
        Name = name;
        Price = price;
        Calories = calories;
    }
}

class Feedback
{
    public int StudentID { get; set; }
    public string FeedbackText { get; set; }
    public DateTime SubmissionDate { get; set; }
}

class Student
{
    public int StudentID { get; set; }
    public string Name { get; set; }
    public double CafeteriaBalance { get; set; }
}

class MealRating
{
    public int StudentID { get; set; }
    public int MealIndex { get; set; }
    public int Rating { get; set; }
    public DateTime RatingDate { get; set; }
}
