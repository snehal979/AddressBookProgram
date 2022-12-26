using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;

namespace AddressBookProgram
{
    public class AddressBookMainPage
    {
        List<DataOfPerson> addresslist = new List<DataOfPerson>();
        Dictionary<string, List<DataOfPerson>> addressBook = new Dictionary<string, List<DataOfPerson>>();

        // connection with the sql databse-AddressServerADO
        public static string connectionString = "Data Source =(localdb)\\MSSQLLocalDB;Initial Catalog =AddressBookServerADO";
        SqlConnection sqlconnection = new SqlConnection(connectionString);
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
            {
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
        /// UC8_Uc10 Search city and state present in the Address book
        /// </summary>
        /// <param name="addresslist"></param>
        /// <param name="Method"></param>
        public void GroupOfSameCityLiveAndState(List<DataOfPerson> addresslist,string Method)
        {

            if (Method.Equals("city"))
            {
                //// To sort the details list
                Console.WriteLine("Enter the name of city");
                string cityname = Console.ReadLine();
                Console.WriteLine(" CITY :"+cityname);
                var AddressBookCityData = addresslist.FindAll(e => e.City == cityname);

                foreach (var data in AddressBookCityData)
                {

                    Console.WriteLine("Name "+data.FirstName +" "+data.LastName);

                }

                //// Count of person Uc10 in city
                Console.WriteLine(" Total perosn present in City {0} is {1} ", cityname, AddressBookCityData.Count());
            }
            else if (Method.Equals("state"))
            {
                //// To sort the details list

                Console.WriteLine("Enter the name of state");
                string statename = Console.ReadLine();
                Console.WriteLine(" STATE :"+statename);
                var addressBookStateData = addresslist.FindAll(e => e.State == statename);
                foreach (var data in addressBookStateData)
                {

                    Console.WriteLine("Name "+data.FirstName +" "+data.LastName);

                }
                //// Count of person Uc10 in state
                Console.WriteLine(" Total perosn present in State {0} is {1} ", statename, addressBookStateData.Count());
            }
            else
            {
                Console.WriteLine("Invalid method");
            }
        }
        /// <summary>
        /// Uc9Display METHOD FOR lAMBDA EXPRESSION
        /// </summary>
        public void ViewLambdaExpression()
        {
            Console.WriteLine("Enter the serach location City/State");
            string method = Console.ReadLine().ToLower(); ;
            GroupOfSameCityLiveAndState(addresslist, method);
        }
        /// <summary>
        /// Uc11 Sort the data of Address book by Alphabate of FirstName
        /// </summary>
        public void SortAddressBookData()
        {
            Console.WriteLine("Hint 1. List of AddressBook Sort");
            int num = Convert.ToInt16(Console.ReadLine());
            if(num == 1)
            {
                addresslist.Sort((x, y) => string.Compare(x.FirstName, y.FirstName));
                Display();
                return;
            }       
            
        }
        /// <summary>
        /// Uc12 Search the data by City State and Zip;
        /// </summary>
        public void SortByCity_State_Zip()
        {
            Console.WriteLine("Hint 1.Sorted by city \n 2.Sorted by State \n 3.Sorted by Zip");
            int num = Convert.ToInt16(Console.ReadLine());
            if (num == 1)
            {
                addresslist.Sort((x, y) => string.Compare(x.State, y.State));
                DisplayList();
                return;
            }
            else if(num == 2)
            {
                addresslist.Sort((x, y) => string.Compare(x.City, y.City));
                DisplayList();
            } else if (num ==3)
            {
                addresslist.Sort((x, y) => string.Compare(x.Zip, y.Zip));
                DisplayList();
            }
        }
        //Display For State ,Zip,City list
        public void DisplayList()
        {
            foreach(var data in addresslist)
            {
                Console.WriteLine("Name "+data.FirstName +" "+data.LastName);
                Console.WriteLine("----------------");
            }
           
        }
        /// <summary>
        /// Uc13 Call the FileReadOrWriteMethod
        /// Uc14 Csv File call Method
        /// Uc15 Json file Not working
        /// </summary>
        public void TxtFileWriteAndRead(string filepath)
        {
            Console.WriteLine("hint 1.Txt file \n 2.Csv File \n 3.Json file");
            int choices = Convert.ToInt32(Console.ReadLine());
            switch (choices)
            {
                case 1:
                    FileReadOrWrite fileReadOrWrite = new FileReadOrWrite();
                    fileReadOrWrite.WriteFile(filepath, addresslist);
                    break;
                case 2:
                    CsvFileAddressBook csv = new CsvFileAddressBook();
                    csv.CsvHandingFile(filepath, addresslist);
                    break;
                case 3:
                    JsonFileAddressBook jsonFileAddressBook = new JsonFileAddressBook();
                    string jsonfile = @"C:\Users\hp\Desktop\newFolder\AddressBookProgram\AddressBookProgram\AddressBookProgram\Files\jsonAddressBook.json";
                    jsonFileAddressBook.JsonSerialize(jsonfile, addresslist);
                   
                    break;
            }
        
        }
        /// <summary>
        /// Uc 16 AddressBook Service database using ADO.NET
        /// Uc 18 Add in Perticular period
        /// </summary>
        public void RetriveAddressBookServer(List<DataOfPerson> addressServer, string query)
        {
            try
            {
                using (this.sqlconnection)
                {
                    this.sqlconnection.Open();
                    SqlCommand command = new SqlCommand(query, this.sqlconnection);
                    SqlDataReader dr = command.ExecuteReader(); //Only use for read
                    if (dr.HasRows)
                    {
                        while (dr.Read())
                        {
                            DataOfPerson data = new DataOfPerson();
                            data.FirstName =dr.GetString(0);
                            data.LastName =dr.GetString(1);
                            data.Address =dr.GetString(2);
                            data.City =dr.GetString(3);
                            data.State =dr.GetString(4);
                            data.Zip =dr.GetString(5);
                            data.PhoneNUmber =dr.GetString(6);
                            data.Email =dr.GetString(7);

                            addressServer.Add(data);
                        }
                        foreach (var contact in addressServer)
                        {
                            Console.WriteLine("Contact Details:" + "\n" + "FirstName: " + contact.FirstName + "\n" + "LastName: " + contact.LastName + "\n" + "Address: " + contact.Address + "\n" + "City: " + contact.City + "\n" + "State: " + contact.State + "\n" + "Zip: " + contact.Zip + "\n" + "PhoneNumber: " + contact.PhoneNUmber + "\n" + "Email: " + contact.Email);
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
            finally
            {
                this.sqlconnection.Close();
            }
        }
        /// <summary>
        /// UC 17 Update database by Person Name
        /// </summary>
        /// <param name="payRoll"></param>
        /// <exception cref="Exception"></exception>
        public string UpdateAddressService(DataOfPerson dataADO)
        {
            string Updatequery = @"UPDATE AddressBookList SET Email =@Email WHERE FirstName=@FirstName";
            try
            {
                using (this.sqlconnection)
                {
                    SqlCommand command = new SqlCommand(Updatequery, this.sqlconnection);

                    command.Parameters.AddWithValue("@FirstName", dataADO.FirstName);
                    command.Parameters.AddWithValue("@Email", dataADO.Email);

                    this.sqlconnection.Open();
                    int a = command.ExecuteNonQuery(); // return only affected row/ return 1,0
                    if (a>0)
                    {
                        Console.WriteLine("Update data in the employeePayRoleTable serivces");
                        return "UPDATE";
                    }
                    else
                    {
                        Console.WriteLine("Not Update data in the employeePayRoleTable serivces");
                        return "NOTUPDATE";
                    }
                }
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
            finally
            {
                this.sqlconnection.Close();
            }
        }


    }

}
