using FluentAssertions;
using NUnit.Framework;

namespace PotterKata.Tests
{
    [TestFixture]
    public class OrderlineTests
    {
        [TestCase(0, 1, 1)]
        [TestCase(1, 1, 2)]
        [TestCase(3, 6, 9)]
        public void WhenIncrementingOrderLineItem_ExpectedQuantityIsShown(int startingQuantity, int quantityToIncrement, int expectedQuantity)
        {
            var sut = new OrderLineItem(new Book(BookTitles.GobletOfFire), startingQuantity);
            sut.Increment(quantityToIncrement);

            sut.Quantity.Should().Be(expectedQuantity);
        }

        [TestCase(1, 1, 0)]
        [TestCase(5, 4, 1)]
        [TestCase(5, 10, 0)]
        public void WhenDecrementOrderLineItem_ExpectedQuantityIsShown(int startingQuantity, int quantityToIncrement, int expectedQuantity)
        {
            var sut = new OrderLineItem(new Book(BookTitles.GobletOfFire), startingQuantity);
            sut.Decrement(quantityToIncrement);

            sut.Quantity.Should().Be(expectedQuantity);
        }
    }
}