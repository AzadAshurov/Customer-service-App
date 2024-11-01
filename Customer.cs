using Newtonsoft.Json;

namespace Customer_service
{
    internal class Customer
    {
        public static string jsonAddress = @"C:\Users\Baku\Desktop\Customer service\customers.json";
        public int Id { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string PhoneNumber { get; set; }

        public static void Add(Customer customer)
        {
            List<Customer> list = PullCustomers();

            if (list.Any(x => x.Id == customer.Id))
            {
                Console.WriteLine("Customer with this ID already exist");
            }
            else
            {
                list.Add(customer);
                PushCustomers(list);
            }
        }

        public static List<Customer> PullCustomers()
        {
            if (File.Exists(jsonAddress))
            {
                using (StreamReader sr = new StreamReader(jsonAddress))
                {
                    string json = sr.ReadToEnd();
                    var list = JsonConvert.DeserializeObject<List<Customer>>(json);
                    if (list != null)
                    {
                        return list;
                    }
                    else
                    {
                        return new List<Customer>();
                    }

                }
            }
            return new List<Customer>();
        }

        public static void PushCustomers(List<Customer> list)
        {
            using (StreamWriter sw = new StreamWriter(jsonAddress))
            {
                string json = JsonConvert.SerializeObject(list);
                sw.Write(json);
            }
        }
        public static void Search(int id)
        {
            List<Customer> list = PullCustomers();

            if (list.Any(x => x.Id == id))
            {
                Console.WriteLine(list.Find(x => x.Id == id).FirstName);
            }
            else
            {
                Console.WriteLine("Doesnt exists");
            }
        }
public static void Update(int id, string newFirstName, string newLastName, string newPhoneNumber){
List<Customer> list = PullCustomers();
if (list == null)
                    { 
Console.WriteLine("No customers");
return;
}
            if (list.Any(x => x.Id == id))
            { 
var updateCustomer = list.Find(x => x.Id == id);
updateCustomer.FirstName =newFirstName;
updateCustomer.LastName =newLastName;
updateCustomer.PhoneNumber =newPhoneNumber;
PushCustomers(list);

}
else{
Console.WriteLine("This index doesnt exists");
}
}
public static void DeleteCustomer(int id){
List<Customer> list = PullCustomers();
if (list.Any(x => x.Id == id))
            { 
list.RemoveAt(id);
PushCustomers(list);
}
}
public static void GetAll(){
List<Customer> list = PullCustomers();
foreach (var customer in list)
                {
                    Console.WriteLine($"ID: {customer.Id}, FirstName: {customer.FirstName}, LastName: {customer.LastName}, PhoneNumber: {customer.PhoneNumber}");
                }
}


    }
}


