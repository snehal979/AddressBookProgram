namespace AddressBookProgram
{
    class Program
    {
        public static void Main(string[] args)
        {
            Console.WriteLine("Welcom to Address Book Project");
            AddressBookMainPage page = new AddressBookMainPage();
            page.NewCreateContact();

        }
    }
}
