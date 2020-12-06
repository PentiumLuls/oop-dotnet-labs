using System;
using System.Collections.Generic;
using static System.Console;


    internal class PhoneBook
    {
        public List<PhoneRecord> Records { get; }

        public PhoneBook()
        {
            Records = new List<PhoneRecord>();
        }

        public void createNewRecord(string firstName, string lastName, string phoneNumber, string address)
        {
            if(IsPhoneNumberCorrect(phoneNumber))
            {
                PhoneRecord record = new PhoneRecord(firstName, lastName, int.Parse(phoneNumber), address);
                Records.Add(record);
            }
        }

        private void Error(string error)
        {
            throw new ApplicationException(error);
        }

        private bool IsPhoneNumberCorrect(string phone)
        {
            if (phone == null || phone.Length != 9)
            {
                Error("Phone must be 9 characters length !");
                return false;
            }
            else if (!int.TryParse(phone, out var result))
            {
                Error("Phone must contain only numbers !");
                return false;
            }
            else
            {
                return true;
            }

        }

        public void Update(List<PhoneBook> phoneBook)
        {
            
        }
    }
