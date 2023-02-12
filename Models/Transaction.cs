using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Models
{
    public class Transaction
    {
        public int TransactionID {get; set;}
        public int ProductId {get; set;}
        public Product Product {get; set;}
        public string Description {get; set;}
        public string DateTransaction {get; set;}
    }
}