﻿using System;
using System.Collections;
using System.Collections.Generic;
using System.Collections.Specialized;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UnityEngine;
using UnityEngine.UI;
using Zenject;

public class PlayerView : MonoBehaviour
{
    [SerializeField] private PlayerCardViewController _playerCardViewController;

    private Player _player;
    public Text _textFieldDeckCount;
    public List<CardView> CardsList = new List<CardView>();
    public Text _textFieldDiscardCount;
    public Text _textFieldPlayerName;
    public Text _textFieldPlayerHealth;
    public Text _textFieldPlayerPower;

    public Player Player => _player;

    public void Init(Player player)
    {
        _player = player;

        _textFieldPlayerName.text = _player.Name;

        UpdateDeck();
        UpdateHand();
        UpdateDiscard();
        UpdateHealth();
        UpdatePower();
        _player.Deck.DeckChanged += UpdateDeck;
        _player.Hand.CollectionChanged += Hand_CollectionChanged;
        _player.Discard.CollectionChanged += Discard_CollectionChanged;
        _player.HealthChanged += UpdateHealth;
        _player.PowerChanged += UpdatePower;
    }

    private void Discard_CollectionChanged(object sender, NotifyCollectionChangedEventArgs e)
    {
        UpdateDiscard();
    }

    private void Hand_CollectionChanged(object sender, NotifyCollectionChangedEventArgs e)
    {
        CardView cardView = null;
        switch (e.Action)
        {
            case NotifyCollectionChangedAction.Add:
                cardView = _playerCardViewController.Create(e.NewItems[0] as Card);
                CardsList.Add(cardView);
                break;
            case NotifyCollectionChangedAction.Remove:
                cardView = _playerCardViewController.Remove(e.OldItems[0] as Card);
                CardsList.Remove(cardView);
                break;
            default:
                throw new NotImplementedException($"NotifyCollectionChangedEventArgs.Action {e.Action.ToString()} not implemented");
        }
        
        //UpdateHand();
    }

    private void OnDestroy()
    {
        _player.Deck.DeckChanged -= UpdateDeck;
        _player.Hand.CollectionChanged -= Hand_CollectionChanged;
        _player.Discard.CollectionChanged -= Discard_CollectionChanged;
        _player.HealthChanged -= UpdateHealth;
        _player.PowerChanged -= UpdatePower;
    }

    private void UpdateDeck()
    {
        _textFieldDeckCount.text = _player.Deck.Count.ToString();
    }

    private void UpdateHand()
    {
        foreach (CardView cardbeh in CardsList)
        {
            Destroy(cardbeh.gameObject);
        }
        CardsList.Clear();

        foreach (Card card in _player.Hand)
        {
            CardView cardView = _playerCardViewController.Create(card);
            CardsList.Add(cardView);
        }
    }

    private void UpdateDiscard()
    {
        _textFieldDiscardCount.text = _player.Discard.Count.ToString();
    }

    private void UpdateHealth()
    {
        _textFieldPlayerHealth.text = $"H: {_player.Health.ToString()}";
    }

    private void UpdatePower()
    {
        _textFieldPlayerPower.text = $"P: {_player.Power.ToString()}";
    }
}
