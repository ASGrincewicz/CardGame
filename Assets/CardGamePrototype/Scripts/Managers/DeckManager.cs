using System.Collections.Generic;
using UnityEngine;

public class DeckManager : MonoBehaviour
{
    [SerializeField] private DeckData _deckData;
    [SerializeField] private List<CardData> _runtimeDeckList = new List<CardData>();
    [SerializeField] private GameObject _actionCardPrefab;
    [SerializeField] private GameObject _bossCardPrefab;
    [SerializeField] private GameObject _characterCardPrefab;
    [SerializeField] private GameObject _creatureCardPrefab;
    [SerializeField] private GameObject _enemyCardPrefab;
    [SerializeField] private GameObject _effectCardPrefab;
    [SerializeField] private GameObject _locationCardPrefab;
    [SerializeField] private GameObject _techCardPrefab;
    [SerializeField] private GameObject _weaponCardPrefab;
    [Tooltip("Ideally, this would be retrieved from something like the Game Manager.")]
    [SerializeField] private string _playerName;
    //public List<IResourceLocation> cardLocations = new List<IResourceLocation>();
    //[Tooltip("Place a prefab here. It should be just an object showing the player's card back.")]
    //[SerializeField] private GameObject _deckCardPrefab;
    //[Tooltip("This will be the parent of the instantiated prefabs.")]
    //[SerializeField] private Transform _deck;
    //[Tooltip("This should be populated with the player's deck size.")]
    //[SerializeField] private int _deckSize;
    //[SerializeField] private float _cardStackOffset = 0f;
    //[SerializeField] private float _cardStackOffsetChange = 0.06f;
    //[SerializeField] private TMP_Text _deckCountText;
    [SerializeField] private List<GameObject> _deckPool = new List<GameObject>();
    //[SerializeField] private int _cardCount = 0;
    //private WaitForSeconds _cardDelay;
    public DeckData Deck { get => _deckData; set => _deckData = value; }
    public List<CardData> RuntimeDeckList { get => _runtimeDeckList; set => _runtimeDeckList = value; }
    //public List<IResourceLocation> CardLocations { get => cardLocations; set => cardLocations = value; }

    private void Start()
    {
        foreach (var card in _deckData.Deck.deckList)
        {
            _runtimeDeckList.Add(card);
            //cardLocations.Add(card);
            _deckPool.Add(CreateCardObjects(card));
        }
        
    }
    private GameObject CreateCardObjects(CardData cardData)
    {
        GameObject cardObject = null;
        var cardType = cardData.Card_base.cardType;
        switch (cardType)
        {
            case CardType.Action:
                cardObject = _actionCardPrefab;
                cardObject.GetComponent<ActionCardComponent>().ActionCardData = cardData as ActionCardData;
                break;
            case CardType.Boss:
                cardObject = _bossCardPrefab;
                cardObject.GetComponent<UnitCardComponent>().UnitCardData = cardData as UnitCardData;
                break;
            case CardType.Character:
                cardObject = _characterCardPrefab;
                cardObject.GetComponent<CharacterCardComponent>().CharacterCardData = cardData as CharacterCardData;
                break;
            case CardType.Creature:
                cardObject = _creatureCardPrefab;
                cardObject.GetComponent<UnitCardComponent>().UnitCardData = cardData as UnitCardData;
                break;
            case CardType.Enemy:
                cardObject = _enemyCardPrefab;
                cardObject.GetComponent<UnitCardComponent>().UnitCardData = cardData as UnitCardData;
                break;
            default:
                break;
                
        }
         var newCardObject = Instantiate(cardObject, transform);
        newCardObject.SetActive(false);
        return newCardObject;
    }
    //private IEnumerator CreateDeckRoutine()
    //{
    //    for (int i = 0; i < _deckSize; i++)
    //    {
    //        //Instantiate each card in the deck
    //        //Set Y position to _cardStackOffset
    //        //Set Z rotation to random between -2,2
    //        yield return _cardDelay;
    //        GameObject card = Instantiate(_deckCardPrefab, _deck);
    //        card.transform.position = new Vector3(transform.position.x,
    //                                                         transform.position.y + _cardStackOffset,
    //                                                         transform.position.z);
    //        _cardStackOffset += _cardStackOffsetChange;
    //        card.transform.rotation = Quaternion.Euler(transform.rotation.x,
    //                                                Random.Range(-3f, 3f),
    //                                                transform.rotation.z);
    //        _deckPool.Add(card);
    //        _cardCount++;
    //        //_deckCountText.text = $"{_playerName}'s Deck: {_cardCount} Cards Remaining.";
    //    }
    //}
}