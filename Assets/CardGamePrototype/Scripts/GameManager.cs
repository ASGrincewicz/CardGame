using UnityEngine;

public class GameManager : MonoBehaviour
{
    [SerializeField] private GameObject _cardToRotate = null;
    [SerializeField] private Vector3 _rotationVector;
    private Transform _transform;
    private float _deltaTime;

    private void Start()
    {
        _transform = _cardToRotate.transform;
    }

    private void Update()
    {
        _deltaTime = Time.deltaTime;

        _transform.Rotate(_rotationVector * _deltaTime);
    }
}
