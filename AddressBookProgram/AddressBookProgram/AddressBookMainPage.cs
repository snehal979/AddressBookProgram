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
        /// <summary>
        /// Uc2
        /// </summary>
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
            Display();

        }
        public void Display()
        {
            foreach (var contact in addresslist)
            {
                Console.WriteLine("Contact Details:" + "\n" + "FirstName: " + contact.FirstName + "\n" + "LastName: " + contact.LastName + "\n" + "Address: " + contact.Address + "\n" + "City: " + contact.City + "\n" + "State: " + contact.State + "\n" + "Zip: " + contact.Zip + "\n" + "PhoneNumber: " + contact.PhoneNUmber + "\n" + "Email: " + contact.Email);
            }

        }
        /// <summary>
        /// Uc3
        /// </summary>
        public void UpdateContact()
        {
            Console.WriteLine("Enter the name whose details you want to edit");
            string editname = Console.ReadLine();

            foreach (var contact in addresslist)
                if (contact.FirstName.Equals(editname) || contact.LastName.Equals(editname))
                {
                    Console.WriteLine("What you want to Edit" + "\n" + "Select 1.Address 2.City 3.State 4.Zip 5.PhoneNumber 6.Email ");
                    int option = Convert.ToInt32(Console.ReadLine());
                    switch (option)
                    {
                        case 1:
                            Console.WriteLine("Enter the new address");
                            contact.Address = Console.ReadLine();
                           
                            break;
                        case 2:
                            Console.WriteLine("Enter the new city");
                            contact.City = Console.ReadLine();
                            break;
                        case 3:
                            Console.WriteLine("Enter the new state");
                            contact.State = Console.ReadLine();
                            break;
                        case 4:
                            Console.WriteLine("Enter the new zip");
                            contact.Zip = Console.ReadLine();
                            break;
                        case 5:
                            Console.WriteLine("Enter the new phone number");
                            contact.PhoneNUmber = Console.ReadLine();
                            break;
                        case 6:
                            Console.WriteLine("Enter the new email id");
                            contact.Email = Console.ReadLine();
                            break;

                    }
                }
                else
                {
                    Console.WriteLine("Person is not found in address book");
                }
        }
    }

}
