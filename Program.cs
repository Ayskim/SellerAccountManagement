using System;

namespace SellerManagement 
{
    internal class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("SELLER ACCOUNT MANAGEMENT");

            char choose;

            Console.Write("1. Create new seller account\n2. View existing seller accounts\n3. Update a seller account\n4. Delete a seller account\n5. Exit\n");

            choose = Console.ReadKey().KeyChar;
            Console.WriteLine();

            switch (choose)
            {
                case '1':
                    Console.WriteLine("Add a account");
                    break;

                case '2':
                    Console.WriteLine("Search account: ");
                    break;

                case '3':
                    Console.WriteLine("Update Information: ");
                    break;

                case '4':
                    Console.WriteLine("Delete account: ");
                    break;

                case '5':
                    Console.WriteLine("Exit.");
                    break;

                default:
                    Console.WriteLine("Invalid input. Select an option.");
                    break;
            }
        }
    }
}
