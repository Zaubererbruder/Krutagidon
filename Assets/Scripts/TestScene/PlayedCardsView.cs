using System;
using System.Collections.Generic;
using System.Collections.Specialized;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UnityEngine;
using Zenject;

namespace Assets.Scripts.TestScene
{
    public class PlayedCardsView : MonoBehaviour
    {
        [SerializeField] private Transform _container;
        private CardsOnPlay _cardsOnPlay;
        private CardViewsController _cardViewsController;


        [Inject]
        public void Construct(CardViewsController cardsController)
        {
            _cardViewsController = cardsController;
        }

        public void Init(CardsOnPlay cardsOnPlay)
        {
            _cardsOnPlay = cardsOnPlay;
            _cardsOnPlay.CollectionChanged += _cardsOnPlay_CollectionChanged;
        }

        private void _cardsOnPlay_CollectionChanged(object sender, NotifyCollectionChangedEventArgs e)
        {
            CardView cardView = null;
            switch (e.Action)
            {
                case NotifyCollectionChangedAction.Add:
                    cardView = _cardViewsController.Create(e.NewItems[0] as Card);
                    cardView.transform.SetParent(_container, false);
                    break;
                case NotifyCollectionChangedAction.Remove:
                    _cardViewsController.Pool(e.OldItems[0] as Card);
                    break;
                default:
                    throw new NotImplementedException($"NotifyCollectionChangedEventArgs.Action {e.Action.ToString()} not implemented");
            }
        }

        private void OnDestroy()
        {
            _cardsOnPlay.CollectionChanged -= _cardsOnPlay_CollectionChanged;
        }
    }
}
