using System;
using System.Collections.Generic;
using System.Text;

namespace OOPSPractice
{
    class CardGameProblem
    {
    }

    interface IPlayer
    {
        void AddMoney(int money);
        void SubstractMoney(int money);
        void Play();
    }
    class Player : IPlayer
    {
        private int _money;
        public void AddMoney(int money)
        {
            _money = _money + money;
        }

        public void Play()
        {
            throw new NotImplementedException();
        }

        public void SubstractMoney(int money)
        {
            _money = _money + money;
        }
    }
    interface IGame
    {
        void PlayGame();
    }
    abstract class Game : IGame
    {
        public abstract void PlayGame();
    }
    abstract class CardGame : Game
    {
        protected CardDeck _cardDeck;
        public virtual void ShuffleDeck(int shuffleCount)
        {
            _cardDeck.Shuffle(shuffleCount);
        }
        public virtual void IntializeDeck(int numberOfCards)
        {
            _cardDeck.IntializeDeck(numberOfCards);
        }
    }
    abstract class PlayingCardGame : CardGame
    {
        public PlayingCardGame(CardDeck cardDeck)
        {
            _cardDeck = cardDeck;
        }
    }
    class ShuffleGame : PlayingCardGame
    {
        List<Player> _players = new List<Player>();
        int _shuffleCount = 5;
        public ShuffleGame(int shuffleCount, PlayingCardDeck deck) : base(deck)
        {
            _shuffleCount = shuffleCount;
        }
        public override void PlayGame()
        {
            int numberOfCards = _cardDeck.Cards.Count;
            PlayingCardDeck cardDeck = (PlayingCardDeck)_cardDeck;
            ShuffleDeck(cardDeck, _shuffleCount);
            while (cardDeck.Cards.Count > 0)
            {
                PrintMessage("Enter your choice");
                PrintMessage("p: play the game");
                PrintMessage("r: restart the game");
                PrintMessage("s: shuffle the deck");

                var ch = ReadInput();
                switch (ch)
                {
                    case "p":
                        var card = PlayCard(cardDeck);
                        if (card == null)
                        {
                            PrintMessage("Deck is empty");
                        }
                        PrintMessage("Your card name: " + card.Name + " Type: " + card.CardType);
                        break;
                    case "s":
                        ShuffleDeck(cardDeck, _shuffleCount);
                        break;
                    case "r":
                        RestartGame(cardDeck, numberOfCards);
                        break;
                }
            }
            PrintMessage("Deck is Empty. Thank you for playing!!");
        }
        private PlayingCard PlayCard(PlayingCardDeck deck)
        {
            if (deck.Cards.Count == 0)
                return null;
            var card = deck.Cards[deck.Cards.Count - 1];
            deck.Cards.RemoveAt(deck.Cards.Count - 1);
            return (PlayingCard)card;
        }

        private void ShuffleDeck(PlayingCardDeck deck, int shuffleCount)
        {
            deck.Shuffle(shuffleCount);
            foreach (var card in deck.Cards)
            {
                PlayingCard cardP = (PlayingCard)card;
                PrintMessage("Your card name: " + cardP.Name + " Type: " + cardP.CardType);
            }
        }
        private void RestartGame(PlayingCardDeck deck, int numberOfCards)
        {
            deck.IntializeDeck(numberOfCards);
        }
        private void PrintMessage(string message)
        {
            Console.WriteLine(message);
        }
        private string ReadInput()
        {
            return Console.ReadLine();
        }
    }
    public abstract class Card
    {
        public string Name { get; set; }
    }
    public class PlayingCard : Card
    {
        public PlayingCardType CardType { get; set; }
    }
    public enum PlayingCardType
    {
        Club,
        Spade,
        Diamond,
        Heart
    }
    public class UnoCard : Card
    {
        public int CartPoint { get; set; }
    }

    abstract class CardDeck
    {
        public int TotalNumberOfCards { get; set; }
        Random random = new Random();
        public CardDeck(int numberOfCards)
        {
            TotalNumberOfCards = numberOfCards;
            IntializeDeck(numberOfCards);
        }
        public List<Card> Cards;
        public virtual void IntializeDeck(int numberOfCards)
        {
            Cards = new List<Card>();
            for (int i = 1; i <= numberOfCards; i++)
            {
                var card = GetCard(i);
                Cards.Add(card);
            }
        }
        public virtual void Shuffle(int shuffleCount)
        {
            int n = Cards.Count - 1;
            while (shuffleCount > 1)
            {
                int k = random.Next(n);
                var value = Cards[k];
                Cards[k] = Cards[n];
                Cards[n] = value;
                shuffleCount--;
            }
        }
        public abstract Card GetCard(int i);

    }

    class UnoCardDeck : CardDeck
    {
        public UnoCardDeck(int numberOfCards) : base(numberOfCards)
        {

        }
        public override Card GetCard(int i)
        {
            return new UnoCard() { Name = GetCardName(i), CartPoint = i };
        }
        private string GetCardName(int index)
        {
            if (index % 13 == 1)
            {
                return "A";
            }
            if (index % 13 == 11)
            {
                return "J";
            }
            if (index % 13 == 12)
            {
                return "Q";
            }
            if (index % 13 == 0)
            {
                return "K";
            }
            return (index % 13).ToString();
        }
    }
    class PlayingCardDeck : CardDeck
    {
        public PlayingCardDeck(int numberOfCards) : base(numberOfCards)
        {

        }
        public override Card GetCard(int i)
        {
            return new PlayingCard() { CardType = GetCardType(i), Name = GetCardName(i) };
        }

        private PlayingCardType GetCardType(int index)
        {
            if (index >= 0 && index <= 13)
            {
                return PlayingCardType.Club;
            }
            if (index >= 14 && index <= 26)
            {
                return PlayingCardType.Diamond;
            }
            if (index >= 27 && index <= 39)
            {
                return PlayingCardType.Heart;
            }
            else
            {
                return PlayingCardType.Spade;
            }
        }
        private string GetCardName(int index)
        {
            if (index % 13 == 1)
            {
                return "A";
            }
            if (index % 13 == 11)
            {
                return "J";
            }
            if (index % 13 == 12)
            {
                return "Q";
            }
            if (index % 13 == 0)
            {
                return "K";
            }
            return (index % 13).ToString();
        }
    }
}
