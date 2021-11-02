using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    [SerializeField] private DeckManager _deckManager;
    [SerializeField] private PlayerManager _playerManager;
    [SerializeField] private Transform _board;
    [SerializeField] private Transform _cardSpot;
    
    private Transform _transform;
    private float _deltaTime;

    private void Start()
    {
        _deckManager = GetComponent<DeckManager>();
        _playerManager = GetComponent<PlayerManager>();
    }

    //private void Update()
    //{
    //    _deltaTime = Time.deltaTime;
        
    //}
}
