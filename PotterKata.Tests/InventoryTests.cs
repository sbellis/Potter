using NUnit.Framework;
using FluentAssertions;

namespace PotterKata.Tests
{
    [TestFixture]
    public class InventoryTests
    {
        [Test]
        public void WhenRetrievingValidBookFromStock_NonNullValueIsReturned()
        {
            var sut = new StockInventory();
            var book = sut.GetBook(BookTitles.GobletOfFire);

            book.Should().NotBeNull();
        }

        [Test]
        public void WhenRetrievingInValidBookFromStock_NullValueIsReturned()
        {
            var sut = new StockInventory();
            var book = sut.GetBook("Invalid Title");

            book.Should().BeNull();
        }

        [Test]
        public void WhenRetrievingBookFromStock_ASingleMatchingBookIsReturned()
        {
            var sut = new StockInventory();
            var book = sut.GetBook(BookTitles.GobletOfFire);

            book.Title.Should().Be(BookTitles.GobletOfFire);
        }
    }
}