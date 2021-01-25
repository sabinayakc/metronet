using System;
using System.Collections.Generic;
using System.Linq;

namespace DeckOfCards
{
    public class CardDeck: ICardSorter<IList<Card>>, IDeckBuilder<IReadOnlyDictionary<string, Card>>
    {
        private IReadOnlyDictionary<string, Card> Deck => BuildDeck();

        ///summary
        ///Builds a standard deck with key value.
        ///
        public IReadOnlyDictionary<string,Card> BuildDeck() {

            var deck = new Dictionary<string, Card>();
            foreach(var suit in Enum.GetValues(typeof(Suit)).Cast<Suit>())
            {
                foreach( var number in Enum.GetValues(typeof(CardNumbers)).Cast<CardNumbers>())
                {
                    var card = new Card(number, suit);
                    deck.Add(card.Key, card);
                }
            }
            return deck;
        }

        public IList<Card> GetSortedCards(IList<Card> unsortedCards, bool descending = false)
        {
            return (descending ?
                 unsortedCards.OrderByDescending(s => Deck.TryGetValue(s.Key, out var card) ? card.Value : -1) :
                 unsortedCards.OrderBy(s => Deck.TryGetValue(s.Key, out var card) ? card.Value : -1)).ToList();
        }
    }
}
