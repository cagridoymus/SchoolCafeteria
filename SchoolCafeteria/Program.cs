using System;
using System.Collections.Generic;

class Program
{
    static List<FoodItem> menu = new List<FoodItem>();

    static void Main()
    {
        while (true)
        {
            Console.WriteLine("1. Manage Menu");
            Console.WriteLine("0. Exit");

            int choice = GetIntInput("Enter your choice: ");

            switch (choice)
            {
                case 1:
                    ManageMenu();
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
        Console.Write("Enter food name: ");
        string foodName = Console.ReadLine();
        double foodPrice = GetDoubleInput("Enter food price: ");

        menu.Add(new FoodItem(foodName, foodPrice));
        Console.WriteLine($"{foodName} added to the menu.");
    }

    static void DeleteFoodFromMenu()
    {
        DisplayMenu();
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

    static void DisplayMenu()
    {
        Console.WriteLine("Current Menu:");
        for (int i = 0; i < menu.Count; i++)
        {
            Console.WriteLine($"{i}. {menu[i].Name} - ${menu[i].Price}");
        }
    }

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
