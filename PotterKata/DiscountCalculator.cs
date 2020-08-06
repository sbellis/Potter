using System.Collections.Generic;
using System.Linq;

namespace PotterKata
{
    public class DiscountCalculator : IDiscountCalculator
    {
        private IDictionary<int, int> _discounts;

        public DiscountCalculator()
        {
            _discounts = new Dictionary<int, int>
            {
                {0, 0},
                {1, 0},
                {2, 5},
                {3, 10},
                {4, 20},
                {5, 25}
            };
        }

        public decimal DiscountToApply(IList<Book> bookGroup)
        {
            if (bookGroup == null || !bookGroup.Any())
            {
                return 0;
            }
            
            if(_discounts.TryGetValue(bookGroup.Count, out int discount))
            {
                return discount;
            }

            return 0;
        }
    }
}