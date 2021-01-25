using System;
using System.Collections.Generic;
using System.Text;

namespace DeckOfCards
{
    public interface ICardSorter<T>
    {
        T GetSortedCards(T unsortedCards, bool descending = false);
    }
}
