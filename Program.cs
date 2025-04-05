using System;
using System.Collections.Generic;

class Program
{
    static List<Package> packages = new List<Package>();
    static int nextId = 1;

    static void Main()
    {
        string input;
        do
        {
            ShowMenu();
            input = Console.ReadLine()?.Trim();

            switch (input)
            {
                case "1": AddPackage(); break;
                case "2": ListPackages(); break;
                case "3": SearchPackages(); break;
                case "4": MarkPickedUp(); break;
                case "5": Console.WriteLine("Exiting. Goodbye!"); break;
                default: Console.WriteLine("Invalid option. Try again."); break;
            }

        } while (input != "5");
    }

    static void ShowMenu()
    {
        Console.WriteLine("\n📦 Mailroom Console App");
        Console.WriteLine("1. Add New Package");
        Console.WriteLine("2. List All Packages");
        Console.WriteLine("3. Search Packages by Resident");
        Console.WriteLine("4. Mark Package as Picked Up");
        Console.WriteLine("5. Exit");
        Console.Write("Choose an option: ");
    }

    static void AddPackage()
    {
        Console.Write("Resident Name: ");
        string name = Console.ReadLine();

        Console.Write("Apartment Number: ");
        string apt = Console.ReadLine();

        Console.Write("Notes (optional): ");
        string notes = Console.ReadLine();

        packages.Add(new Package
        {
            Id = nextId++,
            ResidentName = name,
            ApartmentNumber = apt,
            Notes = notes,
            PickedUp = false
        });

        Console.WriteLine("✅ Package added!");
    }

    static void ListPackages()
    {
        if (packages.Count == 0)
        {
            Console.WriteLine("No packages in the system.");
            return;
        }

        Console.WriteLine("\n📦 All Packages:");
        foreach (var pkg in packages)
            pkg.Display();
    }

    static void SearchPackages()
    {
        Console.Write("Enter resident name to search: ");
        string search = Console.ReadLine()?.ToLower();

        var results = packages.FindAll(p => p.ResidentName.ToLower().Contains(search));

        if (results.Count == 0)
        {
            Console.WriteLine("No packages found.");
            return;
        }

        Console.WriteLine("\n📦 Matching Packages:");
        foreach (var pkg in results)
            pkg.Display();
    }

    static void MarkPickedUp()
    {
        Console.Write("Enter package ID to mark as picked up: ");
        if (int.TryParse(Console.ReadLine(), out int id))
        {
            var pkg = packages.Find(p => p.Id == id);
            if (pkg != null)
            {
                pkg.PickedUp = true;
                Console.WriteLine("✅ Package marked as picked up.");
            }
            else
            {
                Console.WriteLine("Package not found.");
            }
        }
        else
        {
            Console.WriteLine("Invalid ID.");
        }
    }
}
