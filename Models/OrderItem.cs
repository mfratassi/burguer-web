namespace LanchesWeb.Models
{
    public class OrderItem
    {
        public int OrderItemId { get; set; }

        public int OrderId { get; set; }

        public int SnackId { get; set; }

        public int Quantity { get; set; }

        public decimal Price { get; set; }

        public virtual Snack Snack { get; set; }

        public virtual Order Order { get; set; }

    }
}
