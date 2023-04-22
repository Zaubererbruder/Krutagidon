using System;
using System.Collections;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UI;

public class CardView : MonoBehaviour
{
    [SerializeField] private Image _image;
    private Card _card;
    private PlayerView _ownerView;
    public Text _textField;

    public Card Card => _card;

    public void Init(Card card, PlayerView ownerView)
    {
        _card = card;
        _ownerView = ownerView;
        UpdateUI();
    }

    private void UpdateUI()
    {
        _textField.text = _card.CardDefinition.Name;

    }
}
