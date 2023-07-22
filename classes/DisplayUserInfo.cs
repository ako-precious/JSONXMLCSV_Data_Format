using Newtonsoft.Json.Linq;

namespace JSON_XML_CSV_Data_Format.models
{
    internal class DisplayUserInfo
    {
        public void DisplayName(JArray jsonArray)
        {
            foreach (JObject user in jsonArray)
            {
                Console.WriteLine($"{user["name"]}");
            }
        }
        public void DisplayEmail(JArray jsonArray)
        {
            Console.WriteLine("Email");

            foreach (JObject user in jsonArray)
            {
                Console.WriteLine($"{user["email"]}");
            }
        }
        public void DisplayPhoneNumber(JArray jsonArray)
        {
            foreach (JObject user in jsonArray)
            {
                Console.WriteLine($"{user["phone"]}");
            }
        }
        public void DisplayAddress(JArray jsonArray)
        {
            Console.WriteLine("Phone");

            foreach (JObject user in jsonArray)
            {
                 Console.WriteLine($"{user["address"]["suite"].ToString()}-{user["address"]["street"].ToString()}, {user["address"]["city"].ToString()}");
            }
        }
        public void DisplayUserInfoTable(JArray jsonArray)
        {
            Console.WriteLine("Name                      | Email                          | Phone                  | Address");
            Console.WriteLine("---------------------------------------------------------------------------------------------");

            foreach (JObject user in jsonArray)
            {
                string name = user["name"].ToString();
                string email = user["email"].ToString();
                string phone = user["phone"].ToString();
                string address = $"{user["address"]["suite"]}-{user["address"]["street"].ToString()}, {user["address"]["city"].ToString()}";

                Console.WriteLine($"{name.PadRight(25)} | {email.PadRight(30)} | {phone.PadRight(22)} | {address.PadRight(50)}");
            }
        }

    }
}
