using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class DeckManager : MonoBehaviour
{
    [Tooltip("Ideally, this would be retrieved from something like the Game Manager.")]
    [SerializeField] private string _playerName;
    [Tooltip("Place a prefab here. It should be just an object showing the player's card back.")]
    [SerializeField] private GameObject _deckCardPrefab;
    [Tooltip("This will be the parent of the instantiated prefabs.")]
    [SerializeField] private Transform _deck;
    [Tooltip("This should be populated with the player's deck size.")]
    [SerializeField] private int _deckSize;
    [SerializeField] private float _cardStackOffset = 0f;
    [SerializeField] private float _cardStackOffsetChange = 0.06f;
    [SerializeField] private TMP_Text _deckCountText;
    [SerializeField] private List<GameObject> _deckPool = new List<GameObject>();
    private int _cardCount = 0;
    private WaitForSeconds _cardDelay;


    private void Start()
    {
        _deck = new GameObject("Players_Deck").transform;
        _deck.SetParent(this.transform);
        _cardDelay = new WaitForSeconds(0.10f);
        StartCoroutine(CreateDeckRoutine());
    }

    private IEnumerator CreateDeckRoutine()
    {
        for (int i = 0; i < _deckSize; i++)
        {
            //Instantiate each card in the deck
            //Set Y position to _cardStackOffset
            //Set Z rotation to random between -2,2
            yield return _cardDelay;
            GameObject card = Instantiate(_deckCardPrefab, _deck);
            card.transform.position = new Vector3(transform.position.x,
                                                             transform.position.y + _cardStackOffset,
                                                             transform.position.z);
            _cardStackOffset += _cardStackOffsetChange;
            card.transform.rotation = Quaternion.Euler(transform.rotation.x,
                                                    Random.Range(-3f, 3f),
                                                    transform.rotation.z);
            _deckPool.Add(card);
            _cardCount++;
            _deckCountText.text = $"{_playerName}'s Deck: {_cardCount} Cards Remaining.";
        }
    }
}
