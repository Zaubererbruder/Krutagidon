using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UnityEditor;
using UnityEngine;
using UnityEngine.UIElements;
using UnityEditor.UIElements;

namespace Assets.Editorr
{
    public class CardsEditorWindow : EditorWindow
    {
        private List<string> _guids;
        private int _selectedIndex;
        private ListView _leftPane;
        private VisualElement _rightPane;
        //private ListOfCardsSO _listOfCards;
        //private CardSO _selectedCardSO;
        //private CardAdv _selectedCard;
        private string _assetName;
        private string _assetGuid;

        [MenuItem("Window/Card Creator")]
        static void Init()
        {
            // Get existing open window or if none, make a new one:
            CardsEditorWindow window = GetWindow<CardsEditorWindow>();
            window.Show();
        }

        private void Awake()
        {
            InitCardsList();
        }

        private void InitCardsList()
        {
            //var listOfCardsGuids = AssetDatabase.FindAssets("t:ListOfCardsSO");
            //if (listOfCardsGuids.Length > 0)
            //{
            //    _listOfCards = AssetDatabase.LoadAssetAtPath<ListOfCardsSO>(AssetDatabase.GUIDToAssetPath(listOfCardsGuids[0]));
            //    return;
            //}

            //string listpath = AssetDatabase.GenerateUniqueAssetPath("Assets/Data/Cards/ListOfCards.asset");
            //_listOfCards = CreateInstance<ListOfCardsSO>();
            //AssetDatabase.CreateAsset(_listOfCards, listpath);

            //var assetsGuids = AssetDatabase.FindAssets("t:CardSO");
            //_guids = new List<string>();
            //foreach (string guid in assetsGuids)
            //{
            //    _guids.Add(guid);
            //    CardSO card = AssetDatabase.LoadAssetAtPath<CardSO>(AssetDatabase.GUIDToAssetPath(guid));

            //    if (!_listOfCards.Contains(card))
            //    {
            //        _listOfCards.Add(card, 1);
            //        EditorUtility.SetDirty(_listOfCards);
            //    }
            //}
            //AssetDatabase.SaveAssets();
        }

        private void CreateGUI()
        {
            //StyleSheet styleSheet = (StyleSheet)EditorGUIUtility.Load("CardsEditorStyles.uss");
            //rootVisualElement.styleSheets.Add(styleSheet);
            
            //var splitView = new TwoPaneSplitView(0, 250, TwoPaneSplitViewOrientation.Horizontal);
            //rootVisualElement.Add(splitView);

            //Button addButton = new Button();
            //addButton.text = "Add";
            //addButton.clicked += AddButton_clicked;

            //VisualElement leftPaneContainer = new VisualElement();
            //_leftPane = new ListView();
            //leftPaneContainer.Add(addButton);
            //leftPaneContainer.Add(_leftPane);

            //splitView.Add(leftPaneContainer);
            //_rightPane = new ScrollView(ScrollViewMode.VerticalAndHorizontal);
            //splitView.Add(_rightPane);

            //_leftPane.makeItem = () => CreateListElementVisualElement();
            //_leftPane.bindItem = BindItemToVisualElement;
            //_leftPane.itemsSource = _listOfCards.Cards;

            //_leftPane.onSelectionChange += OnCardSelectionChange;
            //_leftPane.onSelectionChange += (items) => { _selectedIndex = _leftPane.selectedIndex; };
        }

        private VisualElement CreateListElementVisualElement()
        {
            //VisualElement element = new VisualElement();

            //Label label = new Label();
            //label.AddToClassList("label-element");

            //IntegerField intField = new IntegerField();
            //intField.AddToClassList("integer-element");
            //intField.RegisterCallback<ChangeEvent<int>>(OnCountChangeEvent);

            //element.Add(label);
            //element.Add(intField);
            //element.AddToClassList("horizontal-container");
            //return element;
            return null;
        }

        private void OnCountChangeEvent(ChangeEvent<int> evt)
        {
            //if (_selectedCardSO == null)
            //    return;

            //var intField = evt.target as IntegerField;
            //intField.value = Mathf.Clamp(evt.newValue, 0, 99);
            //_listOfCards.ChangeCount(_selectedCardSO, intField.value);
            //EditorUtility.SetDirty(_listOfCards);
            //AssetDatabase.SaveAssets();
        }

        private void BindItemToVisualElement(VisualElement visualElement, int index)
        {
            //var name = _listOfCards.GetCard(index).name;
            //visualElement.Q<Label>().text = name;
            //visualElement.Q<IntegerField>().value = _listOfCards.GetCount(index);
        }

        private void AddButton_clicked()
        {
            //CardSO card = ScriptableObject.CreateInstance<CardSO>();
            //string path = AssetDatabase.GenerateUniqueAssetPath("Assets/Data/Cards/newcard.asset");
            //AssetDatabase.CreateAsset(card, path);
            //_listOfCards.Add(card, 1);
            ////_listOfCards.Cards.Add(card);
            ////_listOfCards.CardsCount.Add(1);
            //AssetDatabase.SaveAssets();
            //_guids.Add(AssetDatabase.AssetPathToGUID(path));
            //_leftPane.RefreshItems();
        }

        private void OnCardSelectionChange(IEnumerable<object> selectedCards)
        {
            //_rightPane.Clear();

            //_selectedCardSO = selectedCards.First() as CardSO;
            //if (_selectedCardSO == null)
            //    return;

            //_selectedCard = _selectedCardSO.Card;
            //_assetName = _selectedCardSO.name;

            //var spriteImage = new Image();
            //spriteImage.scaleMode = ScaleMode.ScaleToFit;
            //spriteImage.sprite = _selectedCard.Sprite;

            //ObjectField spriteField = new ObjectField("Sprite");
            //spriteField.objectType = typeof(Sprite);
            //spriteField.value = _selectedCard.Sprite;
            //spriteField.RegisterCallback<ChangeEvent<UnityEngine.Object>>((evt) =>
            //{
            //    spriteImage.sprite = evt.newValue as Sprite;
            //    _selectedCard.Sprite = evt.newValue as Sprite;
            //    EditorUtility.SetDirty(_selectedCardSO);
            //    AssetDatabase.SaveAssets();
            //});

            //TextField cardNameField = new TextField("Card name");
            //cardNameField.value = _assetName;
            //cardNameField.RegisterCallback<ChangeEvent<string>>((evt)=> { _assetName = evt.newValue;});

            ////winscore.text = selectedCard.Card.CardInfo.
            //IntegerField winscoreField = CardIntegerValueField("Win Score", _selectedCard.CardInfo.WinScore);
            //winscoreField.RegisterCallback<ChangeEvent<int>>(OnWinScoreChangeEvent);
            //EnumField typeField = new EnumField("Type", CardType.Starter);
            //IntegerField priceField = CardIntegerValueField("Price", _selectedCard.CardInfo.Price);
            //priceField.RegisterCallback<ChangeEvent<int>>(OnPriceChangeEvent);

            //Button saveButton = new Button();
            //saveButton.text = "Save";
            //saveButton.clicked += SaveButton_clicked;

            //VisualElement cardDataContainer = new VisualElement();
            //cardDataContainer.AddToClassList("horizontal-container");
            //cardDataContainer.Add(winscoreField);
            //cardDataContainer.Add(typeField);
            //cardDataContainer.Add(priceField);

            //VisualElement cardContainer = new VisualElement();
            //cardContainer.Add(cardNameField);
            //cardContainer.Add(spriteField);
            //cardContainer.Add(spriteImage);
            //cardContainer.Add(cardDataContainer);
            //cardContainer.Add(saveButton);

            //_rightPane.Add(cardContainer);
        }

        private void SaveButton_clicked()
        {
            //string assetGuid = _guids[_selectedIndex];
            //AssetDatabase.RenameAsset(AssetDatabase.GUIDToAssetPath(assetGuid), _assetName);
            //_leftPane.RefreshItems();
        }

        private void OnWinScoreChangeEvent(ChangeEvent<int> evt)
        {
            //var intField = evt.target as IntegerField;
            //intField.value = Mathf.Clamp(evt.newValue, 0, 99);
            //_selectedCard.CardInfo.WinScore = intField.value;
        }

        private void OnPriceChangeEvent(ChangeEvent<int> evt)
        {
            //var intField = evt.target as IntegerField;
            //intField.value = Mathf.Clamp(evt.newValue, 0, 99);
            //_selectedCard.CardInfo.Price = intField.value;
        }

        private IntegerField CardIntegerValueField(string label, int defaultValue = 0)
        {
            //IntegerField resultField = new IntegerField(label, 2);
            //resultField.value = defaultValue;
            //resultField.AddToClassList("card-integer");
            //resultField.labelElement.AddToClassList("label-card-integer");

            //return resultField;
            return null;
        }
    }
}
