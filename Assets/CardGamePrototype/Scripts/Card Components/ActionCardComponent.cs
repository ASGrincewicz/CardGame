using TMPro;
using UnityEngine;

public class ActionCardComponent : CardComponent
{
    [SerializeField] private ActionCardData _actionCardData = null;
    [SerializeField] private TMP_Text _actionCostText = null;
    public ActionCardData ActionCardData { get => _actionCardData; set => _actionCardData = value; }


    protected override void PopulateCardInfo()
    {
        var thisCard = _actionCardData.Action_card;
        var thisCardBase = _actionCardData.Card_base;
        _cardNumberText.text = $"{thisCardBase.cardNumber}/200";
        _titleText.text = thisCardBase.cardName;
        _gameplayText.text = thisCardBase.cardText;
        _actionCostText.text = thisCard.actionCost.ToString();
        _artImage.sprite = thisCardBase.cardImage;
    }
}