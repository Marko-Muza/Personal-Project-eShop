using System;
using System.Collections.Generic;
using System.Text;

namespace DTOs
{
    public class Order
    {
        public int Id { get; set; }
        public int UserId { get; set; }
        public string Date { get; set; }
        public float TotalPrice { get; set; }
        public List<OrderItem> Items { get; set; }
    }
}
