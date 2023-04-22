using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Assets.Krutagidon
{
    public class StarterCardDistributor
    {
        private List<Player> _players;

        public StarterCardDistributor(List<Player> players)
        {
            _players = players;
        }

        public void Distribute()
        {
            foreach (var player in _players)
            {
                List<Card> cardsList = new List<Card>();
                cardsList.Add(
                    CreateCard(KrutagidonCards.FizzleCardDefinition, player)
                    );
                cardsList.Add(
                    CreateCard(KrutagidonCards.FizzleCardDefinition, player)
                    );
                cardsList.Add(
                    CreateCard(KrutagidonCards.FizzleCardDefinition, player)
                    );


                cardsList.Add(
                    CreateCard(KrutagidonCards.GlyphCardDefinition, player)
                    );
                cardsList.Add(
                    CreateCard(KrutagidonCards.GlyphCardDefinition, player)
                    );
                cardsList.Add(
                    CreateCard(KrutagidonCards.GlyphCardDefinition, player)
                    );
                cardsList.Add(
                    CreateCard(KrutagidonCards.GlyphCardDefinition, player)
                    );
                cardsList.Add(
                    CreateCard(KrutagidonCards.GlyphCardDefinition, player)
                    );
                cardsList.Add(
                    CreateCard(KrutagidonCards.GlyphCardDefinition, player)
                    );


                cardsList.Add(
                    CreateCard(KrutagidonCards.WandCardDefinition, player)
                    );

                bool shuffle = true;
                player.Deck.AddCardsToDeck(cardsList, shuffle);
            }
        }

        private Card CreateCard(CardDefinition definition, Player player)
        {
            Card card = new Card(definition);
            card.ChangeOwner(player);
            return card;
        }
    }
}
