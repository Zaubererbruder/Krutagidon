using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UnityEngine;
using UnityEngine.UI;

namespace Assets.Scripts.TestScene
{
    public class PlayerTestBeh : MonoBehaviour
    {
        private KrutagidonPlayer _player;
        public Text _textFieldDeckCount;
        public Transform _handContainer;
        public CardBeh _prefab;
        public List<CardBeh> CardsList = new List<CardBeh>();
        public Text _textFieldDiscardCount;
        public Text _textFieldPlayerName;
        public Text _textFieldPlayerHealth;

        public void Init(KrutagidonPlayer player)
        {
            _player = player;

            _textFieldPlayerName.text = _player.Name;

            UpdateDeck();
            UpdateHand();
            UpdateDiscard();
            UpdateHealth();
            _player.Deck.DeckChanged += UpdateDeck;
            _player.Hand.CollectionChanged += Hand_CollectionChanged;
            _player.Discard.CollectionChanged += Discard_CollectionChanged;
            _player.HealthChanged += UpdateHealth;
        }

        private void Discard_CollectionChanged(object sender, System.Collections.Specialized.NotifyCollectionChangedEventArgs e)
        {
            UpdateDiscard();
        }

        private void Hand_CollectionChanged(object sender, System.Collections.Specialized.NotifyCollectionChangedEventArgs e)
        {
            UpdateHand();
        }

        private void OnDestroy()
        {
            _player.Deck.DeckChanged -= UpdateDeck;
            _player.Hand.CollectionChanged -= Hand_CollectionChanged;
            _player.Discard.CollectionChanged -= Discard_CollectionChanged;
        }

        private void UpdateDeck()
        {
            _textFieldDeckCount.text = _player.Deck.Count.ToString();
        }

        private void UpdateHand()
        {
            foreach (CardBeh cardbeh in CardsList)
            {
                Destroy(cardbeh.gameObject);
            }
            CardsList.Clear();

            foreach (Card card in _player.Hand)
            {
                CardBeh cardBeh = Instantiate<CardBeh>(_prefab, _handContainer);
                cardBeh.Init(card);
                CardsList.Add(cardBeh);
            }
        }

        private void UpdateDiscard()
        {
            _textFieldDiscardCount.text = _player.Discard.Count.ToString();
        }

        private void UpdateHealth()
        {
            _textFieldPlayerHealth.text = _player.Health.ToString();
        }
    }
}
