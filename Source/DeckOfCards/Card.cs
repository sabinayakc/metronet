using System;

namespace DeckOfCards
{
    public class Card
    {
        public Card(CardNumbers cardNumber, Suit suit)
        {
            this.CardNumber = cardNumber;
            this.Suit = suit;
        }
        public CardNumbers CardNumber { get; set; }
        public string Name => (int)this.CardNumber > 10 ? this.CardNumber.ToString("g") : this.CardNumber.ToString("d") + " of " + this.Suit.ToString("g");
        public string Key => $"{this.CardNumber.ToString("g")}_{this.Suit.ToString("g")}";
        public int Value =>(int)this.CardNumber + (int)this.Suit;
        public Suit Suit { get; set; }
    }
}
