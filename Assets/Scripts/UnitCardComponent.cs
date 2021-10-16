using UnityEngine;
using TMPro;

public class UnitCardComponent : CardComponent
{
    [SerializeField] private UnitCardData _unitCardData = null;
    [SerializeField] private TMP_Text _attackPowerText = null;
    [SerializeField] private TMP_Text _hitPointsText = null;
    

    private void OnValidate()
    {
        if (_unitCardData == null) return;
        var thisCard = _unitCardData.Unit_card;
        var thisCardBase = _unitCardData.Card_base;

        _titleText.text = thisCardBase.cardName;
        _gameplayText.text = thisCardBase.cardText;
        _attackPowerText.text = thisCard.attackPower.ToString();
        _hitPointsText.text = thisCard.hitPoints.ToString();
        _artImage.sprite = thisCardBase.cardImage;
    }
}