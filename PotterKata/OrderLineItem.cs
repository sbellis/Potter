using System.Collections.Generic;

namespace PotterKata
{
    public class OrderLineItem
    {
        public Book Book { get; }
        public int Quantity { get; private set; }

        public OrderLineItem(Book book, int quantity = 1)
        {
            Book = book;
            Quantity = quantity;
        }

        public void Increment(int quantity)
        {
            Quantity += quantity;
        }

        public void Decrement(int quantity)
        {
            if (Quantity - quantity < 0)
            {
                Quantity = 0;
            }
            else
            {
                Quantity -= quantity;
            }
        }
    }
}