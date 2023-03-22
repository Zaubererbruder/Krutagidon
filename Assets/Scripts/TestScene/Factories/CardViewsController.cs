using UnityEngine;
using Zenject;

public class CardViewsController : MonoBehaviour
{
    [SerializeField] private CardView _prefab;
    private Transform _transform;
    private CardViewsPool _pool;

    [Inject]
    public void Construct(CardViewsPool pool)
    {
        _pool = pool;
        _transform = GetComponent<Transform>();
    }

    public CardView Create(Card card)
    {
        CardView cardView = null;
        if (!_pool.TryGet(card, out cardView))
        {
            cardView = Instantiate(_prefab, _transform);
            _pool.Add(card, cardView);
        }

        return cardView;
    }

    public CardView Pool(Card card)
    {
        CardView cardView = _pool.Get(card);
        cardView.transform.SetParent(_transform, false);
        return cardView;
    }
}
