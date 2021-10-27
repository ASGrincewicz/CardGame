using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;

public class PlayerManager : MonoBehaviour
{
    [SerializeField] private DeckManager _deckManager;
    [SerializeField] private int _handSize = 4;
    [SerializeField] private GameObject _selectedCard = null;
    [SerializeField] private LayerMask _clickMask;
    [SerializeField] private string _cardTag = "Card";
    [SerializeField] private Camera _mainCamera;
   

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
        //Check deck manager for remaining cards in deck
        //if remaining cards > 0
        //Draw cards
    }

    public void PlayCard()
    {
        //if player turn, play selected card.
    }
}
