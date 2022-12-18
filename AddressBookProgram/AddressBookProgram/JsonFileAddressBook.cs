using CsvHelper;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AddressBookProgram
{
    public class JsonFileAddressBook
    {
        /// <summary>
        /// UC15 JSON FILE NOT WORKING
        /// </summary>
        /// <param name="jsonfile"></param>
        /// <param name="addresslist"></param>
        public void JsonSerialize(string jsonfile, List<DataOfPerson> addresslist)
        {
           
            // Write the json file
            var  AddressJson = JsonConvert.SerializeObject(addresslist);
            File.WriteAllText( jsonfile, AddressJson);   
           
            //// read the json file
             AddressJson = File.ReadAllText(jsonfile);
            List<DataOfPerson> contacts = JsonConvert.DeserializeObject<List<DataOfPerson>>(AddressJson);

           Display(contacts);

        }
        /// <summary>
        /// Disply Method
        /// </summary>
        /// <param name="addresslist"></param>
        public void Display(List<DataOfPerson> addresslist)
        {
            foreach (var item in addresslist)
            {
                Console.WriteLine("\t"+item.FirstName+","+item.LastName+","+item.Address+","+item.City+","+item.State+","+item.Zip+","+item.PhoneNUmber+","+item.Email);
            }
        }
       
    }
}
