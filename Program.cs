
using Customer_service;

internal class Program
{
    static void Main(string[] args)
    {
        string address = @"C:\Users\II novbe\Desktop\Customer-service-App";
        Directory.CreateDirectory(address);
        string filePath = Path.Combine(address, "customers.json");

        if (!File.Exists(filePath))
        {
            using (StreamWriter sw = new StreamWriter(filePath))
            {
                sw.Write("[]");
            }
        }

        Customer.Add(new Customer() { FirstName = "Minecart", Id = 1, LastName = "Cave", PhoneNumber = "+666 66 666" });
        Customer.Add(new Customer() { FirstName = "Mine", Id = 2, LastName = "Caveman", PhoneNumber = "+4566454554" });
        Customer.Search(1);
        Customer.DeleteCustomer(1);
        Customer.Update(2, "Boat", "red", "765457654");
    }
}
