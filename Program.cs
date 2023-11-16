﻿internal class Program
{
    private static void Main(string[] args)
    {

        while (true)
        {
            Console.WriteLine("Hello, World!");

            Console.WriteLine("Welcome to the Warehouse Management System");
            Console.WriteLine("Please select an option from the menu below");

            Console.WriteLine("1. List all items located in the Warehouse");
            Console.WriteLine("2. Add an item to the Warehouse");
            Console.WriteLine("3. Remove an item in the Warehouse");
            Console.WriteLine("4. Add a new supplier");


            switch (Console.ReadLine())
            {
                case "1":
                    Console.WriteLine("You have selected to list items in the Warehouse");
                    break;
                case "2":
                    Console.WriteLine("You have selected to add an item to the Warehouse");
                    break;
                case "3":
                    Console.WriteLine("You have selected to add a new order");
                    break;
                case "4":
                    Console.WriteLine("You have selected to add a new supplier");
                    break;
                case "q":
                    Console.WriteLine("Are you sure you want to exit the program? y/n");
                    if (Console.ReadLine() == "y")
                    {
                        Environment.Exit(0);
                    }
                    break;

                default:
                    Console.WriteLine("You have not selected a valid option");
                    break;
            }
            
        }




    }
}