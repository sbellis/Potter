using System;
using System.Collections.Generic;
using System.Text;

namespace PotterKata
{
    public interface IDiscountCalculator
    {
        decimal DiscountToApply(IList<Book> bookGroup);
    }
}
