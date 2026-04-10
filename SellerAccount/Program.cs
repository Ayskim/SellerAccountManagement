using System;
using SellerManagementModels;
using SellerManagementAppService;

namespace SellerManagement
{
    public class Program
    {
        static SellerAppService service = new SellerAppService();

        static void Main(string[] args)
        {
            Console.WriteLine("SHOPEE ACCOUNT MANAGEMENT");
            Console.WriteLine("Please set up your account. Set now");

            bool shop = true;

            while (shop)
            {
                chooseNum();
                char choose = Console.ReadKey().KeyChar;
                Console.WriteLine();

                switch (choose)
                {
                    case '1':
                        createAcc();
                        break;
                    case '2':
                        searchAcc();
                        break;
                    case '3':
                        updateInfo();
                        break;
                    case '4':
                        deleteAcc();
                        break;
                    case '5':
                        viewAcc();
                        break;
                    case '6':
                        Console.WriteLine("Exit.");
                        shop = false;
                        break;
                    default:
                        Console.WriteLine("Invalid input. Select an option.");
                        break;
                }
            }
        }

        static void chooseNum()
        {
            Console.WriteLine("\nACCOUNT & SECURITY");
            Console.WriteLine("Please select an option:");
            Console.WriteLine("\n--------------------------------------------------------");
            Console.WriteLine("[1]. Create account");
            Console.WriteLine("[2]. Search account");
            Console.WriteLine("[3]. Update information");
            Console.WriteLine("[4]. Delete your account");
            Console.WriteLine("[5]. View all accounts");
            Console.WriteLine("[6]. Exit");
            Console.WriteLine("\n--------------------------------------------------------");
            Console.Write("Choose: ");
        }
        static void createAcc()
        {
            SellerModels acc = new SellerModels();

            Console.Write("Enter Seller Name: ");
            acc.SellerName = Console.ReadLine();

            Console.Write("Enter Username: ");
            acc.Username = Console.ReadLine();

            Console.Write("Enter birthday (MM/DD/YY): ");
            acc.Birthday = Console.ReadLine();

            Console.Write("Enter email address: ");
            acc.EmailAddress = Console.ReadLine();

            Console.Write("Enter phone number: ");
            acc.PhoneNumber = Console.ReadLine();

            Console.Write("Enter present address: ");
            acc.PresentAddress = Console.ReadLine();

            Console.Write("Enter Bio: ");
            acc.Bio = Console.ReadLine();

            Console.WriteLine("\nReview your details:");
            Console.WriteLine("Name: " + acc.SellerName);
            Console.WriteLine("Username: " + acc.Username);
            Console.WriteLine("Birthday: " + acc.Birthday);
            Console.WriteLine("Email Address: " + acc.EmailAddress);
            Console.WriteLine("Phone Number: " + acc.PhoneNumber);
            Console.WriteLine("Present Address: " + acc.PresentAddress);
            Console.WriteLine("Bio: " + acc.Bio);

            Console.Write("\nSave this account? (Yes/No): ");
            string confirm = Console.ReadLine().ToLower();

            if (confirm == "yes")
            {
                service.CreateAccount(acc);
                Console.WriteLine("\nCreated Successfully.");
                Console.WriteLine("\n--------------------------------------------------------");

                Console.Write("Do you want to add another account? (Yes/No): ");
                string addAnother = Console.ReadLine()?.ToLower() ?? "";
                if (addAnother == "yes")
                {
                    createAcc();
                }
            }
            else
            {
                Console.WriteLine("\nAccount not saved.");
                Console.WriteLine("\n--------------------------------------------------------");
            }
        }

        static void searchAcc()
        {
            Console.Write("\nEnter username to search: ");
            string username = Console.ReadLine();

            SellerModels acc = service.SearchAccount(username);

            if (acc != null)
            {
                Console.WriteLine("\nAccount Found!");
                Console.WriteLine("Name: " + acc.SellerName);
                Console.WriteLine("Username: " + acc.Username);
                Console.WriteLine("Birthday: " + acc.Birthday);
                Console.WriteLine("Email: " + acc.EmailAddress);
                Console.WriteLine("Phone: " + acc.PhoneNumber);
                Console.WriteLine("Address: " + acc.PresentAddress);
                Console.WriteLine("Bio: " + acc.Bio);
                Console.WriteLine("\n--------------------------------------------------------");
            }
            else
            {
                Console.WriteLine("Username not found.");
                Console.WriteLine("\n--------------------------------------------------------");
            }
        }

        static void updateInfo()
        {
                Console.Write("\nEnter username to update: ");
                string username = Console.ReadLine();

                var existing = service.SearchAccount(username);

                if (existing == null)
                {
                    Console.WriteLine("\nUsername does not exist.");
                    Console.WriteLine("--------------------------------------------------------");
                    return;
                }

                Console.WriteLine("\nAccount Found.");
                Console.WriteLine($"Name: {existing.SellerName}");
                Console.WriteLine($"Username: {existing.Username}");

                Console.Write("\nDo you update this account (Yes/No): ");
                string confirm = Console.ReadLine().ToLower();

                if (confirm != "yes")
                {
                    Console.WriteLine("Update cancelled.");
                    Console.WriteLine("\n--------------------------------------------------------");
                    return;
                }

                SellerModels acc = new SellerModels();

                acc.Username = username;

                Console.Write("Name: ");
                acc.SellerName = Console.ReadLine();

                Console.Write("Username: ");
                acc.Username = Console.ReadLine();

                Console.WriteLine("Birthday: ");
                acc.Birthday = Console.ReadLine();

                Console.Write("Email: ");
                acc.EmailAddress = Console.ReadLine();

                Console.Write("Phone: ");
                acc.PhoneNumber = Console.ReadLine();

                Console.Write("Address: ");
                acc.PresentAddress = Console.ReadLine();

                Console.Write("Bio: ");
                acc.Bio = Console.ReadLine();

                Console.Write("\nSave this info? (Yes/No): ");
                string saveConfirm = Console.ReadLine().ToLower();

                if (saveConfirm == "yes")
                {
                    service.UpdateAccount(acc);
                    Console.WriteLine("\nInformation Updated Successfully.");
                    Console.WriteLine("\n--------------------------------------------------------");
                }
                else
                {
                    Console.WriteLine("Update cancelled.");
                    Console.WriteLine("\n--------------------------------------------------------");
                }
            }

            static void deleteAcc()
        {
            Console.Write("Enter Username to delete: ");
            string username = Console.ReadLine();

            var existing = service.SearchAccount(username);

            if(existing == null)
            {
                Console.WriteLine("\nUsername does not exist.");
                Console.WriteLine("--------------------------------------------------------");
                return;
            }

            Console.WriteLine("\nAccount Found.");
            Console.WriteLine($"Name: {existing.SellerName}");
            Console.WriteLine($"Username: {existing.Username}");

            Console.Write("\nAre you sure you want to delete this account? (Yes/No): ");
            string ans = Console.ReadLine().ToLower();

            if (ans == "yes")
            {
                bool result = service.DeleteAccount(username);

                if (result)
                {
                    Console.WriteLine("\nAccount has been deleted.");
                }
                else
                {
                    Console.WriteLine("\nFailed to delete account.");
                }
            }
            else
            {
                Console.WriteLine("Deletion cancelled.");
            }
                Console.WriteLine("\n--------------------------------------------------------");
        }

        static void viewAcc()
        {
            var accounts = service.GetAccounts();

            if (accounts == null || accounts.Count == 0)
            {
                Console.WriteLine("\nNo accounts found.");
                Console.WriteLine("\n--------------------------------------------------------");
                return;
            }

            Console.WriteLine("\nALL ACCOUNTS:");
            Console.WriteLine("--------------------------------------------------------");

            foreach (var acc in accounts)
            {
                Console.WriteLine($"Name: {acc.SellerName}");
                Console.WriteLine($"Username: {acc.Username}");
                Console.WriteLine($"Email: {acc.EmailAddress}");
                Console.WriteLine($"Phone: {acc.PhoneNumber}");
                Console.WriteLine("--------------------------------------------------------");
            }
        }
        }
    }
