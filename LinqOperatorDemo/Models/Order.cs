namespace LinqOperatorDemo.Models
{
    public class Order
    {
        public int OrderId { get; set; }
        public int PersonId { get; set; }
        public decimal Amount { get; set; }
        public DateTime OrderDate { get; set; }

        public override string ToString()
        {
            return $"OrderId: {OrderId}, PersonId: {PersonId}, Amount: {Amount:C}, Date: {OrderDate:yyyy-MM-dd}";
        }
    }


}
