using TMPro;
using UnityEngine;
using UnityEngine.AddressableAssets;
using UnityEngine.UI;

public abstract class CardComponent : MonoBehaviour
{
    [SerializeField] protected AssetReference _cardData;
    [SerializeField] protected Image _baseImage = null;
    [SerializeField] protected Image _artImage = null;
    [SerializeField] protected TMP_Text _cardNumberText = null;
    [SerializeField] protected TMP_Text _titleText = null;
    [SerializeField] protected TMP_Text _gameplayText = null;
    //
    
    protected abstract void OnEnable();
    protected abstract void OnDisable();
    /// <summary>
    /// This method is required to populate the info on the card game object.
    /// </summary>
    protected abstract void PopulateCardInfo();
}
