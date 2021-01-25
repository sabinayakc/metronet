using System;
using System.Collections.Generic;
using System.Text;

namespace DeckOfCards
{
    public interface IDeckBuilder<T>
    {
        T BuildDeck();
    }
}
