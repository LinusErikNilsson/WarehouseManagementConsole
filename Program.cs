using Dapper;
using System.Data;
using System.Data.SqlClient;


class Program
{

    private static void Main(string[] args)
    {

        IDbConnection sqldbconnection = new SqlConnection("Server=localhost,1433;User=test;Password=test;Database=test;");

        while (true)
        {
            Console.Clear();
            Console.ForegroundColor = ConsoleColor.DarkYellow;
            Console.WriteLine("Welcome to the Warehouse Management System");
            Console.WriteLine();

            Console.WriteLine("Please enter the key for an option in the menu below:");

            Console.WriteLine("1. List all items located in the Warehouse");
            Console.WriteLine("2. Add an item to the Warehouse");
            Console.WriteLine("3. Remove an item in the Warehouse");
            Console.WriteLine("4. Add a new supplier");
            Console.WriteLine("q. Exit the program");
            Console.ResetColor();
            Console.WriteLine();
            Console.Write("Please enter your selection: ");


            switch (Console.ReadLine())
            {
                case "1":
                    Console.Clear();
                    Console.ForegroundColor = ConsoleColor.DarkYellow;
                    Console.WriteLine("You have selected to list items in the Warehouse");
                    Console.ResetColor();
                    Console.ReadLine();

                    break;
                case "2":
                    Console.Clear();
                    Console.ForegroundColor = ConsoleColor.DarkYellow;
                    Console.WriteLine("You have selected to add an item to the Warehouse");
                    Console.ResetColor();
                    break;
                case "3":
                    Console.Clear();
                    Console.ForegroundColor = ConsoleColor.DarkYellow;
                    Console.WriteLine("You have selected to add a new order");
                    Console.ResetColor();
                    break;
                case "4":
                    Console.Clear();
                    Console.ForegroundColor = ConsoleColor.DarkYellow;
                    Console.WriteLine("You have selected to add a new supplier");
                    Console.ResetColor();
                    break;
                case "q":
                    Console.Clear();
                    Console.ForegroundColor = ConsoleColor.DarkYellow;
                    Console.WriteLine("Are you sure you want to exit the program? y/n");
                    Console.ResetColor();
                    if (Console.ReadLine() == "y")
                    {
                        Environment.Exit(0);
                    }
                    break;

                default:
                    Console.ForegroundColor = ConsoleColor.DarkYellow;
                    Console.WriteLine("You have not selected a valid option - press any key to continue");
                    Console.ResetColor();
                    Console.ReadLine();
                    break;
            }
            
        }




    }
}