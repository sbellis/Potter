using System.Collections.Generic;

namespace PotterKata
{
    public interface IBookGrouping
    {
        IEnumerable<BookGroup> Group(IEnumerable<OrderLineItem> orderLines);
    }
}