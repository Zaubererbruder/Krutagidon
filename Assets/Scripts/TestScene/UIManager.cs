using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UI;

namespace Assets.Scripts.TestScene
{
    public class UIManager : MonoBehaviour, IPointerClickHandler
    {
        private GameBoard _gameBoard;
        private UIInputType _uiInputType = UIInputType.Default;
        private CardView _selectedCard;
        public Text _textFieldCurrentPlayer;

        public void Init(GameBoard gameBoard)
        {
            _gameBoard = gameBoard;
            UpdateCurrentPlayer();
            _gameBoard.TurnChanged += UpdateCurrentPlayer;
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

                _gameBoard.PlayCard(_selectedCard.Card);
                SwitchUIInputType(UIInputType.ResolvingActions);
                StartCoroutine(PlayActions());


                return;
            }

            if(_uiInputType == UIInputType.ResolvingActions)
            {
                if(_gameBoard.ActionsPool.State == ActionsPoolState.WaitingTarget)
                {
                    PlayerView playerView;
                    if (eventData.rawPointerPress.TryGetComponent(out playerView))
                    {
                        ActionData actionData
                            = new ActionData(_selectedCard.Card.PlayerOwner)
                            .WithTarget(playerView.Player);

                        _gameBoard.ActionsPool.RequiredActionData = actionData;
                    }
                }
            }
        }

        private IEnumerator PlayActions()
        {
            yield return _gameBoard.ActionsPool.Execute();

            if (_gameBoard.ActionsPool.State == ActionsPoolState.Completed)
            {
                SwitchUIInputType(UIInputType.Default);
                yield break;
            }
        }

        private void SwitchUIInputType(UIInputType uiInputType)
        {
            Debug.Log($"UIInputType switched from {_uiInputType} to {uiInputType}");
            _uiInputType = uiInputType;
        }

        private void UpdateCurrentPlayer()
        {
            _textFieldCurrentPlayer.text = _gameBoard.CurrentPlayer.Name;
        }

        public void NextTurn()
        {
            _gameBoard.EndTurn();
        }

        private void OnDestroy()
        {
            _gameBoard.TurnChanged -= UpdateCurrentPlayer;
        }
    }

    public enum UIInputType
    {
        Default,
        ChooseTarget,
        ChooseTargetEnemy,
        ChooseTargets,
        ChooseEnemyTargets,
        ResolvingActions
    }
}
