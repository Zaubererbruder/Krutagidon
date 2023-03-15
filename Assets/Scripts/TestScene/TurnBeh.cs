using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UnityEngine;
using UnityEngine.UI;

namespace Assets.Scripts.TestScene
{
    public class TurnBeh : MonoBehaviour
    {
        private TurnManager _turnManager;
        public Text _textFieldCurrentPlayer;

        public void Init(TurnManager turnManager)
        {
            _turnManager = turnManager;
            UpdateCurrentPlayer();
            _turnManager.TurnChanged += UpdateCurrentPlayer;
        }

        private void OnDestroy()
        {
            _turnManager.TurnChanged -= UpdateCurrentPlayer;
        }

        private void UpdateCurrentPlayer()
        {
            _textFieldCurrentPlayer.text = _turnManager.CurrentPlayer.Name;
        }

        public void NextTurn()
        {
            _turnManager.NextTurn();
        }
    }
}
