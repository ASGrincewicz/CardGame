using UnityEngine;
using UnityEngine.UI;
using System.Collections.Generic;
using TMPro;

public class CharacterCardComponent : CardComponent
{
    [SerializeField] private CharacterCardData _characterCardData = null;
    //[SerializeField] private Image _attackPowerImage = null;
    //[SerializeField] private Image _hitPointsImage = null;
    [SerializeField] private TMP_Text _attackPowerText = null;
    [SerializeField] private TMP_Text _hitPointsText = null;
    [SerializeField] private List<Image> _upgradeSlotImages = new List<Image>();

    private void OnValidate()
    {
        if (_characterCardData == null) return;
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
