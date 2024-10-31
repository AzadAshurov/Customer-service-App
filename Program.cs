
using Customer_service;

internal class Program
{
    static void Main(string[] args)
    {
        string address = @"C:\Users\Baku\Desktop\Customer service";
        Directory.CreateDirectory(address);
        string filePath = Path.Combine(address, "customers.json");

        if (!File.Exists(filePath))
        {
            using (StreamWriter sw = new StreamWriter(filePath))
            {
                sw.Write("[]");
            }
        }

        Customer.Add(new Customer() { FirstName = "Minecart", Id = 45, LastName = "Cave", PhoneNumber = "+666 66 666" });
        Customer.Search(5);
    }
}
