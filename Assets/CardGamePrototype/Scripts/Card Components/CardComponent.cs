using TMPro;
using UnityEngine;
using UnityEngine.UI;

public abstract class CardComponent : MonoBehaviour
{
   
    [SerializeField] protected Image _baseImage = null;
    [SerializeField] protected Image _artImage = null;
    [SerializeField] protected TMP_Text _cardNumberText = null;
    [SerializeField] protected TMP_Text _titleText = null;
    [SerializeField] protected TMP_Text _gameplayText = null;

    protected void OnEnable() => PopulateCardInfo();
   
    protected abstract void PopulateCardInfo();
}
