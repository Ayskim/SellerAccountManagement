using System;

namespace SellerManagement 
{
    internal class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("SHOPEE ACCOUNT MANAGEMENT");
            Console.WriteLine("Please set up your account. Set now");

            char choose;

            Console.WriteLine("\nACCOUNT & SECURITY");
            Console.Write("1. Create account.\n2. Search name \n3. Update information.\n4. Delete your account\n5. Exit\n");

            choose = Console.ReadKey().KeyChar;
            Console.WriteLine();

            switch (choose)
            {
                case '1':
                    Console.WriteLine("ADD ACCOUNT");

                    Console.WriteLine("\nEnter Seller Name: ");
                    string name = Console.ReadLine();

                    Console.WriteLine("Enter email address: ");
                    string emailAdd = Console.ReadLine();

                    Console.WriteLine("Enter phone number: ");
                    string phoneNum = Console.ReadLine();

                    Console.WriteLine("Enter present address: ");
                    string preAdd = Console.ReadLine();

                    Console.WriteLine("\nCreated Successfully.");

                    break;

                case '2':
                    Console.WriteLine("\nSEARCH ACCOUNT");

                    Console.WriteLine("Enter...");
                    string searchName = Console.ReadLine();

                    Console.WriteLine("Searching account...");

                    break;

                case '3':
                    Console.WriteLine("UPDATE INFORMATION");

                    Console.WriteLine("\nMy Profile");
                    Console.WriteLine("\nName: ");
                    Console.WriteLine("Username: ");
                    Console.WriteLine("Bio: ");
                    Console.WriteLine("Gender");
                    Console.WriteLine("Birthday: ");
                    Console.WriteLine("Phone: ");
                    Console.WriteLine("Email: ");
                    break;

                case '4':
                    Console.WriteLine("REQUEST ACCOUNT DELETION");

                    Console.WriteLine("Do you want to delete your account (Yes/No): ");

                    string ans = Console.ReadLine().ToLower();

                    if(ans == "yes")
                    {
                        Console.WriteLine("Please Note. Account Deletion is Irreversable");
                        Console.WriteLine("Proceed to Delete. Deleting...");
                    }else if (ans == "no"){
                        Console.WriteLine("Cancelled Account Deletion");
                    }else
                    {
                        Console.WriteLine("Invalid Input");
                    }

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
