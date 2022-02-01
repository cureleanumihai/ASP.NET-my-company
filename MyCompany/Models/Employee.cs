namespace MyCompany.Models
{
    public class Employee
    {
        public int Id { get; set; }

        public string FirstName { get; set; }
        
        public string LastName { get; set; }

        public City City { get; set; }

        public Department Department { get; set; }

    }
}
