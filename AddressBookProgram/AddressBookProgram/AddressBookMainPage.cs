﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AddressBookProgram
{
    public class AddressBookMainPage
    {
        List<DataOfPerson> addresslist = new List<DataOfPerson>();
        Dictionary<string, List<DataOfPerson>> addressBook = new Dictionary<string, List<DataOfPerson>>();

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
           
            CheckDuplicateName(addresslist, contact); // to check Duplicated name is present or not
          

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
        /// <summary>
        /// Delect Contact Uc4
        /// </summary>
        public void DeleteContact()
        {
            try
            {
                Console.WriteLine("Enter the name whose contact you want to delete");
                string deleteContactName = Console.ReadLine();

                DataOfPerson deletecontact = new DataOfPerson();

                foreach (var contact in addresslist)
                {
                    if (contact.FirstName.Equals(deleteContactName) || contact.LastName.Equals(deleteContactName))
                    {
                        deletecontact = contact;
                        addresslist.Remove(deletecontact);
                        Console.WriteLine("contact has been deleted successfully");
                    }
                    else
                    {
                        Console.WriteLine("Name not found in address bool list");
                    }
                }
            } catch(Exception ex)
            {
                Console.WriteLine(ex.Message);
            }
            

           
           
        }
        /// <summary>
        /// uC5
        /// </summary>
        // add multiple data of person
        public void CreateDictionary()
        {
            Console.WriteLine("Enter with what name you want to add in dictionary");
            string name = Console.ReadLine();
            addressBook.Add(name, addresslist);
            addresslist = new List<DataOfPerson>();
        }
        /// <summary>
        /// Uc 6
        /// </summary>
        // display dictionary which is base on key value
        public void DisplayDictionary()
        {
            foreach (var data in addressBook)
            {
                Console.WriteLine(data.Key);//printing dictionary keys
                foreach (var contact in data.Value)// checking values inside keys
                {
                    Console.WriteLine("Contact Details:" + "\n" + "FirstName: " + contact.FirstName + "\n" + "LastName: " + contact.LastName + "\n" + "Address: " + contact.Address + "\n" + "City: " + contact.City + "\n" + "State: " + contact.State + "\n" + "Zip: " + contact.Zip + "\n" + "PhoneNumber: " + contact.PhoneNUmber + "\n" + "Email: " + contact.Email);

                }

            }
        }
        /// <summary>
        /// Uc 7 Duplicate Data of person (COLLECTION DEMO) and (LAMBDA)
        /// </summary>
        public void CheckDuplicateName(List<DataOfPerson> addresslist, DataOfPerson contact)
        {
            if(addresslist.Exists(e => e.FirstName == contact.FirstName && e.LastName == contact.LastName))
            {
                Console.WriteLine("*****************");
                Console.WriteLine("The person name is already exits");
            }
            else
            {
                Console.WriteLine("The person name is not already exits then add to the list");
                addresslist.Add(contact);
                Display();
            }
           
        }
        /// <summary>
        /// uC8 Search city and state present in the Address book
        /// </summary>
        /// <param name="addresslist"></param>
        /// <param name="Method"></param>
        public void GroupOfSameCityLiveAndState(List<DataOfPerson> addresslist,string Method)
        {
            Dictionary<string, List<DataOfPerson>> persondataCity = new Dictionary<string, List<DataOfPerson>>();
            if (Method.Equals("city"))
            {
                //// To sort the details list
                Console.WriteLine("Enter the name of city");
                string cityname = Console.ReadLine();
                Console.WriteLine(" CITY :"+cityname);
                var AddressBookCityData = addresslist.OrderBy(e => e.City==cityname);
                
                foreach (var data in AddressBookCityData)
                {

                    Console.WriteLine("Name "+data.FirstName +" "+data.LastName+"\n Address "+ data.Address + "\n" + "City: " + data.City + "\n" + "State: " + data.State + "\n" + "Zip: " + data.Zip + "\n" + "PhoneNumber: " + data.PhoneNUmber + "\n" + "Email: " + data.Email);

                }
                //// Count of person
                Console.WriteLine(" Total perosn present in City {0} is {1} " ,cityname ,AddressBookCityData.Count() ); 
                
            }
            else if (Method.Equals("state"))
            {
                //// To sort the details list
              
                Console.WriteLine("Enter the name of state");
                string statename = Console.ReadLine();
                Console.WriteLine(" STATE :"+statename);
                var addressBookStateData = addresslist.OrderBy(e => e.State);
                foreach (var data in addressBookStateData)
                {

                    Console.WriteLine("Name "+data.FirstName +" "+data.LastName+"\n Address "+ data.Address + "\n" + "City: " + data.City + "\n" + "State: " + data.State + "\n" + "Zip: " + data.Zip + "\n" + "PhoneNumber: " + data.PhoneNUmber + "\n" + "Email: " + data.Email);

                }
                //// Count of person
                Console.WriteLine(" Total perosn present in State {0} is {1} ", statename, addressBookStateData.Count());

            }
            else
            {
                Console.WriteLine("Invalid method");
            }
           
            
        }
        /// <summary>
        /// Display METHOD FOR lAMBDA EXPRESSION
        /// </summary>
        public void ViewLambdaExpression()
        {
            Console.WriteLine("Enter the serach location City/State");
            string method = Console.ReadLine().ToLower(); ;
            GroupOfSameCityLiveAndState(addresslist, method);
            

        }

    }

}
