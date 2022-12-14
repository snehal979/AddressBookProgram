using CsvHelper;
using System;
using System.Collections.Generic;
using System.Formats.Asn1;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AddressBookProgram
{
    public class CsvFileAddressBook
    {
        /// <summary>
        /// Uc14 Csv File Read And Write file in Other File
        /// </summary>
        /// <param name="importFilepath"></param>
        /// <param name="addresslist"></param>
        public void CsvHandingFile(string importFilepath,List<DataOfPerson> addresslist)
        {
            string Exportfilepath = @"C:\Users\hp\Desktop\newFolder\AddressBookProgram\AddressBookProgram\AddressBookProgram\CsvFilEAddressBook.csv";

            
            //read file
            using (var reader = new StreamReader(importFilepath))
            using (var csv = new CsvReader(reader, CultureInfo.InvariantCulture))
            {
                var records = csv.GetRecords<DataOfPerson>().ToList();
                Console.WriteLine("Read data successfully from file csv");
                foreach (DataOfPerson data in records)
                {

                    Console.WriteLine("\t" + data.FirstName);

                    Console.WriteLine("\t" + data.LastName);

                    Console.WriteLine("\t" + data.Address);
                    Console.WriteLine("\t" + data.City);
                    Console.WriteLine("\t" + data.State);
                    Console.WriteLine("\t" + data.Zip);
                    Console.WriteLine("\t" + data.PhoneNUmber);
                    Console.WriteLine("\t" + data.Email);
                    Console.WriteLine("\n");
                }
                Console.WriteLine("\n----------write to csv file--------------");
                // write csv file
                using var writer = new StreamWriter(Exportfilepath);
                using var csvExport = new CsvWriter(writer, CultureInfo.InvariantCulture);
                {
                    csvExport.WriteRecords(records);
                }


            }
        }
    }
}
