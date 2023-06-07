namespace Pharmacy.Data
{
    public class Orders
    {
        public int ID { get; set; }
        public string NumberOrder { get; set; }
        public DateTime DateOrder { get; set; }
        public int IDSupplier { get; set; }
        public virtual Supplier Supplier { get; set; }
        public int IDMedic { get; set; }
        public virtual Medication Medication { get; set; }
        public int IDBatch { get; set; }
        public virtual Batch Batch { get; set; }
        public int Quantity { get; set; }

    }
}
