using UnityEngine;

public class GameManager : MonoBehaviour
{
    [SerializeField] private Transform _board;
    [SerializeField] private Transform _cardSpot;
    [SerializeField] private GameObject _cardToRotate = null;
    [SerializeField] private Vector3 _rotationVector;
    private Transform _transform;
    private float _deltaTime;

    private void Start()
    {
        _transform = _cardToRotate.transform;
        //_cardToRotate.transform.position = _cardSpot.transform.position;
        //_cardToRotate.transform.rotation = _cardSpot.transform.rotation;
    }

    private void Update()
    {
        _deltaTime = Time.deltaTime;
        //_transform.position = Vector3.Lerp(_transform.position, _cardSpot.position, _deltaTime);
        _transform.Rotate(_rotationVector * _deltaTime);
    }
}
