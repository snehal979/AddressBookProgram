using AddressBookProgram;
namespace AddressBookProgramTest
{
    public class Tests
    {
        AddressBookMainPage page = new AddressBookMainPage();
        [Test]
        public void Test1()
        {
            DataOfPerson dataADO = new DataOfPerson();

            Console.WriteLine("Enter the firstName");
            dataADO.FirstName = "Latabai";
            Console.WriteLine("enter the changes in email id");
            dataADO.Email = "lata@gfsfh";
           string actual = page.UpdateAddressService(dataADO);
            Assert.AreEqual(actual, "UPDATE");

        }
    }
}