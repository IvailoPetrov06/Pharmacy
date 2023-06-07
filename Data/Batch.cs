namespace Pharmacy.Data
{
    public class Batch
    {
        public int Id { get; set; }
        public string BatchNumber { get; set; }
        public DateTime ManufactureDate { get; set; }
        public DateTime ExpirationDate { get; set; }
    }
}
