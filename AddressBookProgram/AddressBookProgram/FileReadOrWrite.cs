using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AddressBookProgram
{
    public class FileReadOrWrite 
    {
        /// <summary>
        /// Uc13
        /// Write A txt File Of address book
        /// </summary>
        /// <param name="filepath"></param>
        public void WriteFile(string filepath, List<DataOfPerson> addresslist)
        {
            using (StreamWriter writer = File.AppendText(filepath))
            {
                foreach (var item in addresslist)
                {
                    writer.WriteLine("\n"+item.FirstName+","+item.LastName+","+item.Address+","+item.City+","+item.State+","+item.Zip+","+item.PhoneNUmber+","+item.Email);
                }
                // data Remaining
                writer.Close();
                Console.WriteLine("close file");
                Console.WriteLine("Read the Txt file Of Address book");
                Console.WriteLine(File.ReadAllText(filepath));

            }
        }
        /// <summary>
        /// Uc13
        /// Read A file AddressBook
        /// </summary>
        /// <param name="filepath"></param>
        public void ReadFile(string filepath)
        {
            using (StreamReader sr = File.OpenText(filepath))
            {
                string s = "";
                while ((s = sr.ReadLine()) != null)
                {
                    Console.WriteLine(s);
                }
            }
            Console.ReadLine();
        }


    }
}
