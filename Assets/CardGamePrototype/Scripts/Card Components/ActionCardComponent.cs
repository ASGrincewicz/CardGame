using TMPro;
using UnityEngine;
using UnityEngine.AddressableAssets;
using UnityEngine.ResourceManagement.AsyncOperations;

public class ActionCardComponent : CardComponent
{
    [SerializeField] private ActionCardData _actionCardData = null;
    [SerializeField] private TMP_Text _actionCostText = null;

    protected override void OnEnable()
    {
        if (_cardData == null) return;
        Addressables.LoadAssetAsync<ActionCardData>(_cardData).Completed += CardLoadDone;
    }

    protected override void OnDisable()
    {
        Addressables.LoadAssetAsync<ActionCardData>(_cardData).Completed -= CardLoadDone;
    }

    private void CardLoadDone(AsyncOperationHandle<ActionCardData> card)
    {
        if (card.Status != AsyncOperationStatus.Succeeded) return;
        _actionCardData = card.Result;
        PopulateCardInfo();
    }

    protected override void PopulateCardInfo()
    {
        var thisCard = _actionCardData.Action_card;
        var thisCardBase = _actionCardData.Card_base;

        _titleText.text = thisCardBase.cardName;
        _gameplayText.text = thisCardBase.cardText;
        _actionCostText.text = thisCard.actionCost.ToString();
        _artImage.sprite = thisCardBase.cardImage;
    }
}