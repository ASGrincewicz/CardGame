using System.Collections;
using System.IO;
using UnityEngine;

public class BundleLoaderAsync : MonoBehaviour
{
    [SerializeField] private string _bundleName;
    [SerializeField] private string _assetName;

    private IEnumerator Start()
    {
        AssetBundleCreateRequest asyncBundleRequest = AssetBundle.LoadFromFileAsync(Path.Combine(
            Application.streamingAssetsPath, _bundleName));

        AssetBundle localAssetBundle = asyncBundleRequest.assetBundle;
        if (localAssetBundle == null)
        {
            Debug.Log("Failed to load local assetbundle!");
            yield break;
        }

        AssetBundleRequest assetRequest = localAssetBundle.LoadAssetAsync<GameObject>(_assetName);
        yield return assetRequest;

        GameObject prefab = (GameObject)assetRequest.asset;
        Instantiate(prefab);
        localAssetBundle.Unload(false);
    }
}
