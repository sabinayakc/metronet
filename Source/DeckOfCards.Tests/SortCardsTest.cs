using System;
using System.Collections.Generic;
using System.Linq;
using Xunit;

namespace DeckOfCards.Tests
{
    public class SortCardsTest
    {
        private static IList<Card> BuildHand() => new List<Card>()
        {
            new Card(CardNumbers.Four,Suit.Clubs),
            new Card(CardNumbers.Ace,Suit.Hearts),
            new Card(CardNumbers.Jack,Suit.Clubs),
            new Card(CardNumbers.Two,Suit.Hearts),
            new Card(CardNumbers.Nine,Suit.Spades),
            new Card(CardNumbers.Ace,Suit.Diamonds),
            new Card(CardNumbers.Six,Suit.Diamonds),
            new Card(CardNumbers.Two,Suit.Spades),
            new Card(CardNumbers.Ten,Suit.Diamonds),
        };

        private static CardDeck CardDeck => new CardDeck();

        [Fact]
        public void Should_Get_Sorted_Cards_Ascending()
        {
            var sortedCards = CardDeck.GetSortedCards(BuildHand());
            Assert.NotEmpty(sortedCards);
            var firstCard = sortedCards.First();
            var lastCard = sortedCards.Last();
            Assert.True(firstCard.CardNumber == CardNumbers.Two && firstCard.Suit == Suit.Hearts);
            Assert.True(lastCard.CardNumber == CardNumbers.Ace && lastCard.Suit == Suit.Diamonds);
        }

        [Fact]
        public void Should_Get_Sorted_Cards_Descending()
        {
            var sortedCards = CardDeck.GetSortedCards(BuildHand(), true);
            Assert.NotEmpty(sortedCards);
            var firstCard = sortedCards.First();
            var lastCard = sortedCards.Last();
            Assert.True(lastCard.CardNumber == CardNumbers.Two && lastCard.Suit == Suit.Hearts);
            Assert.True(firstCard.CardNumber == CardNumbers.Ace && firstCard.Suit == Suit.Diamonds);
        }
    }
}
