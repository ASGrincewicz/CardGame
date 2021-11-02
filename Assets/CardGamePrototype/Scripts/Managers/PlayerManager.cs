using System.Collections.Generic;
using UnityEngine;

public class PlayerManager : MonoBehaviour
{
    [SerializeField] private List<Transform> _handSpots = new List<Transform>();
    [SerializeField] private List<CardData> _handData = new List<CardData>();
    [SerializeField] private DeckManager _deckManager;
    [SerializeField] private int _handSize = 3;
    [SerializeField] private GameObject _selectedCard = null;
    [SerializeField] private LayerMask _clickMask;
    [SerializeField] private string _cardTag = "Card";
    [SerializeField] private Camera _mainCamera;
    public int deckSize;
    public bool isHandFull = false;

    private void Start()
    {
        _deckManager = _deckManager.GetComponent<DeckManager>();
        deckSize = _deckManager.Deck.Deck.deckList.Count;
       
    }
    private void Update()
    {
        if (Input.GetMouseButtonDown(0))
        {
            Ray ray = _mainCamera.ScreenPointToRay(Input.mousePosition);
            RaycastHit hitInfo;
            if (!Physics.Raycast(ray, out hitInfo, _clickMask)) return;

            if (!hitInfo.collider.CompareTag(_cardTag)) return;

            _selectedCard = hitInfo.collider.gameObject;
            _selectedCard.transform.Rotate(_selectedCard.transform.rotation.x, 180f, 0f);
        }
    }

    public void DrawHand()
    {
        if (isHandFull) return;
        for (int i = 0; i < _handSize; i++)
        {
            _handData.Add(_deckManager.RuntimeDeckList[i]);
            
        }
        for(int i = 0; i < _handData.Count; i++)
            _deckManager.RuntimeDeckList.Remove(_handData[i]);
        if (_handData.Count == _handSize)
            isHandFull = true;
    }

    public void PlayCard()
    {
        //if player turn, play selected card.
    }
}
