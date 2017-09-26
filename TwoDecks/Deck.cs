using System;
using System.Collections.Generic;

namespace TwoDecks
{
    class Deck
    {
        public List<Card> _cards;
        private Random _random = new Random();

        public Deck()
        {
            _cards = new List<Card>();
            for(int i = 0; i < 4; i++)
            {
                for (int j = 1; j < 14; j++)
                {
                    _cards.Add(new Card((Suits)i, (Values)j));
                }
            }
        }

        public int Count { get { return _cards.Count;  } }

        public void Add(Card cardToAdd)
        {
            _cards.Add(cardToAdd);
        }


        public void Shuffle()
        {
            List<Card> shuffleList = new List<Card>();
            for(int i = _cards.Count; i > 0; i--)
            {
                int ran = _random.Next(i);
                shuffleList.Add(_cards[ran]);
                _cards.RemoveAt(ran);
            }
            _cards = shuffleList;
        }

        public IEnumerable<string> GetCardNames()
        {
            string[] cardNames = new string[_cards.Count];
            for (int i = 0; i < _cards.Count; i++)
            {
                cardNames[i] = _cards[i].Name;
            }
            return cardNames;
        }

    }
}
