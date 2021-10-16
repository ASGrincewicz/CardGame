using UnityEngine;
using UnityEngine.UI;
using UnityEngine.EventSystems;
using TMPro;

public class CardComponent : MonoBehaviour, IPointerEnterHandler, IPointerExitHandler
{
    [SerializeField] protected Image _baseImage = null;
    [SerializeField] protected Image _artImage = null;
    [SerializeField] protected Image _statsImage = null;
    [SerializeField] protected TMP_Text _titleText = null;
    [SerializeField] protected TMP_Text _gameplayText = null;


    public void OnPointerEnter(PointerEventData eventData)
    {
        if (_statsImage == null) return;
        _statsImage.gameObject.SetActive(true);
    }

    public void OnPointerExit(PointerEventData eventData)
    {
        if (_statsImage == null) return;
        _statsImage.gameObject.SetActive(false);
    }
}
