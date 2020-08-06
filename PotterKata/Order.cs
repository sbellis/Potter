using System.Collections;
using System.Collections.Generic;
using System.Linq;

namespace PotterKata
{
    public class Order : IEnumerable<OrderLineItem>
    {
        private readonly IList<OrderLineItem> _orderLineItems = new List<OrderLineItem>();
        private readonly IBookGrouping _bookGrouping;

        public Order(IBookGrouping bookGrouping)
        {
            _bookGrouping = bookGrouping;
        }

        public void AddOrderLineItem(Book book, int quantity = 1)
        {
            var existingOrderLineItem = _orderLineItems.SingleOrDefault(x => x.Book.Equals(book));

            if (existingOrderLineItem == null)
            {
                _orderLineItems.Add(new OrderLineItem(book, quantity));
            }
            else
            {
                existingOrderLineItem.Increment(quantity);
            }
        }

        public void RemoveLineItem(Book book, int quantity = 1)
        {
            var existingOrderLineItem = _orderLineItems.SingleOrDefault(x => x.Book.Equals(book));
            if (existingOrderLineItem != null)
            {
                if (existingOrderLineItem.Quantity - quantity <= 0)
                {
                    _orderLineItems.Remove(existingOrderLineItem);
                }
                else
                {
                    existingOrderLineItem.Decrement(quantity);
                }
            }
        }

        public decimal CalculateOrderPrice()
        {
            if(!_orderLineItems.Any()) return 0;

            var bookGroups = _bookGrouping.Group(_orderLineItems);
            return bookGroups.Sum(x => x.CalculateGroupPrice());
        }

        public IEnumerator<OrderLineItem> GetEnumerator()
        {
            return _orderLineItems.GetEnumerator();
        }

        IEnumerator IEnumerable.GetEnumerator()
        {
            return GetEnumerator();
        }
    }
}