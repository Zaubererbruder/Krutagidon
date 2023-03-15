using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UnityEngine;
using UnityEngine.EventSystems;

namespace Assets.Scripts.TestScene
{
    public class UIManager : MonoBehaviour, IPointerClickHandler
    {
        private GameBoard _gameBoard;
        private UIInputType _uiInputType = UIInputType.Default;
        private CardView _selectedCard;

        public void Init(GameBoard gameBoard)
        {
            _gameBoard = gameBoard;
        }

        public void OnPointerClick(PointerEventData eventData)
        {
            Debug.Log($"Click. Type: {_uiInputType}");
            if (_uiInputType == UIInputType.Default)
            {
                if (!eventData.rawPointerPress.TryGetComponent(out _selectedCard))
                {
                    return;
                }

                if(!_gameBoard.CanPlayCard(_selectedCard.Card))
                {
                    return;
                }

                if (_selectedCard.Card.CardDefinition.NeedTargetOnPlay)
                {
                    SwitchUIInputType(UIInputType.ChooseTarget);
                }
                else
                {
                    _gameBoard.PlayCard(_selectedCard.Card);
                    //_gameBoard.ActionsPool.Add(_selectedCard.Card.CardActionsOnPlay.ToArray());
                    StartCoroutine(_gameBoard.ActionsPool.Execute());
                    //ActionData actionData = new ActionData(cardView.Card.Owner);
                    //StartCoroutine(PlayCard(cardView.Card, actionData));
                }

                return;
            }
            
            if(_uiInputType == UIInputType.ChooseTarget)
            {
                PlayerView playerView;
                if(eventData.rawPointerPress.TryGetComponent(out playerView))
                {
                    ActionData actionData 
                        = new ActionData(_selectedCard.Card.PlayerOwner)
                        .WithTarget(playerView.Player);

                    StartCoroutine(PlayCard(_selectedCard.Card, actionData));
                    _selectedCard = null;
                    SwitchUIInputType(UIInputType.Default);
                }
            }
        }
        private void SwitchUIInputType(UIInputType uiInputType)
        {
            _uiInputType = uiInputType;
        }

        private IEnumerator PlayCard(Card card, ActionData actionData)
        {
            foreach (var action in card.CardDefinition.ActionsOnPlay)
            {
                action.Execute(actionData);
                yield return null;
            }
        }
    }

    public enum UIInputType
    {
        Default,
        ChooseTarget,
        ChooseTargetEnemy,
        ChooseTargets,
        ChooseEnemyTargets
    }
}
