using System;
using System.Text.Json;

namespace ProductCatalogue // Note: actual namespace depends on the project name.
{
    internal class Program
    {
        static void Main(string[] args)
        {

            //Bag bag1 = new Bag(20, "black", "Bag1");
            //Console.WriteLine(bag1.CalculateTax());
            bool showMenu = true;
            while (showMenu)
            {
                showMenu = MainMenu();
            }

             static bool MainMenu()
            {
                Console.Clear();
                Console.WriteLine("Please select an option \n 1.Add a product \n 2.Remove a product \n 3.View a Catalogue \n 4.Remove a Catalogue \n 5.Calculate Price inc GST \n 6.Total Catalogue Price");
         

                switch (Console.ReadLine())
                {
                    case "1":
                        Catalogue<Bag> BagCatalogue = new Catalogue<Bag>();
                        Catalogue<Shoes> ShoeCatalogue = new Catalogue<Shoes>();
                        string name = "";
                        double price = 0;
                        string colour = "";
                        float size = 0;
                        bool x = true;
                        string filepath = "";

                        while (x == true)
                        {
                            Console.WriteLine("What product would you like to add? \n 1.Bag \n 2.Shoe \n 3.Exit");
                            int addOption = Int32.Parse(Console.ReadLine());

                            if (addOption == 3)
                            {
                                x = false;
                            }
                                if (addOption == 1)
                            {
                                Console.WriteLine("Enter Bag Name");
                                name = Console.ReadLine();
                                Console.WriteLine("Product Details:Enter Price Of Your Bag");
                                price = Int32.Parse(Console.ReadLine());
                                Console.WriteLine("Product Details:Enter The Colour Of Your Bag");
                                colour = Console.ReadLine();
                                if (name.Length == 0 || price < 0 || colour.Length == 0)
                                {
                                    Console.WriteLine("Product Details Incomplete. Please Start Again");
                                    x = false;

                                }
                                else
                                {
                                    BagCatalogue.Add(name, Bag.CreateABag(name, price, colour));
                                    Console.Write($"Note:Price Including Tax of {name} is - ");
                                    Console.WriteLine(Bag.CreateABag(name, price, colour).CalculateTax());

                                }
                                filepath = Path.Combine(Directory.GetCurrentDirectory(), "BagCatalogue.json");
                                File.WriteAllText(filepath, SaveCat.serialise(BagCatalogue));



                            }
                            if (addOption == 2)
                            {

                                Console.WriteLine("Enter Shoe Name");
                                name = Console.ReadLine();
                                Console.WriteLine("Product Details:Enter Price Of The Shoes");
                                price = Int32.Parse(Console.ReadLine());
                                Console.WriteLine("Product Details:Enter The Shoe Size");
                                size = Int32.Parse(Console.ReadLine());
                                if (name.Length == 0 || price < 0 || size < 0)
                                {
                                    Console.WriteLine("Product Details Incomplete. Please Start Again");
                                    x = false;
                                }
                                else ShoeCatalogue.Add(name, Shoes.CreateAShoe(price, size, name));
                                 filepath = Path.Combine(Directory.GetCurrentDirectory(), "ShoeCatalogue.json");
                                File.WriteAllText(filepath, SaveCat.serialise(ShoeCatalogue));
                            }

                          

                        }
                        return true;
                    case "2":
                        Console.WriteLine("What product would you like to remove? \n 1.Bag \n 2.Shoe");
                        int RemoveOption = Int32.Parse(Console.ReadLine());
                        string BagData = File.ReadAllText(Path.Combine(Directory.GetCurrentDirectory(), "BagCatalogue.json"));
                        BagCatalogue = JsonSerializer.Deserialize<Catalogue<Bag>>(BagData);
                        if (RemoveOption == 1)
                        {
                            Console.WriteLine("Enter The Name Of The Bag You'd Like To Remove");
                            name = Console.ReadLine();
                            BagCatalogue.Remove(name);
                            filepath = Path.Combine(Directory.GetCurrentDirectory(), "BagCatalogue.json");
                            File.WriteAllText(filepath, SaveCat.serialise(BagCatalogue));
                        }
                        
                        if(RemoveOption == 2)
                        {
                            string ShoeData = File.ReadAllText(Path.Combine(Directory.GetCurrentDirectory(), "ShoeCatalogue.json"));
                            ShoeCatalogue = JsonSerializer.Deserialize<Catalogue<Shoes>>(ShoeData);
                            Console.WriteLine("Enter The Name Of The Shoe You'd Like To Remove");
                            name = Console.ReadLine();
                            ShoeCatalogue.Remove(name);
                            filepath = Path.Combine(Directory.GetCurrentDirectory(), "ShoeCatalogue.json");
                            File.WriteAllText(filepath, SaveCat.serialise(ShoeCatalogue));
                        }

                        return true;
                    case "3":
                        bool y = true;
                        while (y == true)
                        {
                            Console.WriteLine("Which Catalogue Would You Like To View? \n 1.Bag \n 2.Shoe \n 3.Exit");
                            int ViewOption = Int32.Parse(Console.ReadLine());

                            if (ViewOption == 3)
                            {
                                y = false;
                            }
                            if (ViewOption == 1)
                            {
                                BagData = File.ReadAllText(Path.Combine(Directory.GetCurrentDirectory(), "BagCatalogue.json"));
                                BagCatalogue = JsonSerializer.Deserialize<Catalogue<Bag>>(BagData);
                                foreach (KeyValuePair<string, Bag> pair in BagCatalogue.Dict)
                                {
                                   
                                    Console.WriteLine($"Bag Name:{pair.Key} - {pair.Value}");

                                }
                            }
                            if (ViewOption == 2)
                            {
                                string ShoeData = File.ReadAllText(Path.Combine(Directory.GetCurrentDirectory(), "ShoeCatalogue.json"));
                                ShoeCatalogue = JsonSerializer.Deserialize<Catalogue<Shoes>>(ShoeData);
                                foreach (KeyValuePair<string, Shoes> pair in ShoeCatalogue.Dict)
                                {
                                    Console.WriteLine($"Shoe Name:{pair.Key} - {pair.Value}");
                                }
                            }
                        }

                        return true;

                    case "4":
                        bool z = true;
                        while (z == true)
                        {
                            Console.WriteLine("Which Catalogue Would You Like To Clear? \n 1.Bag \n 2.Shoe \n 3.Exit");
                            int ClearOption = Int32.Parse(Console.ReadLine());

                            if (ClearOption == 3)
                            {
                               z = false;
                            }
                            if (ClearOption == 1)
                            {
                                BagData = File.ReadAllText(Path.Combine(Directory.GetCurrentDirectory(), "BagCatalogue.json"));
                                BagCatalogue = JsonSerializer.Deserialize<Catalogue<Bag>>(BagData);
                                BagCatalogue.Clear();
                                filepath = Path.Combine(Directory.GetCurrentDirectory(), "BagCatalogue.json");
                                File.WriteAllText(filepath, SaveCat.serialise(BagCatalogue));
                                Console.WriteLine("You have deleted content in Bag Cataolgue");


                            }
                            if (ClearOption == 2)
                            {
                                string ShoeData = File.ReadAllText(Path.Combine(Directory.GetCurrentDirectory(), "ShoeCatalogue.json"));
                                ShoeCatalogue = JsonSerializer.Deserialize<Catalogue<Shoes>>(ShoeData);
                                ShoeCatalogue.Clear();
                                Console.WriteLine("You have deleted content in Shoe Cataolgue");
                                filepath = Path.Combine(Directory.GetCurrentDirectory(), "ShoeCatalogue.json");
                                File.WriteAllText(filepath, SaveCat.serialise(ShoeCatalogue));

                            }

                        }


                        return true;
                    case "5":

                        bool a = true;
                        while (a == true)
                        {
                            Console.WriteLine("Find the Price of Bag Item After Tax.\n 1.Bag \n 2.Shoe \n 3.Exit");
                            int TaxPriceOption = Int32.Parse(Console.ReadLine());

                            if (TaxPriceOption == 3)
                            {
                                a = false;
                            }
                            if (TaxPriceOption == 1)
                            {
                                Console.WriteLine("Enter Bag Name");
                                name = Console.ReadLine();
                                Console.WriteLine("Product Details:Enter Price Of Your Bag");
                                price = Int32.Parse(Console.ReadLine());
                                Console.WriteLine("Product Details:Enter The Colour Of Your Bag");
                                colour = Console.ReadLine();
                                if (name.Length == 0 || price < 0 || colour.Length == 0)
                                {
                                    Console.WriteLine("Product Details Incomplete. Please Start Again");
                                    a = false;

                                }
                                else
                                {
                                    Console.WriteLine($"Price Including Tax of {name}");
                                    Console.WriteLine(Bag.CreateABag(name, price, colour).CalculateTax());

                                }
                            }
                        }

                            return true;

                    case "6":
                        bool b = true;
                        while (b == true)
                        {
                            Console.WriteLine("Which Catalogue Would You Like To Calaulate Total Price inc Tax? \n 1.Bag \n 2.Shoe \n 3.Exit");
                            int TotalTaxPriceOption = Int32.Parse(Console.ReadLine());
                            if (TotalTaxPriceOption == 3)
                            {
                                b = false;
                            }
                            if (TotalTaxPriceOption == 1)
                            {
                                BagData = File.ReadAllText(Path.Combine(Directory.GetCurrentDirectory(), "BagCatalogue.json"));
                                BagCatalogue = JsonSerializer.Deserialize<Catalogue<Bag>>(BagData);
                                Console.Write("Total Prize (inc tax) of Bag Catalogue is - ");
                                Console.WriteLine(BagCatalogue.CalculateTotal());
                            }
                            if (TotalTaxPriceOption == 2)
                            {
                                string ShoeData = File.ReadAllText(Path.Combine(Directory.GetCurrentDirectory(), "ShoeCatalogue.json"));
                                ShoeCatalogue = JsonSerializer.Deserialize<Catalogue<Shoes>>(ShoeData);
                                Console.Write("Total Prize (inc tax) of Shoe Catalogue is - ");
                                Console.WriteLine(ShoeCatalogue.CalculateTotal());
                            }

                        }

                        return true;
                    default:
                        return true;
                }
            }


         

         
           

            

            //if (MainMenuOptions == 2)
            //{
            //    Console.WriteLine("What product type would you like to remove? \n 1.Bag \n 2.Shoe");
            //    int removeOption = Int32.Parse(Console.ReadLine());

            //    if (removeOption == 1)
            //    {
            //        Console.WriteLine("Enter Product Name");

            //        BagCatalogue.Names

                   
            //    }
            //}







            // Bag bag1 = new Bag(20, "black", "Bag1");
            // Bag bag2 = new Bag(50, "Red", "Bag2");
            // //Shoes shoe1 = new Shoes(100, 7, "nike");
            // //Shoes shoe2 = new Shoes(200, 8, "nike1");

            // //shoe1.CalculateTax();
            // //Console.WriteLine(shoe1.Price);
            // //shoe2.CalculateTax();
            // //Console.WriteLine(shoe2.Price);


            // bag1.CalculateTax();
            // Console.WriteLine(bag1.Price);
            // bag2.CalculateTax();
            // Console.WriteLine(bag2.Price);

            //// Catalogue<Shoes> ShoeCatalogue = new Catalogue<Shoes>();
            // Catalogue<Bag> BagCatalogue = new Catalogue<Bag>();

            // //ShoeCatalogue.Add(shoe1);
            // //Console.WriteLine(ShoeCatalogue);
            // //ShoeCatalogue.Add(shoe2);
            // //ShoeCatalogue.Remove(shoe1);

            // BagCatalogue.Add(bag1);
            // BagCatalogue.Add(bag2);

            // //Console.WriteLine(ShoeCatalogue.CalculateTotal());
            // Console.WriteLine(BagCatalogue.CalculateTotal());


            // Console.WriteLine("Hello World!");



        }


    


    }
}