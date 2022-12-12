using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AddressBookProgram
{
    public class AddressBookMainPage
    {
        List<DataOfPerson> addresslist = new List<DataOfPerson>();
        public void NewCreateContact()
        {
            DataOfPerson contact = new DataOfPerson();

            Console.WriteLine("Enter the firstName");
            contact.FirstName = Console.ReadLine();
            Console.WriteLine("Enter the lastName");
            contact.LastName = Console.ReadLine();
            Console.WriteLine("Enter the Address");
            contact.Address = Console.ReadLine();
            Console.WriteLine("Enter the City");
            contact.City = Console.ReadLine();
            Console.WriteLine("Enter the State");
            contact.State = Console.ReadLine();
            Console.WriteLine("Enter the Zip");
            contact.Zip = Console.ReadLine();
            Console.WriteLine("Enter the PhoneNumber");
            contact.PhoneNUmber = Console.ReadLine();
            Console.WriteLine("Enter the Email ID");
            contact.Email = Console.ReadLine();

            addresslist.Add(contact);    // add data into the list of address book

        }
    }

}
