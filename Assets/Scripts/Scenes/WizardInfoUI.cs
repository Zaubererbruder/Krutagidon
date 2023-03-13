using Assets.Scripts.Krutagidon;
using Assets.Scripts.Network;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UnityEngine;
using UnityEngine.UI;

namespace Assets.Scripts.Scenes
{
    public class WizardInfoUI : MonoBehaviour
    {
        [SerializeField] private Text _textViewName;
        [SerializeField] private Text _textViewHealth;

        private Wizard _wizard;

        public void Init(Wizard wizard)
        {
            _wizard = wizard;
            UpdateUI();
            _wizard.StatChanged += UpdateUI;
        }

        public void UpdateUI()
        {
            _textViewName.text = _wizard.Name;
            _textViewHealth.text = _wizard.Health.Value.ToString();
        }

        private void OnDestroy()
        {
            if (_wizard != null)
            {
                _wizard.StatChanged -= UpdateUI;
            }
        }
    }
}
