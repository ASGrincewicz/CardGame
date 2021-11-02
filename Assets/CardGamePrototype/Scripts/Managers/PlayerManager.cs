using System.Collections.Generic;
using UnityEngine;

public class PlayerManager : MonoBehaviour
{
    [SerializeField] private Vector3 _inspectionPos;
    [SerializeField] private Vector3 _inspectionRot;
    [SerializeField] private List<Transform> _handSpots = new List<Transform>();
    [SerializeField] private List<GameObject> _handData = new List<GameObject>();
    [SerializeField] private DeckManager _deckManager;
    [SerializeField] private int _handSize = 3;
    [SerializeField] private GameObject _selectedCard = null;
    [SerializeField] private LayerMask _clickMask;
    [SerializeField] private string _cardTag = "Card";
    [SerializeField] private Camera _mainCamera;
    public int deckSize;
    public bool isHandFull = false;
    public List<GameObject> HandData { get => _handData; set => _handData = value; }

    private void Start()
    {
        _deckManager = _deckManager.GetComponent<DeckManager>();
        deckSize = _deckManager.Deck.Deck.deckList.Count;
       
    }
    private void Update()
    {
        if (Input.GetMouseButtonDown(0))
        {
            if (_selectedCard != null)
            {
                _selectedCard.transform.localPosition = Vector3.zero;
                _selectedCard.transform.rotation = Quaternion.identity;
                _selectedCard = null;
            }
            Ray ray = _mainCamera.ScreenPointToRay(Input.mousePosition);
            RaycastHit hitInfo;
            if (!Physics.Raycast(ray, out hitInfo, _clickMask)) return;

            if (!hitInfo.collider.CompareTag(_cardTag)) return;
           
            _selectedCard = hitInfo.collider.gameObject;
            _selectedCard.transform.position = _inspectionPos;
            _selectedCard.transform.rotation = Quaternion.Euler(_inspectionRot);
        }
    }

    public void DrawHand()
    {
        if (isHandFull) return;
        if (_deckManager.DeckPool.Count < _handSize)
            _handSize = _deckManager.DeckPool.Count;

        for (int i = 0; i < _handSize; i++)
        {

            _handData.Add(_deckManager.DeckPool[i]);
            _handData[i].transform.SetParent(_handSpots[i]);
            _handData[i].transform.SetPositionAndRotation(_handSpots[i].transform.position,
                                                            _handSpots[i].transform.rotation);
            _handData[i].transform.localScale = Vector3.one;
            _handData[i].SetActive(true);
        }
        for (int i = 0; i < _handData.Count - 1; i++)
            _deckManager.DeckPool.Remove(_handData[i]);
        if (_handData.Count == _handSize)
            isHandFull = true;
        
    }

    public void PlayCard()
    {
        //if player turn, play selected card.
    }
}
