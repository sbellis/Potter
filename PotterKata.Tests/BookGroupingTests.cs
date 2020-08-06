using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using FluentAssertions;
using NUnit.Framework;

namespace PotterKata.Tests
{
    [TestFixture]
    public class BookGroupingTests
    {
        private IBookGrouping bookGrouping;

        [SetUp]
        public void Setup()
        {
            bookGrouping = new BookGrouping(new DiscountCalculator());
        }


        [Test]
        public void SingleOrderLineWithQuantityOf1_SingleGroupReturned()
        {
            var orderLines = new List<OrderLineItem>
            {
                new OrderLineItem(new Book(BookTitles.GobletOfFire), 1)
            };

            var bookGroups = bookGrouping.Group(orderLines);

            bookGroups.Count().Should().Be(1);
        }
        
        [Test]
        public void SingleOrderLineWithQuantityOf2_2GroupsReturned()
        {
            var orderLines = new List<OrderLineItem>
            {
                new OrderLineItem(new Book(BookTitles.GobletOfFire), 2)
            };

            var bookGroups = bookGrouping.Group(orderLines);

            bookGroups.Count().Should().Be(2);
        }

        [Test]
        public void MultipleOrderLineWithQuantityOf1_1GroupsReturned()
        {
            var orderLines = new List<OrderLineItem>
            {
                new OrderLineItem(new Book(BookTitles.GobletOfFire), 1),
                new OrderLineItem(new Book(BookTitles.ChamberOfSecrets), 1)
            };

            var bookGroups = bookGrouping.Group(orderLines);

            bookGroups.Count().Should().Be(1);
        }

        [Test]
        public void MultipleOrderLineWithQuantityOf2_2GroupsReturned()
        {
            var orderLines = new List<OrderLineItem>
            {
                new OrderLineItem(new Book(BookTitles.GobletOfFire), 2),
                new OrderLineItem(new Book(BookTitles.ChamberOfSecrets), 2)
            };

            var bookGroups = bookGrouping.Group(orderLines);

            bookGroups.Count().Should().Be(2);
        }

        [Test]
        public void MultipleOrderLineWithDifferentQuantities_MultipleGroupsReturned()
        {
            var orderLines = new List<OrderLineItem>
            {
                new OrderLineItem(new Book(BookTitles.GobletOfFire), 2),
                new OrderLineItem(new Book(BookTitles.ChamberOfSecrets), 3),
                new OrderLineItem(new Book(BookTitles.HalfBloodPrince), 1),
            };

            var bookGroups = bookGrouping.Group(orderLines);

            bookGroups.Count().Should().Be(3);
        }

        [Test]
        public void CalculateGroupPrice_OneBook()
        {
            var orderLines = new List<OrderLineItem>
            {
                new OrderLineItem(new Book(BookTitles.GobletOfFire), 1)
                
            };

            var bookGroups = bookGrouping.Group(orderLines);
            bookGroups.First().CalculateGroupPrice().Should().Be(8);
        }

        [Test]
        public void CalculateGroupPrice_TwoBooks()
        {
            var orderLines = new List<OrderLineItem>
            {
                new OrderLineItem(new Book(BookTitles.GobletOfFire), 1),
                new OrderLineItem(new Book(BookTitles.ChamberOfSecrets), 1)
            };

            var bookGroups = bookGrouping.Group(orderLines);
            bookGroups.First().CalculateGroupPrice().Should().Be(15.2m);
        }

        [Test]
        public void CalculateGroupPrice_ThreeBooks()
        {
            var orderLines = new List<OrderLineItem>
            {
                new OrderLineItem(new Book(BookTitles.GobletOfFire), 1),
                new OrderLineItem(new Book(BookTitles.ChamberOfSecrets), 1),
                new OrderLineItem(new Book(BookTitles.HalfBloodPrince), 1)
            };

            var bookGroups = bookGrouping.Group(orderLines);
            bookGroups.First().CalculateGroupPrice().Should().Be(21.6m);
        }

        [Test]
        public void CalculateGroupPrice_FourBooks()
        {
            var orderLines = new List<OrderLineItem>
            {
                new OrderLineItem(new Book(BookTitles.GobletOfFire), 1),
                new OrderLineItem(new Book(BookTitles.ChamberOfSecrets), 1),
                new OrderLineItem(new Book(BookTitles.HalfBloodPrince), 1),
                new OrderLineItem(new Book(BookTitles.OrderOfThePheonix), 1)
            };

            var bookGroups = bookGrouping.Group(orderLines);
            bookGroups.First().CalculateGroupPrice().Should().Be(25.6m);
        }

        [Test]
        public void CalculateGroupPrice_FiveBooks()
        {
            var orderLines = new List<OrderLineItem>
            {
                new OrderLineItem(new Book(BookTitles.GobletOfFire), 1),
                new OrderLineItem(new Book(BookTitles.ChamberOfSecrets), 1),
                new OrderLineItem(new Book(BookTitles.HalfBloodPrince), 1),
                new OrderLineItem(new Book(BookTitles.OrderOfThePheonix), 1),
                new OrderLineItem(new Book(BookTitles.PhilosophersStone), 1)
            };

            var bookGroups = bookGrouping.Group(orderLines);
            bookGroups.First().CalculateGroupPrice().Should().Be(30m);
        }
    }
}
