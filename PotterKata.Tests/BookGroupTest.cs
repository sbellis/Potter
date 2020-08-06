using System;
using System.Collections.Generic;
using System.Text;
using FluentAssertions;
using NUnit.Framework;

namespace PotterKata.Tests
{
    [TestFixture]
    public class BookGroupTest
    {
        [Test]
        public void CanOnlyAdd5BooksToGroup()
        {
            var bookGroup = new BookGroup(new DiscountCalculator());

            bookGroup.AddBookToGroup(new Book(BookTitles.GobletOfFire));
            bookGroup.AddBookToGroup(new Book(BookTitles.ChamberOfSecrets));
            bookGroup.AddBookToGroup(new Book(BookTitles.HalfBloodPrince));
            bookGroup.AddBookToGroup(new Book(BookTitles.PhilosophersStone));
            bookGroup.AddBookToGroup(new Book(BookTitles.PrisonerOfAzkaban));

            bookGroup.AddBookToGroup(new Book(BookTitles.DeathlyHallows)).Should().BeFalse();
        }

        [Test]
        public void CalculateGroupPrice_OneBook()
        {
            var bookGroup = new BookGroup(new DiscountCalculator());
            bookGroup.AddBookToGroup(new Book(BookTitles.GobletOfFire));

            bookGroup.CalculateGroupPrice().Should().Be(8m);
        }

        [Test]
        public void CalculateGroupPrice_TwoBook()
        {
            var bookGroup = new BookGroup(new DiscountCalculator());
            bookGroup.AddBookToGroup(new Book(BookTitles.GobletOfFire));
            bookGroup.AddBookToGroup(new Book(BookTitles.ChamberOfSecrets));

            bookGroup.CalculateGroupPrice().Should().Be(15.2m);
        }

        [Test]
        public void CalculateGroupPrice_ThreeBook()
        {
            var bookGroup = new BookGroup(new DiscountCalculator());
            bookGroup.AddBookToGroup(new Book(BookTitles.GobletOfFire));
            bookGroup.AddBookToGroup(new Book(BookTitles.ChamberOfSecrets));
            bookGroup.AddBookToGroup(new Book(BookTitles.DeathlyHallows));

            bookGroup.CalculateGroupPrice().Should().Be(21.6m);
        }

        [Test]
        public void CalculateGroupPrice_FourBook()
        {
            var bookGroup = new BookGroup(new DiscountCalculator());
            bookGroup.AddBookToGroup(new Book(BookTitles.GobletOfFire));
            bookGroup.AddBookToGroup(new Book(BookTitles.ChamberOfSecrets));
            bookGroup.AddBookToGroup(new Book(BookTitles.DeathlyHallows));
            bookGroup.AddBookToGroup(new Book(BookTitles.HalfBloodPrince));

            bookGroup.CalculateGroupPrice().Should().Be(25.6m);
        }

        [Test]
        public void CalculateGroupPrice_FiveBook()
        {
            var bookGroup = new BookGroup(new DiscountCalculator());
            bookGroup.AddBookToGroup(new Book(BookTitles.GobletOfFire));
            bookGroup.AddBookToGroup(new Book(BookTitles.ChamberOfSecrets));
            bookGroup.AddBookToGroup(new Book(BookTitles.DeathlyHallows));
            bookGroup.AddBookToGroup(new Book(BookTitles.HalfBloodPrince));
            bookGroup.AddBookToGroup(new Book(BookTitles.OrderOfThePheonix));

            bookGroup.CalculateGroupPrice().Should().Be(30m);
        }
    }
}
