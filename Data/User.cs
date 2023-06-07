namespace Pharmacy.Data
{
    public class User
    {
        public int Id { get; set; }
        public string Username { get; set; }
        public string Email { get; set; }
        public string Password { get; set; }
        public int ProfileImage { get; set; }
        public int Role { get; set; }
        public int Medications { get; set; }
        public int Batches { get; set; }
        public string Suppliers { get; set; }
    }
}
