using System;
using System.Collections.Generic;
using System.Linq;
using System.Text.RegularExpressions;
using System.Web;

namespace BootstrapTest
{
    public class Contact
    {
        private string firstName;
        private string lastName;
        private string personNr;
        public string FirstName
        {

            get { return firstName; }
            set
            {
                if (value.Trim().Length > 0 /*&& value.First().ToString().ToUpper() == value.First().ToString()*/)
                {
                    //value = char.ToUpper(value.First()).ToString() + value.Substring(1);
                    //firstName = value.Trim();
                    char[] a = value.Trim().ToCharArray();
                    a[0] = char.ToUpper(a[0]);

                    firstName = new string(a).Trim();

                }
                else
                    throw new Exception("Name must contian something");
            }
        }
        public string LastName
        {
            get { return lastName; }
            set
            {
                if (value.Trim().Length > 0)
                {
                    char[] a = value.Trim().ToCharArray();
                    a[0] = char.ToUpper(a[0]);

                    lastName = new string(a).Trim();
                }

                else
                    throw new Exception("Name must contian something");
            }
        }

        public string FullName
        {
            get { return FirstName + "\t" + LastName; }
        }
        public string PersonNr
        {
            get { return personNr; }
            set
            {
                Regex myRegex = new Regex(@"\d{8}[-]\d{4}");
                if (myRegex.IsMatch(value.Trim()))
                    personNr = value;
                else
                    throw new Exception("Ssn must be 13 digits (yyyymmdd-xxxx)");
            }
        }

        public Contact(string firstN, string lastN, string ssn)
        {
            FirstName = firstN;
            LastName = lastN;
            PersonNr = ssn;
        }
    }
}