using System;
using System.Collections.Generic;
using System.Text;

namespace DTOs
{
    public class Cart
    {
       

        public int Id { get; set; }
        public int UserId { get; set; }
        public DateTime DateLastUpdated { get; set; }

        public Cart(int id, int userId, DateTime dateLastUpdated)
        {
            Id = id;
            UserId = userId;
            DateLastUpdated = dateLastUpdated;
        }
    }
}
