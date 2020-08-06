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
    }
}
