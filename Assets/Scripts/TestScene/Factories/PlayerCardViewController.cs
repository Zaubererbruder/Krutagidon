using System.Collections.Generic;
using UnityEngine;
using Zenject;

public class PlayerCardViewController : MonoBehaviour
{
    [SerializeField] private Transform _handContainer;
    [SerializeField] private Transform _discardContainer;
    [SerializeField] private CardView _prefab;
    private PlayerView _playerView;
    private CardViewsController _cardViewsController;
    private PlayerView PlayerView => _playerView ??= GetComponent<PlayerView>();

    [Inject]
    public void Construct(CardViewsController cardViewsController)
    {
        _cardViewsController = cardViewsController;
    }

    public CardView Create(Card card)
    {
        CardView cardView = _cardViewsController.Create(card);
        cardView.transform.SetParent(_handContainer, false);
        cardView.Init(card, PlayerView);
        return cardView;
    }

    public CardView Remove(Card card)
    {
        return _cardViewsController.Pool(card);
    }
}