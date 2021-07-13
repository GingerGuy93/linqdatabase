using System;
using System.Linq;
using Microsoft.EntityFrameworkCore;
using DatabaseFirstLINQ.Models;
using System.Collections.Generic;

namespace DatabaseFirstLINQ
{
    class Problems
    {
        private ECommerceContext _context;

        public Problems()
        {
            _context = new ECommerceContext();
        }
        public void RunLINQQueries()
        {
            //ProblemOne();
            //ProblemTwo();
            //ProblemThree();
            //ProblemFour();
            //ProblemFive();
            //ProblemSix();
            //ProblemSeven();
            //ProblemEight();
            //ProblemNine();
            //ProblemTen();
            //ProblemEleven();
            //ProblemTwelve();
            //ProblemThirteen();
            //ProblemFourteen();
            //ProblemFifteen();
            //ProblemSixteen();
            //ProblemSeventeen();
            //ProblemEighteen();
            //ProblemNineteen();
            //ProblemTwenty();
            //BonusOne();
            //BonusTwo();
            BonusThree();
        }

        // <><><><><><><><> R Actions (Read) <><><><><><><><><>
        private void ProblemOne()
        {
            var users = _context.Users.ToList().Count;
            Console.WriteLine(users);
            // Write a LINQ query that returns the number of users in the Users table.
            // HINT: .ToList().Count

        }

        private void ProblemTwo()
        {
            // Write a LINQ query that retrieves the users from the User tables then print each user's email to the console.
            var users = _context.Users;

            foreach (User user in users)
            {
                Console.WriteLine(user.Email);
            }

        }

        private void ProblemThree()
        {
            var products = _context.Products;
            var productsOverOneFifty = products.Where(p => p.Price > 150);
            foreach (var product in productsOverOneFifty)
            {
                Console.WriteLine(product.Name + " " + product.Price);
            }
            // Write a LINQ query that gets each product where the products price is greater than $150.
            // Then print the name and price of each product from the above query to the console.

        }

        private void ProblemFour()
        {
            // Write a LINQ query that gets each product that contains an "s" in the products name.
            // Then print the name of each product from the above query to the console.
            var products = _context.Products;
            var name = "s";
            var productName = products.Where(p => p.Name.Contains(name));

            foreach (var product in productName)
            {
                Console.WriteLine(product.Name);
            }
        }

        private void ProblemFive()
        {
            // Write a LINQ query that gets all of the users who registered BEFORE 2016
            // Then print each user's email and registration date to the console.
            var user = _context.Users;
            DateTime beforeDate = new DateTime(2016, 1, 1);
            Console.WriteLine(beforeDate);
            var dates = user.Where(u => u.RegistrationDate < beforeDate);

            foreach (var date in dates)
            {
                Console.WriteLine(date.Email + " " + date.RegistrationDate);
            }
        }

        private void ProblemSix()
        {
            // Write a LINQ query that gets all of the users who registered AFTER 2016 and BEFORE 2018
            // Then print each user's email and registration date to the console.
            var user = _context.Users;
            DateTime beforeDate = new DateTime(2017, 1, 1);
            DateTime afterDatte = new DateTime(2018, 1, 1);

            var dates = user.Where(u => u.RegistrationDate > beforeDate && u.RegistrationDate < afterDatte);

            foreach (var date in dates)
            {
                Console.WriteLine(date.Email + " " + date.RegistrationDate);
            }
        }

        // <><><><><><><><> R Actions (Read) with Foreign Keys <><><><><><><><><>

        private void ProblemSeven()
        {
            // Write a LINQ query that retreives all of the users who are assigned to the role of Customer.
            // Then print the users email and role name to the console.
            var customerUsers = _context.UserRoles.Include(ur => ur.Role).Include(ur => ur.User).Where(ur => ur.Role.RoleName == "Customer");
            foreach (UserRole userRole in customerUsers)
            {
                Console.WriteLine($"Email: {userRole.User.Email} Role: {userRole.Role.RoleName}");
            }
        }

        private void ProblemEight()
        {
            // Write a LINQ query that retreives all of the products in the shopping cart of the user who has the email "afton@gmail.com".
            // Then print the product's name, price, and quantity to the console.
            var customerUsers = _context.ShoppingCarts.Include(ur => ur.Product).Include(ur => ur.User).Where(ur => ur.User.Email == "afton@gmail.com");
            foreach (ShoppingCart shoppingCart in customerUsers)
            {
                Console.WriteLine($"Product Name: {shoppingCart.Product.Name} Price: {shoppingCart.Product.Price} Quantity: {shoppingCart.Quantity}");
            }
        }

        private void ProblemNine()
        {
            // Write a LINQ query that retreives all of the products in the shopping cart of the user who has the email "oda@gmail.com" and returns the sum of all of the products prices.
            // HINT: End of query will be: .Select(sc => sc.Product.Price).Sum();
            // Then print the total of the shopping cart to the console.
            var customerUsers = _context.ShoppingCarts.Include(ur => ur.Product).Include(ur => ur.User).Where(ur => ur.User.Email == "oda@gmail.com").Select(ur => ur.Product.Price).Sum();
            Console.WriteLine(customerUsers);
        }

        private void ProblemTen()
        {
            // Write a LINQ query that retreives all of the products in the shopping cart of users who have the role of "Employee".
            // Then print the user's email as well as the product's name, price, and quantity to the console.
            var employee = _context.UserRoles.Include(ur => ur.Role).Include(ur => ur.User).Where(ur => ur.Role.RoleName == "Employee").Select(u => u.User.Id);
            var employees = _context.ShoppingCarts.Include(ur => ur.Product).Include(p => p.User).Where(u => employee.Contains(u.UserId));

            foreach (var shopping in employees)
            {
                Console.WriteLine(shopping.User.Email + " " + shopping.Product.Name + " " + shopping.Product.Price + " " + shopping.Quantity);
            }
        }

        // <><><><><><><><> CUD (Create, Update, Delete) Actions <><><><><><><><><>

        // <><> C Actions (Create) <><>

        private void ProblemEleven()
        {
            // Create a new User object and add that user to the Users table using LINQ.
            User newUser = new User()
            {
                Email = "david@gmail.com",
                Password = "DavidsPass123"
            };
            _context.Users.Add(newUser);
            _context.SaveChanges();
        }

        private void ProblemTwelve()
        {
            // Create a new Product object and add that product to the Products table using LINQ.
            Product newProduct = new Product()
            {
                Name = "Monopoly",
                Description = "The most angering game in the world",
                Price = 20
            };
            _context.Products.Add(newProduct);
            _context.SaveChanges();
        }

        private void ProblemThirteen()
        {
            // Add the role of "Customer" to the user we just created in the UserRoles junction table using LINQ.
            var roleId = _context.Roles.Where(r => r.RoleName == "Customer").Select(r => r.Id).SingleOrDefault();
            var userId = _context.Users.Where(u => u.Email == "david@gmail.com").Select(u => u.Id).SingleOrDefault();
            UserRole newUserRole = new UserRole()
            {
                UserId = userId,
                RoleId = roleId
            };
            _context.UserRoles.Add(newUserRole);
            _context.SaveChanges();
        }

        private void ProblemFourteen()
        {
            // Add the product you create to the user we created in the ShoppingCart junction table using LINQ.
            var userId = _context.Users.Where(u => u.Email == "david@gmail.com").Select(u => u.Id).SingleOrDefault();
            var productId = _context.Products.Where(p => p.Id == 8).Select(p => p.Id).SingleOrDefault();
            var quantity = 1;

            ShoppingCart newShoppingCart = new ShoppingCart()
            {
                UserId = userId,
                ProductId = productId,
                Quantity = quantity
            };
            _context.ShoppingCarts.Add(newShoppingCart);
            _context.SaveChanges();
        }

        // <><> U Actions (Update) <><>

        private void ProblemFifteen()
        {
            // Update the email of the user we created to "mike@gmail.com"
            var user = _context.Users.Where(u => u.Email == "david@gmail.com").SingleOrDefault();
            user.Email = "mike@gmail.com";
            _context.Users.Update(user);
            _context.SaveChanges();
        }

        private void ProblemSixteen()
        {
            // Update the price of the product you created to something different using LINQ.
            var product = _context.Products.Where(p => p.Name == "Monopoly").SingleOrDefault();
            product.Price = 15;
            _context.Products.Update(product);
            _context.SaveChanges();
        }

        private void ProblemSeventeen()
        {
            // Change the role of the user we created to "Employee"
            // HINT: You need to delete the existing role relationship and then create a new UserRole object and add it to the UserRoles table
            // See problem eighteen as an example of removing a role relationship
            var userRole = _context.UserRoles.Where(ur => ur.User.Email == "mike@gmail.com").SingleOrDefault();
            _context.UserRoles.Remove(userRole);
            UserRole newUserRole = new UserRole()
            {
                UserId = _context.Users.Where(u => u.Email == "mike@gmail.com").Select(u => u.Id).SingleOrDefault(),
                RoleId = _context.Roles.Where(r => r.RoleName == "Employee").Select(r => r.Id).SingleOrDefault()
            };
            _context.UserRoles.Add(newUserRole);
            _context.SaveChanges();
        }

        // <><> D Actions (Delete) <><>

        private void ProblemEighteen()
        {
            // Delete the role relationship from the user who has the email "oda@gmail.com" using LINQ.
            var userRole = _context.UserRoles.Where(ur => ur.User.Email == "oda@gmail.com").SingleOrDefault();
            _context.UserRoles.Remove(userRole);
            _context.SaveChanges();
        }

        private void ProblemNineteen()
        {
            // Delete all of the product relationships to the user with the email "oda@gmail.com" in the ShoppingCart table using LINQ.
            // HINT: Loop
            var shoppingCartProducts = _context.ShoppingCarts.Where(sc => sc.User.Email == "oda@gmail.com");
            foreach (ShoppingCart userProductRelationship in shoppingCartProducts)
            {
                _context.ShoppingCarts.Remove(userProductRelationship);
            }
            _context.SaveChanges();
        }

        private void ProblemTwenty()
        {
            // Delete the user with the email "oda@gmail.com" from the Users table using LINQ.
            var user = _context.Users.Where(ur => ur.Email == "oda@gmail.com").SingleOrDefault();
            _context.Users.Remove(user);
            _context.SaveChanges();
        }

        // <><><><><><><><> BONUS PROBLEMS <><><><><><><><><>

        private void BonusOne()
        {
            // Prompt the user to enter in an email and password through the console.

            Console.WriteLine("Enter your Email");
            string email = Console.ReadLine();

            Console.WriteLine("Enter your Password");
            string password = Console.ReadLine();

            var users = _context.Users;

            foreach (User user in users)
            {
                if (user.Email == email && user.Password == password)
                {
                    Console.WriteLine($"{user.Email} You Are Signed In!");
                }
            }
            // Take the email and password and check if the there is a person that matches that combination.
            // Print "Signed In!" to the console if they exists and the values match otherwise print "Invalid Email or Password.".

        }

        private void BonusTwo()
        {
            // Write a query that finds the total of every users shopping cart products using LINQ.
            // Display the total of each users shopping cart as well as the total of the toals to the console.

            List<int> userId = _context.Users.Select(u => u.Id).ToList();
            decimal? everyone = 0;
            foreach (int id in userId)
            {
                var shoppingCart = _context.ShoppingCarts.Include(ur => ur.Product).Include(ur => ur.User).Where(ur => ur.User.Id == id).Select(ur => new { ur.Product.Price, ur.Quantity });
                decimal? total = 0;
                foreach (var product in shoppingCart)
                {
                    total += product.Price * product.Quantity;
                }
                everyone += total;
                Console.WriteLine($"User Id {id} has a total of {total}");
            }
            Console.WriteLine($"The total of everyones shopping cart is {everyone}");
        }

        // BIG ONE
        private void BonusThree()
        {
            // 1. Create functionality for a user to sign in via the console
            // 2. If the user succesfully signs in
            bool signedIn = false;
            User user = new User();
            void Credentials()
            {
                Console.WriteLine("Enter your Email");
                string email = Console.ReadLine();

                Console.WriteLine("Enter your Password");
                string password = Console.ReadLine();

                var valid = _context.Users.Where(user => user.Email == email).Where(user => user.Password == password).Any();
                    if (valid)
                    {
                        Console.WriteLine($"{user.Email} You Are Signed In!");
                        signedIn = true;
                        user = _context.Users.Where(user => user.Email == email).Where(user => user.Password == password).SingleOrDefault();
                    }
                    else
                    {
                        Console.WriteLine("Invalid Email Try Again!");
                    }
                
            }
                // a. Give them a menu where they perform the following actions within the console
                // View the products in their shopping cart
                // View all products in the Products table
                void Menu()
                {
                    Console.WriteLine("Main Menu");
                    Console.WriteLine("Press 1 to view your shopping cart");
                    Console.WriteLine("Press 2 to view available products");
                    string input = Console.ReadLine();

                    if (input == "1")
                    {
                        ShoppingCart();
                    }
                    else if (input == "2")
                    {
                        Products();
                    }
                }

                void ShoppingCart()
                {
                    var userCart = _context.ShoppingCarts.Include(ur => ur.Product).Include(ur => ur.User).Where(ur => ur.User.Id == user.Id);
                    foreach (var product in userCart)
                    {
                        Console.WriteLine($"Product ID: {product.Product.Id} Product Name: {product.Product.Name} Price: {product.Product.Price} Quantity: {product.Quantity}");
                    }
                    Console.WriteLine("Enter 0 to go back to main screen");
                    Console.WriteLine("If you want to delete something enter product ID and click enter");
                    string input = Console.ReadLine();
                    int result = Int32.Parse(input);
                        if (result == 0)
                        {
                            Menu();
                        }
                        else
                        {
                            Delete(result);
                        }
                    }

                void Products()
                {
                    var products = _context.Products;
                    //var userCart = _context.ShoppingCarts.Include(ur => ur.Product).Include(ur => ur.User).Where(ur => ur.User.Id == user.Id);
                    foreach (var product in products)
                    {
                        Console.WriteLine($"Product ID: {product.Id} Name: {product.Name} Description: {product.Description} Price: {product.Price}");
                    }
                    Console.WriteLine("To add a product to your shopping cart enter the product ID Number");
                    Console.WriteLine("To go back to the menu enter 0");
                    string input = Console.ReadLine();
                    int result = Int32.Parse(input);
                        if (result == 0)
                            {
                                 Menu();
                            }
                         else
                            {
                                Add(result);
                            }
                }

                void Add(int result)
                {
                    
                    var userCart = _context.ShoppingCarts.Include(ur => ur.Product).Include(ur => ur.User).Where(ur => ur.User.Id == user.Id);
                    List<int> productId = userCart.Select(ur => ur.Product.Id).ToList();
                    if (productId.Contains(result))
                    {
                        var item = _context.ShoppingCarts.Where(ur => ur.ProductId == result && ur.UserId == user.Id).SingleOrDefault();
                        item.Quantity += 1;
                        _context.ShoppingCarts.Update(item);
                        _context.SaveChanges();
                    }
                    else
                    {
                    ShoppingCart newProduct = new ShoppingCart()
                    {
                        UserId = user.Id,
                        ProductId = result,
                        Quantity = 1
                    };
                    _context.ShoppingCarts.Add(newProduct);
                    _context.SaveChanges();
                    }
                ShoppingCart();
                }

                void Delete(int result)
                {

                    var userCart = _context.ShoppingCarts.Include(ur => ur.Product).Include(ur => ur.User).Where(ur => ur.User.Id == user.Id);
                    List<int> productId = userCart.Select(ur => ur.Product.Id).ToList();
                    if (productId.Contains(result))
                    {
                            var item = _context.ShoppingCarts.Where(ur => ur.ProductId == result && ur.UserId == user.Id).SingleOrDefault();
                        if (item.Quantity == 1)
                        {
                             _context.ShoppingCarts.Remove(item);
                        }
                        else
                        {
                            item.Quantity -= 1;
                            _context.ShoppingCarts.Update(item);
                        }
                    _context.SaveChanges();
                    ShoppingCart();
                    }               
                }

            // Add a product to the shopping cart (incrementing quantity if that product is already in their shopping cart)
            // Remove a product from their shopping cart
            // 3. If the user does not succesfully sing in
            // a. Display "Invalid Email or Password"
            // b. Re-prompt the user for credentials
            while (!signedIn)
            {
                Credentials();
            }
            while (signedIn)
            {
                Menu();
                signedIn = false;
            }
        }
           
    }
}

