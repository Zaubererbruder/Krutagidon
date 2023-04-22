using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UnityEngine.EventSystems;
using UnityEngine.UI;

namespace Assets.Scripts.TestScene
{
    internal class CardSelectable : Selectable
    {
        private bool _selected;
        
        public override void OnDeselect(BaseEventData eventData)
        {
            return;
            base.OnDeselect(eventData);
        }
    }
}
