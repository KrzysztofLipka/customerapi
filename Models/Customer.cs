namespace customerapi.Models
{

    public class Customer
    {
        public Customer(string name, string surname)
        {
            Name = name;
            Surname = surname;
        }
        public string Name { get; set; }

        public string Surname { get; set; }
    }
}