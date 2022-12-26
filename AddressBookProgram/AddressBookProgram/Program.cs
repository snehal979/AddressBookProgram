using System.Collections.Generic;

namespace AddressBookProgram
{
    class Program
    {
        public static void Main(string[] args)
        {
            string filepath = @"C:\Users\hp\Desktop\newFolder\AddressBookProgram\AddressBookProgram\AddressBookProgram\Files\AddressBook.txt";
            Console.WriteLine("Welcom to Address Book Project");
           
            //For ADO .net data provider
            AddressBookMainPage page = new AddressBookMainPage();
            List<DataOfPerson> addressServer = new List<DataOfPerson>();
            try
            {
                bool flag = true;
                while (flag)
                {
                    Console.WriteLine("****************************************************");
                    Console.WriteLine("Select 1.CreateContact \n 2.Edit Contact\n 3.Delete contact \n4.Display contacts \n5.Create Dictionary\n6.Display Dictionary\n7.SearchByCityOrStateVSdata\n8.Sort The Address book list\n 9.Sorted by state zip and city\n 10.File read or write" +
                        "11.Database Retrive 12.Update Data Database13.Add in Perticular period \n14.Exit");
                    int option = Convert.ToInt32(Console.ReadLine());
                    switch (option)
                    {
                        case 1:
                            page.NewCreateContact();
                            break;
                        case 2:
                            page.UpdateContact();
                            break;
                        case 3:
                            page.DeleteContact();
                            break;
                            page.Display();
                            break;
                        case 5:
                            page.CreateDictionary();
                            break;
                        case 6:
                            page.DisplayDictionary();
                            break;
                        case 7:
                            page.ViewLambdaExpression();
                            break;
                        case 8:
                            page.SortAddressBookData();
                            break;
                        case 9:
                            page.SortByCity_State_Zip();
                            break;
                        case 10:
                            page.TxtFileWriteAndRead(filepath);
                            break;
                        case 11:
                            string query = @"Select * from AddressBookList";
                            page.RetriveAddressBookServer(addressServer,query);
                            break;
                        case 12:
                            DataOfPerson dataADO = new DataOfPerson();

                            Console.WriteLine("Enter the firstName");
                            dataADO.FirstName = Console.ReadLine();
                            Console.WriteLine("enter the changes in email id");
                            dataADO.Email = Console.ReadLine();
                            page.UpdateAddressService(dataADO);
                            break;
                        case 13:
                            string queryForDiff = @"SELECT * FROM AddressBookList WHERE WorkingPeriod BETWEEN CAST('2017-01-01'AS DATE) AND GETDATE();";
                            page.RetriveAddressBookServer(addressServer,queryForDiff);
                            break;
                        case 14:
                            page.RetriveBycityOrstate(addressServer);
                            break;
                        case 15:
                            flag = false;
                            break;
                    }
                }
                
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
            }

        }

        
    }
}
