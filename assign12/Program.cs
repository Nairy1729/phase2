using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace assign12
{
    public class Program
    {
        static void Main(string[] args)
        {
            Customer customer = new Customer
            {
                Name = "John Doe",
                Email = "john.doe@example.com",
                PhoneNumber = "1234567890",
                DateOfBirth = new DateTime(2020, 5, 20)
            };

            bool isValidCustomer = customer.IsValid();

            Console.WriteLine($"Is the customer valid? {isValidCustomer}");
            Console.ReadKey();
        }
    }
}
