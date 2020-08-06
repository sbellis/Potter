using FluentAssertions;
using NUnit.Framework;

namespace PotterKata.Tests
{
    [TestFixture]
    public class BookTests
    {
        [Test]
        public void BookIsEquatable_WhenSameBookIsCompared()
        {
            var book = new Book(BookTitles.GobletOfFire);

            book.Equals(book).Should().BeTrue();
        }

        [Test]
        public void BookIsNotEquatable_WhenDifferentBookIsCompared()
        {
            var book1 = new Book(BookTitles.GobletOfFire);
            var book2 = new Book(BookTitles.ChamberOfSecrets);

            book1.Equals(book2).Should().BeFalse();
        }

        [Test]
        public void BookIsNotEquatable_WhenBookComparedWithNull()
        {
            var book1 = new Book(BookTitles.GobletOfFire);

            book1.Equals(null).Should().BeFalse();
        }

        [Test]
        public void BookIsEquatable_WhenSameObjectIsCompared()
        {
            var book = new Book(BookTitles.GobletOfFire);

            book.Equals((object)book).Should().BeTrue();
        }

        [Test]
        public void BookIsNotEquatable_WhenDifferentObjectIsCompared()
        {
            var book1 = new Book(BookTitles.GobletOfFire);
            var book2 = new Book(BookTitles.ChamberOfSecrets);

            book1.Equals((object)book2).Should().BeFalse();
        }
    
        [Test]
        public void BookIsNotEquatable_WhenObjectComparedWithNull()
        {
            var book1 = new Book(BookTitles.GobletOfFire);

            book1.Equals((object)null).Should().BeFalse();
        }

        [Test]
        public void GetHashcode_CalulatesSameHashForEquivalentBooks()
        {
            var book1 = new Book(BookTitles.GobletOfFire);
            var book2 = new Book(BookTitles.GobletOfFire);

            book1.GetHashCode().Should().Be(book2.GetHashCode());
        }
        
        [Test]
        public void GetHashcode_CalulatesDifferentHashForDifferentBooks()
        {
            var book1 = new Book(BookTitles.GobletOfFire);
            var book2 = new Book(BookTitles.ChamberOfSecrets);

            book1.GetHashCode().Should().NotBe(book2.GetHashCode());
        }
    }
}
