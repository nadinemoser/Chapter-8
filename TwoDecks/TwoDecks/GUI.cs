using System;
using System.Windows.Forms;

namespace TwoDecks
{
    public partial class GUI : Form
    {
        Random _random = new Random();
        Deck _deck1;
        Deck _deck2;

        public GUI()
        {
            InitializeComponent();
            _deck1 = new Deck();
            _deck2 = new Deck();

            ResetDeck(1);
            RedrawDeck(1);
            ResetDeck(2);
            RedrawDeck(2);
        }

        public void ResetDeck(int decknumber)
        {
            Deck newDeck = new Deck();
            if (decknumber == 1)
            {
                _deck1 = new Deck();
                newDeck._cards.Clear();
                for (int i = 0; i < _random.Next(12); i++)
                {
                    newDeck.Add(_deck1._cards[_random.Next(_deck1.Count)]);
                }
                _deck1 = newDeck;
            }
            
            if( decknumber == 2 )
            {
                _deck2 = new Deck();
            }
        }

        private void RedrawDeck(int DeckNumber)
        {
            if (DeckNumber == 1)
            {
                listBox1.Items.Clear();
                foreach (string cardName in _deck1.GetCardNames())
                {
                    listBox1.Items.Add(cardName);
                }
                label1.Text = "Deck #1 (" + _deck1.Count + " cards)";
            }
            else
            {
                listBox2.Items.Clear();
                foreach (string cardName in _deck2.GetCardNames())
                {
                    listBox2.Items.Add(cardName);
                }
                label2.Text = "Deck #2 (" + _deck2.Count + " cards)";
            }
        }

        private void moveToDeck1_Click(object sender, EventArgs e)
        {
            if (listBox2.SelectedIndex > 0)
            {
                _deck1.Add(_deck2._cards[listBox2.SelectedIndex]);
                _deck2._cards.RemoveAt(listBox2.SelectedIndex);
                RedrawDeck(1);
                RedrawDeck(2);
            }          
        }

        private void moveToDeck2_Click(object sender, EventArgs e)
        {
            if (listBox1.SelectedIndex > 0)
            {
                _deck2.Add(_deck1._cards[listBox1.SelectedIndex]);
                _deck1._cards.RemoveAt(listBox1.SelectedIndex);
                RedrawDeck(1);
                RedrawDeck(2);
            }
            
        }

        private void reset1_Click(object sender, EventArgs e)
        {
            ResetDeck(1);
            RedrawDeck(1);
        }

        private void reset2_Click(object sender, EventArgs e)
        {
            ResetDeck(2);
            RedrawDeck(2);
        }

        private void shuffle1_Click(object sender, EventArgs e)
        {
            _deck1.Shuffle();
            RedrawDeck(1);
        }

        private void shuffle2_Click(object sender, EventArgs e)
        {
            _deck2.Shuffle();
            RedrawDeck(2);
        }    
    }
}
