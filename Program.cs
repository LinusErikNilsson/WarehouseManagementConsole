using Dapper;
using System.Data;
using System.Data.SqlClient;
using Models;
using System.ComponentModel;


class Program
{

    private static void Main(string[] args)
    {

        IDbConnection sqldbconnection = new SqlConnection("Server=localhost,1433;User=sa;Password=apaAPA123;Database=master;");

        while (true)
        {
            Console.Clear();
            Console.ForegroundColor = ConsoleColor.DarkYellow;
            Console.WriteLine("Welcome to the Warehouse Management System");
            Console.WriteLine();

            Console.WriteLine("Please enter the key for an option in the menu below:");

            Console.WriteLine("1. Materials");
            Console.WriteLine("2. MaterialStorage");
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
                    Console.WriteLine("Select an option");
                    Console.WriteLine("1. List all Materials");
                    Console.WriteLine("2. Add a new Material");
                    Console.WriteLine("3. Update a Material");
                    Console.WriteLine("4. Delete a Material");

                    switch (Console.ReadLine())
                    {
                        case "1":
                            Console.Clear();
                            Console.ForegroundColor = ConsoleColor.DarkYellow;
                            Console.WriteLine("Listing all materials:");
                            Console.WriteLine("----------------------------------------");

                            IEnumerable<Material> result = sqldbconnection.Query<Material>("SELECT * FROM Material");

                            foreach (Material material in result)
                            {
                                Console.WriteLine($"Id: {material.Id} Name: {material.Name}");
                            }

                            Console.ResetColor();
                            Console.ReadLine();
                            break;

                        case "2": // Add a new Material
                            Console.Clear();
                            Console.ForegroundColor = ConsoleColor.DarkYellow;
                            Console.WriteLine("Add a new Material");
                            Console.WriteLine("----------------------------------------");
                            Console.ResetColor();

                            Console.Write("Please enter the name of the Material: ");
                            string? inputName = Console.ReadLine();
                            bool isSuccessful = true;

                            try
                            {
                                sqldbconnection.Execute("INSERT INTO Material (Name) VALUES (@Name)",
                                new Material { Name = inputName });
                            }
                            catch (Exception ex)
                            {
                                isSuccessful = false;
                                Console.WriteLine($"Error, could not complete request: {ex.Message}");
                            }
                            finally
                            {
                                Console.ForegroundColor = ConsoleColor.DarkYellow;
                                if (isSuccessful)
                                {
                                    Console.WriteLine("Material added successfully");
                                }
                                Console.ResetColor();
                                Console.ReadLine();
                            }
                            Console.WriteLine("Press any key to continue...");
                            break;

                        case "3": // Update a Material
                            Console.Clear();
                            Console.ForegroundColor = ConsoleColor.DarkYellow;
                            Console.WriteLine("Update a Material");
                            Console.WriteLine("----------------------------------------");
                            Console.ResetColor();

                            Console.Write("Please enter the name of the Material you want to update: ");
                            string? inputString = Console.ReadLine();

                            IEnumerable<Material> updateMaterialQuery = sqldbconnection.Query<Material>("SELECT id, name FROM Material WHERE name LIKE '%' + @Name + '%'",
                                new Material { Name = inputString });

                            foreach (Material material in updateMaterialQuery)
                            {
                                Console.WriteLine($"Id: {material.Id} Name: {material.Name}");
                            }

                            if (updateMaterialQuery.Count() == 0)
                            {
                                Console.ForegroundColor = ConsoleColor.DarkYellow;
                                Console.WriteLine("No materials found");
                                Console.ResetColor();
                                Console.ReadLine();
                                break;
                            }

                            Console.Write("Please enter the Id you wish to update: ");
                            int inputUpdatedMaterialId = Convert.ToInt32(Console.ReadLine());
                            Console.WriteLine();

                            Console.Write("Please enter the new name of the Material: ");
                            string? inputUpdatedMaterialName = Console.ReadLine();

                            sqldbconnection.Execute("UPDATE Material SET Name = @Name WHERE Id = @Id",
                                new Material { Id = inputUpdatedMaterialId, Name = inputUpdatedMaterialName });
                            break;


                        case "4": // Delete a Material
                            Console.Clear();
                            Console.ForegroundColor = ConsoleColor.DarkYellow;
                            Console.WriteLine("Delete a Material");
                            Console.WriteLine("----------------------------------------");
                            Console.ResetColor();

                            Console.Write("Please enter the name of the Material you want to update: ");
                            string? inputMaterialDeleteString = Console.ReadLine();

                            IEnumerable<Material> deleteMaterialQuery = sqldbconnection.Query<Material>("SELECT id, name FROM Material WHERE name LIKE '%' + @Name + '%'",
                                new Material { Name = inputMaterialDeleteString });

                            foreach (Material material in deleteMaterialQuery)
                            {
                                Console.WriteLine($"Id: {material.Id} Name: {material.Name}");
                            }

                            if (deleteMaterialQuery.Count() == 0)
                            {
                                Console.ForegroundColor = ConsoleColor.DarkYellow;
                                Console.WriteLine("No materials found");
                                Console.ResetColor();
                                Console.ReadLine();
                                break;
                            }

                            Console.Write("Please enter the Id you wish to delete: ");
                            int inputDeletedMaterialId = Convert.ToInt32(Console.ReadLine());
                            Console.WriteLine();
                            Console.Clear();
                            sqldbconnection.Execute("DELETE FROM Material WHERE Id = @Id",
                                new Material { Id = inputDeletedMaterialId });
                            Console.WriteLine("Material deleted successfully - Press any key to continue...");
                            Console.ReadLine();

                            break;
                    }

                    break;
                case "2":
                    Console.Clear();
                    Console.WriteLine("Select an option");
                    Console.WriteLine("1. Add Material to Storage place");
                    Console.WriteLine("2. List all Material in Storage");
                    Console.WriteLine("3. Move Material within Storage");
                    Console.WriteLine("4. ");

                    switch (Console.ReadLine())
                    {
                        case "1":
                            Console.Clear();
                            Console.ForegroundColor = ConsoleColor.DarkYellow;
                            Console.WriteLine("Add Material to Storage place");
                            Console.WriteLine("----------------------------------------");

                            Console.Write("Please enter the name of the material you want to add to search for it: ");
                            string? inputString = Console.ReadLine();
                            Console.WriteLine();
                            Console.WriteLine("Search result:");
                            Console.WriteLine("----------------------------------------");

                            IEnumerable<Material> updateMaterialQuery = sqldbconnection.Query<Material>("SELECT id, name FROM Material WHERE name LIKE '%' + @Name + '%'",
                                new Material { Name = inputString });

                            foreach (Material material in updateMaterialQuery)
                            {
                                Console.WriteLine($"Id: {material.Id} Name: {material.Name}");
                            }

                            if (updateMaterialQuery.Count() == 0)
                            {
                                Console.ForegroundColor = ConsoleColor.DarkYellow;
                                Console.WriteLine("No materials found");
                                Console.ResetColor();
                                Console.ReadLine();
                                break;
                            }

                            Console.WriteLine();
                            Console.Write("Please enter the Id you wish to add to Storage: ");
                            int inputMaterialId = Convert.ToInt32(Console.ReadLine());
                            Console.WriteLine();

                            Console.Write("Please enter the Aisle you wish to add to Storage: ");
                            int inputMaterialAisle = Convert.ToInt32(Console.ReadLine());
                            Console.WriteLine();

                            Console.Write("Please enter the Shelf you wish to add to Storage: ");
                            int inputMaterialShelf = Convert.ToInt32(Console.ReadLine());
                            Console.WriteLine();

                            Console.Write("Please enter the Quantity you wish to add to Storage: ");
                            int inputMaterialQuantity = Convert.ToInt32(Console.ReadLine());

                            sqldbconnection.Execute("INSERT INTO MaterialStorage (MaterialId, Aisle, Shelf, Quantity) VALUES (@MaterialId, @Aisle, @Shelf, @Quantity)",
                                new MaterialStorage { MaterialId = inputMaterialId, Aisle = inputMaterialAisle, Shelf = inputMaterialShelf, Quantity = inputMaterialQuantity });
                            Console.WriteLine();
                            Console.Write("Material added successfully to Storage - Press any key to continue...");
                            Console.ReadKey();


                            break;
                        case "2":
                            Console.Clear();
                            Console.ForegroundColor = ConsoleColor.DarkYellow;
                            Console.WriteLine("Listing all materials in storage:");
                            Console.WriteLine("----------------------------------------");

                            IEnumerable<MaterialStorage> result = sqldbconnection.Query<MaterialStorage>("SELECT * FROM MaterialStorage INNER JOIN Material ON MaterialStorage.MaterialId = Material.id;");

                            foreach (MaterialStorage materialStorage in result)
                            {
                                Console.WriteLine($"Id: {materialStorage.Id}  Aisle: {materialStorage.Aisle}  Shelf: {materialStorage.Shelf}  Material Name: {materialStorage.Name}  MaterialId: {materialStorage.MaterialId} Quantity: {materialStorage.Quantity}");
                            }
                            Console.ResetColor();
                            Console.ReadLine();

                            break;

                        case "3":
                            Console.Clear();
                            Console.ForegroundColor = ConsoleColor.DarkYellow;
                            Console.WriteLine("Update a Material in Storage");
                            Console.WriteLine("----------------------------------------");
                            Console.ResetColor();

                            Console.Write("Please enter the name of the Material you want to update: ");
                            string? inputUpdateMaterialStorage = Console.ReadLine();

                            IEnumerable<MaterialStorage> updateMaterialStorageQuery = sqldbconnection.Query<MaterialStorage>("SELECT materialStorage.id, name, quantity, aisle, shelf FROM MaterialStorage INNER JOIN Material ON MaterialStorage.MaterialId = Material.id WHERE name LIKE '%' + @Name + '%' ",
                                new MaterialStorage { Name = inputUpdateMaterialStorage });

                            foreach (MaterialStorage materialStorage in updateMaterialStorageQuery)
                            {
                                Console.WriteLine($"Id: {materialStorage.Id} Name: {materialStorage.Name} Quantity: {materialStorage.Quantity}  Aisle: {materialStorage.Aisle}  Shelf: {materialStorage.Shelf}");
                            }

                            if (updateMaterialStorageQuery.Count() == 0)
                            {
                                Console.ForegroundColor = ConsoleColor.DarkYellow;
                                Console.WriteLine("No materials found");
                                Console.ResetColor();
                                Console.ReadLine();
                                break;
                            }

                            Console.WriteLine("Please the ID for the MaterialStorage you would like to change:");
                            int inputUpdateMaterialStorageId = Convert.ToInt32(Console.ReadLine());

                            Console.WriteLine("Please enter the new Aisle:");
                            int inputUpdatedMaterialAisle = Convert.ToInt32(Console.ReadLine());

                            Console.WriteLine("Please enter the new Shelf:");
                            int inputUpdatedMaterialShelf = Convert.ToInt32(Console.ReadLine());

                            Console.WriteLine("Please enter the new Quantity:");
                            int inputUpdatedMaterialQuantity = Convert.ToInt32(Console.ReadLine());

                            sqldbconnection.Execute("UPDATE MaterialStorage SET Aisle = @Aisle, Shelf = @Shelf, Quantity = @Quantity WHERE Id = @MaterialId ",
                            new MaterialStorage {MaterialId = inputUpdateMaterialStorageId, Aisle = inputUpdatedMaterialAisle, Shelf = inputUpdatedMaterialShelf, Quantity = inputUpdatedMaterialQuantity} );

                            Console.WriteLine("Successfully updated. Press any key to continue.");
                            Console.ReadLine();
                            break;
                    }




                    break;
                case "4":
                    Console.Clear();
                    Console.ForegroundColor = ConsoleColor.DarkYellow;
                    Console.WriteLine("You have selected to add a new order");
                    Console.ResetColor();
                    break;
                case "5":
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
