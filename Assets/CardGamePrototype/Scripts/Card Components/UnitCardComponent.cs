using TMPro;
using UnityEngine;
using UnityEngine.AddressableAssets;
using UnityEngine.ResourceManagement.AsyncOperations;

public class UnitCardComponent : CardComponent
{
    [SerializeField] private UnitCardData _unitCardData = null;
    [SerializeField] private TMP_Text _attackPowerText = null;
    [SerializeField] private TMP_Text _hitPointsText = null;


    protected override void OnEnable()
    {
        if (_cardData == null) return;
        Addressables.LoadAssetAsync<UnitCardData>(_cardData).Completed += CardLoadDone;
    }

    protected override void OnDisable()
    {
        Addressables.LoadAssetAsync<UnitCardData>(_cardData).Completed -= CardLoadDone;
    }

    private void CardLoadDone(AsyncOperationHandle<UnitCardData> card)
    {
        if (card.Status != AsyncOperationStatus.Succeeded) return;
        _unitCardData = card.Result;
        PopulateCardInfo();
    }

    protected override void PopulateCardInfo()
    {
        var thisCard = _unitCardData.Unit_card;
        var thisCardBase = _unitCardData.Card_base;
        _cardNumberText.text = $"{thisCardBase.cardNumber}/200";
        _titleText.text = thisCardBase.cardName;
        _gameplayText.text = thisCardBase.cardText;
        _attackPowerText.text = thisCard.attackPower.ToString();
        _hitPointsText.text = thisCard.hitPoints.ToString();
        _artImage.sprite = thisCardBase.cardImage;
    }
}