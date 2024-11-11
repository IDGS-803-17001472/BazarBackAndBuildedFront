namespace ExamenBazar.Models
{
    public class Sale
    {
        public int SaleId { get; set; }
        public int ProductId { get; set; }
        public DateTime SaleDate { get; set; } = DateTime.Now;
        public int Quantity { get; set; }

        public Product Product { get; set; }
    }
}
