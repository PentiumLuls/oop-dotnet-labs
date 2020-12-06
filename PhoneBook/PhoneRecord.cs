using System;
using System.Collections.Generic;
using static System.Console;

    internal class PhoneRecord
    {
        
        public string FirstName { get; private set; }
        public string LastName { get; private set; }
        public int PhoneNumber { get; private set; }
        public string Address { get; set; }

        public PhoneRecord(string firstName, string lastName, int phoneNumber, string address)
        {
            FirstName = firstName;
            LastName = lastName;
            PhoneNumber = phoneNumber;
            Address = address;
        }

        ~PhoneRecord() 
        { 
            WriteLine("Destroying instance of PhoneRecord class..."); 
        } 

        public void Update(string firstName, string lastName, string phoneNumber, string address)
        {
            if (!String.IsNullOrEmpty(firstName))
                FirstName = firstName;
            if (!String.IsNullOrEmpty(lastName))
                LastName = lastName;
            if (!String.IsNullOrEmpty(phoneNumber))
                PhoneNumber = int.Parse(phoneNumber);
            if (!String.IsNullOrEmpty(address))
                Address = address;
        }

        // public override bool Equals(object obj)
        // {
        //     if (obj == null) return false;
        //     return obj.ToString() == LastName || obj.ToString() == PhoneNumber.ToString() || obj.ToString() == CompanyName;
        // }

        public override string ToString()
        {
            return $"First name: {FirstName}\nLast Name: {LastName}\nPhone Number: {PhoneNumber}\nAddress: {Address ?? "None"}";
        }
    }
