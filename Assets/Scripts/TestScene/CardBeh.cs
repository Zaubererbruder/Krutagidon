using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UI;

namespace Assets.Scripts.TestScene
{
    public class CardBeh : MonoBehaviour, IPointerClickHandler
    {
        private Card _card;
        public Text _textField;
        public void Init(Card card)
        {
            _card = card;
            UpdateUI();
        }

        private void UpdateUI()
        {
            _textField.text = _card.CardDefinition.Name;

        }

        public void OnPointerClick(PointerEventData eventData)
        {
            
        }
    }
}
