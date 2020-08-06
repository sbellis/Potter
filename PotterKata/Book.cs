using System;

namespace PotterKata
{
    public class Book : IEquatable<Book>
    {
        public string Title { get; }

        public decimal Price { get; } = 8m;

        public Book(string title)
        {
            Title = title;
        }

        public bool Equals(Book other)
        {
            if (ReferenceEquals(null, other)) return false;
            if (ReferenceEquals(this, other)) return true;
            return Title == other.Title && Price == other.Price;
        }

        public override bool Equals(object obj)
        {
            if (ReferenceEquals(null, obj)) return false;
            if (ReferenceEquals(this, obj)) return true;
            if (obj.GetType() != this.GetType()) return false;
            return Equals((Book) obj);
        }

        public override int GetHashCode()
        {
            return ((Title != null ? Title.GetHashCode() : 0) * 397) ^ Price.GetHashCode();
        }
    }
}
