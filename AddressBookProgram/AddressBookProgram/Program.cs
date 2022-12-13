namespace AddressBookProgram
{
    class Program
    {
        public static void Main(string[] args)
        {
            Console.WriteLine("Welcom to Address Book Project");
           
            AddressBookMainPage page = new AddressBookMainPage();
            bool flag = true;
            while (flag)
            {
                Console.WriteLine("****************************************************");
                Console.WriteLine("Select 1.CreateContact \n 2.Edit Contact\n 3.Delete contact \n4.Display contacts \n5.Create Dictionary\n6.Display Dictionary\n7.SearchByCityOrStateVSdata\n8.Sort The Address book list\n 9.Exit");
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
                        flag = false;
                        break;
                }
            }
               
        }
    }
}
