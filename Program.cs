using System;

namespace SellerManagement
{
    internal class Program
    {
        static string sName = "";
        static string bDay = "";
        static string emailAdd = "";
        static string phoneNum = "";
        static string preAdd = "";
        static string gender = "";
        static void Main(string[] args)
        {
            Console.WriteLine("SHOPEE ACCOUNT MANAGEMENT");
            Console.WriteLine("Please set up your account. Set now");

            char choose;

            bool shop = true;
            while (shop)
            {

                chooseNum();
                choose = Console.ReadKey().KeyChar;
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
            Console.Write("1. Create account.\n2. Search name \n3. Update information.\n4. Delete your account\n5. Exit\n");
            Console.WriteLine("\n--------------------------------------------------------");
            Console.Write("\nChoose: ");
        }

        static void createAcc()
        {
            Console.WriteLine("\nADD ACCOUNT");

            Console.Write("\nEnter Seller Name: ");
            sName = Console.ReadLine();

            Console.Write("Enter birthday: (MM/DD/YY): ");
            bDay = Console.ReadLine();

            Console.Write("Enter email address: ");
            emailAdd = Console.ReadLine();

            Console.Write("Enter phone number: ");
            phoneNum = Console.ReadLine();

            Console.Write("Enter present address: ");
            preAdd = Console.ReadLine();

            Console.WriteLine("\nReview your details: ");
            Console.WriteLine("Name: " + sName);
            Console.WriteLine("Birthday: " + bDay);
            Console.WriteLine("Email Address: " + emailAdd);
            Console.WriteLine("Phone Number: " + phoneNum);
            Console.WriteLine("Present Address: " + preAdd);

            Console.Write("\nSave this account? (Yes/No): ");
            string confirm = Console.ReadLine().ToLower();

            if (confirm == "yes")
            {
                Console.WriteLine("\nCreated Successfully.");
            }
            else
            {
                Console.WriteLine("\nAccount not saved.");
                sName = bDay = emailAdd = phoneNum = preAdd = "";
            }
        }

        static void searchAcc()
        {
            Console.WriteLine("\nSEARCH ACCOUNT");

            if (string.IsNullOrEmpty(sName))
            {
                Console.WriteLine("No Account Created Yet. ");
                return;
            }

            Console.Write("\nEnter name to search: ");
            string searchName = Console.ReadLine();

            Console.WriteLine("Searching account...");

            if (searchName.Trim().ToLower() == sName.Trim().ToLower())
            {
                Console.WriteLine("Username Found!");
            }
            else
            {
                Console.WriteLine("Username not found.");
            }
        }

        static void updateInfo()
        {

            Console.WriteLine("\nUPDATE INFORMATION");

            if (string.IsNullOrEmpty(sName))
            {
                Console.WriteLine("No Account Created Yet. ");
                return;
            }

            Console.Write("\nMy Profile");

            Console.Write("\nName: ");
            sName = Console.ReadLine();

            Console.Write("Username: ");
            string uName = Console.ReadLine();

            Console.Write("Bio: ");
            string bio = Console.ReadLine();

            Console.Write("Phone: ");
            phoneNum = Console.ReadLine();

            Console.Write("Email: ");
            emailAdd = Console.ReadLine();


            Console.WriteLine("\nReview update information");
            Console.WriteLine("Name: " + sName);
            Console.WriteLine("Username: " + uName);
            Console.WriteLine("Bio: " + bio);
            Console.WriteLine("Phone: " + phoneNum);
            Console.WriteLine("Email: " + emailAdd);

            Console.Write("\nSave this info? (Yes/No): ");
            string info = Console.ReadLine().ToLower();

            if (info == "yes")
            {
                Console.WriteLine("\nCreated Successfully.");
            }
            else
            {
                Console.WriteLine("\nAccount not saved.");
            }
        }

                static void deleteAcc()
                {
                    Console.WriteLine("REQUEST ACCOUNT DELETION");

                    if (string.IsNullOrEmpty(sName))
                    {
                        Console.WriteLine("No Account Created Yet.");
                        return;
                    }

                    Console.WriteLine("\nDo you want to delete your account (" + sName + ") (Yes/No): ");

                    string ans = Console.ReadLine().ToLower();

                    if (ans == "yes")
                    {
                        Console.WriteLine("Please Note. Account Deletion is Irreversable");
                        Console.WriteLine("Proceed to Delete. Deleting...");
                        Console.WriteLine("DELETED SUCCESSFULLY");

                        sName = bDay = emailAdd = phoneNum = preAdd = "";
                    }
                    else if (ans == "no")
                    {
                        Console.WriteLine("Cancelled Account Deletion");
                    }
                    else
                    {
                        Console.WriteLine("Invalid Input");
                    }
                }
            }
        }
    