using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.AddressableAssets;
using UnityEngine.ResourceManagement.AsyncOperations;

public class CharacterCardComponent : CardComponent
{
    
    [SerializeField] private CharacterCardData _characterCardData = null;
    [SerializeField] private TMP_Text _attackPowerText = null;
    [SerializeField] private TMP_Text _hitPointsText = null;
    [SerializeField] private List<Image> _upgradeSlotImages = new List<Image>();

    private void OnEnable()
    {
        if (_cardData == null) return;
        Addressables.LoadAssetAsync<CharacterCardData>(_cardData).Completed += CardLoadDone;
    }

    private void OnDisable()
    {
        Addressables.LoadAssetAsync<CharacterCardData>(_cardData).Completed -= CardLoadDone;
    }

    private void CardLoadDone(AsyncOperationHandle<CharacterCardData> card)
    {
        if (card.Status != AsyncOperationStatus.Succeeded) return;
        _characterCardData = card.Result;
        PopulateCardInfo();
    }

    private void PopulateCardInfo()
    {
        var thisCard = _characterCardData.Character_card;
        var thisCardBase = _characterCardData.Card_base;
        for (int i = 0; i < thisCard.upgradeSlots; i++)
        {
            _upgradeSlotImages[i].gameObject.SetActive(true);
        }
        _titleText.text = thisCardBase.cardName;
        _gameplayText.text = thisCardBase.cardText;
        _attackPowerText.text = thisCard.attackPower.ToString();
        _hitPointsText.text = thisCard.hitPoints.ToString();
        _artImage.sprite = thisCardBase.cardImage;
    }
}
