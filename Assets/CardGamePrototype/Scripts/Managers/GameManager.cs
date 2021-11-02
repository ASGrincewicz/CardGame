using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    [SerializeField] private Transform _board;
    [SerializeField] private Transform _cardSpot;
    [SerializeField] private List<GameObject> _cardsToRotate = new List<GameObject>();
    [SerializeField] private Vector3 _rotationVector;
    private Transform _transform;
    private float _deltaTime;

    //private void Start()
    //{
       
    //}

    private void Update()
    {
        _deltaTime = Time.deltaTime;

        foreach(var card in _cardsToRotate)
        {
            card.transform.Rotate(_rotationVector * _deltaTime);
        }
    }
}
