using System;
using System.Collections.Generic;
using System.Linq;

namespace PotterKata
{
    public class StockInventory
    {
        private IDictionary<string, Book> books;

        public StockInventory()
        {
            this.books = new Dictionary<string, Book>
            {
                {BookTitles.PhilosophersStone, new Book(BookTitles.PhilosophersStone)},
                {BookTitles.ChamberOfSecrets, new Book(BookTitles.ChamberOfSecrets)},
                {BookTitles.PrisonerOfAzkaban, new Book(BookTitles.PrisonerOfAzkaban)},
                {BookTitles.GobletOfFire, new Book(BookTitles.GobletOfFire)},
                {BookTitles.OrderOfThePheonix, new Book(BookTitles.OrderOfThePheonix)},
                {BookTitles.HalfBloodPrince, new Book(BookTitles.HalfBloodPrince)},
                {BookTitles.DeathlyHallows, new Book(BookTitles.DeathlyHallows)}
            };
        }

        public Book GetBook(string title)
        {
            var book = books.SingleOrDefault(x => x.Key.Equals(title, StringComparison.OrdinalIgnoreCase));
            return book.Value;
        }
    }
}