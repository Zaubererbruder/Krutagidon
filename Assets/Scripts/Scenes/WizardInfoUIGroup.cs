using Assets.Scripts.Krutagidon;
using Assets.Scripts.Network;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UnityEngine;

namespace Assets.Scripts.Scenes
{
    public class WizardInfoUIGroup : MonoBehaviour
    {
        [SerializeField] WizardInfoUI _wizardInfoUIPrefab;
        private List<WizardInfoUI> _wizardInfoUIs = new List<WizardInfoUI>();

        public void UpdateWizards(IEnumerable<Player> wizards)
        {
            foreach(WizardInfoUI wizardInfoUI in _wizardInfoUIs)
            {
                Destroy(wizardInfoUI.gameObject);
            }
            _wizardInfoUIs.Clear();

            foreach(Wizard wizard in wizards)
            {
                WizardInfoUI wizardInfo = Instantiate(_wizardInfoUIPrefab, transform);
                wizardInfo.Init(wizard);
                _wizardInfoUIs.Add(wizardInfo);
            }
        }
    }
}
