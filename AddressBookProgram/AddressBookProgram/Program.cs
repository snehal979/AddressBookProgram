namespace AddressBookProgram
{
    class Program
    {
        public static void Main(string[] args)
        {
            Console.WriteLine("Welcom to Address Book Project");
            Console.WriteLine("Select 1.CreateContact \n 2.Edit Contact");
            AddressBookMainPage page = new AddressBookMainPage();

            int option = Convert.ToInt32(Console.ReadLine());
            switch (option)
            {
                case 1:
                    page.NewCreateContact();
                    break;
                case 2:
                    page.UpdateContact();
                    break;

            }
        }
    }
}
