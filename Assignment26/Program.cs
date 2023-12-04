using System;
using System.Collections.Generic;
using System.Linq;
using System.IO;
using System.Runtime.Serialization.Formatters.Binary;
using System.Runtime.Serialization;
using System.Text;
using System.Threading.Tasks;
using System.Globalization;
using System.Runtime.Remoting;
using System.Xml.Serialization;

namespace Assignment26
{
    internal class Program
    {
        static void Main(string[] args)
        {
            //Object instantiation
            Employee emp = new Employee()
            {
                Id = 1,
                FirstName = "Mukesh",
                LastName = "Ambani",
                Salary = 45000.00
            };

            //Binary Serialization
            IFormatter formatter = new BinaryFormatter();
            Stream stream = new FileStream(@"G:\SimpliLearn\Phase 1\Day 21\Assignment26\employee.bin", FileMode.Create, FileAccess.Write);

            formatter.Serialize(stream, emp);
            stream.Close();
            stream = new FileStream(@"G:\SimpliLearn\Phase 1\Day 21\Assignment26\employee.bin", FileMode.Open, FileAccess.Read);
            
            //Binary Deserialization
            Employee empBinDes = (Employee)formatter.Deserialize(stream);
            Console.WriteLine("Here is the Employee object after binary deserialization");
            Console.WriteLine("Employee ID:\t"+empBinDes.Id);
            Console.WriteLine("First Name:\t"+empBinDes.FirstName);
            Console.WriteLine("Last Name:\t"+empBinDes.LastName);
            Console.WriteLine("Emp Salary:\t"+empBinDes.Salary);
            Console.WriteLine("\n");

            if (emp.Id == empBinDes.Id && emp.FirstName == empBinDes.FirstName && emp.LastName == empBinDes.LastName && emp.Salary == empBinDes.Salary)
            {
                Console.WriteLine("Binary Deserialized Object Properties match the original Object, confirmed!\n");
            }

            //XML Serialization
            XmlSerializer serializer = new XmlSerializer(typeof(Employee));
            using (TextWriter writer = new StreamWriter("employee.xml"))
            {
                serializer.Serialize(writer, emp);
            }

            //XML Deserialization
            Console.WriteLine("Here is the Employee object after XML deserialization");
            using (TextReader reader = new StreamReader("employee.xml"))
            {
                Employee empXMLdes = (Employee)serializer.Deserialize(reader);
                Console.WriteLine("Employee ID:\t"+empXMLdes.Id);
                Console.WriteLine("First Name:\t" + empXMLdes.FirstName);
                Console.WriteLine("Last Name:\t" + empXMLdes.LastName);
                Console.WriteLine("Emp Salary:\t" + empXMLdes.Salary);
                Console.WriteLine("\n");
                if (emp.Id == empXMLdes.Id && emp.FirstName == empXMLdes.FirstName && emp.LastName == empXMLdes.LastName && emp.Salary == empXMLdes.Salary)
                {
                    Console.WriteLine("XML Deserialized Object Properties match the original Object, confirmed!");
                }
            }
            Console.ReadKey();
        }
    }
}
