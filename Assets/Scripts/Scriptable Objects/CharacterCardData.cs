using UnityEngine;

[CreateAssetMenu(menuName = "Card/Character", fileName = "newCharacterCard.asset")]
public class CharacterCardData : CardData
{
    [SerializeField] private CharacterCard _characterCard = new CharacterCard();
    public CharacterCard Character_card { get => _characterCard; set => _characterCard = value; }

    private void OnValidate()
    {
        _cardBase.cardType = CardType.Character;
        name = $"{_cardBase.cardNumber}_{_cardBase.cardName}";
    }
}
