using Dapper;
using System.Data;
using System.Data.SqlClient;
using Models;
using System.ComponentModel;
using System.Security.Cryptography.X509Certificates;


class Program
{

    private static void Main(string[] args)
    {

        IDbConnection sqldbconnection = new SqlConnection("Server=localhost,1433;User=sa;Password=apA123!#!;Database=master;");

        while (true)
        {
            Console.Clear();
            Console.ForegroundColor = ConsoleColor.DarkYellow;
            Console.WriteLine("Welcome to the Warehouse Management System");
            Console.WriteLine();

            Console.WriteLine("Please enter the key for an option in the menu below, and press ENTER:");

            Console.WriteLine("1. Materials");
            Console.WriteLine("2. MaterialStorage");
            Console.WriteLine("3. Production ");
            Console.WriteLine("4. Customer Orders ");
            Console.WriteLine("5. Customers");
            Console.WriteLine("q. Exit the program");
            Console.ResetColor();
            Console.WriteLine();
            Console.Write("Please enter your selection: ");


            switch (Console.ReadLine())
            {
                case "1": // Materials menu
                    Console.Clear();
                    Console.ForegroundColor = ConsoleColor.DarkYellow;
                    Console.WriteLine("Select an option");
                    Console.WriteLine("1. List all Materials");
                    Console.WriteLine("2. Add a new Material");
                    Console.WriteLine("3. Update a Material");
                    Console.WriteLine("4. Delete a Material");
                    Console.ResetColor();

                    switch (Console.ReadLine())
                    {
                        case "1":
                            Console.Clear();
                            Console.ForegroundColor = ConsoleColor.DarkYellow;
                            Console.WriteLine("Listing all materials:");
                            Console.WriteLine("----------------------------------------");
                            Console.ResetColor();

                            IEnumerable<Material> result = sqldbconnection.Query<Material>("SELECT * FROM Material");

                            foreach (Material material in result)
                            {
                                Console.WriteLine($"Id: {material.Id} Name: {material.Name}");
                            }

                            Console.ForegroundColor = ConsoleColor.DarkYellow;
                            Console.WriteLine();
                            Console.WriteLine("Press any key to continue...");
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
                            }
                            Console.WriteLine("Press any key to continue...");
                            Console.ReadLine();
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
                            Console.WriteLine();
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

                            Console.Write("Please enter the name of the Material you want to delete: ");
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
                case "2": // Storage Menu
                    Console.Clear();
                    Console.WriteLine("Select an option");
                    Console.WriteLine("1. Add Material to Storage place");
                    Console.WriteLine("2. List all Material in Storage");
                    Console.WriteLine("3. Move Material within Storage");
                    Console.WriteLine("4. Move Material to ProductionQueue");
                    Console.WriteLine("5. Show Products in ProductStorage");

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

                            IEnumerable<MaterialStorage> result = sqldbconnection.Query<MaterialStorage>("SELECT MaterialStorage.id , MaterialStorage.Aisle, MaterialStorage.Shelf, MaterialStorage.Quantity, Material.id AS materialID, Material.name FROM MaterialStorage INNER JOIN Material ON MaterialStorage.MaterialId = Material.id;");

                            foreach (MaterialStorage materialStorage in result)
                            {
                                Console.WriteLine($"Id: {materialStorage.Id}  Aisle: {materialStorage.Aisle}  Shelf: {materialStorage.Shelf}  Material Name: {materialStorage.Name}  MaterialId: {materialStorage.MaterialId} Quantity: {materialStorage.Quantity}");
                            }
                            Console.ResetColor();
                            Console.ReadLine();

                            break;
                        case "3": //Update a material in Storage
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
                            new MaterialStorage { MaterialId = inputUpdateMaterialStorageId, Aisle = inputUpdatedMaterialAisle, Shelf = inputUpdatedMaterialShelf, Quantity = inputUpdatedMaterialQuantity });

                            Console.WriteLine("Successfully updated. Press any key to continue.");
                            Console.ReadLine();
                            break;

                            case "4": //Move Material to ProductionQueue
                            Console.Clear();
                            Console.ForegroundColor = ConsoleColor.DarkYellow;
                            Console.WriteLine("Move Material to ProductionQueue");
                            Console.WriteLine("----------------------------------------");
                            Console.ResetColor();

                            IEnumerable<MaterialStorage> moveMaterialQuery = sqldbconnection.Query<MaterialStorage>("SELECT MaterialStorage.id , MaterialStorage.Aisle, MaterialStorage.Shelf, MaterialStorage.Quantity, Material.id AS materialID, Material.name FROM MaterialStorage INNER JOIN Material ON MaterialStorage.MaterialId = Material.id");

                            foreach (MaterialStorage materialstorage in moveMaterialQuery)
                            {
                                Console.WriteLine($"MaterialStorageID: {materialstorage.Id} Aisle: {materialstorage.Aisle} Shelf: {materialstorage.Shelf} MaterialID {materialstorage.MaterialId} MaterialName: {materialstorage.Name}  QTY: {materialstorage.Quantity}");
                            }

                            Console.WriteLine("Please enter the StorageID you wish to move to ProductionQueue: ");
                            int inputStorageIdmove = Convert.ToInt32(Console.ReadLine());

                            Console.WriteLine("Please enter the MaterialID you wish to move to ProductionQueue: ");
                            int inputMaterialIdmove = Convert.ToInt32(Console.ReadLine());

                            Console.WriteLine("Please enter the Quantity you wish to move to ProductionQueue: ");
                            int inputQuantitymove = Convert.ToInt32(Console.ReadLine());

                            Console.WriteLine("Please enter the Priority level 1 to 3: ");
                            int inputPrioritymove = Convert.ToInt32(Console.ReadLine());

                            IEnumerable<MaterialStorage> checkQuantityQuery = sqldbconnection.Query<MaterialStorage>("SELECT MaterialStorage.id , MaterialStorage.Aisle, MaterialStorage.Shelf, MaterialStorage.Quantity, Material.id AS materialID, Material.name FROM MaterialStorage INNER JOIN Material ON MaterialStorage.MaterialId = Material.id WHERE MaterialStorage.id = @id",
                                new MaterialStorage { Id = inputStorageIdmove });

                            int quantityInMaterialStorage = checkQuantityQuery.Select(x => x.Quantity).FirstOrDefault();
                            Console.WriteLine($" QTY in MaterialStorage: {quantityInMaterialStorage}");
                            Console.WriteLine($" QTY to move: {inputQuantitymove}");

                            if(inputQuantitymove > quantityInMaterialStorage)
                            {
                                Console.WriteLine("Error - Missing quantity in storage to proceed");
                                Console.ReadLine();
                                break;
                            }

                            sqldbconnection.Execute("INSERT INTO ProductionQueue (MaterialId, Quantity, Priority) VALUES (@materialId, @quantity, @priority)",
                                new ProductionQueue { materialId = inputMaterialIdmove, quantity = inputQuantitymove, priority = inputPrioritymove });

                            Console.WriteLine("Material added to ProductionQueue");
                            Console.ReadLine();

                            if (inputQuantitymove == quantityInMaterialStorage)
                            {
                                sqldbconnection.Execute("DELETE FROM MaterialStorage WHERE Id = @Id",
                                    new MaterialStorage { Id = inputStorageIdmove });
                            }
                            else
                            {
                                sqldbconnection.Execute("UPDATE MaterialStorage SET Quantity = Quantity - @Quantity WHERE Id = @Id",
                                    new MaterialStorage { Id = inputStorageIdmove, Quantity = inputQuantitymove });
                            }
                            Console.ReadLine();
                            break;

                            case "5": //Show Products in ProductStorage
                            Console.Clear();
                            Console.ForegroundColor = ConsoleColor.DarkYellow;
                            Console.WriteLine("Show all Products in ProductStorage");
                            Console.WriteLine("----------------------------------------");
                            Console.ResetColor();

                            IEnumerable<ProductStorage> productStorageQuery = sqldbconnection.Query<ProductStorage>("SELECT ProductStorage.id, ProductStorage.Aisle, ProductStorage.Shelf, Product.Name, ProductStorage.Quantity FROM ProductStorage\r\n    INNER JOIN Product ON ProductStorage.ProductId = Product.Id;");

                            foreach (ProductStorage productstorage in productStorageQuery)
                            {
                                Console.WriteLine($"ProductStorageID: {productstorage.Id} | Aisle: {productstorage.Aisle} | Shelf: {productstorage.Shelf}");
                                Console.WriteLine($"ProductID {productstorage.ProductId} ProductName: {productstorage.Name}  QTY: {productstorage.Quantity}");
                                Console.WriteLine();
                            }
                            Console.WriteLine();
                            Console.WriteLine("Press any key to continue...");
                            Console.ReadLine();

                            break;
                    }

                    break;
                case "3": // Production
                    Console.Clear();
                    Console.ForegroundColor = ConsoleColor.DarkYellow;
                    Console.WriteLine("Production");
                    Console.WriteLine("----------------------------------------");


                    Console.WriteLine("Select an option and press ENTER");

                    Console.WriteLine("1. List all Materials Located in ProductionQueue (Inbound)");
                    Console.WriteLine("2. Start Production of a product");
                    Console.ResetColor();
                    Console.WriteLine();
                    Console.Write("Your selection: ");

                    switch(Console.ReadLine())
                    {
                        case "1": //List all Materials Located in ProductionQueue (Inbound)
                            Console.Clear();
                            Console.ForegroundColor = ConsoleColor.DarkYellow;
                            Console.WriteLine("List all Materials in ProductionQueue - INBOUND");
                            Console.WriteLine("-------------------------------------------------");
                            Console.ResetColor();

                            IEnumerable<ProductionQueue> result = sqldbconnection.Query<ProductionQueue>("SELECT ProductionQueue.id, ProductionQueue.MaterialId, ProductionQueue.Quantity, ProductionQueue.Priority, Material.Name FROM ProductionQueue INNER JOIN Material ON ProductionQueue.MaterialId = Material.Id");

                            foreach (ProductionQueue productionQueue in result)
                            {
                                Console.WriteLine($"Id: {productionQueue.id} MaterialId: {productionQueue.materialId} Quantity: {productionQueue.quantity} Priority: {productionQueue.priority} MaterialName: {productionQueue.name}");
                            }
                            Console.WriteLine();
                            Console.WriteLine("Press any key to continue...");
                            Console.ReadLine();

                            break;

                            case "2": //Start Production of a product
                            Console.Clear();
                            Console.ForegroundColor = ConsoleColor.DarkYellow;
                            Console.WriteLine("Start Production of a Product");
                            Console.WriteLine("-------------------------------------------------");
                            Console.WriteLine("Listing Products that can be produced: ");
                            Console.WriteLine();
                            Console.ResetColor();

                            //List to temporarly store materials to be used in production:
                            List<MaterialProductItem> tempItemList = new List<MaterialProductItem>();

                            //GET LIST OF PRODUCTS in Product

                            IEnumerable<Product> productQuery = sqldbconnection.Query<Product>("SELECT id, name FROM Product");
                            foreach (Product product in productQuery)
                            {
                                Console.WriteLine($"Id: {product.Id} Name: {product.Name}");
                            }

                            Console.WriteLine();
                            Console.WriteLine("Please add the product you wish to produce: ");
                            int userProductSelection = Convert.ToInt32(Console.ReadLine());

                            //Get list of Materials to be used to produce the product:
                            IEnumerable<MaterialToProduct_Prod> getmaterialUsedForProduct = sqldbconnection.Query<MaterialToProduct_Prod>("SELECT MaterialToProduct.ProductID, MaterialToProduct.MaterialID, Material.name FROM MaterialToProduct INNER JOIN Material ON MaterialToProduct.MaterialID = Material.id WHERE ProductID = @productId;",
                                new MaterialToProduct_Prod { productId = userProductSelection });

                            Console.WriteLine();
                            Console.WriteLine("Listing Materials that can be used to produce the product: ");
                            foreach (MaterialToProduct_Prod materialtoproduct_prod in getmaterialUsedForProduct)
                            {
                                Console.WriteLine($"ProductID: {materialtoproduct_prod.productId} MaterialID: {materialtoproduct_prod.materialId} MaterialName: {materialtoproduct_prod.name}");
                            }
                            Console.ForegroundColor = ConsoleColor.DarkYellow;
                            Console.WriteLine("Press any key to continue...");
                            Console.ReadLine();
                            Console.ResetColor();

                            int noofmaterials = getmaterialUsedForProduct.Count();
                            Console.WriteLine($"Noof materials: {noofmaterials}");
                            int i = 0;



                            while (i < noofmaterials)
                            {
                                IEnumerable<ProductionQueue> productionQuery = sqldbconnection.Query<ProductionQueue>("SELECT ProductionQueue.id, ProductionQueue.MaterialId, ProductionQueue.Quantity, ProductionQueue.Priority, Material.Name FROM ProductionQueue INNER JOIN Material ON ProductionQueue.MaterialId = Material.Id");

                                Console.WriteLine();
                                Console.ForegroundColor = ConsoleColor.DarkYellow;
                                Console.WriteLine("Listing all material availible in productionqueue: ");
                                Console.ResetColor();
                                foreach (ProductionQueue productionqueue in productionQuery)
                                {
                                    Console.WriteLine($"Id: {productionqueue.id} MaterialId: {productionqueue.materialId} Quantity: {productionqueue.quantity} Priority: {productionqueue.priority} MaterialName: {productionqueue.name}");
                                }


                                Console.WriteLine();
                                Console.WriteLine("Please enter the ProductionQueueID of the Queued product you wish to start production on: ");
                                int inputProductionQueueId = Convert.ToInt32(Console.ReadLine());
                                Console.WriteLine();

                                IEnumerable<ProductionQueue> productionQueueQuery2 = sqldbconnection.Query<ProductionQueue>("SELECT ProductionQueue.id, ProductionQueue.MaterialId, ProductionQueue.Quantity, ProductionQueue.Priority, Material.Name FROM ProductionQueue INNER JOIN Material ON ProductionQueue.MaterialId = Material.Id WHERE ProductionQueue.id = @id",
                                                                   new ProductionQueue { id = inputProductionQueueId });

                                int materialIdForProduction = productionQueueQuery2.Select(x => x.materialId).FirstOrDefault();
                                int quantityForProduction = productionQueueQuery2.Select(x => x.quantity).FirstOrDefault();
                                string? materialnameForProduction = productionQueueQuery2.Select(x => x.name).FirstOrDefault();

                                Console.ForegroundColor = ConsoleColor.DarkYellow;
                                var tempItem = new MaterialProductItem() { materialIdItem = materialIdForProduction, materialquantityItem = quantityForProduction, materialNameItem = materialnameForProduction };
                                tempItemList.Add(tempItem);

                                foreach (MaterialProductItem materialproductitem in tempItemList)
                                {
                                    Console.WriteLine("Material Added: ");
                                    Console.WriteLine($"{materialproductitem.materialNameItem} | {materialproductitem.materialIdItem} | {materialproductitem.materialquantityItem}");
                                }

                                sqldbconnection.Execute("DELETE FROM ProductionQueue WHERE Id = @id",
                                                                       new ProductionQueue { id = inputProductionQueueId });

                                Console.ResetColor();
                                Console.WriteLine("Press any key to continue...");
                                Console.ReadLine();
                                i++;
                            }

                            Console.Clear();
                            Console.WriteLine("Creating new Products");
                            int minQuantity = tempItemList.Min(item => item.materialquantityItem);
                            Console.WriteLine($" QTY to Produce: {minQuantity}");

                            sqldbconnection.Execute("INSERT INTO ProductQueueForStorage (ProductId, Quantity) VALUES (@productid, @quantity)",
                                new ProductQueueForStorage { productid = userProductSelection, quantity = minQuantity });

                            Console.ForegroundColor = ConsoleColor.DarkYellow;
                            Console.WriteLine("Products created and placed in ProductQueueForStorage - press any key to continue");
                            Console.ResetColor();
                            Console.ReadLine();
                            break;
                    }

                    break;

                case "4": // Customer Order
                    Console.Clear();
                    Console.ForegroundColor = ConsoleColor.DarkYellow;
                    Console.WriteLine("CustomerOrder");
                    Console.WriteLine("----------------------------------------");
                    Console.WriteLine("Select an option");
                    Console.WriteLine("1. Search for an Ordernumber/OrderID");
                    Console.WriteLine("2. Add a new Customer Order");
                    Console.WriteLine("3. Delete a Customer Order");
                    Console.ResetColor();

                    switch(Console.ReadLine())
                    {
                        case "1":
                            Console.Clear();
                            Console.ForegroundColor = ConsoleColor.DarkYellow;
                            Console.WriteLine("Please enter a Ordernumber/OrderID.");
                            
                            //
                            int inputCustomerOrderID = Convert.ToInt32(Console.ReadLine());
                            Console.WriteLine("----------------------------------------------------------------------------------");
                            Console.ResetColor();

                            IEnumerable<ProductOrder_Customer> resultQueryCustomerOrder = sqldbconnection.Query<ProductOrder_Customer>("SELECT ProductOrder.Id, Customer.Surname, Customer.LastName, Customer.Phonenumber, ProductOrder.IsDelivered, ProductOrder.IsPacked, ProductOrder.IsSent FROM ProductOrder INNER JOIN Customer ON ProductOrder.CustomerId = Customer.Id WHERE ProductOrder.Id = @id;",
                                                               new CustomerOrder { id = inputCustomerOrderID });

                            IEnumerable<ProductToOrder_Product> resultQueryProductToOrder = sqldbconnection.Query<ProductToOrder_Product>("SELECT Id, ProductId, OrderId, OrderQuantity, Product.Name FROM ProductToOrder INNER JOIN Product ON ProductToOrder.ProductId =  Product.Id WHERE ProductToOrder.OrderId = @orderid",
                                                                                              new ProductToOrder_Product { orderid = inputCustomerOrderID });

                            foreach (ProductOrder_Customer productorder_customer in resultQueryCustomerOrder)
                            {
                                Console.WriteLine($"Ordernumber: {productorder_customer.id}");
                                Console.WriteLine($"Name: {productorder_customer.Surname} {productorder_customer.Lastname} Phone: {productorder_customer.Phonenumber}");
                                Console.WriteLine($"Status - Delivered: {productorder_customer.isDelivered} Sent: {productorder_customer.isSent} Packed: {productorder_customer.isPacked}");
                            }

                            if (resultQueryCustomerOrder.Count() == 0)
                            {
                                Console.ForegroundColor = ConsoleColor.DarkYellow;
                                Console.WriteLine("No Customer Orders found");
                                Console.ResetColor();
                                Console.ReadLine();
                                break;
                            }

                            Console.WriteLine();
                            Console.WriteLine("Products:");
                            foreach (ProductToOrder_Product productToorder_product in resultQueryProductToOrder)
                            {
                                Console.WriteLine($" {productToorder_product.Name} Quantity: {productToorder_product.orderQuantity}");
                            }
                            Console.WriteLine("----------------------------------------------------------------------------------");
;                            

                            Console.ForegroundColor = ConsoleColor.DarkYellow;
                            Console.WriteLine();
                            Console.WriteLine("Press any key to continue...");
                            Console.ReadLine();
                            Console.ResetColor();

                            break;

                        case "2":
                            Console.Clear();
                            Console.ForegroundColor = ConsoleColor.DarkYellow;
                            Console.WriteLine("Create an Order");
                            Console.WriteLine("----------------------------------------");
                            Console.ResetColor();
                            Console.WriteLine();

                            Console.Write("Please enter customer name: ");
                            string? inputCustomerSurName = Console.ReadLine();


                            IEnumerable<Customer> customerSearchQuery = sqldbconnection.Query<Customer>("SELECT id, surname, lastname, Address, Email, Phonenumber FROM Customer WHERE surname LIKE '%' + @Surname + '%'",
                                                               new Customer { Surname = inputCustomerSurName });

                            foreach (Customer customer in customerSearchQuery)
                            {
                                Console.WriteLine($"Id: {customer.Id} Surname: {customer.Surname} Lastname: {customer.Lastname} Address: {customer.Address} Phone: {customer.Phonenumber}");
                            }

                            Console.Write("Please enter your CustomerId: ");
                            int inputCustomerId = Convert.ToInt32(Console.ReadLine());

                            sqldbconnection.Execute("INSERT INTO ProductOrder (CustomerId, isPacked, isSent, isDelivered) VALUES (@CustomerId, @isPacked, @isSent, @isDelivered)",
                                                               new CustomerOrder { customerid = inputCustomerId, isPacked = false, isSent = false, isDelivered = false });

                            //Get a new OrderID from the Database
                            IEnumerable<CustomerOrder> customerOrderSearchQuery = sqldbconnection.Query<CustomerOrder>("SELECT id FROM ProductOrder");
                            int orderIdCount =  customerOrderSearchQuery.Count();

                            bool addNewProduct = true;

                            while(addNewProduct == true)
                            {
                                Console.Write("Please enter the name of the product you want to add: ");
                                string? inputSearchQuery = Console.ReadLine();

                                IEnumerable<Product> productSearchQuery = sqldbconnection.Query<Product>("SELECT id, name FROM Product WHERE name LIKE '%' + @Name + '%'",
                                    new Product { Name = inputSearchQuery });

                                foreach (Product product in productSearchQuery)
                                {
                                    Console.WriteLine($"Id: {product.Id} Name: {product.Name}");
                                }

                                if (productSearchQuery.Count() == 0)
                                {
                                    Console.ForegroundColor = ConsoleColor.DarkYellow;
                                    Console.WriteLine("No materials found");
                                    Console.ResetColor();
                                    Console.ReadLine();
                                    break;
                                }

                                Console.Write("Please enter the Id you wish to add to the Order: ");
                                int inputProductId = Convert.ToInt32(Console.ReadLine());

                                Console.Write("Please enter the Quantity you wish to add to the Order: ");
                                int inputProductQuantity = Convert.ToInt32(Console.ReadLine());

                                sqldbconnection.Execute("INSERT INTO ProductToOrder (ProductID, OrderID, OrderQuantity) VALUES (@productid, @orderid, @orderQuantity)",
                                    new ProductToOrder { productid = inputProductId, orderid = orderIdCount, orderQuantity = inputProductQuantity });

                                Console.WriteLine();
                                Console.Write("Product added successfully to Order");
                                Console.WriteLine("Add another product by pressing key: N ");
                                Console.WriteLine("Continue by pressing key: A");

                                string? userSelection = Console.ReadLine();

                                if (userSelection == "a")
                                {
                                    addNewProduct = false;
                                }

                            }

                            Console.WriteLine();
                            Console.Write("Order added successfully - Press any key to continue...");
                            Console.ReadLine();
                            break;

                            case "3": //Delete Order
                            Console.Clear();
                            Console.ForegroundColor = ConsoleColor.DarkYellow;
                            Console.WriteLine("Delete an Order");
                            Console.WriteLine("----------------------------------------");
                            Console.ResetColor();
                            Console.WriteLine();

                            try
                            {
                                Console.WriteLine("Please enter Ordernumber: ");
                                int inputOrderNumber = Convert.ToInt32(Console.ReadLine());

                                sqldbconnection.Execute("DELETE FROM ProductToOrder WHERE OrderId = @orderid",
                                    new ProductToOrder { orderid = inputOrderNumber });
                                sqldbconnection.Execute("DELETE FROM ProductOrder WHERE Id = @id",
                                    new CustomerOrder { id = inputOrderNumber });
                            }
                            catch (Exception ex)
                            {
                                Console.WriteLine($"Error, could not complete request: {ex.Message}");
                                Console.WriteLine("Press any key to continue");
                                Console.ReadLine();
                                break;
                                
                            }

                            Console.WriteLine("Delete successful - press any key to continue");
                            Console.ReadLine();

                            break;

                    }
                    break;

                case "5": // Customer
                    Console.Clear();
                    Console.Clear();
                    Console.WriteLine("Select an option");
                    Console.WriteLine("1. List all Customers"); // KLAR
                    Console.WriteLine("2. Add a new Customer"); // KLAR
                    Console.WriteLine("3. Update a Customer"); // KLAR
                    Console.WriteLine("4. Delete a Customer"); // KLAR

                    switch (Console.ReadLine())
                    {
                        case "1":
                            Console.Clear();
                            Console.ForegroundColor = ConsoleColor.DarkYellow;
                            Console.WriteLine("Listing all customer:");
                            Console.WriteLine("----------------------------------------");

                            IEnumerable<Customer> result = sqldbconnection.Query<Customer>("SELECT * FROM Customer");

                            foreach (Customer customer in result)
                            {
                                Console.WriteLine($"Id: {customer.Id} Name: {customer.Surname} {customer.Lastname}.  Address: {customer.Address}  Email: {customer.Email}  Phonenumber: {customer.Phonenumber}");
                            }
                            Console.ResetColor();
                            Console.ReadLine();
                            break;

                        case "2":
                            Console.Clear();
                            Console.ForegroundColor = ConsoleColor.DarkYellow;
                            Console.WriteLine("Add a new customer");
                            Console.WriteLine("----------------------------------------");

                            Console.Write("Please enter the Name of your new customer: ");
                            string? inputSurName = Console.ReadLine();
                            Console.WriteLine();

                            Console.Write("Please enter the Lastname of your new customer: ");
                            string? inputLastName = Console.ReadLine();
                            Console.WriteLine();

                            Console.Write("Please enter the Address of your new customer: ");
                            string? inputAdress = Console.ReadLine();
                            Console.WriteLine();

                            Console.Write("Please enter the Email of your new customer: ");
                            string? inputEmail = Console.ReadLine();
                            Console.WriteLine();

                            Console.Write("Please enter the Phonenumber of your new customer: ");
                            string? inputPhonenumber = Console.ReadLine();

                            sqldbconnection.Execute("INSERT INTO Customer (Surname, Lastname, Address, Email, Phonenumber) VALUES (@Surname, @Lastname, @Address, @Email, @Phonenumber)",
                                new Customer { Surname = inputSurName, Lastname = inputLastName, Address = inputAdress, Email = inputEmail, Phonenumber = inputPhonenumber });
                            Console.WriteLine();
                            Console.Write("Customer added successfully - Press any key to continue...");
                            Console.ReadKey();
                            break;

                        case "3":
                            Console.Clear();
                            Console.ForegroundColor = ConsoleColor.DarkYellow;
                            Console.WriteLine("Update a Customer");
                            Console.WriteLine("----------------------------------------");
                            Console.ResetColor();

                            Console.Write("Please enter the name of the Customer you want to update: ");
                            string? inputUpdateCustomer = Console.ReadLine();

                            IEnumerable<Customer> updateCustomerQuery = sqldbconnection.Query<Customer>("SELECT customer.id, surname, lastname, address, email, phonenumber FROM Customer WHERE Surname LIKE '%' + @Surname + '%' ",
                                new Customer { Surname = inputUpdateCustomer });

                            foreach (Customer customer in updateCustomerQuery)
                            {
                                Console.WriteLine($"Id: {customer.Id} Name: {customer.Surname} {customer.Lastname}  Address: {customer.Address}  Email: {customer.Email}  Phonenumber: {customer.Phonenumber}");
                            }

                            if (updateCustomerQuery.Count() == 0)
                            {
                                Console.ForegroundColor = ConsoleColor.DarkYellow;
                                Console.WriteLine("No customers found");
                                Console.ResetColor();
                                Console.ReadLine();
                                break;
                            }

                            Console.WriteLine("Please the ID for the Customer you would like to change:");
                            int inputUpdateCustomerId = Convert.ToInt32(Console.ReadLine());

                            Console.WriteLine("Please enter the new Surname:");
                            string? inputUpdatedSurName = Console.ReadLine();

                            Console.WriteLine("Please enter the new Lastname:");
                            string? inputUpdatedLastname = Console.ReadLine();

                            Console.WriteLine("Please enter the new Address:");
                            string? inputUpdatedAddress = Console.ReadLine();


                            Console.WriteLine("Please enter the new Email:");
                            string? inputUpdatedEmail = Console.ReadLine();

                            Console.WriteLine("Please enter the new Phonenumber:");
                            string? inputUpdatedPhonenumber = Console.ReadLine();

                            sqldbconnection.Execute("UPDATE Customer SET Surname = @Surname, Lastname = @Lastname, Address = @Address, Email = @Email, Phonenumber = @Phonenumber WHERE Id = @Id ",
                            new Customer { Id = inputUpdateCustomerId, Surname = inputUpdatedSurName, Lastname = inputUpdatedLastname, Address = inputUpdatedAddress, Email = inputUpdatedEmail, Phonenumber = inputUpdatedPhonenumber });

                            Console.WriteLine("Successfully updated. Press any key to continue.");
                            Console.ReadLine();
                            break;

                        case "4":
                            Console.Clear();
                            Console.ForegroundColor = ConsoleColor.DarkYellow;
                            Console.WriteLine("Delete a Customer");
                            Console.WriteLine("----------------------------------------");
                            Console.ResetColor();

                            Console.Write("Please enter the name of the Customer you want to delete ");
                            string? inputCustomerDeleteString = Console.ReadLine();

                            IEnumerable<Customer> deleteCustomerQuery = sqldbconnection.Query<Customer>("SELECT customer.id, surname, lastname, address, email, phonenumber FROM Customer WHERE Surname LIKE '%' + @Surname + '%' ",
                                new Customer { Surname = inputCustomerDeleteString });

                            foreach (Customer customer in deleteCustomerQuery)
                            {
                                Console.WriteLine($"Id: {customer.Id} Name: {customer.Surname} {customer.Lastname}  Address: {customer.Address}  Email: {customer.Email}  Phonenumber: {customer.Phonenumber}");
                            }

                            if (deleteCustomerQuery.Count() == 0)
                            {
                                Console.ForegroundColor = ConsoleColor.DarkYellow;
                                Console.WriteLine("No customers found");
                                Console.ResetColor();
                                Console.ReadLine();
                                break;
                            }

                            Console.Write("Please enter the Id you wish to delete: ");
                            int inputDeletedCustomerId = Convert.ToInt32(Console.ReadLine());
                            Console.WriteLine();
                            Console.Clear();
                            sqldbconnection.Execute("DELETE FROM Customer WHERE Id = @Id",
                                new Customer { Id = inputDeletedCustomerId });
                            Console.WriteLine("Customer deleted successfully - Press any key to continue...");
                            Console.ReadLine();

                            break;
                    }

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
