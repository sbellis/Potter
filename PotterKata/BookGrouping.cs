using System.Collections.Generic;
using System.Linq;

namespace PotterKata
{
    public class BookGrouping : IBookGrouping
    {
        private IDiscountCalculator _discountCalculator;

        public BookGrouping(IDiscountCalculator discountCalculator)
        {
            _discountCalculator = discountCalculator;
        }

        public IEnumerable<BookGroup> Group(IEnumerable<OrderLineItem> orderLines)
        {
            var bookGroups = new List<BookGroup>();

            foreach (var orderLineItem in orderLines)
            {
                ProcessBookQuantity(orderLineItem, bookGroups);
            }

            return bookGroups;
        }

        private void ProcessBookQuantity(OrderLineItem orderLineItem, IList<BookGroup> bookGroups)
        {
            if (!bookGroups.Any())
            {
                bookGroups.Add(new BookGroup(_discountCalculator));
            }
            
            for (int i = 0; i < orderLineItem.Quantity; i++)
            {
                var addedToGroup = false;
                foreach (var bookGroup in bookGroups)
                {
                    addedToGroup = bookGroup.AddBookToGroup(orderLineItem.Book);
                    if (addedToGroup)
                    {
                        break;
                    }
                }

                if (!addedToGroup)
                {
                    var bookGroup = new BookGroup(_discountCalculator);
                    bookGroup.AddBookToGroup(orderLineItem.Book);
                    bookGroups.Add(bookGroup);
                }
            }
        }
    }
}