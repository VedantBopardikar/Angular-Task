namespace Forms.api.Models
{
    public class FormModel
    {
        public Guid Id { get; set; }

        public string FirstName { get; set; }

        public string MiddleName { get; set; }
        public string LastName { get; set; }

        public string Email { get; set; }
        public int ContactNumber { get; set; }

        public string Address1 { get; set; }
        public string Address2 { get; set; }
        
        public string City { get; set; }

        public int Zip { get; set; }

    }
}
