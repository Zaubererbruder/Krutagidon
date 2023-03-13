using Assets.Scripts.Network;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UnityEngine;
using UnityEngine.UI;
using Zenject;

namespace Assets.Scripts
{
    public class DebugBehaviour : MonoBehaviour, IDebugger
    {
        private string _debugMessage = "Hey";
        private Dictionary<string, string> _messagges = new Dictionary<string, string>();

        public void ChangeMessage(string type, string message)
        {
            if(_messagges.ContainsKey(type))
            {
                _messagges[type] = message;
            }
            else
            {
                _messagges.Add(type, message);
            }
            UpdateTextView();
        }

        public void RemoveType(string type)
        {
            if (_messagges.ContainsKey(type))
                _messagges.Remove(type);
        }

        private void UpdateTextView()
        {
            StringBuilder builder = new StringBuilder();
            foreach(KeyValuePair<string, string> kvp in _messagges)
            {
                builder.AppendLine($"{kvp.Key}: {kvp.Value}");
            }
            _debugMessage = builder.ToString();
        }

        private void OnGUI()
        {
            GUI.color = Color.black;
            GUI.Label(new Rect(20,20,200,500), _debugMessage);
        }
    }
}
