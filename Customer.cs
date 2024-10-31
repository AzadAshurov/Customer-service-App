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
    }
}