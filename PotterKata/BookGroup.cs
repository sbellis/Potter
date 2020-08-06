using System.Collections.Generic;
using System.Linq;

namespace PotterKata
{
    public class BookGroup
    {
        private IDiscountCalculator _discountCalculator;
        private IList<Book> _books;

        public BookGroup(IDiscountCalculator discountCalculator)
        {
            _discountCalculator = discountCalculator;
            _books = new List<Book>();
        }

        public bool AddBookToGroup(Book book)
        {
            var existingBook = _books.SingleOrDefault(x => x.Equals(book));
            if (existingBook == null)
            {
                _books.Add(book);
            }

            return existingBook == null;
        }

        public decimal CalculateGroupPrice()
        {
            var discount = _discountCalculator.DiscountToApply(_books);

            return _books.Sum(x => x.Price -((x.Price * discount) / 100));
        }
    }
}