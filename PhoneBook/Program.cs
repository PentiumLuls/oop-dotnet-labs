using System.Collections.Generic;
using System.Linq;
using static System.Console;


    internal static class Program
    {
        private static void Main()
        {
            PhoneBook phoneBook = new PhoneBook();
            // phoneBook.createNewRecord("Ivan", "LastName", "099999999", "");
            // phoneBook.createNewRecord("Maksym", "Deer", "088888888", "some adress...");
            // phoneBook.createNewRecord("John", "Doe", "077777777", "");
            // phoneBook.createNewRecord("Fedor", "Doe", "066666666", "");
            while (true)
            {
                Clear();
                WriteLine(
                    "Welcome to Phone book !\n1. Create new record\n2. Show records\n3. Search\n4. Update phone book\n5. Exit");
                switch (int.TryParse(ReadLine(), out var chose) ? chose : 0)
                {
                    case 0:
                        WriteLine("Enter any number from list !");
                        break;
                    case 1:
                        CreateNewRecord(ref phoneBook);
                        ReadLine();
                        break;
                    case 2:
                        ShowAllRecords(phoneBook);
                        ReadLine();
                        break;
                    case 3:
                        FindRecord(phoneBook);
                        ReadLine();
                        break;
                    case 4:
                        WriteLine("Enter Phone number of record, you want to update:");
                        SearchAndUpdate(phoneBook, int.Parse(ReadLine()));
                        break;
                    case 5:
                        return;
                    default:
                        WriteLine("Enter only number from list !");
                        ReadLine();
                        break;
                }
            }
        }

        private static void FindRecord(PhoneBook phoneBook)
        {
            Clear();
            WriteLine("Search by :\n1. Last Name\n2. Phone Number");
            switch (int.TryParse(ReadLine(), out var chose) ? chose : 0)
            {
                case 0:
                    WriteLine("Enter ony number from list !");
                    break;
                case 1:
                    Clear();
                    Write("Enter last name : ");
                    string lastName = ReadLine();
                    foreach (var record in phoneBook.Records.Where(record => record.LastName == lastName))
                    {
                        WriteLine("----------------\n" + record + "\n");
                    }
                    break;
                case 2:
                    Clear();
                    Write("Enter phone number : ");
                    int phoneNumber = int.Parse(ReadLine());
                    foreach (var record in phoneBook.Records.Where(record => record.PhoneNumber == phoneNumber))
                    {
                        WriteLine("----------------\n" + record + "\n");
                    }
                    break;
                default:
                    WriteLine("Enter only number from list !");
                    break;
            }
        }

        private static void SearchAndUpdate(PhoneBook phoneBook, int phoneNember)
        {
            Clear();
            foreach (var record in phoneBook.Records.Where(record => record.PhoneNumber == phoneNember))
            {
                WriteLine(record + "\n");

                WriteLine("Enter new first name (or leave empty): ");
                string firstName = ReadLine();
                WriteLine("Enter new last name (or leave empty): ");
                string lastName = ReadLine();
                WriteLine("Enter new phone number (or leave empty):");
                string phoneNumber = ReadLine();
                WriteLine("Enter new address (or leave empty):");
                string address = ReadLine();
                
                record.Update(firstName, lastName, phoneNumber, address);
            }
        }

        private static void CreateNewRecord(ref PhoneBook phoneBook)
        {
            Clear();
            WriteLine("Enter first name: ");
            string firstName = ReadLine();
            WriteLine("Enter last name: ");
            string lastName = ReadLine();
            WriteLine("Enter phone number:");
            string phoneNumber = ReadLine();
            WriteLine("Enter address (or leave empty):");
            string address = ReadLine();
            while (true)
            {
                try
                {
                    phoneBook.createNewRecord(firstName, lastName, phoneNumber, address);
                    break;
                }
                catch (System.Exception e)
                {
                    WriteLine("Error: " + e.Message);
                    WriteLine("Enter phone number again: ");
                    phoneNumber = ReadLine();
                }
            }
        }

        private static void ShowAllRecords(PhoneBook phoneBook)
        {
            Clear();
            WriteLine("All records :");
            if (!phoneBook.Records.Any()) { WriteLine("Phone book is empty"); return; }
            foreach (var record in phoneBook.Records)
            {
                WriteLine("----------------\n" + record + "\n");
            }
        }
    }
