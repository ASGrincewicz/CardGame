using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AddressableAssets;
using UnityEngine.ResourceManagement.AsyncOperations;

public class AssetReferenceUtility : MonoBehaviour
{
    [SerializeField] private Transform _cardPanel;
    [SerializeField] private AssetReference _objectToLoad;
    [SerializeField] private AssetReference _accessoryObjectToLoad;

    [SerializeField] private GameObject _instantiatedObject;
    [SerializeField] private GameObject _instantiatedAccessoryObject;

    private void Start()
    {
        Addressables.LoadAssetAsync<GameObject>(_objectToLoad).Completed += ObjectLoadDone;
    }

    private void ObjectLoadDone(AsyncOperationHandle<GameObject> obj)
    {
        if (obj.Status != AsyncOperationStatus.Succeeded) return;
        var loadedObject = obj.Result;
        Debug.Log("Successfully Loaded Object");
        _instantiatedObject = Instantiate(loadedObject, _cardPanel);
        if (_accessoryObjectToLoad == null) return;
        _accessoryObjectToLoad.InstantiateAsync(_cardPanel).Completed += op =>
        {
            if (op.Status != AsyncOperationStatus.Succeeded) return;
            _instantiatedAccessoryObject = op.Result;
        };
    }
}
