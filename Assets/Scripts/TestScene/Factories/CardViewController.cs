using System.Collections.Generic;
using UnityEngine;


public class CardViewController : MonoBehaviour
{
    [SerializeField] private Transform _handContainer;
    [SerializeField] private Transform _discardContainer;
    [SerializeField] private CardView _prefab;
    private PlayerView _playerView;
    private PlayerView PlayerView => _playerView ??= GetComponent<PlayerView>();

    public CardView Create(Card card)
    {
        CardView cardView = Instantiate<CardView>(_prefab, _handContainer);
        cardView.Init(card, PlayerView);
        return cardView;
    }
}