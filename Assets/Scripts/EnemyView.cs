using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UnityEngine;
using UnityEngine.UI;

namespace Assets
{
    public class EnemyView : MonoBehaviour
    {
        [SerializeField] Text _textComp;

        public void ChangeText(string text)
        {
            _textComp.text = text;
        }
    }
}
