using System;
using System.Collections.Generic;
using System.Linq;
using FluentAssertions;
using NUnit.Framework;

namespace PotterKata.Tests
{
    [TestFixture]
    public class OrderTests
    {
        private Order _order;

        [SetUp()]
        public void Setup()
        {
            var bookGroup = new BookGrouping(new DiscountCalculator());
            _order = new Order(bookGroup);
        }

        [Test]
        public void AddBooksToOrder_CreatesExpectedOrderLines()
        {
            var orderList = new List<Book>
            {
                new Book(BookTitles.GobletOfFire),
                new Book(BookTitles.ChamberOfSecrets),
                new Book(BookTitles.HalfBloodPrince)
            };

            foreach (var book in orderList)
            {
                _order.AddOrderLineItem(book);
            }

            var actual = _order.Select(x => x).ToList();

            actual.Select(x => x.Book).Should().BeEquivalentTo(orderList);
        }

        [TestCase(1, 1)]
        [TestCase(3, 3)]
        public void AddingNewItemToOrder_CreatesBookOrderLineWithCorrectQuantity(int quantity, int expectedQuantity)
        {
            _order.AddOrderLineItem(new Book(BookTitles.ChamberOfSecrets), quantity);

            _order.Single(x => x.Book.Title.Equals(BookTitles.ChamberOfSecrets, StringComparison.OrdinalIgnoreCase))
                .Quantity
                .Should().Be(expectedQuantity);
        }

        [TestCase(1, 0, 1)]
        [TestCase(10, 1, 9)]
        [TestCase(10, 9, 1)]
        public void RemoveLineItemFromOrder_BookOrderLineQuantityIsExpectedValue(int initialQuantity, int quantityToRemove, int expectedQuantity)
        {
            var book = new Book(BookTitles.ChamberOfSecrets);

            _order.AddOrderLineItem(book, initialQuantity);

            _order.RemoveLineItem(book, quantityToRemove);

            _order.Single(x => x.Book.Title.Equals(BookTitles.ChamberOfSecrets, StringComparison.OrdinalIgnoreCase))
                .Quantity
                .Should().Be(expectedQuantity);
        }

        [Test]
        public void RemoveLineItem_QuantityGoesBelow0_ItemIsRemovedFromOrderLines()
        {
            var book = new Book(BookTitles.ChamberOfSecrets);

            _order.AddOrderLineItem(book);
            _order.RemoveLineItem(book);

            var orderLineItem = _order.SingleOrDefault(x =>
                x.Book.Title.Equals(BookTitles.ChamberOfSecrets, StringComparison.OrdinalIgnoreCase));

            orderLineItem.Should().BeNull();
        }

        [Test]
        public void OrderCalculateTotal()
        {
            _order.AddOrderLineItem(new Book(BookTitles.GobletOfFire),2);
            _order.AddOrderLineItem(new Book(BookTitles.ChamberOfSecrets),2);
            _order.AddOrderLineItem(new Book(BookTitles.HalfBloodPrince),2);
            _order.AddOrderLineItem(new Book(BookTitles.OrderOfThePheonix),1);
            _order.AddOrderLineItem(new Book(BookTitles.PhilosophersStone),1);

            var price = _order.CalculateOrderPrice();

            price.Should().Be(51.6m);
        }
    }
}