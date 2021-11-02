using TMPro;
using UnityEngine;
using UnityEngine.AddressableAssets;
using UnityEngine.ResourceManagement.AsyncOperations;

public class CharacterCardComponent : CardComponent
{
    
    [SerializeField] private CharacterCardData _characterCardData = null;
    [SerializeField] private TMP_Text _attackPowerText = null;
    [SerializeField] private TMP_Text _hitPointsText = null;
    public CharacterCardData CharacterCardData { get => _characterCardData; set => _characterCardData = value; }


    protected override void PopulateCardInfo()
    {
        var thisCard = _characterCardData.Character_card;
        var thisCardBase = _characterCardData.Card_base;
       
        _cardNumberText.text = $"{thisCardBase.cardNumber}/200";
        _titleText.text = thisCardBase.cardName;
        _gameplayText.text = thisCardBase.cardText;
        _attackPowerText.text = thisCard.attackPower.ToString();
        _hitPointsText.text = thisCard.hitPoints.ToString();
        _artImage.sprite = thisCardBase.cardImage;
    }
}
