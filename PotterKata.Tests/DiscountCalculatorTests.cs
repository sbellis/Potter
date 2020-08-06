using System.Collections.Generic;
using FluentAssertions;
using NUnit.Framework;

namespace PotterKata.Tests
{
    [TestFixture]
    public class DiscountCalculatorTests
    {
        private IDiscountCalculator _discountCalculator;

        [SetUp]
        public void Setup()
        {
            _discountCalculator = new DiscountCalculator();
        }

        [Test]
        public void CalculatePrice_ZeroOrderItems()
        {
            _discountCalculator.DiscountToApply(new List<Book>()).Should().Be(0);
        }

        [Test]
        public void ZeroBooks_Returns0PercentDiscount()
        {
            var book = new Book(BookTitles.GobletOfFire);
            var bookGroup = new List<Book>
            {
                book
            };

            _discountCalculator.DiscountToApply(bookGroup).Should().Be(0);
        }

        [Test]
        public void OneBooks_Returns0PercentDiscount()
        {
            var book = new Book(BookTitles.GobletOfFire);
            var bookGroup = new List<Book>
            {
                book
            };

            _discountCalculator.DiscountToApply(bookGroup).Should().Be(0);
        }

        [Test]
        public void TwoBooks_Returns5PercentDiscount()
        {
            var bookGroup = new List<Book>
            {
                new Book(BookTitles.GobletOfFire),
                new Book(BookTitles.ChamberOfSecrets)
            };

            _discountCalculator.DiscountToApply(bookGroup).Should().Be(5);
        }

        [Test]
        public void ThreeBooks_Returns10PercentDiscount()
        {
            var bookGroup = new List<Book>
            {
                new Book(BookTitles.GobletOfFire),
                new Book(BookTitles.ChamberOfSecrets),
                new Book(BookTitles.HalfBloodPrince),
            };

            _discountCalculator.DiscountToApply(bookGroup).Should().Be(10);
        }

        [Test]
        public void FourBooks_Returns20PercentDiscount()
        {
            var bookGroup = new List<Book>
            {
                new Book(BookTitles.GobletOfFire),
                new Book(BookTitles.ChamberOfSecrets),
                new Book(BookTitles.HalfBloodPrince),
                new Book(BookTitles.OrderOfThePheonix),
            };

            _discountCalculator.DiscountToApply(bookGroup).Should().Be(20);
        }

        [Test]
        public void FiveBooks_Returns25PercentDiscount()
        {
            var bookGroup = new List<Book>
            {
                new Book(BookTitles.GobletOfFire),
                new Book(BookTitles.ChamberOfSecrets),
                new Book(BookTitles.HalfBloodPrince),
                new Book(BookTitles.OrderOfThePheonix),
                new Book(BookTitles.PhilosophersStone),
            };

            _discountCalculator.DiscountToApply(bookGroup).Should().Be(25);
        }
    }
}