namespace Models
{
    public class Transaction
    {
        public int TransactionId {get; set;}
        public int ProductId {get; set;}
        public Product Product {get; set;}
        public string Description {get; set;}
        public string DateTransaction {get; set;}
    }
}